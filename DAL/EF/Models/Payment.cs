using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string PaymentType { get; set; }
        [Column(TypeName = "DECIMAL")]
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        [ForeignKey("Order")]
        public int OId { get; set; }
        public virtual Order Order { get; set; }
    }
}
