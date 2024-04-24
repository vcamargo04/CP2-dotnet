
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cp2_DotNet.Models
{
    [Table("tb_consultas")]
    public class Consulta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "A data da consulta é obrigatória.")]
        public DateTime DataConsulta { get; set; }

        // relccionamento 1 pra N com o paciente
        [ForeignKey("Paciente")]
        public int? PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        // relacionamento da classe clinicoGeral
        [ForeignKey("ClinicoGeral")]
        public int? ClinicoGeralId { get; set; }
        public ClinicoGeral? ClinicoGeral { get; set; }
    }
}
