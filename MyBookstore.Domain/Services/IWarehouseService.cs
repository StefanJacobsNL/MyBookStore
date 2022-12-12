using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Services
{
    public interface IWarehouseService
    {
        Task<Result> AddWarehouse(Warehouse warehouse);
        Task<Result> DeleteWarehouse(int warehouseId);
        Task<List<Warehouse>> GetWarehouses();
        Task<Result> UpdateWarehouse(Warehouse warehouse);
        Task<List<BookStock>> GetBookStocksBasedOnWarehouses();
    }
}
