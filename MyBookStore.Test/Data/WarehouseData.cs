using MyBookstore.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test.Data
{
    internal static class WarehouseData
    {
        internal static Warehouse GetWarehouseData()
        {
            return new Warehouse()
            {
                Id = 1,
                Name = "Strijp P",
                Address = "SchoolStraat 12",
                City = "Eindhoven"
            };
        }

        internal static List<Warehouse> GetWarehousesData()
        {
            return new List<Warehouse>()
            {
                GetWarehouseData(),
                new Warehouse()
                {
                    Id = 2,
                    Name = "Astrid C",
                    Address = "Kerkstraat 3",
                    City = "Helmond"
                }
            };
        }
    }
}
