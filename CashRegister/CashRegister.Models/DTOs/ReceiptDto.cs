using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Models.DTOs
{
    public class ReceiptDto
    {
        public ICollection<ReceiptLineDto> ReceiptLines { get; set; }
    }

    public class ReceiptLineDto
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
