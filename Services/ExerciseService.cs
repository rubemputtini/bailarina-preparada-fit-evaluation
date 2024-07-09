using AvaliacaoBailarinaPreparada.Data;
using AvaliacaoBailarinaPreparada.Models;

namespace AvaliacaoBailarinaPreparada.Services
{
    public class ExerciseService
    {
        private readonly ApplicationDbContext _context;

        public ExerciseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InitializeExerciseAsync()
        {
            if (!_context.Exercises.Any())
            {
                var exercises = new List<Exercise>
                {
                    new Exercise { Name = "Agachamento profundo", Category = "FMS" },
                    new Exercise { Name = "Passo por cima da barreira D", Category = "FMS" },
                    new Exercise { Name = "Passo por cima da barreira E", Category = "FMS" },
                    new Exercise { Name = "Avanço em linha D", Category = "FMS" },
                    new Exercise { Name = "Avanço em linha E", Category = "FMS" },
                    new Exercise { Name = "Mobilidade de ombro D", Category = "FMS" },
                    new Exercise { Name = "Mobilidade de ombro E", Category = "FMS" },
                    new Exercise { Name = "Flexão de quadril D", Category = "FMS" },
                    new Exercise { Name = "Flexão de quadril E", Category = "FMS" },
                    new Exercise { Name = "Estabilidade de tronco (Flexão)", Category = "FMS" },
                    new Exercise { Name = "Estabilidade de rotação E", Category = "FMS" },
                    new Exercise { Name = "Estabilidade de rotação D", Category = "FMS" },
                    new Exercise { Name = "Resistência de força MMSS (Flexão de braço)", Category = "Capacidades Fisicas" },
                    new Exercise { Name = "Resistência de força MMII (Agachamento)", Category = "Capacidades Fisicas" },
                    new Exercise { Name = "Resistência de força core (Abdominal exército)", Category = "Capacidades Fisicas" },
                    new Exercise { Name = "Resistência aeróbia (1' burpee test)", Category = "Capacidades Fisicas" },
                    new Exercise { Name = "Equilíbrio", Category = "Capacidades Fisicas" },
                    new Exercise { Name = "Rise unilateral", Category = "Capacidades Fisicas" },
                };

                _context.Exercises.AddRange(exercises);
                await _context.SaveChangesAsync();
            }
        }
    }
}
