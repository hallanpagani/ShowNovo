using ShowRoomModelo.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_mesorregiao")]
    public class Mesorregiao
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

      /*  [Column("mesorregiao")]
        [Display(Name = "Mesorregião")]
        [Required(ErrorMessage = "Mesorregião é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(10, ErrorMessage = "Campo 'Mesorregião' deve ter no máximo 10 caracteres!")]  
        public string mesorregiao { get; set; }*/

        [Column("nome")]
        [Display(Name = "Nome da Mesorregião")]
        [Required(ErrorMessage = "O nome da Mesorregião é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Campo 'Nome da Mesorregião' deve ter no máximo 100 caracteres!")]
        public string nome { get; set; }

        [Required]
        [Column("id_uf")]
        public long id_uf { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_estado p where p.id = a.id_uf) as nm_estado")]
        [Display(Name = "Nome do Estado")]
        public string nm_estado { get; set; }

        [Column("id_regiao")]
        public long id_regiao { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_regiao p where p.id = a.id_regiao) as nm_regiao")]
        [Display(Name = "Nome da Região")]
        public string nm_regiao { get; set; }

        /*  [Column("id_conta")]
          public long id_conta { get; set; }

          [Column("id_usuario")]
          public long id_usuario { get; set; } */

        public Mesorregiao()
        {
            
        }

    }
}
