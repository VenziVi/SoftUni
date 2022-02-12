using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models
{
    public class Cart
    {
        public Cart()
        {
            Products = new HashSet<Product>();
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
