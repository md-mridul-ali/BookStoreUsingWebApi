using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int OId { get; set; }
    }
}
