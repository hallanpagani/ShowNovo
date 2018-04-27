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
        [Display(Name = "Nome do cliente")]
        public string nome { get; set; }

        [Required]
        [Column("razao")]
        [Display(Name = "Razão do cliente")]
        public string razao { get; set; }

        [Required]
        [Column("fantasia")]
        [Display(Name = "fantasia")]
        public string fantasia { get; set; }

        [Required]
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

        [Column("bairro")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Column("id_cidade")]
        [Display(Name = "Cidade")]
        public long cidade { get; set; }

        [Required]
        [Column("cnpj")]
        [Display(Name = "Cnpj")]
        public string cnpj { get; set; }

        [Column("obs")]
        [Display(Name = "obs")]
        public string obs { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public Prospect()
        {
            
        }
    }
}