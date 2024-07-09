using Core.Entities;

namespace Entities.Concrete
{
    public class MovieCast : IBaseEntity
    {
        public int MovieCastId { get; set; }
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public int DirectorId { get; set; }


    }
}
