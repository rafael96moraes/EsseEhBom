using EsseEhBom.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class InvitationFriend
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string FriendUserId { get; set; }
        public ApplicationUser ApplicationUser { get;set; }

        public bool IsAccepted { get; set; }
    }
}
