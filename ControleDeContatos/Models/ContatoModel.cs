using System.ComponentModel.DataAnnotations;

namespace ControledeContatos.Models
{
    public class ContatoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        
        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Cidade { get; set; }

        public string Rua { get; set; }

        public string Bairro { get; set; }

        [StringLength(2, ErrorMessage = "O estado deve ter 2 caracteres.")]
        public string Estado { get; set; }
    }
}