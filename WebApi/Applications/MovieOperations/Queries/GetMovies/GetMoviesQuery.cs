using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.MovieOperations.Queries
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public List<MovieViewModel> Handle()
        {
             var movies = _dbContext.Movies.Include(x => x.Director).OrderBy(x => x.Id).ToList<Movie>();
            List<MovieViewModel> vm = _mapper.Map<List<MovieViewModel>>(movies);
            return vm;
        }

    }


    public class MovieViewModel
        {
            public string Title { get; set; }
            public string Director { get; set; }
        }

}