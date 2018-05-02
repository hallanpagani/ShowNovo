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
    public class EstadoController : AppController
    {
        // GET: Pais
        [HttpGet]
        public ActionResult Cadastrar(int id = 0)
        {
            var model = new Estado();
            if (id > 0)
            {
                model = DAL.GetObjetoById<Estado>(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastrar(Estado model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.nome = model.nome.ToUpper();
            try
            {
                var existe = DAL.GetObjeto<Estado>(string.Format("nome='{1}'", model.nome)) ?? new Estado();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Estado já existe!", "Alerta");
                    return View();
                }
                long id = DAL.Gravar(model);

                if (model.id > 0 && id == 0)
                {
                    this.AddNotification("Estado alterada!", "Sucesso");
                }
                else
                {
                    this.AddNotification("Estado cadastrada!", "Sucesso");
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
            return View(DAL.ListarObjetos<Estado>());
        }

        [HttpPost]
        public ActionResult Deletar(int id = 0)
        {
            var model = new Estado();
            if (id > 0)
            {
                model = DAL.GetObjeto<Estado>(string.Format("id={1}", id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

        [HttpGet]
        [OutputCache(Duration = 30)]
        public JsonResult GetEstado(string term)
        {
            List<Lista> list = DAL.ListarObjetos<Estado>((term??"").Equals("") ? "" : string.Format("nome like '%{0}%'", term), "id").Select(i => new Lista { id = i.id, text = i.nome.ToUpper() }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}