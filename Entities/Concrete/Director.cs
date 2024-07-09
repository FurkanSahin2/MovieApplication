using Core.Entities;

namespace Entities.Concrete
{
    public class Director : IBaseEntity
    {
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
    }
}
