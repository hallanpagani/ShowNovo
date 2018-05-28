using Conciliacao.Controllers.Generico;
using ShowRoom.App_Helpers.Componentes;
using ShowRoomModelo.model.cadastros;
using ShowRoomModelo.model.generico;
using ShowRoomPersistencia.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShowRoom.Controllers
{
    [Authorize]
    public class MesorregiaoController : AppController
    {
        // GET: Regiao
        [HttpGet]
        public ActionResult Cadastrar(int id = 0)
        {
            if (Settings.hasPermission(Settings.MENU_CADASTRO_MESOREGIAO, UsuarioLogado.Perfil))
            {
                var model = new Mesorregiao();
                if (id > 0)
                {
                    model = DAL.GetObjetoById<Mesorregiao>(id);
                }
                return View(model);
            }
            else
            {
                return View("~/views/Shared/error.cshtml");
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(Mesorregiao model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.nome = model.nome.ToUpper();
           // model.id_usuario = Convert.ToInt64(UsuarioLogado.IdUsuario);
           // model.id_conta = Convert.ToInt64(UsuarioLogado.IdConta);
            try
            {
                var existe = DAL.GetObjeto<Mesorregiao>(string.Format("nome='{0}'", model.nome)) ?? new Mesorregiao();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Mesorregião já existe!", "Alerta");
                    return View();
                }
                long id = DAL.Gravar(model);

                if (model.id > 0 && id == 0)
                {
                    this.AddNotification("Mesorregião alterada!", "Sucesso");
                }
                else
                {
                    this.AddNotification("Mesorregião cadastrada!", "Sucesso");
                }
            }
            catch (Exception e)
            {
                this.AddNotification("Erro:" + e.Message, "Erro");
            }
            return View(model);
        }

        // GET: Regiao
        public ActionResult Consultar()
        {
            return View(DAL.ListarObjetos<Mesorregiao>());
        }

        [HttpPost]
        public ActionResult Deletar(int id = 0)
        {
            var model = new Mesorregiao();
            if (id > 0)
            {
                model = DAL.GetObjeto<Mesorregiao>(string.Format("id={0}", id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

        [HttpGet]
        [OutputCache(Duration = 30)]
        public JsonResult GetMesorregiao(string term)
        {
            List<Lista> list = DAL.ListarObjetos<Mesorregiao>((term ?? "").Equals("") ? "" : string.Format("nome like '%{0}%'", term), "id").Select(i => new Lista { id = i.id, text = i.nome.ToUpper() }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}