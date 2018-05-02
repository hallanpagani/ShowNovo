using ShowRoomModelo.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_regiao")]
    public class Regiao
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Column("regiao")]
        [Display(Name = "Região")]
        [Required(ErrorMessage = "Região é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(10, ErrorMessage = "Campo 'Região' deve ter no máximo 10 caracteres!")]  
        public string regiao { get; set; }

        [Column("nome")]
        [Display(Name = "Nome da região")]
        [Required(ErrorMessage = "O nome da região é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Campo 'Nome da Região' deve ter no máximo 100 caracteres!")]
        public string nome { get; set; }

      /*  [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; } */

        public Regiao()
        {
            
        }

    }
}
