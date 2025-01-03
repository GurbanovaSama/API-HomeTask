namespace FinalApiTask.BL.DTOs.ProductDtos
{
    public record ProductEditDto
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? ImagePath { get; set; }
        public int? CategoryId { get; set; }
    }
}
