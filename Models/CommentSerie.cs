using EsseEhBom.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class CommentSerie
    {
        public int Id { get; set; }

        [Display(Name = "Avaliação")]
        public int Rate { get; set; }

        [Display(Name = "Texto")]
        public string Text { get; set; }

        public int SerieId { get; set; }
        public Movie Serie { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string UserName { get; set; }
    }
}
