using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        private readonly IMovieService _movieService;

        public RatingsController(IRatingService ratingService, IMovieService movieService) 
        {
            _ratingService = ratingService;
            _movieService = movieService;
        }

        [HttpGet("GetAllWithMovies")] 
        public IActionResult GetAllWithMovies() 
        {
            var result = _ratingService.GetAll();
            if (result.Success)
            {
                var ratingsWithMovies = result.Data.Select(rating => new
                {
                    MovieTitle = _movieService.GetById(rating.MovieId).Title,
                    // Rating = $"{rating.NumberOfStars} / 10"
                });

                return Ok(ratingsWithMovies);
            }
            return BadRequest(result.Message);
        }
    }
}