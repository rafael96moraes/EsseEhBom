using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EsseEhBom.Models;
using EsseEhBom.Data;
using Microsoft.AspNetCore.Identity;

namespace EsseEhBom.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DetailsModel(DatabaseContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }
        public List<ReviewMovie> Comments { get; set; }
        [BindProperty]
        public ReviewMovie Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            Comments = await _context.CommentsMovie.Where(m => m.MovieId == id).OrderByDescending(m => m.Id).ToListAsync();

            if (Movie == null)
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

            Movie = await _context.Movies.FindAsync(id);

            if (Movie != null)
            {
                _context.CommentsMovie.Add(Comment);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Details", new { Id = id});
        }
    }
}
