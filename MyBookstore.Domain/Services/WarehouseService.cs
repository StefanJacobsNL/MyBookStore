using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repositories;
using MyBookstore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Services
{
    public class WarehouseService : IWarehouseService
    {
        private IWarehouseRepository WarehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            WarehouseRepository = warehouseRepository;
        }

        public async Task<Result> AddWarehouse(Warehouse warehouse)
        {
            await WarehouseRepository.AddWarehouse(warehouse);

            return Result.OK($"The warehouse '{warehouse.Name}' has been added");
        }

        public async Task<Result> DeleteWarehouse(int warehouseId)
        {
            var getWarehouse = await WarehouseRepository.GetWarehouse(warehouseId);

            if (getWarehouse != null && getWarehouse.Id > 0)
            {
                await WarehouseRepository.DeleteWarehouse(getWarehouse.Id);

                return Result.OK($"The warehouse '{getWarehouse.Name}' has been deleted");
            }
            else
            {
                return Result.Fail($"The given warehouse doesn't exist");
            }
        }

        public async Task<List<Warehouse>> GetWarehouses()
        {
            return await WarehouseRepository.GetWarehouses();
        }

        public async Task<Result> UpdateWarehouse(Warehouse warehouse)
        {
            var getWarehouse = await WarehouseRepository.GetWarehouse(warehouse.Id);

            if (getWarehouse != null)
            {
                getWarehouse.Name = warehouse.Name;
                getWarehouse.Address = warehouse.Address;
                getWarehouse.City = warehouse.City;

                await WarehouseRepository.UpdateWarehouse(getWarehouse);

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
