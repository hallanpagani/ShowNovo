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

        [Column("microregiao")]
        [Display(Name = "Micro Região")]
        [Required(ErrorMessage = "Micro Região é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(10, ErrorMessage = "Campo 'Região' pode ter no máximo 10 caracteres!")]  
        public string microregiao { get; set; }

        [Column("nome")]
        [Display(Name = "Nome da Micro região")]
        [Required(ErrorMessage = "O nome da região é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Nome da Região' pode ter no máximo 100 caracteres!")]
        public string nome { get; set; }

        [Column("id_regiao")]
        public long id_regiao { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_regiao p where r.id = a.id_regiao) as nm_regiao")]
        [Display(Name = "Nome da Região")]
        public string nm_regiao { get; set; }

        [Column("id_subregiao")]
        public long id_subregiao { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_subregiao p where r.id = a.id_subregiao) as nm_subregiao")]
        [Display(Name = "Nome da SubRegião")]
        public string nm_subregiao { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public RegiaoMicro()
        {
            
        }

    }
}
