﻿using ShowRoomModelo.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_pais")]
    public class Pais
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Column("pais")]
        [Display(Name = "Pais")]
        [Required(ErrorMessage = "País é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(6, ErrorMessage = "Campo 'País' pode ter no máximo 6 números!")]
        public int pais { get; set; }

        [Column("nome")]
        [Display(Name = "Nome do país")]
        [Required(ErrorMessage = "O nome do país é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Campo 'Nome do país' pode ter no máximo 100 caracteres!")]
        public string nome { get; set; }

        [Column("codigobacen")]
        [Display(Name = "Código bacen")]
        [Required(ErrorMessage = "O nome código bacen é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Código bacen' pode ter no máximo 100 caracteres!")]
        public string codigo_bacen { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public Pais()
        {
            
        }

    }
}
