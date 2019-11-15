using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using FluentValidation;
using FluentValidation.Results;

using Finances.Common.Data;

namespace Finances.Core.Application 
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : class
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) 
        { 
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) 
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return await (failures.Any() ? Errors(failures) : next());
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new JsonDefaultResponse 
            { 
                Success = false,
                Errors = failures.Select(f => f.ErrorMessage).ToList(),
                Message = "Houveram um ou mais erros ao tentar realizar sua solicitação. Por favor, revise os valores enviados e tente novamente"
            };
            return Task.FromResult(response as TResponse);
        }
    }
}