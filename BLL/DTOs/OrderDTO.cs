using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public int quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int BId { get; set; }
    }
}
