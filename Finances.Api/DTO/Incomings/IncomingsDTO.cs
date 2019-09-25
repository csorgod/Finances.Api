using System.Collections.Generic;

namespace Finances.Api.DTO.Incomings
{
    public class IncomingsDTO
    {
        public IEnumerable<IncomingDTO> Incomings { get; private set; }
        public IncomingsDTO(IEnumerable<IncomingDTO> incomings) => Incomings = incomings;
    }
}
