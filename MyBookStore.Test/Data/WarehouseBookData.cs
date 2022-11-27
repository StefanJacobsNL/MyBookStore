using MyBookstore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test.Data
{
    internal static class WarehouseBookData
    {
        internal static WarehouseBookDTO GetWarehouseBookData()
        {
            var warehouseBookData = new WarehouseBookDTO(1, 1, 10);

            warehouseBookData.Warehouse = WarehouseData.GetWarehouseData();

            return warehouseBookData;
        }

        internal static List<WarehouseBookDTO> GetWarehouseBooksData()
        {
            var wareBooks = new List<WarehouseBookDTO>();
            int amount = 10;

            foreach (var warehouse in WarehouseData.GetWarehousesData())
            {
                var warehouseBookData = new WarehouseBookDTO(warehouse.Id, 1, amount);
                warehouseBookData.Warehouse = warehouse;

                wareBooks.Add(warehouseBookData);
                amount = 4;
            }

            return wareBooks;
        }
    }
}
