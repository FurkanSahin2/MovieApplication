using Core.Entities;

namespace Entities.Concrete
{
    public class Actor : IBaseEntity
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string ActorGender  { get; set; }
    }
}
