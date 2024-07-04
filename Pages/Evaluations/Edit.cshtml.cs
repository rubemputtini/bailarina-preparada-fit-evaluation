using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvaliacaoBailarinaPreparada.Data;
using AvaliacaoBailarinaPreparada.Models;

namespace AvaliacaoBailarinaPreparada.Pages_Evaluations
{
    public class EditModel : PageModel
    {
        private readonly AvaliacaoBailarinaPreparada.Data.ApplicationDbContext _context;

        public EditModel(AvaliacaoBailarinaPreparada.Data.ApplicationDbContext context)
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

            var evaluation =  await _context.Evaluations.FirstOrDefaultAsync(m => m.Id == id);
            if (evaluation == null)
            {
                return NotFound();
            }
            Evaluation = evaluation;
           ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Evaluation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluationExists(Evaluation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EvaluationExists(int id)
        {
            return _context.Evaluations.Any(e => e.Id == id);
        }
    }
}
