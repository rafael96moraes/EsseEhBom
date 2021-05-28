using EsseEhBom.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class Friend
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public int ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUser")]
        public int FriendUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
