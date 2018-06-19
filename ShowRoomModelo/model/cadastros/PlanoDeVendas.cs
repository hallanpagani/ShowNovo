using ShowRoomModelo.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_plano_vendas")]
    public class PlanoDeVendas
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Column("id_colecao")]
        [Display(Name = "Coleção")]
        public long colecao { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_colecao c where c.id = a.id_colecao) as nm_colecao")]
        [Display(Name = "Nome do Coleção")]
        public string nm_colecao { get; set; }

        [Column("id_marca")]
        [Display(Name = "Marca")]
        public long marca { get; set; }
        
        [OnlySelect]
        [Column("(select nome from tb_cadastro_marca c where c.id = a.id_marca) as nm_marca")]
        [Display(Name = "Nome da Marca")]
        public string nm_marca { get; set; }

        [Column("id_cliente")]
        [Display(Name = "Cliente")]
        public long cliente { get; set; }

        [OnlySelect]
        [Column("(select coalesce(razao,fantasia) from tb_cadastro_cliente c where c.id = a.id_cliente) as nm_cliente")]
        [Display(Name = "Nome da Cliente")]
        public string nm_cliente { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_cidade c where c.id = (select c.id_cidade from tb_cadastro_cliente c where c.id = a.id_cliente) ) as nm_cidade")]
        [Display(Name = "Cidade")]
        public string nm_cidade { get; set; }

        [Column("valcolecaoanterior")]
        [Display(Name = "Valor coleção anterior")]
        public decimal valorcolecaoanterior { get; set; }

        [Column("valcolecaoatual")]
        [Display(Name = "Valor coleção atual")]
        public decimal valorcolecaoatual { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public PlanoDeVendas()
        {
            
        }
    }
}