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
        [Display(Name = "Grupo de Marcas")]
        [Required(ErrorMessage = "Campo código do grupo de marcas é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(10, ErrorMessage = "Campo 'Grupo Marca' deve ter no máximo 10 caracteres!")]  
        public string grupomarca { get; set; }

        [Column("nome")]
        [Display(Name = "Nome do grupo da marcas")]
        [Required(ErrorMessage = "O nome da grupo da marca é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Campo 'Nome grupo da marca' deve ter no máximo 100 caracteres!")]
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
