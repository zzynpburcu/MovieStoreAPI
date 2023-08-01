using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public DeleteMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x=> x.Id == MovieId);
            if (movie == null)
            {
                throw new InvalidOperationException("Böyle bir film bulunamadı");
            }

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

        }

    }
}