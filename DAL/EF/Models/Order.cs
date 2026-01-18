using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int quantity { get; set; }
        public DateTime OrderDate { get; set; }
        [ForeignKey("Book")]
        public int BId { get; set; }
        public virtual Book Book { get; set; }  
    }
}
