using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciarProjetos.Database.Entities
{
    [Table("projeto")]
    public class ProjetoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_projeto")]
        public int IdProjeto { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("data-criacao", TypeName = "date")]
        public DateTime DataCriacao { get; set; }

        [Column("data-termino", TypeName = "date")]
        public DateTime DataTermino { get; set; }

        [Column("excluido")]
        public bool Excluido { get; set; }

        /// <summary>
        /// Foreign Key relacionada a entidade <see cref="Empregado"/>
        /// </summary>
        [Column("gerente")]
        public int IdGerente { get; set; }

        /// <summary>
        /// Entidade relacionada a partir da Foreign Key <see cref="IdGerente"/>
        /// </summary>
        public EmpregadoEntity Empregado { get; set; }

        /// <summary>
        /// Entidade relacionada a partir da Foreign Key <see cref="MembrosEntity.IdProjeto"/>
        /// </summary>
        public List<MembrosEntity> Membro { get; set; }
    }
}
