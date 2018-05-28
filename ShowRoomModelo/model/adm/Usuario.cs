﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShowRoomModelo.classes;
using ShowRoomModelo.model.generico;

namespace ShowRoomModelo.model.adm
{
    [Table("tb_sistema_usuario")]
    public class Usuario: BaseID
    {
        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("id_perfil")]
        public long IdPerfil { get; set; }

        public string descricaoPerfil { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail de acesso")]
        [Column("ds_login")]
        public string Email { get; set; }

        [Required]
        [Column("nm_usuario")]
        [Display(Name = "Nome do usuário")]
        public string NomeDoUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha de acesso")]
        [Column("ds_senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirmação de senha")]
        public string PasswordConfirmacao { get; set; }

        [Required]
        [Column("is_ativo")]
        [Display(Name = "Ativar ?")]
        public int is_ativo { get; set; }

        [Required]
        [Display(Name = "Ativar usuário ?")]
        public bool ativar_usuario { get; set; }

    }
}