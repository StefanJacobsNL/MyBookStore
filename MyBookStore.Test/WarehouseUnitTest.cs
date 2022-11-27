using Moq;
using MyBookstore.Database.Entities;
using MyBookstore.Database.Repositories;
using MyBookstore.Domain.Catalog;
using MyBookstore.Domain.DomainModels;
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
                var getFakeDTOs = GetFakeDTOWarehouses();
                List<Warehouse> getFakeObjects = getFakeDTOs.Select(x => new Warehouse(x)).ToList();

                Mock<IBookRepository> mockBookRepo = new Mock<IBookRepository>();
                mockBookRepo.Setup(x => x.GetWarehouses()).Returns(Task.FromResult(getFakeDTOs));
                var bookService = new BookCatalog(mockBookRepo.Object);

                List<Warehouse> getWarehouses = bookService.GetWarehouses().Result;

                Assert.NotNull(getWarehouses);
                Assert.Equal(getFakeObjects.Count(), getWarehouses.Count());
            }

            [Fact]
            public void Add_Warehouse()
            {
                var getFakeDTO = GetFakeDTOWarehouse();
                Warehouse setupWarehouse = new(getFakeDTO);

                var mockBookRepo = new Mock<IBookRepository>();
                mockBookRepo.Setup(x => x.AddWarehouse(It.IsAny<WarehouseDTO>()));
                var bookService = new BookCatalog(mockBookRepo.Object);

                Result response = bookService.AddWarehouse(setupWarehouse).Result;

                Assert.NotNull(response);
                Assert.True(response.Succes, response.Error);
            }

            [Fact]
            public void Update_Warehouse()
            {
                var getFakeDTO = GetFakeDTOWarehouse();
                Warehouse setupWarehouse = new(getFakeDTO);

                var mockBookRepo = new Mock<IBookRepository>();
                mockBookRepo.Setup(x => x.GetWarehouse(It.IsAny<int>())).Returns(Task.FromResult(getFakeDTO));
                mockBookRepo.Setup(x => x.UpdateWarehouse(It.IsAny<WarehouseDTO>()));
                var bookService = new BookCatalog(mockBookRepo.Object);

                setupWarehouse.Name = "sdasdasda";
                Result response = bookService.UpdateWarehouse(setupWarehouse).Result;

                Assert.NotNull(response);
                Assert.True(response.Succes, response.Error);
                Assert.Equal(getFakeDTO.Name, setupWarehouse.Name);
            }

            [Fact]
            public void Delete_Warehouse()
            {
                var getFakeDTO = GetFakeDTOWarehouse();
                Warehouse setupWarehouse = new(getFakeDTO);
                
                var mockBookRepo = new Mock<IBookRepository>();
                mockBookRepo.Setup(x => x.GetWarehouse(It.IsAny<int>())).Returns(Task.FromResult(getFakeDTO));
                mockBookRepo.Setup(x => x.DeleteWarehouse(It.IsAny<int>()));
                var bookService = new BookCatalog(mockBookRepo.Object);

                Result response = bookService.DeleteWarehouse(setupWarehouse.Id).Result;

                Assert.NotNull(response);
                Assert.True(response.Succes, response.Error);
            }

            internal static List<WarehouseDTO> GetFakeDTOWarehouses()
            {
                return new List<WarehouseDTO>()
                {
                    GetFakeDTOWarehouse(),
                    new WarehouseDTO(2, "Astrid C", "Kerkstraat 3", "Helmond")
                };
            }

            internal static WarehouseDTO GetFakeDTOWarehouse()
            {
                return new WarehouseDTO(1, "Strijp P", "Schoolstraat 1", "Eindhoven");
            }
        }
    }
}
