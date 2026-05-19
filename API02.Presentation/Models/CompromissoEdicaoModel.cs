using System.ComponentModel.DataAnnotations;

namespace API02.Presentation.Models
{
    public class CompromissoEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do compromisso.")]
        public Guid Id { get; set; }
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do compromisso.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data do compromisso.")]
        public string Data { get; set; }

        [Required(ErrorMessage = "Por favor, informe a hora do compromisso.")]
        public string Hora { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(500, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a descrição do compromisso.")]
        public string Descricao { get; set; }
    }
}
