using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DapperIdentity.Api.Entities
{
    public class Product
    {
        public Product()
        {  }

        public Product(int productId, string productName, decimal price, int categoryId)
        {
            ProductId = productId;
            CategoryId = categoryId;
            ProductName = productName;
            Price = price;
        }

        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
