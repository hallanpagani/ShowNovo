using ShowRoomModelo.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_agendamento")]
    public class Agendamento
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

        [Column("id_showroom")]
        [Display(Name = "ShowRoom")]
        public long showroom { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_showroom c where c.id = a.id_showroom) as nm_showroom")]
        [Display(Name = "Nome do ShowRoom")]
        public string nm_showroom { get; set; }

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
        [Column("(select nome from tb_cadastro_cidade c where c.id = a.id_cliente) as nm_cliente")]
        [Display(Name = "Nome da Cliente")]
        public string nm_cliente { get; set; }


        [Column("id_vendedor")]
        [Display(Name = "Vendedor")]
        public long vendedor { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_vendedor c where c.id = a.id_vendedor) as nm_vendedor")]
        [Display(Name = "Nome da Vendedor")]
        public string nm_vendedor { get; set; }

        [Column("id_cidade")]
        [Display(Name = "Cidade")]
        public long cidade { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_cidade c where c.id = a.id_cidade) as nm_cidade")]
        [Display(Name = "Nome da Cidade")]
        public string nm_cidade { get; set; }

        [Column("reservasuite")]
        [Display(Name = "Reserva Suíte")]
        public int reservasuite { get; set; }

        [Column("clientenovo")]
        [Display(Name = "Cliente novo?")]
        public int clientenovo { get; set; }

        [Column("atendeshowroom")]
        [Display(Name = "Atende Showroom?")]
        public int atendeshowroom { get; set; }

        [Column("statuspedido")]
        [Display(Name = "Pedido")]
        public string statuspedido { get; set; }

        [Column("ipc")]
        [Display(Name = "ipc")]
        public decimal ipc { get; set; }

        [Column("consumomoda")]
        [Display(Name = "Consumo Moda")]
        public decimal consumomoda { get; set; }

        [Column("potencialpdv")]
        [Display(Name = "Pontencial PDV")]
        public decimal potencialpdv { get; set; }

        [Column("populacao")]
        [Display(Name = "População")]
        public decimal populacao { get; set; }

        [Column("historicocolecao1")]
        [Display(Name = "Histórico Coleção 1")]
        public decimal historicocolecao1 { get; set; }

        [Column("historicocolecao2")]
        [Display(Name = "Histórico Coleção 2")]
        public decimal historicocolecao2 { get; set; }

        [Column("historicocolecao3")]
        [Display(Name = "Histórico Coleção 3")]
        public decimal historicocolecao3 { get; set; }

        [Column("historicocolecao4")]
        [Display(Name = "Histórico Coleção 4")]
        public decimal historicocolecao4 { get; set; }

        [Column("metacolecaoatual")]
        [Display(Name = "Meta Coleção Atual")]
        public decimal metacolecaoatual { get; set; }

        [Column("realizado")]
        [Display(Name = "Realizado")]
        public decimal realizado { get; set; }

        [Column("percmetaatingida")]
        [Display(Name = "%Meta Atingida")]
        public decimal percmetaatingida { get; set; }

        [Column("perccrescimento")]
        [Display(Name = "%Crescimento")]
        public decimal perccrescimento { get; set; }

        [Column("id_conta")]
        [Display(Name = "Conta")]
        public long id_conta { get; set; }

        [Column("id_cliente")]
        [Display(Name = "Cliente")]
        public long id_cliente { get; set; }


        public Agendamento()
        {

        }

    }
}