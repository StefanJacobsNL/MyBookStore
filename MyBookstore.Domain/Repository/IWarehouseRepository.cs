using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Domain.Repository
{
    public interface IWarehouseRepository
    {
        Task AddWarehouse(Warehouse warehouse);
        Task DeleteWarehouse(int warehouseId);
        Task<Warehouse> GetWarehouse(int warehouseId);
        Task<List<Warehouse>> GetWarehouses();
        Task UpdateWarehouse(Warehouse warehouse);
    }
}
