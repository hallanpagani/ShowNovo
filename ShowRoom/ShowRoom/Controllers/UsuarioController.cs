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
    public class UsuarioController : AppController
    {
        public virtual ActionResult Consultar()
        {
            var model = new Usuario();
            var lista = DAL.ListarObjetos<Usuario>(string.Format("id_conta = {0}", UsuarioLogado.IdConta));
            return View("~/views/configuracao/usuario/consultar.cshtml", lista);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Cadastrar(int id = 0)
        {
            if (Settings.hasPermission(Settings.MENU_CONFIGURACAO_USUARIO, UsuarioLogado))
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

        [HttpPost]
        public ActionResult Cadastrar(Usuario viewModel)
        {
            if (viewModel.NomeDoUsuario == null)
            {
                this.AddNotification("Nome do usuario é obrigatório !", "Alerta");
                return View("~/views/configuracao/conta/Cadastrar.cshtml", viewModel);
            }

            ViewBag.Notification = "";

            if (viewModel.Id == 0)
            {
                Usuario u = new Usuario();
                Filtros f = new Filtros(u);
                f.Add(() => viewModel.NomeDoUsuario, viewModel.NomeDoUsuario, FiltroExpressao.Igual);
                u = DAL.GetObjeto<Usuario>(f);
                if (u != null)
                {
                    this.AddNotification("Usuário já cadastrado !", "Erro");
                    return View("~/views/configuracao/usuario/Cadastrar.cshtml", viewModel);
                }
            }

            try
            {
                if (viewModel.ativar_usuario)
                {
                    viewModel.is_ativo = 1;
                }
                else
                {
                    viewModel.is_ativo = 0;
                }
                viewModel.IdPerfil = DAL.GetObjeto<Perfil>(string.Format("tp_perfil = '{0}'", viewModel.descricaoPerfil)).cd_perfil;

                this.AddNotification("Usuário salvo !", "Sucesso");
                DAL.Gravar(viewModel);
            }
            catch (Exception ex)
            {
                AddErrors(ex);
                return View("~/views/configuracao/usuario/Cadastrar.cshtml", viewModel);
            }

            var model = new Usuario();
            return View("~/views/configuracao/usuario/Cadastrar.cshtml", model);
        }

        public virtual ActionResult Ativar(int id = 0)
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
            return View("~/views/configuracao/usuario/consultar.cshtml", lista);
        }

        public virtual ActionResult Desativar(int id = 0)
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
            return View("~/views/configuracao/usuario/consultar.cshtml", lista);
        }

        [HttpPost]
        public ActionResult Excluir(int id = 0)
        {
            var model = new Usuario();
            if (id > 0)
            {
                model = DAL.GetObjeto<Usuario>(string.Format("id={0}", id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

        private void AddErrors(Exception exc)
        {
            ModelState.AddModelError("", exc);
        }
    }
}