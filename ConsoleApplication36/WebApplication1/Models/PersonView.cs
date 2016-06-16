using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PersonView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        [Display(Name = "Person Name")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Name should be valid.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number cannot be empty")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}