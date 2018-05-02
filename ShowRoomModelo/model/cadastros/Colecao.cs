
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_colecao")]
    public class Colecao
    {
        [Key]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Column("datainicio")]
        [Display(Name = "Data início")]
        [Required(ErrorMessage = "Data início é obrigatório!", AllowEmptyStrings = false)]
        [DataType(DataType.DateTime)]
        public DateTime datainicio { get; set; }

        [Column("qtdsemanas")]
        [Display(Name = "Qtd.Semanas")]
        [Required(ErrorMessage = "Qtd.Semanas é obrigatório!", AllowEmptyStrings = false)]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade de semanas deve ser maior que 1.")]
        public int qtdsemanas { get; set; }

        [Column("colecaoequivalente")]
        [Display(Name = "Coleção equivalente")]
        [MaxLength(8, ErrorMessage = "Campo 'Coleção equivalente' deve ter no máximo 8 caracteres!")]
        public string colecaoequivalente { get; set; }

        [Column("colecao")]
        [Display(Name = "Coleção")]
        [Required(ErrorMessage = "O campo Coleção é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(8, ErrorMessage = "Campo 'Coleção' deve ter no máximo 8 caracteres!")]
        public string colecao { get; set; }

        [Column("nome")]
        [Display(Name = "Nome da Coleção")]
        [Required(ErrorMessage = "O nome da coleção é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Nome da coleção' deve ter no máximo 30 caracteres!")]
        public string nome { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public Colecao()
        {
           // datainicio = DateTime.Now;
        }

    }
}