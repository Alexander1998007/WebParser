using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebParser.Models;

namespace WebParser.ViewModels
{
    public class StringViewModel
    {
        public IEnumerable<Document> Documents { get; set; }
        public IEnumerable<DocumentString> DocumentStrings { get; set; }
    }
}
