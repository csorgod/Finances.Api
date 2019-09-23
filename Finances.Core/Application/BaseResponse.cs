using System.Collections.Generic;

using MediatR;

namespace Finances.Core.Application
{
    public class BaseResponse : IRequest
    {
        public int StatusCode { get; set; } = 200;
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
