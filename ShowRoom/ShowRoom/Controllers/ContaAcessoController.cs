using System;
using System.Web.Mvc;
using ShowRoomModelo.model.adm;
using System.Text;
using ShowRoomPersistencia.banco;
using ShowRoom;
using Conciliacao.Controllers.Generico;
using ShowRoom.App_Helpers.Componentes;

namespace BaseWeb.Controllers.Acesso.ContaAcesso
{
    public class ContaAcessoController : AppController
    {
        public virtual ActionResult DadosConta()
        {
            if (Settings.hasPermission(Settings.MENU_CONFIGURACAO_CONTA, UsuarioLogado.Perfil))
            {
                var model = new Conta();
                var lista = DAL.GetObjetoById<Conta>(Convert.ToInt64(UsuarioLogado.IdConta));
                lista.usuarios = DAL.ListarObjetos<Usuario>(string.Format("id_conta = {0}", lista.Id));
                lista.perfil = DAL.ListarObjetos<Perfil>(string.Format("id_conta = {0}", lista.Id));

                return View("~/views/configuracao/conta/dados.cshtml", lista);
            }
            else
            {
                return View("~/views/Shared/error.cshtml");
            }
        }


        public virtual ActionResult Consultar()
        {
            var model = new Conta();
            var lista = DAL.ListarObjetos<Conta>(string.Format("id = {0}", UsuarioLogado.IdConta));
            return View("~/views/configuracao/conta/consultar.cshtml", lista);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Cadastrar(int id = 0)
        {
            if (Settings.hasPermission(Settings.MENU_CONFIGURACAO_CONTA, UsuarioLogado.Perfil))
            {
                var model = new Conta();
                if (id > 0)
                {
                    model = DAL.GetObjetoById<Conta>(id);
                }
                return View("~/views/configuracao/conta/Cadastrar.cshtml", model);
            }
            else
            {
                return View("~/views/Shared/error.cshtml");
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(Conta viewModel)
        {
            if (viewModel.NmConta == null)
            {
                this.AddNotification("Nome da conta é obrigatório !", "Alerta");
                return View("~/views/configuracao/conta/Cadastrar.cshtml", viewModel);
            }

            ViewBag.Notification = "";

            if (viewModel.Id == 0)
            {
                Conta u = new Conta();
                Filtros f = new Filtros(u);
                f.Add(() => viewModel.NmConta, viewModel.NmConta, FiltroExpressao.Igual);
                u = DAL.GetObjeto<Conta>(f);
                if (u != null)
                {
                    this.AddNotification("Conta já cadastrada !", "Erro");
                    return View("~/views/configuracao/conta/Cadastrar.cshtml", viewModel);
                }
            }

            try
            {
                viewModel.DhInc = DateTime.Now;
                this.AddNotification("Conta salva !", "Sucesso");
                long lnContaId =  DAL.Gravar(viewModel);

                // Cria o usuário ADMINISTRADOR para a CONTA.
                Usuario userConta = new Usuario();
                userConta.Id = 0;
                userConta.IdConta = lnContaId;
                userConta.IdPerfil = 999;
                userConta.is_ativo = 1;
                userConta.Email = "administrador@" + viewModel.NmConta.ToLower().Replace(" ", "") + ".com.br";
                userConta.NomeDoUsuario = "Administrador";
                userConta.Password = "$administrador102030$";

                DAL.Gravar(userConta);

            }
            catch (Exception ex)
            {
                AddErrors(ex);
                return View("~/views/configuracao/conta/Cadastrar.cshtml", viewModel);
            }

            var model = new Conta();
            return View("~/views/configuracao/conta/Cadastrar.cshtml", model);
        }

        public virtual ActionResult Ativar(int id = 0)
        {
            var model = new Conta();
            if (id > 0)
            {
                model = DAL.GetObjetoById<Conta>(id);
                model.is_ativo = "Sim";

                try
                {
                    DAL.Gravar(model);
                    this.AddNotification("Conta ativada !", "Sucesso");
                }
                catch (Exception ex)
                {
                    AddErrors(ex);
                }
            }

            var lista = DAL.ListarObjetos<Conta>();
            return View("~/views/configuracao/conta/consultar.cshtml", lista);
        }

        public virtual ActionResult Desativar(int id = 0)
        {
            var model = new Conta();
            if (id > 0)
            {
                model = DAL.GetObjetoById<Conta>(id);
                model.is_ativo = "Não";

                try
                {
                    DAL.Gravar(model);
                    this.AddNotification("Conta desativada !", "Sucesso");
                }
                catch (Exception ex)
                {
                    AddErrors(ex);
                }
            }

            var lista = DAL.ListarObjetos<Conta>();
            return View("~/views/configuracao/conta/consultar.cshtml", lista);
        }

        [HttpPost]
        public ActionResult Excluir(int id = 0)
        {
            var model = new Conta();
            if (id > 0)
            {
                model = DAL.GetObjeto<Conta>(string.Format("id={0}", id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

        private void AddErrors(Exception exc)
        {
            ModelState.AddModelError("", exc);
        }

        /**================================================================================
         * 
         * MIGUE DO USUARIO
         * 
         * ===============================================================================*/

        public virtual ActionResult UsuarioAtivar(int id = 0)
        {
            var model = new Usuario();
            if (id > 0)
            {
                model = DAL.GetObjetoById<Usuario>(id);
                model.is_ativo = 1;

                try
                {
                    DAL.Gravar(model);
                    this.AddNotification("Usuário ativado !", "Sucesso");
                }
                catch (Exception ex)
                {
                    AddErrors(ex);
                }
            }

            var lista = DAL.ListarObjetos<Usuario>();
            return DadosConta();
        }

        public virtual ActionResult UsuarioDesativar(int id = 0)
        {
            var model = new Usuario();
            if (id > 0)
            {
                model = DAL.GetObjetoById<Usuario>(id);
                model.is_ativo = 0;

                try
                {
                    DAL.Gravar(model);
                    this.AddNotification("Usuário desativado !", "Sucesso");
                }
                catch (Exception ex)
                {
                    AddErrors(ex);
                }
            }

            var lista = DAL.ListarObjetos<Usuario>();
            return DadosConta();
        }

        public virtual ActionResult UsuarioEditar(int id = 0)
        {
            if (Settings.hasPermission(Settings.MENU_CONFIGURACAO_USUARIO, UsuarioLogado.Perfil))
            {
                var model = new Usuario();
                if (id > 0)
                {
                    model = DAL.GetObjetoById<Usuario>(id);
                }
                return View("~/views/configuracao/usuario/Cadastrar.cshtml", model);
            }
            else
            {
                return View("~/views/Shared/error.cshtml");
            }
        }

        /**================================================================================
        * 
        * MIGUE DO PERFIL
        * 
        * ===============================================================================*/

        public virtual ActionResult PerfilEditar(int id = 0)
        {
            if (Settings.hasPermission(Settings.MENU_CONFIGURACAO_PERFIL, UsuarioLogado.Perfil))
            {
                var model = new Perfil();
                if (id > 0)
                {
                    model = DAL.GetObjetoById<Perfil>(id);
                    Perfil novoPerfil = model.setPermissoes(model.nm_menu, true);
                    novoPerfil.Id = id;
                    novoPerfil.DhInc = model.DhInc;
                    novoPerfil.tp_perfil = model.tp_perfil;
                    novoPerfil.nm_menu = model.nm_menu;
                    novoPerfil.id_conta = model.id_conta;
                    return View("~/views/configuracao/perfil/Cadastrar.cshtml", novoPerfil);
                }
                return View("~/views/configuracao/perfil/Cadastrar.cshtml", model);
            }
            else
            {
                return View("~/views/Shared/error.cshtml");
            }
        }

        public ActionResult PerfilExcluir(int id = 0)
        {
            var model = new Perfil();
            if (id > 0)
            {
                model = DAL.GetObjeto<Perfil>(string.Format("id={0}", id));
                DAL.Excluir(model);
            }            
            return DadosConta(); 
        }
    }
}