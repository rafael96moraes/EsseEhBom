using EsseEhBom.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Text { get; set; }
        public Catalog Catalog { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}