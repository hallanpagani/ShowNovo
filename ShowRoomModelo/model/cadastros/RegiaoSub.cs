using ShowRoomModelo.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_subregiao")]
    public class RegiaoSub
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Column("subregiao")]
        [Display(Name = "SubRegião")]
        [Required(ErrorMessage = "SubRegião é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(10, ErrorMessage = "Campo 'Região' deve ter no máximo 10 caracteres!")]  
        public string subregiao { get; set; }

        [Column("nome")]
        [Display(Name = "Nome da região")]
        [Required(ErrorMessage = "O nome da SubRegião é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Campo 'Nome da Região' deve ter no máximo 100 caracteres!")]
        public string nome { get; set; }

        [Column("id_regiao")]
        public long id_regiao { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_regiao p where p.id = a.id_regiao) as nm_regiao")]
        [Display(Name = "Nome da Região")]
        public string nm_regiao { get; set; }

    /*     [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }  */

        public RegiaoSub()
        {
            
        }

    }
}
