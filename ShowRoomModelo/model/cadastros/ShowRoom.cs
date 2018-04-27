using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShowRoomModelo.classes;
using ShowRoomModelo.model.generico;
using System.Collections.Generic;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_showroom")]
    public class ShowRoom
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public int id { get; set; }

        [Required]
        [Column("showroom")]
        public string showroom { get; set; }

        [Required]
        [Column("razao")]
        [Display(Name = "Razão do cliente")]
        public string razao { get; set; }

        [Required]
        [Column("fantasia")]
        [Display(Name = "Fantasia")]
        public string fantasia { get; set; }

        [Required]
        [Column("email")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [Column("fone1")]
        [Display(Name = "Fone 1")]
        public string fone1 { get; set; }

        [Column("fone2")]
        [Display(Name = "Fone 2")]
        public string fone2 { get; set; }

        [Column("www")]
        [Display(Name = "www")]
        public string www { get; set; }

        [Column("contato")]
        [Display(Name = "contato")]
        public string contato { get; set; }

        [Required]
        [Column("cnpj")]
        [Display(Name = "Cnpj")]
        public string cnpj { get; set; }

        [Column("endereco")]
        [Display(Name = "endereco")]
        public string endereco { get; set; }

        [Column("numero")]
        [Display(Name = "numero")]
        public string numero { get; set; }

        [Column("id_cidade")]
        [Display(Name = "Cidade")]
        public long cidade { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public ShowRoom()
        {
            
        }
    }
}