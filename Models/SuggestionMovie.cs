using EsseEhBom.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class SuggestionMovie
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Diretor")]
        public string Director { get; set; }

        [Display(Name = "País")]
        public string Country { get; set; }

        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Release { get; set; }

        public string ApplicationUserId { get; set; }

        public bool IsApproved { get; set; }

        public string Administrator { get; set; }
    }
}
