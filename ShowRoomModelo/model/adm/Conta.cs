using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShowRoomModelo.classes;

namespace ShowRoomModelo.model.adm
{
    [Table("tb_sistema_conta")]
    public class Conta
    {
        [Key]
        [AutoInc]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("dh_inc")]
        public DateTime DhInc { get; set; }

        [Required]
        [Column("ds_login")]
        public string DsLogin { get; set; }

        public Conta()
        {
            DhInc = DateTime.Now;
        }
    }
}
