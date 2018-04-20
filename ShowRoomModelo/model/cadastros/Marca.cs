﻿using ShowRoomModelo.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_marca")]
    public class Marca
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Column("marca")]
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "O nome da marca é obrigatório!", AllowEmptyStrings = false)]
        public string marca { get; set; }

        [Column("nome")]
        [Display(Name = "Nome da marca")]
        [Required(ErrorMessage = "O nome da marca é obrigatório!", AllowEmptyStrings = false)]
        public string nome { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public Marca()
        {
            
        }

    }
}
