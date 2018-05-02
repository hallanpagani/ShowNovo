using ShowRoomModelo.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_estado")]
    public class Estado
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Required]
        [Column("uf")]
        [Display(Name = "UF")]
        [MaxLength(2, ErrorMessage = "Campo 'UF' pode ter no máximo 2 caracteres!")]
        public string uf { get; set; }

        [Column("nome")]
        [Display(Name = "Nome do estado")]
        [Required(ErrorMessage = "O nome do estado é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Nome do Estado' deve ter no máximo 100 caracteres!")]
        public string nome { get; set; }

        [Column("pais")]
        [Display(Name = "Nome do País")]
        [MaxLength(6, ErrorMessage = "Campo 'País' deve ter no máximo 15 caracteres!")]
        public long pais { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_pais p where p.id = a.pais) as nm_pais")]
        [Display(Name = "Nome do País")]
        public string nm_pais { get; set; }

        public Estado()
        {

        }

    }
}