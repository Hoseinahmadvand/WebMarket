using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket_DataLayer.Entities
{
    public class Product: BaseProductEntity
    {
        public int CategoryId { get; set; }
        public Nullable<int> SubCategoryId { get; set; }

        public int BrandId { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }

        ///Releation

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("SubCategoryId")]
        public Category SubCategory { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
    }
}
