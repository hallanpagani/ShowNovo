using ShowRoomModelo.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShowRoomModelo.model.cadastros
{
    [Table("tb_cadastro_cidade")]
    public class Cidade
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long id { get; set; }

        [Required]
        [Column("id_mesorregiao")]
        [Range(1, long.MaxValue, ErrorMessage = "Campo 'Mesorregião' deve ser preenchido!")]
        public long id_mesorregiao { get; set; }

        [OnlySelect]
        [Column("(select concat(p.nome,' - ',p.uf) from tb_cadastro_mesorregiao p where p.id = a.id_mesorregiao) as nm_mesorregiao")]
        [Display(Name = "Nome da Mesorregião")]
        public string nm_mesorregiao { get; set; }

      /*  [Required]
        [Column("id_regiao")]
        public long id_regiao { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_regiao p where p.id = a.id_regiao) as nm_regiao")]
        [Display(Name = "Nome da Região")]
        public string nm_regiao { get; set; }

        [Required]
        [Column("id_subregiao")]
        public long id_subregiao { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_subregiao p where p.id = a.id_subregiao) as nm_subregiao")]
        [Display(Name = "Nome da SubRegião")]
        public string nm_subregiao { get; set; }

        [Required]
        [Column("id_microregiao")]
        public long id_microregiao { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_microregiao p where p.id = a.id_microregiao) as nm_microregiao")]
        [Display(Name = "Nome da micro região, por exemplo, região Sul do Brasil, sub região Sul de Santa Catarina, MICROREGIÃO AMREC")]
        public string nm_microregiao { get; set; } */

        [Required]
        [Column("id_uf")]
        [Range(1, long.MaxValue, ErrorMessage = "Campo 'Estado' deve ser preenchido!")]
        public long id_uf { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_estado p where p.id = a.id_uf) as nm_estado")]
        [Display(Name = "Nome do Estado")]
        public string nm_estado { get; set; }

       /* [Column("cidade")]
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Cidade é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(6, ErrorMessage = "Campo 'Cidade' deve ter no máximo 6 caracteres!")]
        public int cidade { get; set; }*/

        [Column("nome")]
        [Display(Name = "Nome da Cidade")]
        [Required(ErrorMessage = "O nome da cidade é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Nome da Cidade' deve ter no máximo 100 caracteres!")]
        public string nome { get; set; }

        [Column("ipc")]
        [Display(Name = "Índice de Preço ao Consumidor")]
        [Range(0, 99999999999, ErrorMessage = "Campo 'IPC - Índice de preço ao consumidor' deve ter no máximo 11 caracteres!")]
        public decimal ipc { get; set; }

        [Column("consumomoda")]
        [Display(Name = "Consumo moda")]
        [Range(0, 99999999999, ErrorMessage = "Campo 'Consumo' deve ter no máximo 11 caracteres!")]
        public decimal consumomoda { get; set; }

        [Column("potencialpdv")]
        [Display(Name = "Potencial do PDV")]
        [Range(0, 999999,ErrorMessage = "Campo 'Potencial PDV' deve ter no máximo 6 caracteres!")]
        public int potencialpdv { get; set; }

        public Cidade()
        {

        }

    }
}