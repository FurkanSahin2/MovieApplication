using Core.Entities;

namespace Entities.Concrete
{
    public class Movie : IBaseEntity
    {
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
        public int CategoryId { get; set; }
        public int ActorId { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string TrailerUrl { get; set; }

        // public int CoverImagePath { get; set; }
    }
}
