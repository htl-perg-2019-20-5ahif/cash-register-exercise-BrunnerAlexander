using System;
using System.Collections.Generic;

namespace CashRegister.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal TotalPrice { get; set; }

        // Key
        public ICollection<ReceiptLine> ReceiptLines { get; set; }
    }
}
