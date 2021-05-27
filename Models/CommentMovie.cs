using EsseEhBom.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class CommentMovie
    {
        public int Id { get; set; }

        [Display(Name = "Avaliação")]
        public int Rate { get; set; }

        [Display(Name = "Texto")]
        public string Text { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Display(Name = "Usuário")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}