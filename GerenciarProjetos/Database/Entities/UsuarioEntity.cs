using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GerenciarProjetos.Database.Entities
{
    [Table("usuario")]
    public class UsuarioEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_usuario")]
        public int ID { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha-hash")]
        public string SenhaHash { get; set; }

        public List<RefreshTokenEntity> RefreshToken { get; set; }
    }
}
