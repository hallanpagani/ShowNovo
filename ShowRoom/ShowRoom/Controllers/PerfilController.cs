using System;
using System.Web.Mvc;
using ShowRoomModelo.model.adm;
using System.Text;
using ShowRoomPersistencia.banco;
using ShowRoom;
using Conciliacao.Controllers.Generico;
using ShowRoom.App_Helpers.Componentes;
using System.Collections.Generic;
using ShowRoomModelo.model.generico;
using System.Linq;

namespace BaseWeb.Controllers.Acesso.ContaAcesso
{
    public class PerfilController : AppController
    {
        public virtual ActionResult Consultar()
        {
            var model = new Perfil();
            var lista = DAL.ListarObjetos<Perfil>(string.Format("id_conta = {0}", UsuarioLogado.IdConta));
            return View("~/views/configuracao/perfil/consultar.cshtml", lista);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Cadastrar(int id = 0)
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

        [HttpPost]
        public ActionResult Cadastrar(Perfil viewModel, FormCollection frm)
        {
            if (viewModel.tp_perfil == null)
            {
                this.AddNotification("Perfil é obrigatório !", "Alerta");
                return View("~/views/configuracao/perfil/Cadastrar.cshtml", viewModel);
            }
            else if (viewModel.tp_perfil.ToLower().Equals("administrador"))
            {
                this.AddNotification("Não é possível modificar este perfil !", "Alerta");
                return View("~/views/configuracao/perfil/Cadastrar.cshtml", viewModel);
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                Dictionary<string, bool> acessoList = viewModel.getPermissoes();
                foreach (KeyValuePair<string, bool> pair in acessoList)
                {
                    if (pair.Value)
                    {
                        builder.Append(pair.Key);
                        builder.Append(";");
                    }
                }

                // Recebe os menus habilitados ...
                viewModel.nm_menu = builder.ToString();


                ViewBag.Notification = "";

                if (viewModel.Id == 0)
                {
                    Perfil u = new Perfil();
                    Filtros f = new Filtros(u);
                    f.Add(() => viewModel.tp_perfil, viewModel.tp_perfil, FiltroExpressao.Igual);
                    u = DAL.GetObjeto<Perfil>(f);
                    if (u != null)
                    {
                        this.AddNotification("Perfil já cadastrada !", "Erro");
                        return View("~/views/configuracao/perfil/Cadastrar.cshtml", viewModel);
                    }
                }

                try
                {
                    viewModel.id_conta = Convert.ToInt64(UsuarioLogado.IdConta);
                    viewModel.DhInc = DateTime.Now;
                    this.AddNotification("Perfil salvo !", "Sucesso");
                    DAL.Gravar(viewModel);
                }
                catch (Exception ex)
                {
                    AddErrors(ex);
                    return View("~/views/configuracao/perfil/Cadastrar.cshtml", viewModel);
                }

                var model = new Perfil();
                return View("~/views/configuracao/perfil/Cadastrar.cshtml", model);
            }
        }

        [HttpPost]
        public ActionResult Excluir(int id = 0)
        {
            var model = new Perfil();
            if (id > 0)
            {
                model = DAL.GetObjeto<Perfil>(string.Format("id={0}", id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

        [HttpGet]
        [OutputCache(Duration = 30)]
        public JsonResult GetPerfil(string term)
        {
            List<Lista> list = DAL.ListarObjetos<Perfil>((term ?? "").Equals("") ? "" : string.Format("tp_perfil like '%{0}%'", term), "tp_perfil").Select(i => new Lista { id = i.Id, text = i.tp_perfil.ToUpper() }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        private void AddErrors(Exception exc)
        {
            ModelState.AddModelError("", exc);
        }
    }
}