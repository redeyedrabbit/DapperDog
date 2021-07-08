using DapperDog.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Models.Customer
{
    public class CustomerCreate
    {
        [Required]
        [Display(Name = "Enter your first name")]
        [MinLength(3, ErrorMessage = "The name needs to be longer.")]
        [MaxLength(15, ErrorMessage = "Please enter a more brief name.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Enter your last name")]
        [MinLength(3, ErrorMessage = "The name needs to be longer.")]
        [MaxLength(15, ErrorMessage = "Please enter a more brief name.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Enter your phone number")]
        [Range(0, 10, ErrorMessage = "Please enter a valid phone number")]
        public int PhoneNumber { get; set; }
        public string Address { get; set; }

        [Required]
        [Display(Name = "Enter your city")]
        [MinLength(3, ErrorMessage = "The city name needs to be longer.")]
        [MaxLength(20, ErrorMessage = "Please enter a valid city")]
        public string City { get; set; }

        [Required]
        public State State { get; set; }

        [Required]
        [Display(Name = "Enter your zipcode")]
        [StringLength(5, ErrorMessage = "Please enter a valid zipcode.")]
        public string Zipcode { get; set; }
    }
}
