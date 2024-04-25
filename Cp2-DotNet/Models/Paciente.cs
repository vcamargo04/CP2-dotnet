using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cp2_DotNet.Models
{
    [Table("tb_pacientes")]
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        public string Diagnostico { get; set; }

        [MaxLength(20, ErrorMessage = "O telefone deve conter no máximo 20 caracteres.")]
        public string Telefone { get; set; }

        [MaxLength(11, ErrorMessage = "O CPF deve conter no máximo 11 caracteres.")]
        public string CPF { get; set; }

        [EmailAddress(ErrorMessage = "O email inserido não é válido.")]
        public string Email { get; set; }

        // relacionamento 1 pra N com a classe consulta
        public ICollection<Consulta> Consultas { get; set; }
    }
}
