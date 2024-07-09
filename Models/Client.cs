using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AvaliacaoBailarinaPreparada.Models
{
    public class Client
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o nome")]
        [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
        [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres")]
        [DisplayName("Nome Completo")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Insira o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [DisplayName("E-mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Insira a idade")]
        [Range(0, 100, ErrorMessage = "A idade deve ser estar entre 0 e 100")]
        [DisplayName("Idade")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Insira o gênero")]
        [StringLength(20, ErrorMessage = "O gênero deve conter até 20 caracteres")]
        [DisplayName("Gênero")]
        public string Gender { get; set; } = string.Empty;
    }
}
