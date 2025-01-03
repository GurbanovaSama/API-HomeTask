﻿using FinalApiTask.Core.Entities.Base;

namespace FinalApiTask.Core.Entities
{
    public class Product : BaseAuiditableEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }  
        public Category? Category { get; set; }  
        public ICollection<ProductColor>? ProductColors { get; set; }    
        public ICollection<ProductSize>? ProductSizes { get; set; } 
    }
}