using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.DTOs.ProductColorDtos
{
    public record ProductColorCreateDto
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
    }
}
