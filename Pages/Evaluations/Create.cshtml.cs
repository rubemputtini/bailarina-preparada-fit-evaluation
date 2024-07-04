using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AvaliacaoBailarinaPreparada.Data;
using AvaliacaoBailarinaPreparada.Models;

namespace AvaliacaoBailarinaPreparada.Pages_Evaluations
{
    public class CreateModel : PageModel
    {
        private readonly AvaliacaoBailarinaPreparada.Data.ApplicationDbContext _context;

        public CreateModel(AvaliacaoBailarinaPreparada.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Evaluation Evaluation { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Evaluations.Add(Evaluation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
