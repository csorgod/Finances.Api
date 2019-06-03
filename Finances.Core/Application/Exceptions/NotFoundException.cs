using System;

namespace Finances.Core.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Guid key) : base($"Entidade com o Id ({key}) não encontrada.") { }
    }
}
