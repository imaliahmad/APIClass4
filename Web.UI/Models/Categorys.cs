using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Models
{
    public class Categorys
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category Description is required.")]
        public string Description { get; set; }
    }
}
