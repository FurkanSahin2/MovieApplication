using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private IMovieDal _movieDal;

        // Bir EntityManager kendi ismi dışındaki başka ...Dal'ı enjekte edemezken ihtiyaca binaen kendi ismi dışındaki ...Service'leri enjekte edebiliriz.
        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }
        [CacheAspect]
        public IDataResult<List<Movie>> GetAll()
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(), Messages.MoviesListed);
        }

        public IDataResult<List<Movie>> GetAllByCategoryId(int categoryId)
        {
            var singleItem = _movieDal.Get(c => c.CategoryId == categoryId);
            var itemList = new List<Movie> { singleItem };
            return new SuccessDataResult<List<Movie>>(itemList);
        }


        public IDataResult<List<Movie>> GetAllByActorId(int actorId)
        {
            var singleItem = _movieDal.Get(a => a.ActorId == actorId);
            var itemList = new List<Movie> { singleItem };
            return new SuccessDataResult<List<Movie>>(itemList);
        }

        public IDataResult<List<Movie>> GetAllByDirectorId(int directorId)
        {
            var singleItem = _movieDal.Get(d => d.DirectorId == directorId);
            var itemList = new List<Movie> { singleItem };
            return new SuccessDataResult<List<Movie>>(itemList);
        }

        [CacheAspect]
        [PerformanceAspect(5000)]
        public IDataResult<Movie> GetById(int movieId)
        {
            return new SuccessDataResult<Movie>(_movieDal.Get(m => m.MovieId == movieId));
        }

        public IDataResult<List<Movie>> GetAllByMovieName(string movieName)
        {
            var singleItem = _movieDal.Get(mn => mn.MovieName == movieName);
            var itemList = new List<Movie> { singleItem };
            return new SuccessDataResult<List<Movie>>(itemList);
        }

        public IDataResult<List<MovieDetailDto>> GetMovieDetails()
        {
            return new SuccessDataResult<List<MovieDetailDto>>(_movieDal.GetMovieDetails());
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(MovieValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Movie movie)
        {
            var result = BusinessRules.Run(CheckIfMovieNameExists(movie.MovieName));

            if (result != null)
            {
                return result;
            }

            _movieDal.Add(movie);

            return new SuccessResult(Messages.MovieAdded);
        }

        [ValidationAspect(typeof(MovieValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Movie movie)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfMovieNameExists(string movieName)
        {
            var result = _movieDal.GetAll(m => m.MovieName == movieName).Any();
            if (result)
            {
                return new ErrorResult(Messages.MovieNameAlreadyExists);
            }

            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Movie movie)
        {
            Add(movie);

            if (movie.Description == "ABC")
            {
                throw new Exception(" ");
            }

            Add(movie);

            return null;
        }

        //[TransactionScopeAspect]
        //public IResult AddTransactionalTest(Movie movie)
        //{
        //    _movieDal.Update(movie);
        //    _movieDal.Add(movie);
        //    return new SuccessResult(Messages.MovieUpdated);
        //}
    }
}
