using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Data
{
    public class Category
    {
        public int CategoryId { get; set; }

        //Changed from string to enum
        [Required]
        public string Name { get; set; }
    }
}
