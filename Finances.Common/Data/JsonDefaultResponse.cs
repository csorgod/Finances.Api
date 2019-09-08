using System.Collections.Generic;
using MediatR;

namespace Finances.Common.Data
{
    public class JsonDefaultResponse : IRequest
    {
        public int StatusCode { get; set; } = 200;
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public object Payload { get; set; }
    }
}
