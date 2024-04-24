
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cp2_DotNet.Models
{
    [Table("Enfermeiros")]
    public class Enfermeiro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O setor é obrigatório.")]
        public string Setor { get; set; }

       

        [MaxLength(20, ErrorMessage = "O telefone deve conter no máximo 20 caracteres.")]
        public string Telefone { get; set; }

        // Relacionamento 1 para 1 com a classe COREN
        [ForeignKey("COREN")]
        public int CORENId { get; set; }
        public COREN COREN { get; set; }
    }
}
