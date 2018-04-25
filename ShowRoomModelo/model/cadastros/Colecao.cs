using ShowRoomModelo.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_colecao")]
    public class Colecao
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Column("datainicio")]
        [Display(Name = "Data inicio")]
        [Required(ErrorMessage = "Data inicio é obrigatório!", AllowEmptyStrings = false)]
        [DataType(DataType.DateTime)]
        public DateTime datainicio { get; set; }

        [Column("qtdsemanas")]
        [Display(Name = "Qtd.Semanas")]
        [Required(ErrorMessage = "Qtd.Semanas é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(3, ErrorMessage = "Campo 'Qtd.Semanas' pode ter no máximo 3 caracteres!")]
        public int qtdsemanas { get; set; }

        [Column("colecaoequivalente")]
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Cidade é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(8, ErrorMessage = "Campo 'Cidade' pode ter no máximo 8 caracteres!")]
        public string colecaoequivalente { get; set; }

        [Column("colecao")]
        [Display(Name = "Nome da Coleção")]
        [Required(ErrorMessage = "O nome da região é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Nome da Cidade' pode ter no máximo 100 caracteres!")]
        public string colecao { get; set; }

        [Column("nome")]
        [Display(Name = "Nome da Coleção")]
        [Required(ErrorMessage = "O nome da região é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Nome da Cidade' pode ter no máximo 100 caracteres!")]
        public string nome { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public Colecao()
        {

        }

    }
}