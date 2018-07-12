using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebParser.Models
{
    public sealed class ParserContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentString> DocumentStrings { get; set; }

        public ParserContext(DbContextOptions<ParserContext> options)
            : base(options)
        {
            Database?.EnsureCreated();
        }
    }
}
