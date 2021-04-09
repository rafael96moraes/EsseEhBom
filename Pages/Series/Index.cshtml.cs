using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EsseEhBom.Data;
using EsseEhBom.Models;

namespace EsseEhBom.Pages.Series
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _context;

        public IndexModel(DatabaseContext context)
        {
            _context = context;
        }

        public IList<Serie> Serie { get;set; }

        public async Task OnGetAsync()
        {
            Serie = await _context.Series.ToListAsync();
        }
    }
}
