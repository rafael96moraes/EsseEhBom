using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class SuggestionBook
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Display(Name = "Editora")]
        public string PublishingCompany { get; set; }

        [Display(Name = "País")]
        public string Country { get; set; }

        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseRelease { get; set; }
        public int ApplicationUserId { get; set; }

        public bool IsApproved { get; set; }

        public int Administrator { get; set; }
    }
}
