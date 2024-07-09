using AvaliacaoBailarinaPreparada.Models;
using AvaliacaoBailarinaPreparada.Services;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoBailarinaPreparada.Controllers
{
    public class EvaluationsController : Controller
    {
        private readonly EvaluationService _evaluationService;

        public EvaluationsController(EvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        public async Task<IActionResult> Create(Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                await _evaluationService.CreateEvaluationAsync(evaluation);

                return RedirectToAction(nameof(Index));
            }

            return View(evaluation);
        }
    }
}
