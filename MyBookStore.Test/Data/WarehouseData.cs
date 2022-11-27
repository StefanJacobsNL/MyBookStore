using MyBookstore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test.Data
{
    internal static class WarehouseData
    {
        internal static WarehouseDTO GetWarehouseData()
        {
            return new WarehouseDTO(1, "Strijp P", "Schoolstraat 1", "Eindhoven");
        }

        internal static List<WarehouseDTO> GetWarehousesData()
        {
            return new List<WarehouseDTO>()
            {
                GetWarehouseData(),
                new WarehouseDTO(2, "Astrid C", "Kerkstraat 3", "Helmond")
            };
        }
    }
}
