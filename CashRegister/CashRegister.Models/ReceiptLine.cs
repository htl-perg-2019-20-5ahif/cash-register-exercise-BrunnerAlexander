namespace CashRegister.Models
{
    public class ReceiptLine
    {
        public int ReceiptLineId { get; set; }

        public int Amount { get; set; }

        public decimal TotalPrice { get; set; }

        // Key
        public Product Product { get; set; }
    }
}
