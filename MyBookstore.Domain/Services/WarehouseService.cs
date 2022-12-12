using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Services
{
    public class WarehouseService : IWarehouseService
    {
        private IBookRepository BookRepository;

        public WarehouseService(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public async Task<Result> AddWarehouse(Warehouse warehouse)
        {
            await BookRepository.AddWarehouse(warehouse);

            return Result.OK($"The warehouse '{warehouse.Name}' has been added");
        }

        public async Task<Result> DeleteWarehouse(int warehouseId)
        {
            var getWarehouse = await BookRepository.GetWarehouse(warehouseId);

            if (getWarehouse != null && getWarehouse.Id > 0)
            {
                await BookRepository.DeleteWarehouse(getWarehouse.Id);

                return Result.OK($"The warehouse '{getWarehouse.Name}' has been deleted");
            }
            else
            {
                return Result.Fail($"The given warehouse doesn't exist");
            }
        }

        public async Task<List<Warehouse>> GetWarehouses()
        {
            return await BookRepository.GetWarehouses();
        }

        public async Task<Result> UpdateWarehouse(Warehouse warehouse)
        {
            var getWarehouse = await BookRepository.GetWarehouse(warehouse.Id);

            if (getWarehouse != null)
            {
                getWarehouse.Name = warehouse.Name;
                getWarehouse.Address = warehouse.Address;
                getWarehouse.City = warehouse.City;

                await BookRepository.UpdateWarehouse(getWarehouse);

                return Result.OK($"The warehouse '{getWarehouse.Name}' has been updated");
            }
            else
            {
                return Result.Fail($"The given warehouse doesn't exist");
            }
        }

        public async Task<List<BookStock>> GetBookStocksBasedOnWarehouses()
        {
            List<BookStock> bookStocks = new();
            List<Warehouse> getWarehouses = await GetWarehouses();

            foreach (var warehouse in getWarehouses)
            {
                bookStocks.Add(new BookStock(warehouse.Id, warehouse.Name));
            }

            return bookStocks;
        }
    }
}
