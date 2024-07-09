using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AvaliacaoBailarinaPreparada.Models
{
    public class Evaluation
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira a data da avaliação")]
        [DisplayName("Data da Avaliação")]
        [DataType(DataType.DateTime)]
        public DateTime AssessmentDate { get; set; }

        [Required(ErrorMessage = "O nome do aluno é obrigatório")]
        [DisplayName("Aluno")]
        public int ClientId { get; set; }

        public Client? Client { get; set; }

        public List<EvaluationItem> EvaluationItems { get; set; } = [];
    }
}
