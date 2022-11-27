using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Database.Entities
{
    public class WarehouseBookDTO
    {
        public int Id { get; set; }
        public WarehouseDTO Warehouse { get; set; }
        public int WarehouseId { get; set; }
        public BookDTO Book { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }

        public WarehouseBookDTO()
        {

        }

        public WarehouseBookDTO(int warehouseId, int bookId, int amount)
        {
            WarehouseId = warehouseId;
            BookId = bookId;
            Amount = amount;
        }
    }
}
