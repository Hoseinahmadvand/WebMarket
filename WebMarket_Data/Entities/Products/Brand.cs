using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket_DataLayer.Entities
{
    public class Brand: BaseProductEntity
    {
        public string Country { get; set; }
        public string Description { get; set; }
        public string WebSiteLink { get; set; }

        [InverseProperty("Brand")]
        public ICollection<Product> BrandProduct { get; set; }
    }
}
