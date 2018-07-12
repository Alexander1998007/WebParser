using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebParser.Models
{
    public class DocumentString
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Count { get; set; } // count of words

        public int DocumentId { get; set; }
        public Document Document { get; set; } // document
    }
}
