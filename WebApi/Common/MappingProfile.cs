using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.MovieOperations.Queries; 
using WebApi.Applications.MovieOperations.Commands; 
using WebApi.Applications.MovieOperations.Commands.CreateMovie;
using WebApi.Applications.MovieOperations.Commands.DeleteMovie;
using WebApi.Applications.MovieOperations.Commands.UpdateMovie;
using WebApi.Applications.CustomerOperations.CreateCustomer;
using static WebApi.Applications.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
using static WebApi.Applications.MovieOperations.Commands.UpdateMovie.UpdateMovieCommand;
using static WebApi.Applications.CustomerOperations.CreateCustomer.CreateCustomerCommand;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

               CreateMap<Movie, MovieViewModel>().ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname));
            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreTitle))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.ActorActressMovieJoint.Select(x => x.actorActress.Name + " " + x.actorActress.Surname)));
  CreateMap<CreateMovieViewModel, Movie>();
            CreateMap<UpdateMovieViewModel, Movie>();
            //Customer Mapping
            CreateMap<CreateCustomerModel, Customer>();



        }
    }
}