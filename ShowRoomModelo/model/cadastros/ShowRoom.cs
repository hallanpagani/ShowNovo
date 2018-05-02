using ShowRoomModelo.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_showroom")]
    public class ShowRoom
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }
        
        [Column("showroom")]
        [Display(Name = "Show Room")]
        [Required(ErrorMessage = "Campo Show Room é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(10, ErrorMessage = "Campo 'Show Room' deve ter no máximo 10 caracteres!")]
        public string showroom { get; set; }

        [Column("razao")]
        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Campo Razão Social é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Razão Social' deve ter no máximo 30 caracteres!")]
        public string razao { get; set; }
        
        [Column("fantasia")]
        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Campo Nome Fantasia é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(300, ErrorMessage = "Campo 'Nome Fantasia' deve ter no máximo 300 caracteres!")]
        public string fantasia { get; set; }
        
        [Column("email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo Email é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(200, ErrorMessage = "Campo 'Email' deve ter no máximo 200 caracteres!")]
        public string email { get; set; }

        [Column("fone1")]
        [Display(Name = "Fone 1")]
        [Required(ErrorMessage = "Campo Fone 1 é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Fone 1' deve ter no máximo 30 caracteres!")]
        public string fone1 { get; set; }

        [Column("fone2")]
        [Display(Name = "Fone 2")]
        public string fone2 { get; set; }

        [Column("www")]
        [Display(Name = "URL")]
        public string www { get; set; }

        [Column("contato")]
        [Display(Name = "Contato")]
        [Required(ErrorMessage = "Campo Contato é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Contato' deve ter no máximo 30 caracteres!")]
        public string contato { get; set; }

        [Required]
        [Column("cnpj")]
        [Display(Name = "CNPJ")]
        public string cnpj { get; set; }

        [Column("endereco")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Column("numero")]
        [Display(Name = "Número")]
        public string numero { get; set; }

        [Column("id_cidade")]
        [Display(Name = "Cidade")]
        public long cidade { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_cidade c where c.id = a.id_cidade) as nm_cidade")]
        [Display(Name = "Cidade")]
        public string nm_cidade { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public ShowRoom()
        {
            
        }
    }
}