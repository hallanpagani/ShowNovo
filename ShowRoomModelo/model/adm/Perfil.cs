using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShowRoomModelo.classes;
using System.Collections.Generic;
using System.Reflection;

namespace ShowRoomModelo.model.adm
{
    [Table("tb_sistema_perfil")]
    public class Perfil
    {
        [Key]
        [AutoInc]
        [Column("id")]
        public long Id { get; set; }

        [Column("id_conta")]
        public long id_conta { get; set; }

        [Required]
        [Column("dh_inc")]
        public DateTime DhInc { get; set; }

        [Display(Name = "Perfil (Ex: Administrador. Convidado. Parcial. Gestor ...")]
        [Column("tp_perfil")]
        public string tp_perfil { get; set; }

        [Column("nm_menu")]
        public string nm_menu { get; set; }

        [Column("cd_perfil")]
        public long cd_perfil { get; set; }

        [Display(Name = "Agenda")]
        public bool agenda { get; set; }

        [Display(Name = "Clientes")]
        public bool clientes { get; set; }

        [Display(Name = "Vendedores")]
        public bool vendedores { get; set; }

        [Display(Name = "Showroom")]
        public bool showroom { get; set; }

        [Display(Name = "Marcas")]
        public bool marcas { get; set; }

        [Display(Name = "Grupo de Marcas")]
        public bool grupoMarcas { get; set; }

        [Display(Name = "Comissao")]
        public bool comissao { get; set; }

        [Display(Name = "Coleção")]
        public bool colecao { get; set; }

        [Display(Name = "Geração da Semana")]
        public bool geracao { get; set; }

        [Display(Name = "Cidade")]
        public bool cidade { get; set; }

        [Display(Name = "Mesorregião")]
        public bool mesorregião { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }

        [Display(Name = "País")]
        public bool pais { get; set; }

        [Display(Name = "Conta")]
        public bool conta { get; set; }

        [Display(Name = "Perfil")]
        public bool perfil { get; set; }

        [Display(Name = "Usuário")]
        public bool usuario { get; set; }

        public Dictionary<string, bool> getPermissoes()
        {
            Dictionary<string, bool> acessoList = new Dictionary<string, bool>();
            acessoList.Add("agenda", agenda);
            acessoList.Add("clientes", clientes);
            acessoList.Add("vendedores", vendedores);
            acessoList.Add("showroom", showroom);
            acessoList.Add("marcas", marcas);
            acessoList.Add("grupoMarcas", grupoMarcas);
            acessoList.Add("comissao", comissao);
            acessoList.Add("colecao", colecao);
            acessoList.Add("geracao", geracao);
            acessoList.Add("cidade", cidade);
            acessoList.Add("mesorregião", mesorregião);
            acessoList.Add("estado", estado);
            acessoList.Add("pais", pais);
            acessoList.Add("conta", conta);
            acessoList.Add("perfil", perfil);
            acessoList.Add("usuario", usuario);

            return acessoList;
        }

        /**
         *  Seta as permissões para edição
         */
        public Perfil setPermissoes(string opcoes, bool value)
        {
            Perfil p = new Perfil();

            string[] menu = opcoes.Split(';');
            foreach (string m in menu)
            {
                PropertyInfo propertyInfo = p.GetType().GetProperty(m);
                if (propertyInfo != null)
                    propertyInfo.SetValue(p, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            }

            return p;
        }

        public Perfil()
        {
            DhInc = DateTime.Now;
        }
    }
}
