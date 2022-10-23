using Craftsmen.Domain.Entities.Base;

namespace Craftsmen.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
