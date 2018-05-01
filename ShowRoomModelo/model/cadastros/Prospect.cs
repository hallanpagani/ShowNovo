using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShowRoomModelo.classes;
using ShowRoomModelo.model.generico;
using System.Collections.Generic;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_prospect")]
    public class Prospect
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public int id { get; set; }

        [Required]
        [Column("prospect")]
        public int prospect { get; set; }

        [Required]
        [Column("cliente")]
        [Display(Name = "Cliente")]
        public string cliente { get; set; }

        [Required]
        [Column("razao")]
        [Display(Name = "Nome do cliente")]
        public string razao { get; set; }

        [Required]
        [Column("fantasia")]
        [Display(Name = "Nome Fantasia")]
        public string fantasia { get; set; }

        [Required]
        [Column("contato")]
        [Display(Name = "Contato")]
        public string contato { get; set; }

        [Required]
        [Column("fone1")]
        [Display(Name = "Fone 1")]
        public string fone1 { get; set; }

        [Column("fone2")]
        [Display(Name = "Fone 2")]
        public string fone2 { get; set; }

        [Column("bairro")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Column("id_cidade")]
        [Display(Name = "Cidade")]
        public long cidade { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_cidade c where c.id = a.id_cidade) as nm_cidade")]
        [Display(Name = "Cidade")]
        public string nm_cidade { get; set; }

        [Column("cep")]
        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Column("endereco")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Required]
        [Column("cnpj")]
        [Display(Name = "CNPJ")]
        public string cnpj { get; set; }

        [Column("obs")]
        [Display(Name = "Observação")]
        public string obs { get; set; }

        [Column("email")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [Column("numero")]
        [Display(Name = "Número")]
        public string numero { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public Prospect()
        {
            
        }
    }
}