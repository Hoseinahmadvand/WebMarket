using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket_DataLayer.Entities
{
    public class Category: BaseProductEntity
    {
        public string Description { get; set; }
        public int? ParentId { get; set; }




        [InverseProperty("Category")]
        public ICollection<Product> CategoryProduct { get; set; }

        [InverseProperty("SubCategory")]
        public ICollection<Product> SubCategoryProduct { get; set; }

    }
}
