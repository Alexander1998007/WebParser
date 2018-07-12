using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebParser.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Word { get; set; } 
        public List<DocumentString> DocumentStrings { get; set; } // strings of document
    }
}
