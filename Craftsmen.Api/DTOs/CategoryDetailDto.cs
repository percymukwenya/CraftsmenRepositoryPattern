namespace Craftsmen.Api.DTOs
{
    public class CategoryDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IReadOnlyList<ProductDto> Products { get; set; }
    }
}
