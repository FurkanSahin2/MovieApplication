using Core.Entities;

namespace Entities.Concrete
{
    public class Category : IBaseEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
