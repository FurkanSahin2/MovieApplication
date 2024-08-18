using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RatingManager : IRatingService
    {
        private IRatingDal _ratingDal;

        public RatingManager(IRatingDal ratingDal)
        {
            _ratingDal = ratingDal;
        }

        public IDataResult<List<Rating>> GetAll()
        {
            return new SuccessDataResult<List<Rating>>(_ratingDal.GetAll(), Messages.RatingsListed);
        }
    }
}
