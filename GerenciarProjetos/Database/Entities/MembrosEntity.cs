using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciarProjetos.Database.Entities
{
    [Table("membros")]
    public class MembrosEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Foreign Key relacionada a entidade <see cref="Projeto"/>
        /// </summary>
        [Column("id_projeto")]
        public int IdProjeto { get; set; }

        /// <summary>
        /// Foreign Key relacionada a entidade <see cref="Empregado"/>
        /// </summary>
        [Column("id_empregado")]
        public int IdEmpregado { get; set; }

        /// <summary>
        /// Entidade relacionada a partir da Foreign Key <see cref="IdProjeto"/>
        /// </summary>
        public ProjetoEntity Projeto { get; set; }

        /// <summary>
        /// Entidade relacionada a partir da Foreign Key <see cref="IdEmpregado"/>
        /// </summary>
        public EmpregadoEntity Empregado { get; set; }
    }
}
