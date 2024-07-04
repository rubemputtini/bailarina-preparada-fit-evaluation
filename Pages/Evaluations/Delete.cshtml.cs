using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AvaliacaoBailarinaPreparada.Data;
using AvaliacaoBailarinaPreparada.Models;

namespace AvaliacaoBailarinaPreparada.Pages_Evaluations
{
    public class DeleteModel : PageModel
    {
        private readonly AvaliacaoBailarinaPreparada.Data.ApplicationDbContext _context;

        public DeleteModel(AvaliacaoBailarinaPreparada.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Evaluation Evaluation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluations.FirstOrDefaultAsync(m => m.Id == id);

            if (evaluation == null)
            {
                return NotFound();
            }
            else
            {
                Evaluation = evaluation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation != null)
            {
                Evaluation = evaluation;
                _context.Evaluations.Remove(Evaluation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
