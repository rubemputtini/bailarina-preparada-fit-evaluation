using AvaliacaoBailarinaPreparada.Data;
using AvaliacaoBailarinaPreparada.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoBailarinaPreparada.Services
{
    public class EvaluationService
    {
        private readonly ApplicationDbContext _context;

        public EvaluationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Evaluation> CreateEvaluationAsync(Evaluation evaluation)
        {
            var exercises = await _context.Exercises.ToListAsync();

            evaluation.EvaluationItems = exercises.Select(e => new EvaluationItem
            {
                ExerciseId = e.Id,
                Score = 0
            }).ToList();

            _context.Evaluations.Add(evaluation);
            await _context.SaveChangesAsync();

            return evaluation;
        }
    }
}
