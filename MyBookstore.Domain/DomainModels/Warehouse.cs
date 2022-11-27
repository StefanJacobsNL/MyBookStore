﻿using MyBookstore.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DomainModels
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A warehouse name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "A address is required")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "A city is required")]
        public string City { get; set; } = string.Empty;

        public Warehouse()
        {

        }

        public Warehouse(WarehouseDTO warehouseDTO)
        {
            Id = warehouseDTO.Id;
            Name = warehouseDTO.Name;
            Address = warehouseDTO.Address;
            City = warehouseDTO.City;
        }
    }
}
