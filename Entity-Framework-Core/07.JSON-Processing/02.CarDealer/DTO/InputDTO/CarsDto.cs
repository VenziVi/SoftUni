﻿using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.InputDTO
{
    public class CarsDto
    {   
        public string Make { get; set; }
        
        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<int> PartsId { get; set; }
    }
}
