using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Title == Model.Title);
            if (movie !=null)
            {
                throw new InvalidOperationException("Böyle bir film zaten mevcut");
            }

            movie = _mapper.Map<Movie>(Model);
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }



        public class CreateMovieViewModel
        {
            public string Title { get; set; }
            public int DirectorId { get; set; }
            public int GenreId { get; set; }
            public double Price { get; set; }
        }

    }
}