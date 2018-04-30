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
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade de semanas deve ser maior que 1.")]
        public int qtdsemanas { get; set; }

        [Column("colecaoequivalente")]
        [Display(Name = "Coleção equivalente")]
        [MaxLength(8, ErrorMessage = "Campo 'Coleção equivalente' pode ter no máximo 8 caracteres!")]
        public string colecaoequivalente { get; set; }

        [Column("colecao")]
        [Display(Name = "Coleção")]
        [Required(ErrorMessage = "O campo Coleção é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(8, ErrorMessage = "Campo 'Coleção' pode ter no máximo 8 caracteres!")]
        public string colecao { get; set; }

        [Column("nome")]
        [Display(Name = "Nome da Coleção")]
        [Required(ErrorMessage = "O nome da coleção é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Nome da coleção' pode ter no máximo 30 caracteres!")]
        public string nome { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public Colecao()
        {
            datainicio = DateTime.Now;
        }

    }
}