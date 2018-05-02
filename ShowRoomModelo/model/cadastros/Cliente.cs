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
        public long id { get; set; }

        [Column("razao")]
        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Campo razão social é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Campo 'Razão Social' deve ter no máximo 100 caracteres!")]
        public string razao { get; set; }

        [Column("cnpj")]
        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Campo 'CNPJ do cliente' é obrigatório!", AllowEmptyStrings = false)]
        public string cnpj { get; set; }

        [Column("ie")]
        [Display(Name = "Inscrição Estadual")]
        public string ie { get; set; }

        [Column("contato")]
        [Display(Name = "Contato")]
        public string contato { get; set; }

       
        [Column("fone1")]
        [Display(Name = "Fone 1")]
        [Required(ErrorMessage = "Campo 'Fone 1' é obrigatório!", AllowEmptyStrings = false)]
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

        [Column("endereco")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Column("corredor")]
        [Display(Name = "Corredor")]
        public string corredor { get; set; }

        [Column("id_cidade")]
        [Display(Name = "Cidade")]
        public long cidade { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_cidade c where c.id = a.id_cidade) as nm_cidade")]
        [Display(Name = "Cidade")]
        public string nm_cidade { get; set; }

        [Column("email")]
        [Display(Name = "Email 1")]
        public string email { get; set; }

        [Column("email2")]
        [Display(Name = "Email 2")]
        public string email2 { get; set; }

        [DataType(DataType.Date)]
        [Column("fundacao")]
        [Display(Name = "Data da fundação")]
        public Nullable<DateTime> fundacao { get; set; }

        [Column("facebook")]
        [Display(Name = "Facebook")]
        public string facebook { get; set; }

        [Column("instagram")]
        [Display(Name = "Instagram")]
        public string instagram { get; set; }

        [Column("www")]
        [Display(Name = "URL")]
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