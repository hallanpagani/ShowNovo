using Conciliacao.Controllers.Generico;
using ShowRoom.App_Helpers.Componentes;
using ShowRoomModelo.model.generico;
using ShowRoomPersistencia.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShowRoom.Controllers
{
    [Authorize]
    public class ShowRoomController : AppController
    {
        // GET: Regiao
        [HttpGet]
        public ActionResult Cadastrar(int id = 0)
        {
            if (Settings.hasPermission(Settings.MENU_CADASTRO_SHOWROOM, UsuarioLogado))
            {
                var model = new ShowRoomModelo.model.cadastros.ShowRoom();
                if (id > 0)
                {
                    model = DAL.GetObjetoById<ShowRoomModelo.model.cadastros.ShowRoom>(id);
                }
                return View(model);
            }
            else
            {
                return View("~/views/Shared/error.cshtml");
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(ShowRoomModelo.model.cadastros.ShowRoom model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            model.fantasia = model.fantasia.ToUpper();
            model.razao = model.razao.ToUpper();
            model.id_usuario = Convert.ToInt64(UsuarioLogado.IdUsuario);
            model.id_conta = Convert.ToInt64(UsuarioLogado.IdConta);
            try
            {
                var existe = DAL.GetObjeto<ShowRoomModelo.model.cadastros.ShowRoom>(string.Format("id_conta={0} and showroom='{1}'", UsuarioLogado.IdConta, model.showroom)) ?? new ShowRoomModelo.model.cadastros.ShowRoom();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Show Room já existe!", "Alerta");
                    return View();
                }
                long id = DAL.Gravar(model);

                if (model.id > 0 && id == 0)
                {
                    this.AddNotification("Show Room alterada!", "Sucesso");
                }
                else
                {
                    this.AddNotification("Show Room cadastrada!", "Sucesso");
                }
            }
            catch (Exception e)
            {
                this.AddNotification("Erro:" + e.Message, "Erro");
            }
            return View(model);
        }

        // GET: ShowRoom
        public ActionResult Consultar()
        {
            return View(DAL.ListarObjetos<ShowRoomModelo.model.cadastros.ShowRoom>(string.Format("id_conta={0}", UsuarioLogado.IdConta)));
        }

        [HttpPost]
        public ActionResult Deletar(int id = 0)
        {
            var model = new ShowRoomModelo.model.cadastros.ShowRoom();
            if (id > 0)
            {
                model = DAL.GetObjeto<ShowRoomModelo.model.cadastros.ShowRoom>(string.Format("id_conta={0} and id={1}", UsuarioLogado.IdConta, id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

        [HttpGet]
        [OutputCache(Duration = 30)]
        public JsonResult GetShowRoom(string term)
        {
            List<Lista> list = DAL.ListarObjetos<ShowRoomModelo.model.cadastros.ShowRoom>("", "id").Select(i => new Lista { id = i.id, text = i.fantasia.ToUpper() }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}