using Moq;
using MyBookstore.Database.Entities;
using MyBookstore.Database.Repositories;
using MyBookstore.Domain.Services;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repositories;
using MyBookStore.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Test
{
    public class WarehouseUnitTest
    {
        public class AuthorUnitTest
        {
            [Fact]
            public void Get_AllWarehouses()
            {
                List<Warehouse> getWarehouseData = WarehouseData.GetWarehousesData();
                Mock<IBookRepository> mockBookRepo = new();
                mockBookRepo.Setup(x => x.GetWarehouses()).Returns(Task.FromResult(getWarehouseData));
                var bookService = new BookCatalog(mockBookRepo.Object);

                List<Warehouse> getWarehouses = bookService.GetWarehouses().Result;

                Assert.NotNull(getWarehouses);
                Assert.Equal(getWarehouses.Count(), getWarehouses.Count());
            }

            [Fact]
            public void Add_Warehouse()
            {
                Warehouse setupWarehouse = WarehouseData.GetWarehouseData();
                var mockBookRepo = new Mock<IBookRepository>();
                mockBookRepo.Setup(x => x.AddWarehouse(It.IsAny<Warehouse>()));
                var bookService = new BookCatalog(mockBookRepo.Object);

                Result response = bookService.AddWarehouse(setupWarehouse).Result;

                Assert.NotNull(response);
                Assert.True(response.Succes, response.Error);
            }

            [Fact]
            public void Update_Warehouse()
            {
                Warehouse setupWarehouse = WarehouseData.GetWarehouseData();
                Warehouse updateObject = setupWarehouse;
                var mockBookRepo = new Mock<IBookRepository>();
                mockBookRepo.Setup(x => x.GetWarehouse(It.IsAny<int>())).Returns(Task.FromResult(setupWarehouse));
                mockBookRepo.Setup(x => x.UpdateWarehouse(It.IsAny<Warehouse>()));
                var bookService = new BookCatalog(mockBookRepo.Object);

                updateObject.Name = "sdasdasda";
                Result response = bookService.UpdateWarehouse(updateObject).Result;

                Assert.NotNull(response);
                Assert.True(response.Succes, response.Error);
                Assert.Equal(updateObject.Name, setupWarehouse.Name);
            }

            [Fact]
            public void Delete_Warehouse()
            {
                Warehouse setupWarehouse = WarehouseData.GetWarehouseData();
                var mockBookRepo = new Mock<IBookRepository>();
                mockBookRepo.Setup(x => x.GetWarehouse(It.IsAny<int>())).Returns(Task.FromResult(setupWarehouse));
                mockBookRepo.Setup(x => x.DeleteWarehouse(It.IsAny<int>()));
                var bookService = new BookCatalog(mockBookRepo.Object);

                Result response = bookService.DeleteWarehouse(setupWarehouse.Id).Result;

                Assert.NotNull(response);
                Assert.True(response.Succes, response.Error);
            }
        }
    }
}
