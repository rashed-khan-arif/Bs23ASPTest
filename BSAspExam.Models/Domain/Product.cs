using BSAspExam.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Models.Domain
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }

        public virtual ProductBrand Brand { get; set; }
        public virtual ProductCategory Category { get; set; }

    }

    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public ICollection<Product> Products { get; set; }
    }

    public class ProductBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
