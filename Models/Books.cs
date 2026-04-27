using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_dotnet_core.Models
{
    public class Books
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public DateTime PublicationYear { get; set; }
    }
}