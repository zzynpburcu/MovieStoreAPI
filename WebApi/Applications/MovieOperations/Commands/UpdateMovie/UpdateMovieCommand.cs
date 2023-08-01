using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using WebApi.DBOperations;
using System.Security.AccessControl;

namespace WebApi.Applications.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public int MovieId { get; set; }
        public UpdateMovieViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie == null)
            {
                throw new InvalidOperationException("Böyle bir film bulunamadı");
            }

            _mapper.Map(Model, movie);
            _dbContext.SaveChanges();
        }


        public class UpdateMovieViewModel
        {
            public string Title { get; set; }
            public int DirectorId { get; set; }
            public int GenreId { get; set; }
            public double Price { get; set; }
        }
    }
}