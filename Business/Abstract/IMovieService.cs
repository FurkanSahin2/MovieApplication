using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IDataResult<List<Movie>> GetAll();
        IDataResult<Movie> GetById(int movieId);
        IDataResult<List<Movie>> GetAllByActorId(int actorId);
        IDataResult<List<Movie>> GetAllByCategoryId(int categoryId); 
        IDataResult<List<Movie>> GetAllByDirectorId(int directorId);
        IDataResult<List<Movie>> GetAllByMovieName(string movieName);
        IDataResult<List<MovieDetailDto>> GetMovieDetails();

        IResult Add(Movie movie);
        IResult Update(Movie movie);
        IResult AddTransactionalTest(Movie movie);

    }
}
