using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class Catalog
    {
        public int Id { get; set; }

        public List<Movie> Movies { get; set; }
        public List<Serie> Series { get; set; }
        public List<Book> Books { get; set; }
    }
}