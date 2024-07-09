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
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Email");
          
            Evaluation = new Evaluation
            {
                EvaluationItems = _context.Exercises
                    .Select(e => new EvaluationItem
                    {
                        Exercise = e,
                        ExerciseId = e.Id,
                        Score = e.Category == "FMS" ? 0 : 1
                    }).ToList()
            };

            return Page();
        }

        [BindProperty]
        public Evaluation Evaluation { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Recarregar dados necess�rios se o ModelState n�o for v�lido
                ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Email");
                return Page();
            }

            // Adicionar a avalia��o e seus itens ao contexto
            _context.Evaluations.Add(Evaluation);

            // Se EvaluationItems n�o estiver vazio, adicione-os tamb�m
            if (Evaluation.EvaluationItems != null)
            {
                foreach (var item in Evaluation.EvaluationItems)
                {
                    item.EvaluationId = Evaluation.Id;
                    _context.EvaluationItems.Add(item);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
