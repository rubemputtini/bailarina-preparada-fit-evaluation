using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvaliacaoBailarinaPreparada.Data;
using AvaliacaoBailarinaPreparada.Models;

namespace AvaliacaoBailarinaPreparada.Pages_Clients
{
    public class DetailsModel : PageModel
    {
        private readonly AvaliacaoBailarinaPreparada.Data.ApplicationDbContext _context;

        public DetailsModel(AvaliacaoBailarinaPreparada.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                Client = client;
            }
            return Page();
        }
    }
}
