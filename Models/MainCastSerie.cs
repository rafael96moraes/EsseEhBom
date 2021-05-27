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

        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}