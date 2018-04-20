using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShowRoomModelo.classes;
using ShowRoomModelo.model.generico;

namespace ShowRoomModelo.model.adm
{
    [Table("tb_sistema_usuario")]
    public class Usuario: BaseID
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [EmailAddress]
        [Column("ds_login")]
        public string Email { get; set; }

        [Required]
        [Column("nm_usuario")]
        public string NomeDoUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Column("ds_senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmacao { get; set; }

    }
}