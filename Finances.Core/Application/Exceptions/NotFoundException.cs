using System;

namespace Finances.Core.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string entity, Guid key) : base($"{entity} com o Id ({key}) não encontrado(a).") { }

        public NotFoundException(bool multiple, string entity, Guid key) : base($"Nenhum(a) {entity} com o Id ({key}) foram encontrado(a)s.") { }
    }
}
