using EsseEhBom.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class ReviewBook
    {
        public int Id { get; set; }

        [Display(Name = "Avaliação")]
        public int Rate { get; set; }

        [Display(Name = "Texto")]
        public string Text { get; set; }
        [Display(Name = "Curtidas")]
        public int Likes { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string UserName { get; set; }
    }
}
