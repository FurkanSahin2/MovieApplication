using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCastsController : ControllerBase
    {
        IMovieCastService _movieCastService;

        public MovieCastsController(IMovieCastService movieCastService)
        {
            _movieCastService = movieCastService;
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int movieCastId)
        {
            var result = _movieCastService.GetById(movieCastId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
