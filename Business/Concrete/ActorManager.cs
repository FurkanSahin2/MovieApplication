using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ActorManager : IActorService
    {
        private IActorDal _actorDal;

        public ActorManager(IActorDal actorDal)
        {
            _actorDal = actorDal;
        }

        public IDataResult<List<Actor>> GetAll()
        {
            return new SuccessDataResult<List<Actor>>(_actorDal.GetAll());
        }

        public IDataResult<Actor> GetById(int actorId)
        {
            return new SuccessDataResult<Actor>(_actorDal.Get(a => a.ActorId == actorId));
        }
    }
}
