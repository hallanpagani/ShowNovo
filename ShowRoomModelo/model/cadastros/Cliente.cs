using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShowRoomModelo.classes;
using ShowRoomModelo.model.generico;
using System.Collections.Generic;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_cliente")]
    public class Cliente
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public int id { get; set; }

        [Required]
        [Column("cliente")]
        [Display(Name = "Nome do cliente")]
        public string nome { get; set; }

        [Required]
        [Column("razao")]
        [Display(Name = "Razão do cliente")]
        public string razao { get; set; }

        [Required]
        [Column("cnpj")]
        [Display(Name = "CNPJ")]
        public string cnpj { get; set; }

        [Column("ie")]
        [Display(Name = "ie")]
        public string ie { get; set; }

        [Column("contato")]
        [Display(Name = "contato")]
        public string contato { get; set; }

        [Required]
        [Column("fone1")]
        [Display(Name = "Fone 1")]
        public string fone1 { get; set; }

        [Column("fone2")]
        [Display(Name = "Fone 2")]
        public string fone2 { get; set; }

        [Column("cep")]
        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Column("bairro")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Column("numero")]
        [Display(Name = "Número")]
        public string numero { get; set; }

        [Column("corredor")]
        [Display(Name = "Corredor")]
        public string corredor { get; set; }

        [Column("id_cidade")]
        [Display(Name = "Cidade")]
        public long cidade { get; set; }

        [Column("email")]
        [Display(Name = "Email 1")]
        public string email { get; set; }

        [Column("email2")]
        [Display(Name = "Email 2")]
        public string email2 { get; set; }

        [DataType(DataType.Date)]
        [Column("dt_inc")]
        [Display(Name = "Data do cadastro")]
        public DateTime dt_inc { get; set; }

        [DataType(DataType.Date)]
        [Column("fundacao")]
        [Display(Name = "Data da fundação")]
        public DateTime fundacao { get; set; }

        [Column("facebook")]
        [Display(Name = "Facebook")]
        public string facebook { get; set; }

        [Column("instagram")]
        [Display(Name = "Instagram")]
        public string instagram { get; set; }

        [Column("www")]
        [Display(Name = "WWW")]
        public string www { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public Cliente()
        {
            
        }
    }
}