using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EsseEhBom.Data;
using EsseEhBom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EsseEhBom.Pages.PersonalPage
{
    public class VisitPageModel : PageModel
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public VisitPageModel(DatabaseContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public List<Friend> Friends { get; set; }
        public List<Friend> MutualFriends { get; set; }
        public List<Friend> FriendsOtherUser = new List<Friend>();
        public InvitationFriend InvitationFriend { get; set; }
        public string Message { get; set; }
        public bool IsFriend { get; set; }

        public async Task<IActionResult> OnGetAsync(string userName)
        {
            var user = await _userManager.GetUserAsync(User);
            var otherUser = await _userManager.FindByNameAsync(userName);
            if (user == null || otherUser == null)
            {
                return NotFound();
            }


            Friends = await _context.Friends.Where(m => m.ApplicationUserId == user.Id).ToListAsync();
            FriendsOtherUser = await _context.Friends.Where(m => m.ApplicationUserId == otherUser.Id).ToListAsync();

            //Amizade em comum
            foreach(var friend in Friends)
            {
                var mutualFriends = FriendsOtherUser
                    .FirstOrDefault(f => f.ApplicationUserId == friend.ApplicationUserId);
                if (mutualFriends != null)
                {
                    MutualFriends.Add(mutualFriends);
                }           
            }

            // Verificar se já são amigos
            IsFriend = Friends.Exists(a => a.FriendUserId == otherUser.Id);


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string userName)
        {
            var user = await _userManager.GetUserAsync(User);
            var otherUser = await _userManager.FindByNameAsync(userName);
            if (user == null || otherUser == null)
            {
                return NotFound();
            }


            // Verificar se ja mandou invite
            var e = await _context.InvitationsFriend
                .Where(f => f.ApplicationUserId == otherUser.Id)
                .FirstOrDefaultAsync(f => f.FriendUserId == user.Id);

            if (e != null)
            {
                Message = "Voce já mandou o convite antes!";
            }
            else
            {
                var invitation = new InvitationFriend()
                {
                    ApplicationUserId = otherUser.Id,
                    FriendUserId = user.Id
                };
                _context.InvitationsFriend.Add(invitation);
                await _context.SaveChangesAsync();
            }
            return Page();
        }
    }
}
