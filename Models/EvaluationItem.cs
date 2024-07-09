using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaliacaoBailarinaPreparada.Models
{
    public class EvaluationItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Avaliação")]
        public int EvaluationId { get; set; }

        [ForeignKey("EvaluationId")]
        public Evaluation Evaluation { get; set; }

        [Required]
        [DisplayName("Exercício")]
        public int ExerciseId { get; set; }

        [ForeignKey("Exercício")]
        public Exercise Exercise { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "A nota deve estar entre 0 e 100")]
        [DisplayName("Nota")]
        public int Score { get; set; }

    }
}
