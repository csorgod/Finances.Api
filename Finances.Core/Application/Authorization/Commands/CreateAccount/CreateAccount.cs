using Finances.Common.Data;
using MediatR;
using System;

namespace Finances.Core.Application.Authorization.Commands.CreateAccount
{
    public class SignUp : IRequest<JsonDefaultResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string TaxNumber { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
    }
}
