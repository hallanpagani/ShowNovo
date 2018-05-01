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
        [Display(Name = "Nome da SubRegião")]
        public string nm_microregiao { get; set; }

        [Required]
        [Column("id_uf")]
        public long id_uf { get; set; }

        [OnlySelect]
        [Column("(select nome from tb_cadastro_estado p where p.id = a.id_uf) as nm_estado")]
        [Display(Name = "Nome do Estado")]
        public string nm_estado { get; set; }

        [Column("cidade")]
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Cidade é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(6, ErrorMessage = "Campo 'Cidade' pode ter no máximo 6 caracteres!")]
        public int cidade { get; set; }

        [Column("nome")]
        [Display(Name = "Nome da Cidade")]
        [Required(ErrorMessage = "O nome da região é obrigatório!", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Campo 'Nome da Cidade' pode ter no máximo 100 caracteres!")]
        public string nome { get; set; }

        [Column("ipc")]
        [Display(Name = "Nome da Cidade")]
        [MaxLength(30, ErrorMessage = "Campo 'Nome da Cidade' pode ter no máximo 100 caracteres!")]
        public decimal ipc { get; set; }

        [Column("consumomoda")]
        [Display(Name = "Nome da Micro região")]
        [MaxLength(15, ErrorMessage = "Campo 'Consumo moda' pode ter no máximo 15 caracteres!")]
        public decimal consumomoda { get; set; }

        [Column("potencialpdv")]
        [Display(Name = "Nome da Micro região")]
        [MaxLength(15, ErrorMessage = "Campo 'Potencial PDV' pode ter no máximo 15 caracteres!")]
        public int potencialpdv { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Column("id_usuario")]
        public long id_usuario { get; set; }

        public Cidade()
        {

        }

    }
}