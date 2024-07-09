using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MovieCastManager : IMovieCastService
    {
        private IMovieCastDal _movieCastDal;

        public MovieCastManager(IMovieCastDal movieCastDal)
        {
            _movieCastDal = movieCastDal;
        }

        public IDataResult<MovieCast> GetById(int movieCastId)
        {
            return new SuccessDataResult<MovieCast>(_movieCastDal.Get(mc => mc.MovieCastId == movieCastId));
        }
    }
}
