using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Applications.MovieOperations.Queries;
using WebApi.Applications.MovieOperations.Commands;
using WebApi.Applications.MovieOperations.Commands.CreateMovie;
using WebApi.Applications.MovieOperations.Commands.DeleteMovie;
using WebApi.Applications.MovieOperations.Commands.UpdateMovie;
using static WebApi.Applications.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
using static WebApi.Applications.MovieOperations.Commands.UpdateMovie.UpdateMovieCommand;
using WebApi.Applications.MovieOperations.Commands.DeleteMovie;
namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context; //
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
           MovieDetailViewModel result;
            GetMovieByIdQuery query = new GetMovieByIdQuery(_context, _mapper);
            query.MovieId = id;
            result = query.Handle();
            return Ok(result);

        }
        [HttpPost] // Film ekleme
        public IActionResult AddMovie([FromBody] CreateMovieViewModel newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            command.Model = newMovie;
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")] // Film güncelle
        public IActionResult UpdateMovie([FromBody] UpdateMovieViewModel updatedMovie, int id)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper);
            command.MovieId = id;
            command.Model = updatedMovie;
            command.Handle();
            return Ok();
        }
        [HttpDelete] // Film silme
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context, _mapper);
            command.MovieId = id;
            command.Handle();
            return Ok();
        }

       
       

      

       

    }
}