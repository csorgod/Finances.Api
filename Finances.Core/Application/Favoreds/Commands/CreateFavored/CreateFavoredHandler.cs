using Finances.Common.Data;
using Finances.Core.Application.Interfaces;
using Finances.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Finances.Common.Helpers.Enum;

namespace Finances.Core.Application.Favoreds.Commands.CreateFavored
{
    public class CreateFavoredHandler : IRequestHandler<CreateFavored, JsonDefaultResponse>
    {
        private readonly IFinancesDbContext _context;
        private readonly IMediator _mediator;

        public CreateFavoredHandler(IFinancesDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<JsonDefaultResponse> HandleAsync(CreateFavored request, CancellationToken cancellationToken)
        {
            bool registerAuthorized = false;

            try
            {
                var favoredAlreadyRegistered = await _context.Favored
                .Where(f => f.TaxNumber == request.TaxNumber
                && f.Status == Status.Active
                && f.BelongsToUserId == request.BelongToUserId)
                .ToListAsync();

                if (favoredAlreadyRegistered.Count == 0)
                    registerAuthorized = true;
                else
                {
                    if (request.Account != null)
                    {
                        foreach(var favored in favoredAlreadyRegistered)
                        {
                            var favoredAccounts = await _context.FavoredHasAccount
                            .Where(fha => fha.FavoredId == favored.Id)
                            .Select(fha => fha.Account)
                            .ToListAsync();

                            if (favoredAccounts.Count > 0)
                            {
                                var favoredAccount = favoredAccounts
                                .Where(a => a.BankAccount == request.Account.BankAccount)
                                .SingleOrDefault();

                                if (favoredAccount != null)
                                    return new JsonDefaultResponse
                                    {
                                        Success = false,
                                        Message = "Já existe um favorecido cadastrado com essa conta no sistema"
                                    };
                            }
                        }

                        registerAuthorized = true;
                    }
                    else
                    {

                        foreach (var favored in favoredAlreadyRegistered)
                        {
                            var favoredAccounts = await _context.FavoredHasAccount
                            .Where(fha => fha.FavoredId == favored.Id)
                            .Select(fha => fha.Account)
                            .ToListAsync();

                            if (favoredAccounts.Count > 0)
                            {
                                var favoredAccount = favoredAccounts
                                .Where(a => a.BankAccount == request.Account.BankAccount)
                                .SingleOrDefault();

                                if (favoredAccount == null)
                                    return new JsonDefaultResponse
                                    {
                                        Success = false,
                                        Message = "Um favorecido igual a esse sem conta cadastrada já foi registrado no sistema"
                                    };
                            }
                        }

                        registerAuthorized = true;
                    }
                }
            }
            catch (Exception ex)
            {
                return new JsonDefaultResponse
                {
                    Success = false,
                    Message = "Houve um problema em validar o favorecido antes de cadastrá-lo."
                };
            }

            if (registerAuthorized)
            {
                var favored = new Favored
                {
                    BelongsToUserId = request.BelongToUserId,
                    Name = request.Name,
                    TaxNumber = request.TaxNumber,
                    Status = Status.Active
                };

                if (request.Account.BankAccount != null)
                {
                    var account = new Account
                    {
                        Bank = request.Account.BankAccount.Value,
                        BankBranch = request.Account.BankBranch.Value,
                        BankAccount = request.Account.BankAccount.Value,
                        BankAccountDigit = request.Account.BankAccountDigit.Value,
                        Status = Status.Active
                    };

                    var favored_has_account = new FavoredHasAccount
                    {
                        FavoredId = favored.Id,
                        AccountId = account.Id
                    };

                    try
                    {
                        _context.Account.Add(account);
                        _context.FavoredHasAccount.Add(favored_has_account);
                    }
                    catch (Exception ex)
                    {
                        return new JsonDefaultResponse
                        {
                            Success = false,
                            Message = "Algo deu errado no servidor. Por favor, tente novamente mais tarde"
                        };
                    }
                }

                try
                {
                    _context.Favored.Add(favored);
                    await _context.SaveChangesAsync(cancellationToken);

                    await _mediator.Publish(new FavoredCreated { Id = favored.Id }, cancellationToken);
                }
                catch (Exception ex)
                {
                    return new JsonDefaultResponse
                    {
                        Success = false,
                        Message = "Algo deu errado no servidor. Por favor, tente novamente mais tarde"
                    };
                }

                return new JsonDefaultResponse
                {
                    Success = true,
                    Message = "Favorecido cadastrado com sucesso!"
                };
            }
            
            return new JsonDefaultResponse
            {
                Success = false,
                Message = "Erro na criação do favorecido. Por favor, revise os dados enviados e tente novamente"
            };
        }

    }
}
