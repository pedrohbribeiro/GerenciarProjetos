using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GerenciarProjetos.Database.Entities
{
    [Table("refresh_token")]
    public class RefreshTokenEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Column("token")]
        public string Token { get; set; }

        public UsuarioEntity Usuario { get; set; }
    }
}
