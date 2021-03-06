﻿using ShowRoomModelo.classes;
using System;
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
        [Required(ErrorMessage = "Campo 'Coleção' é obrigatório!", AllowEmptyStrings = false)]
        [Range(1, long.MaxValue, ErrorMessage = "Campo 'Coleção' deve ser preenchido!")]
        public long colecao { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_colecao c where c.id = a.id_colecao) as nm_colecao")]
        [Display(Name = "Nome do Coleção")]
        public string nm_colecao { get; set; }

    /*    [Column("id_showroom")]
        [Display(Name = "ShowRoom")]
        public long showroom { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_showroom c where c.id = a.id_showroom) as nm_showroom")]
        [Display(Name = "Nome do ShowRoom")]
        public string nm_showroom { get; set; }*/

        [Column("id_marca")]
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Campo 'Marca!", AllowEmptyStrings = false)]
        [Range(1, long.MaxValue, ErrorMessage = "Campo 'Marca' deve ser preenchido!")]
        public long marca { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_marca c where c.id = a.id_marca) as nm_marca")]
        [Display(Name = "Nome da Marca")]
        public string nm_marca { get; set; }

        [OnlySelect]
        [Column("(select cor_padrao from tb_cadastro_marca c where c.id = a.id_marca) as cor_marca")]
        [Display(Name = "Cor da Marca")]
        public string cor_marca { get; set; }

        [Column("id_cliente")]
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Campo 'Cliente' é obrigatório!", AllowEmptyStrings = false)]
        [Range(1, long.MaxValue, ErrorMessage = "Campo 'Cliente' deve ser preenchido!")]
        public long cliente { get; set; }

        [OnlySelect]
        [Column("(select coalesce(razao,fantasia) from tb_cadastro_cliente c where c.id = a.id_cliente) as nm_cliente")]
        [Display(Name = "Nome da Cliente")]
        public string nm_cliente { get; set; }

        [OnlySelect]
        [Column("(select case when status = 0 then 'ATIVO' when status = 1 then 'INATIVO' else 'PROSPECT' end  from tb_cadastro_cliente c where c.id = a.id_cliente) as status_cliente")]
        [Display(Name = "Status")]
        public string status_cliente { get; set; }

      /*  [Column("id_vendedor")]
        [Display(Name = "Vendedor")]
        public long vendedor { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_vendedor c where c.id = a.id_vendedor) as nm_vendedor")]
        [Display(Name = "Nome da Vendedor")]
        public string nm_vendedor { get; set; }*/

     /*   [Column("id_cidade")]
        [Display(Name = "Cidade")]
        public long cidade { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_cidade c where c.id = a.id_cidade) as nm_cidade")]
        [Display(Name = "Nome da Cidade")]
        public string nm_cidade { get; set; } */

        [Column("reservasuite")]
        [Display(Name = "Reserva Suíte?")]
        public bool reservasuite { get; set; }
        
        [Column("clientenovo")]
        [Display(Name = "Cliente novo?")]
        public bool clientenovo { get; set; }

        [Column("atendeshowroom")]
        [Display(Name = "Atende Showroom?")]
        public bool atendeshowroom { get; set; }

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
        public int potencialpdv { get; set; }

        [Column("populacao")]
        [Display(Name = "População")]
        public int populacao { get; set; }

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
        [Display(Name = "Meta para a Coleção")]
        [Range(0.00, 999999999.99, ErrorMessage = "O campo Meta para a Coleção deve ser preenchido corretamente!")]
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

        [Column("dt_agenda")]
        [Display(Name = "Data agendada")]
        [Required(ErrorMessage = "Campo 'Data agendamento' é obrigatório!", AllowEmptyStrings = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? dt_agenda { get; set; }

        [Timestamp]
        [Column("hr_agenda")]
        [Display(Name = "Horário")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo 'Hora agendamento' é obrigatório!", AllowEmptyStrings = false)]
        public string hr_agenda { get; set; }

        [Column("tp_status")]
        [Display(Name = "Status")]
        public int tp_status { get; set; }

        public string tp_status_nome
        {
            get
            {
                switch (tp_status)
                {
                    case 1:
                        return "AGENDADO";
                    case 2:
                        return "REALIZADO";
                    case 3:
                        return "ATENDIDO";
                    case 4:
                        return "FALTOU";
                    //case 5:
                    //    return "Concluído";
                    default:
                        return "AGENDADO";
                };
            }
        }

        [Column("id_conta")]
        [Display(Name = "Conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        [Display(Name = "Usuario")]
        public long id_usuario { get; set; }

        public Agendamento()
        {
            metacolecaoatual = 0;
            tp_status = 1;
        }

    }
}