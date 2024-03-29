﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO.InputDTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplaiersDto, Supplier>();

            CreateMap<PartsDto, Part>();

            CreateMap<CarsDto, Car>();
        }
    }
}
