using ShowRoomModelo.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_microregiao")]
    public class RegiaoMicro
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Required]
        [Column("id_regiao")]
        public long id_regiao { get; set; }

        [Column("microregiao")]
        [Display(Name = "Micro Região")]
        [Required(ErrorMessage = "Micro Região é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(10, ErrorMessage = "Campo 'Região' pode ter no máximo 10 caracteres!")]  
        public string regiao { get; set; }

        [Column("nome")]
        [Display(Name = "Nome da Micro região")]
        [Required(ErrorMessage = "O nome da região é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Nome da Região' pode ter no máximo 100 caracteres!")]
        public string nome { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public RegiaoMicro()
        {
            
        }

    }
}
