using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebParser.ViewModels
{
    public class DocumentViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Please select a file")]
        public IFormFile DocumentFile { get; set; }
    }
}
