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
        [MaxLength(2, ErrorMessage = "Campo 'UF' pode ter no máximo 2 caracteres!")]
        public string uf { get; set; }

        [Column("nome")]
        [Display(Name = "Nome da Cidade")]
        [Required(ErrorMessage = "O nome da região é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Nome da Cidade' pode ter no máximo 100 caracteres!")]
        public string nome { get; set; }

        [Column("pais")]
        [Display(Name = "Nome da Micro região")]
        [MaxLength(6, ErrorMessage = "Campo 'País' pode ter no máximo 15 caracteres!")]
        public int pais { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_pais p where r.id = a.pais) as nm_pais")]
        [Display(Name = "Nome do País")]
        public string nm_pais { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public Estado()
        {

        }

    }
}