using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(DatabaseContext context, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public List<InvitationFriend> InvitationsFriends { get; set; }
        public List<Friend> Friends { get; set; }
        [DisplayName("Buscar")]
        [BindProperty]
        public string Search { get; set; }
        public string Message { get; set; }
        public List<ReviewBook> ReviewBooks { get; set; }
        public List<ReviewSerie> ReviewSeries { get; set; }
        public List<ReviewMovie> ReviewMovies { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Não foi possível carregar o ID do usuário '{_userManager.GetUserId(User)}'.");
            }

            Friends = await _context.Friends
                .Where(m => m.ApplicationUserId == user.Id)
                .ToListAsync();
            InvitationsFriends = await _context.InvitationsFriend
                .Include(u => u.ApplicationUser)
                .AsNoTracking()
                .Where(m => m.ApplicationUserId == user.Id)
                .ToListAsync();
            ReviewBooks = await _context.CommentsBook
                .Include(u => u.Book)
                .AsNoTracking()
                .Where(c => c.UserName == user.UserName)
                .ToListAsync();
            ReviewSeries = await _context.CommentsSerie
                .Include(u => u.Serie)
                .AsNoTracking()
                .Where(c => c.UserName == user.UserName)
                .ToListAsync();
            ReviewMovies = await _context.CommentsMovie
                .Include(u => u.Movie)
                .AsNoTracking()
                .Where(c => c.UserName == user.UserName)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(Search == null)
            {
                Message = "O nome do usuário não pode ficar branco!";
                return Page();
            }
            var otherUser = await _userManager.FindByNameAsync(Search);
            if (otherUser == null)
            {
                Message = "O usuário não existe!";
                return Page();
            }

            return RedirectToPage("./Visit", new { userName = Search });
        }

        public async Task<IActionResult> OnPutAsync()
        {
            if (Search == null)
            {
                Message = "O nome do usuário não pode ficar branco!";
                return Page();
            }
            var otherUser = await _userManager.FindByNameAsync(Search);
            if (otherUser == null)
            {
                Message = "O usuário não existe!";
                return Page();
            }

            return RedirectToPage("./Visit", new { userName = Search });
        }

    }
}
