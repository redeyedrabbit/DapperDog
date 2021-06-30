﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Models.Category
{
    public class CategoryEdit
    {
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Enter a category name")]
        [MinLength(3, ErrorMessage = "The name needs to be longer.")]
        [MaxLength(80, ErrorMessage = "Please enter a more brief name.")]
        public string Name { get; set; }
    }
}