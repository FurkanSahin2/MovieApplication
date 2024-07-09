using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IMovieDal : IEntityRepository<Movie>
    {
        List<MovieDetailDto> GetMovieDetails();
    }
}
