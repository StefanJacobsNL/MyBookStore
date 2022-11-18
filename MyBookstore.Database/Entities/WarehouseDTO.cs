using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Database.Entities
{
    public class WarehouseDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }

        public WarehouseDTO()
        {

        }

        public WarehouseDTO(string name, string address, string city)
        {
            Name = name;
            Address = address;
            City = city;
        }

        public WarehouseDTO(int id, string name, string address, string city)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
        }
    }
}
