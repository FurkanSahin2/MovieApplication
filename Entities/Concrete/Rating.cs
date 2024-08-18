using Core.Entities;

namespace Entities.Concrete
{
    public class Rating : IBaseEntity
    {
        public int RatingId { get; set; }
        public int MovieId { get; set; }
        // public int NumberOfStars { get; set; }
    }
}
