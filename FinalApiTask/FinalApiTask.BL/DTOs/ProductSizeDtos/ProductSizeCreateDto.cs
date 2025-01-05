using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.DTOs.ProductSizeDtos
{
    public record ProductSizeCreateDto
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int SizeId { get; set; }
        public Size? Size { get; set; }
    }
}
