namespace Finances.Api.DTO.Incomings
{
    public class IncomingDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool Recurrent { get; set; }
    }
}
