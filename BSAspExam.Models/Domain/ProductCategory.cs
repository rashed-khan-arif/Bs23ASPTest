﻿namespace BSAspExam.Models.Domain
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
