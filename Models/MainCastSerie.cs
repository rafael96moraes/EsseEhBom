using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class MainCastSerie
    {
        public int Id { get; set; }

        [Display(Name = "Série")]
        public Serie Serie { get; set; }

        [Display(Name = "Ator")]
        public Actor Actor { get; set; }
    }
}