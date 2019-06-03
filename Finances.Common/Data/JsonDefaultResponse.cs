using MediatR;

namespace Finances.Common.Data
{
    public class JsonDefaultResponse : IRequest
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Payload { get; set; }
    }
}
