using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AvaliacaoBailarinaPreparada.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nome do Exercício")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DisplayName("Categoria")]
        public string Category { get; set; } = string.Empty;
    }
}
