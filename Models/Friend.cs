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

        public string ApplicationUserId { get; set; }

        public string FriendUserId { get; set; }
    }
}
