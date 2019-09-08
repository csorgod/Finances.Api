using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using Finances.Common.Data;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : JsonDefaultResponse
{
    private AbstractValidator<TRequest> _validator;
    public ValidationBehavior(AbstractValidator<TRequest> validator) 
    { 
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) 
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid) 
        {
            return new JsonDefaultResponse
            {
                StatusCode = 400,
                Success = false,
                Errors = String.Join(";", validationResult.Errors).Split(";").ToList()
            } as TResponse;
        }
        
        var response = await next();
                
        return response;
    }
}