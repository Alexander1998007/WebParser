using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebParser.ViewModels
{
    public class DocumentViewModel
    {
        public string Name { get; set; }
        public IFormFile DocumentFile { get; set; }
    }
}
