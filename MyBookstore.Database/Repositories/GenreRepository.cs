using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBookstore.Database.Entities;
using MyBookstore.Domain.DomainModels;
using MyBookstore.Domain.Repository;

namespace MyBookstore.Database.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext dbContext;
        private IMapper Mapper;

        public GenreRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            Mapper = mapper;
        }

        /// <summary>
        /// Gets all the genres that exist
        /// </summary>
        /// <returns></returns>
        public async Task<List<Genre>> GetGenres()
        {
            var getGenres = await dbContext.Genres
                                .Include(x => x.Discount).ToListAsync();
            List<Genre> genres = Mapper.Map<List<Genre>>(getGenres);

            return genres;
        }

        public async Task<Genre> GetGenre(int genreId)
        {
            Genre genre = new();

            GenreDTO getGenre = await dbContext.Genres
                                .Include(x => x.Discount).FirstOrDefaultAsync(x => x.Id == genreId);

            if (getGenre != null)
            {
                genre = Mapper.Map<Genre>(getGenre);
            }

            return genre;
        }

        public async Task<Genre> GetGenreByName(string genreName)
        {
            Genre genre = new();

            GenreDTO checkObject = await dbContext.Genres.FirstOrDefaultAsync(x => x.Name.ToLower() == genreName.ToLower());

            if (checkObject != null)
            {
                genre = Mapper.Map<Genre>(checkObject);
            }

            return genre;
        }

        /// <summary>
        /// Adds a new genre to the database
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>Result class with the response</returns>
        public async Task AddGenre(Genre genre)
        {
            GenreDTO genreDTO = Mapper.Map<GenreDTO>(genre);

            dbContext.Genres.Add(genreDTO);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateGenre(Genre genre)
        {
            var dbRequest = await dbContext.Genres.FindAsync(genre.Id);

            Mapper.Map(genre, dbRequest);

            dbContext.Genres.Update(dbRequest);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteGenre(int genreId)
        {
            var dbRequest = await dbContext.Genres.FindAsync(genreId);

            if (dbRequest != null)
            {
                dbContext.Genres.Remove(dbRequest);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
