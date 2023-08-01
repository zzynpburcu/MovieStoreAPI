using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;
using System.Collections.Generic;

namespace WebApi.Applications.MovieOperations.Queries
{
    public class GetMovieByIdQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int MovieId { get;set;}

        public GetMovieByIdQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public MovieDetailViewModel Handle()
        {
            var movie = _dbContext.Movies.Include(x=> x.Director).Include(x=> x.Genre).Include(x=> x.ActorActressMovieJoint).ThenInclude(x=>x.actorActress).Where(x => x.Id == MovieId).FirstOrDefault();

            var aktörler = _dbContext.actorActressMovieJoints.Where(x => x.MovieId == MovieId).ToList();

            if (movie == null)
            {
                throw new InvalidOperationException("Böyle bir film bulunamadı");
            }

            MovieDetailViewModel vm = _mapper.Map<MovieDetailViewModel>(movie);

            return vm;
        }

    }


    public class MovieDetailViewModel
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public List<string> Actors { get; set; }

    }

}