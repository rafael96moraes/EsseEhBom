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

namespace EsseEhBom.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DetailsModel(DatabaseContext context)
        {
            _context = context;
        }
        public Book Book { get; set; }
        public List<CommentBook> Comments { get; set; }
        [BindProperty]
        public CommentBook Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
            Comments = await _context.CommentsBook.Where(m => m.BookId == id).OrderByDescending(m => m.Id).ToListAsync();

            if (Book == null)
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

            Book = await _context.Books.FindAsync(id);

            if (Book != null)
            {
                _context.CommentsBook.Add(Comment);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Details", new { Id = id });
        }
    }
}
