using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShowRoomModelo.classes;
using ShowRoomModelo.model.generico;
using System.Collections.Generic;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_vendedor")]
    public class Vendedor
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public int id { get; set; }

        [Column("razao")]
        [Display(Name = "Razão do vendedor")]
        [Required(ErrorMessage = "Nome do vendedor é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Campo 'Razão' pode ter no máximo 100 caracteres!")]
        public string razao { get; set; }

        [Column("fantasia")]
        [Display(Name = "Nome fantasia")]
        [Required(ErrorMessage = "Nome Fantasia é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Fantasia' pode ter no máximo 30 caracteres!")]
        public string fantasia { get; set; }

        [Column("cnpj")]
        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Campo CNPJ do vendedor é obrigatório!", AllowEmptyStrings = false)]
        public string cnpj { get; set; }

        [Column("inscestadual")]
        [Display(Name = "Inscr.Estadual")]
        public string ie { get; set; }

        [Column("contato")]
        [Display(Name = "Contato")]
        public string contato { get; set; }
               
        [Column("fone1")]
        [Display(Name = "Fone 1")]
        [Required(ErrorMessage = "Campo Fone 1 é obrigatório!", AllowEmptyStrings = false)]
        public string fone1 { get; set; }

        [Column("fone2")]
        [Display(Name = "Fone 2")]
        public string fone2 { get; set; }

        [Column("cep")]
        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Column("numero")]
        [Display(Name = "Número")]
        public string numero { get; set; }

        [Column("endereco")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Column("id_cidade")]
        [Display(Name = "Cidade")]
        public long cidade { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_cidade c where c.id = a.id_cidade) as nm_cidade")]
        [Display(Name = "Cidade")]
        public string nm_cidade { get; set; }

        [Column("email")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Column("www")]
        [Display(Name = "www")]
        public string www { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public Vendedor()
        {
            
        }
    }
}