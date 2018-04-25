using ShowRoomModelo.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_grupomarca")]
    public class MarcaGrupo
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Column("grupomarca")]
        [Display(Name = "Grupo Marca")]
        [Required(ErrorMessage = "Grupo marca é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(10, ErrorMessage = "Campo 'Grupo Marca' pode ter no máximo 10 caracteres!")]  
        public string marca { get; set; }

        [Column("nome")]
        [Display(Name = "Nome grupo da marca")]
        [Required(ErrorMessage = "O nome da grupo da marca é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Campo 'Nome grupo da marca' pode ter no máximo 100 caracteres!")]
        public string nome { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public MarcaGrupo()
        {
            
        }

    }
}
