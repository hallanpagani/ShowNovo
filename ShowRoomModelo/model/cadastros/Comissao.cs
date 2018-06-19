
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_comissao_vendedor")]
    public class Comissao
    {
        [Key]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Column("id_vendedor")]
        public long id_vendedor { get; set; }

        [Column("id_colecao")]
        public long id_colecao { get; set; }

        [Column("id_marca")]
        public long id_marca { get; set; }

        [Column("pr_comissao_interna")]
        public float pr_comissao_interna { get; set; }

        [Column("pr_comissao_externa")]
        public float pr_comissao_externa { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public string nm_vendedor { get; set; }
        public string nm_colecao { get; set; }
        public string nm_marca { get; set; }

        public Comissao()
        {
           // datainicio = DateTime.Now;
        }

    }
}