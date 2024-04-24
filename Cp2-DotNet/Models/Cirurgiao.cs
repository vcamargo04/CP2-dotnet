
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cp2_DotNet.Models
{
    [Table("tb_cirurgioes")]
    public class Cirurgiao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A especialidade é obrigatória.")]
        public string Especialidade { get; set; }

        

        [MaxLength(20, ErrorMessage = "O telefone deve conter no máximo 20 caracteres.")]
        public string Telefone { get; set; }

        // Relaciomento 1 pra 1 com a classe CRM
        [ForeignKey("CRM")]
        public int CRMId { get; set; }
        public CRM? CRM { get; set; }
    }
}
