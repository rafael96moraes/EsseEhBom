using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsseEhBom.Models
{
    public class InvitationFriend
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public string FriendUserId { get; set; }

        public bool IsAccepted { get; set; }
    }
}
