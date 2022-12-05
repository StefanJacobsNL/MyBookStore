using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DomainModels
{
    public class BookStock
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; } = string.Empty;
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }

        public BookStock(int warehouseId, string warehouseName)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
        }

        public BookStock(int warehouseId, string warehouseName, int amount)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
            Amount = amount;
        }
    }
}
