
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace   Cp2_DotNet.Models
{
    [Table("tb_crm")]
    public class CRM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CRMId { get; set; }

        [Required(ErrorMessage = "O número do CRM é obrigatório.")]
        public string Numero { get; set; }

        // relacionamento 1 pra 1 com a classe do cirurgiao
        [ForeignKey("Cirurgiao")]
        public int CirurgiaoId { get; set; }
        public Cirurgiao? Cirurgiao { get; set; }

        // relacionamento 1 pra 1 com a classe pediatra
        [ForeignKey("Pediatra")]
        public int PediatraId { get; set; }
        public Pediatra? Pediatra { get; set; }
    }
}
