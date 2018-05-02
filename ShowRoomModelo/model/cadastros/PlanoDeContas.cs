using ShowRoomModelo.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_plano_vendas")]
    public class PlanoDeContas
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Column("id_colecao")]
        [Display(Name = "Coleção")]
        public long id_colecao { get; set; }

        [Column("id_marca")]
        [Display(Name = "Marca")]
        public long id_marca { get; set; }

        [Column("id_cliente")]
        [Display(Name = "Cliente")]
        public long id_cliente { get; set; }

        [Column("id_cidade")]
        [Display(Name = "Cidade")]
        public long id_cidade { get; set; }

        [Column("valorcolecaoanterior")]
        [Display(Name = "Valor coleção anterior")]
        public decimal valorcolecaoanterior { get; set; }

        [Column("valorcolecaoatual")]
        [Display(Name = "Valor coleção atual")]
        public decimal valorcolecaoatual { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public PlanoDeContas()
        {
            
        }
    }
}