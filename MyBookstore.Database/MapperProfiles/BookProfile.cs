using AutoMapper;
using MyBookstore.Database.Entities;
using MyBookstore.Domain.DomainModels;

namespace MyBookstore.Database.MapperProfiles
{
    public class BookProfile : Profile
    {
        

        public BookProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dst => dst.BookGenres, opt => opt.MapFrom(src => src.Genres))
                .ForMember(dst => dst.BookAuthors, opt => opt.MapFrom(src => src.Authors));
                //.ForMember(dst => dst.BookWarehouses, opt => opt.MapFrom(src => src.Warehouses));
            CreateMap<Genre, BookGenreDTO>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.GenreId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Author, BookAuthorDTO>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.AuthorId, opt => opt.MapFrom(src => src.Id));
            CreateMap<BookDTO, Book>()
                .ForMember(dst => dst.Warehouses, opt => opt.MapFrom(src => ConvertWarehouseDTOToWarehouse(src.BookWarehouses)))
                .ForMember(dst => dst.Genres, opt => opt.MapFrom(src => src.BookGenres.Select(x => x.Genre)))
                .ForMember(dst => dst.Authors, opt => opt.MapFrom(src => src.BookAuthors.Select(x => x.Author)));

            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();
        }

        public List<Warehouse> ConvertWarehouseDTOToWarehouse(ICollection<WarehouseBookDTO> warehouseBooks)
        {
            List<Warehouse> warehouses = new();

            foreach (var warehouseBook in warehouseBooks)
            {
                Warehouse setWarehouse = new()
                {
                    Id = warehouseBook.Warehouse.Id,
                    Name = warehouseBook.Warehouse.Name,
                    Address = warehouseBook.Warehouse.Address,
                    City = warehouseBook.Warehouse.City,
                    Amount = warehouseBook.Amount
                };
                warehouses.Add(setWarehouse);
            }

            return warehouses;
        }
    }
}
