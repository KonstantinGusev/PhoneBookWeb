using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CategoryViev
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3,ErrorMessage = "Name should be more than two symbols")]
        public string Name { get; set; }
    }
}