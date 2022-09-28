using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciarProjetos.Database.Entities
{
    [Table("empregado")]
    public class EmpregadoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_empregado")]
        public int IdEmpregado { get; set; }

        [Column("primeiro-nome")]
        public string PrimeiroNome { get; set; }

        [Column("ultimo-nome")]
        public string UltimoNome { get; set; }

        [Column("telefone")]
        public long Telefone { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }
        
        [Column("excluido")]
        public bool Excluido { get; set; } = false;

        /// <summary>
        /// Entidade relacionada a partir da Foreign Key <see cref="ProjetoEntity.IdGerente"/>
        /// </summary>
        public List<ProjetoEntity> Projeto { get; set; }

        /// <summary>
        /// Entidade relacionada a partir da Foreign Key <see cref="MembrosEntity.IdEmpregado"/>
        /// </summary>
        public List<MembrosEntity> Membro { get; set; }
    }
}
