using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublishingCompany { get; set; }
        public string Country { get; set; }
        public DateTime ReleaseYear { get; set; }
    }
}