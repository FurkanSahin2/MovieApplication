using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DirectorManager : IDirectorService
    {
        private IDirectorDal _directorDal;

        public DirectorManager(IDirectorDal directorDal)
        {
            _directorDal = directorDal;
        }

        public IDataResult<List<Director>> GetAll()
        {
            return new SuccessDataResult<List<Director>>(_directorDal.GetAll());
        }

        public IDataResult<Director> GetById(int directorId)
        {
            return new SuccessDataResult<Director>(_directorDal.Get(d => d.DirectorId == directorId));
        }
    }
}
