using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBookstore.Database.Entities;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Database.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private ApplicationDbContext dbContext;
        private IMapper Mapper;

        public WarehouseRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            Mapper = mapper;
        }

        /// <summary>
        /// Gets all the warehouses that exist
        /// </summary>
        /// <returns></returns>
        public async Task<List<Warehouse>> GetWarehouses()
        {
            var getWarehouses = await dbContext.Warehouses.ToListAsync();

            List<Warehouse> warehouses = Mapper.Map<List<Warehouse>>(getWarehouses);

            return warehouses;
        }

        public async Task<Warehouse> GetWarehouse(int warehouseId)
        {
            Warehouse warehouse = new();

            var getWarehouse = await dbContext.Warehouses.FirstOrDefaultAsync(x => x.Id == warehouseId);

            if (getWarehouse != null)
            {
                warehouse = Mapper.Map<Warehouse>(getWarehouse);
            }

            return warehouse;
        }

        public async Task AddWarehouse(Warehouse warehouse)
        {
            WarehouseDTO getWarehouse = Mapper.Map<WarehouseDTO>(warehouse);
            dbContext.Warehouses.Add(getWarehouse);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateWarehouse(Warehouse warehouse)
        {
            var dbRequest = await dbContext.Warehouses.FindAsync(warehouse.Id);

            Mapper.Map(warehouse, dbRequest);

            dbContext.Warehouses.Update(dbRequest);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteWarehouse(int warehouseId)
        {
            var dbRequest = await dbContext.Warehouses.FindAsync(warehouseId);

            if (dbRequest.Id > 0)
            {
                dbContext.Warehouses.Remove(dbRequest);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
