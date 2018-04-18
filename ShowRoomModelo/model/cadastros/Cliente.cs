using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShowRoomModelo.classes;
using ShowRoomModelo.model.generico;
using System.Collections.Generic;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cliente")]
    public class Cliente : BaseUGrav
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public int id { get; set; }

        [Required]
        [Column("nm_cliente")]
        [Display(Name = "Nome do cliente")]
        public string nome { get; set; }

        [Required]
        [Column("ds_cpfcnpj")]
        [Display(Name = "CPF ou CNPJ")]
        public string cpfcnpj { get; set; }

        [Column("ds_rg")]
        [Display(Name = "RG")]
        public string rg { get; set; }

        [Column("ds_fone1")]
        [Display(Name = "Fone 1")]
        public string fone1 { get; set; }

        [Column("ds_fone2")]
        [Display(Name = "Fone 2")]
        public string fone2 { get; set; }

        [Column("ds_cep")]
        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Column("ds_logradouro")]
        [Display(Name = "Endereço")]
        public string logradouro { get; set; }

        [Column("nr_logradouro")]
        [Display(Name = "Número")]
        public string numero { get; set; }

        [Column("ds_complemento")]
        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        [Column("ds_bairro")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Column("ds_cidade")]
        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Column("ds_estado")]
        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Column("ds_email")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [DataType(DataType.Date)]
        [Column("dt_inc")]
        [Display(Name = "Data do cadastro")]
        public DateTime dt_inc { get; set; }

        [DataType(DataType.Date)]
        [Column("dt_nasc")]
        [Display(Name = "Data do nascimento")]
        public DateTime dt_nasc { get; set; }

        
        public List<Cartao> Cartoes { get; set; }
        public Cartao Cartao { get; set; }

        public Cliente()
        {
            this.id = 0;
            this.numero = null;
            this.email = string.Empty;
            dt_inc = DateTime.Now;
            Cartoes = new List<Cartao>();
            Cartao = new Cartao();
        }
    }
}