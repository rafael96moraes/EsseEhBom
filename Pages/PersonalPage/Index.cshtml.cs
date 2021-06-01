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

        public List<Friend> Friends { get; set; }
        public string Teste { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            Teste = user.UserName;

            if (user == null)
            {
                return NotFound($"Não foi possível carregar o ID do usuário '{_userManager.GetUserId(User)}'.");
            }

            var e = await _context.Friends.Where(m => m.ApplicationUserId == user.Id).ToListAsync();

            return Page();
        }
    }
}
