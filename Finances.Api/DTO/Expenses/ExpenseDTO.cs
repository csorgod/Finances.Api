namespace Finances.Api.DTO.Expenses
{
    public class ExpenseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool Recurrent { get; set; }
    }
}
