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

        public List<Friend> MyFriends { get; set; }
        public List<Friend> MutualFriends { get; set; }
        public List<Friend> FriendsOtherUser = new List<Friend>();
        public InvitationFriend InvitationFriend { get; set; }
        public string Message { get; set; }
        public bool IsFriend { get; set; }
        public bool? TryInvitation {get;set;}
        public string NameOtherUser { get; set; }
        public List<ReviewBook> ReviewBooks { get; set; }
        public List<ReviewSerie> ReviewSeries { get; set; }
        public List<ReviewMovie> ReviewMovies { get; set; }

        public async Task<IActionResult> OnGetAsync(string userName, bool? invitation = null)
        {
            var user = await _userManager.GetUserAsync(User);
            var otherUser = await _userManager.FindByNameAsync(userName);
            NameOtherUser = otherUser.UserName;
            if (user == null || otherUser == null)
            {
                return NotFound();
            }
            MyFriends = await _context.Friends.Where(m => m.ApplicationUserId == user.Id).ToListAsync();
            FriendsOtherUser = await _context.Friends.Where(m => m.ApplicationUserId == otherUser.Id).ToListAsync();

            //Amizade em comum
            foreach(var friend in MyFriends)
            {
                var mutualFriends = FriendsOtherUser
                    .FirstOrDefault(f => f.ApplicationUserId == friend.ApplicationUserId);
                if (mutualFriends != null)
                {
                    MutualFriends.Add(mutualFriends);
                }           
            }

            // Verificar se já são amigos
            IsFriend = MyFriends.Exists(a => a.FriendUserId == otherUser.Id);

            TryInvitation = invitation;

            ReviewBooks = await _context.CommentsBook
                .Include(u => u.Book)
                .AsNoTracking()
                .Where(c => c.UserName == otherUser.UserName)
                .ToListAsync();
            ReviewSeries = await _context.CommentsSerie
                .Include(u => u.Serie)
                .AsNoTracking()
                .Where(c => c.UserName == otherUser.UserName)
                .ToListAsync();
            ReviewMovies = await _context.CommentsMovie
                .Include(u => u.Movie)
                .AsNoTracking()
                .Where(c => c.UserName == otherUser.UserName)
                .ToListAsync();

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
                bool? result = false;
                return RedirectToPage("./Visit", new { userName = userName, invitation = result });
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
            return RedirectToPage("./Visit", new { userName = userName, invitation = true });
        }
    }
}
