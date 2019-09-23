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
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : class
    {
        private AbstractValidator<TRequest> _validator;
        public ValidationBehavior(AbstractValidator<TRequest> validator) 
        { 
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) 
        {
            var failures = _validator.Validate(request).Errors;
            return await (failures.Any() ? Errors(failures) : next());
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new BaseResponse() { Errors = failures.Select(f => f.ErrorMessage).ToList() };
            return Task.FromResult(response as TResponse);
        }
    }
}