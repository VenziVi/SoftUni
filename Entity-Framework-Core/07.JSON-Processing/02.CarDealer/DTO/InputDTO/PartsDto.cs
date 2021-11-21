using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.InputDTO
{
    public class PartsDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SupplierId { get; set; }
    }
}
