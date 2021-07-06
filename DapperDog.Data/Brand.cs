using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Data
{
    public class Brand
    {
        public int BrandId { get; set; }

        [Required]
        public string Name { get; set; }

        //public virtual IEnumerable<Brand> Brands { get; set; }
    }
}
