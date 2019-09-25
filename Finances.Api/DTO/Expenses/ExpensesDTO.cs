using System.Collections.Generic;

namespace Finances.Api.DTO.Expenses
{
    public class ExpensesDTO
    {
        public IEnumerable<ExpenseDTO> Expenses { get; private set; }
        public ExpensesDTO(IEnumerable<ExpenseDTO> expenses) => Expenses = expenses; 
    }
}
