using ShowRoomModelo.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_semana_colecao")]
    public class ColecaoSemana
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Column("datainicio")]
        [Display(Name = "Data início")]
        [Required(ErrorMessage = "Data início é obrigatório!", AllowEmptyStrings = false)]
        [DataType(DataType.DateTime)]
        public DateTime datainicio { get; set; }

        [Column("datafim")]
        [Display(Name = "Data fim")]
        [Required(ErrorMessage = "Data fim é obrigatório!", AllowEmptyStrings = false)]
        [DataType(DataType.DateTime)]
        public DateTime datafim { get; set; }

        [Column("codigosemana")]
        [Display(Name = "Código da Semana")]
        [Required(ErrorMessage = "Código da Semana é obrigatório!", AllowEmptyStrings = false)]
        [Range(1, int.MaxValue, ErrorMessage = "Código da Semana deve ser maior que 1.")]
        public int codigosemana { get; set; }

        [Column("id_colecao")]
        [Display(Name = "Coleção")]
        [Required(ErrorMessage = "O campo Coleção é obrigatório!", AllowEmptyStrings = false)]
        public long id_colecao { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_colecao p where p.id = a.id_colecao) as nm_colecao")]
        [Display(Name = "Nome da Coleção")]
        public string nm_colecao { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public ColecaoSemana()
        {
            datainicio = DateTime.Now;
        }

    }
}