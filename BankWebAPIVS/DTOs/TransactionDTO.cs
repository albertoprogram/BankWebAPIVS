namespace BankWebAPIVS.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string TXNTypeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}
