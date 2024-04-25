
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cp2_DotNet.Models
{
    [Table("tb_coren")]
    public class COREN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número do COREN é obrigatório.")]
        public string Numero { get; set; }

        // relacionamento com a classe 1 pra N com a classe enfermeiro
        public ICollection<Enfermeiro>? Enfermeiros { get; set; }
    }
}
