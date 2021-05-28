using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EsseEhBom.Data;
using EsseEhBom.Models;
using Microsoft.AspNetCore.Identity;

namespace EsseEhBom.Pages.Series
{
    public class DetailsModel : PageModel
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DetailsModel(DatabaseContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ApplicationUser UserView { get; set; }
        public Serie Serie { get; set; }
        public List<ReviewSerie> Comments { get; set; }
        [BindProperty]
        public ReviewSerie Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserView = await _userManager.GetUserAsync(User);
            Serie = await _context.Series.FirstOrDefaultAsync(m => m.Id == id);
            Comments = await _context.CommentsSerie.Where(m => m.SerieId == id).OrderByDescending(m => m.Id).ToListAsync();

            if (Serie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserView = await _userManager.GetUserAsync(User);
            Serie = await _context.Series.FindAsync(id);

            if (Serie != null)
            {
                _context.CommentsSerie.Add(Comment);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Details", new { Id = id });
        }
    }
}
