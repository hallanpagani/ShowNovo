using ShowRoomModelo.classes;
using ShowRoomModelo.model.generico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_marca")]
    public class Marca
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Column("nm_marca")]
        [Display(Name = "Nome da marca")]
        [Required(ErrorMessage = "O nome da marca é obrigatório!", AllowEmptyStrings = false)]
        public string nm_marca { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public Marca()
        {
            
        }

    }
}
