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
                .ForMember(dst => dst.BookAuthors, opt => opt.MapFrom(src => src.Authors))
                .ForMember(dst => dst.BookWarehouses, opt => opt.MapFrom(src => src.BookStocks));
            CreateMap<Genre, BookGenreDTO>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.GenreId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Author, BookAuthorDTO>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.AuthorId, opt => opt.MapFrom(src => src.Id));
            CreateMap<BookStock, WarehouseBookDTO>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.WarehouseId, opt => opt.MapFrom(src => src.WarehouseId))
                .ForMember(dst => dst.Amount, opt => opt.MapFrom(src => src.Amount));
            CreateMap<BookDTO, Book>()
                .ForMember(dst => dst.BookStocks, opt => opt.MapFrom(src => src.BookWarehouses))
                .ForMember(dst => dst.Genres, opt => opt.MapFrom(src => src.BookGenres.Select(x => x.Genre)))
                .ForMember(dst => dst.Authors, opt => opt.MapFrom(src => src.BookAuthors.Select(x => x.Author)));
            CreateMap<WarehouseBookDTO, BookStock>()
                .ForMember(dst => dst.WarehouseId, opt => opt.MapFrom(src => src.WarehouseId))
                .ForMember(dst => dst.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.Name))
                .ForMember(dst => dst.Amount, opt => opt.MapFrom(src => src.Amount));

            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();
        }
    }
}
