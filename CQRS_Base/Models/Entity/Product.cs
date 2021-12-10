using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Base.Models.Entity
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [Required]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
