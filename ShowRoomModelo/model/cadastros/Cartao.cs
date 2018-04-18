using ShowRoomModelo.classes;
using ShowRoomModelo.model.generico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cartao")]
    public class Cartao  
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public int IdCartao { get; set; }

        [Column("nm_portador")]
        [Display(Name = "Nome do portador")]
        public string nm_portador { get; set; }

        [Column("nr_cartao")]
        [Display(Name = "Número do cartão")]
        public string nr_cartao { get; set; }

        [Column("validade_mes")]
        [Display(Name = "Mês validade")]
        public int? mes_validade { get; set; }

        [Column("validade_ano")]
        [Display(Name = "Ano de validade")]
        public int? ano_validade { get; set; }

        [Column("nm_bandeira")]
        [Display(Name = "Bandeira")]
        public string nm_bandeira { get; set; }

        [Column("cvv")]
        [Display(Name = "CVV")]
        public int cvv { get; set; }

        [Column("id_cliente")]
        [Display(Name = "Cliente")]
        public int idCliente { get; set; }

        [Column("is_padrao")]
        [Display(Name = "Padrão")]
        public bool is_padrao { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        public Cartao()
        {
            is_padrao = true;
            nm_bandeira = "Cielo";
            id_conta = 1;
        }

    }
}
