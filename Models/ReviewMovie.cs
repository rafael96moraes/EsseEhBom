using EsseEhBom.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class ReviewMovie
    {
        public int Id { get; set; }

        [Display(Name = "Avaliação")]
        public int Rate { get; set; }

        [Display(Name = "Texto")]
        public string Text { get; set; }
        [Display(Name = "Curtidas")]
        public int Likes { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string UserName { get; set; }
    }
}