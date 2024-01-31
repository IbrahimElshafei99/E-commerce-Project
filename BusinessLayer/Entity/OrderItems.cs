using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class OrderItems
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int Order_Id { get; set; }
        [ForeignKey("Order_Id")]
        public Order? Order { get; set; }
    }
}
