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
    public class CidadeController : AppController
    {
        // GET: Pais
        [HttpGet]
        public ActionResult Cadastrar(int id = 0)
        {
            var model = new Cidade();
            if (id > 0)
            {
                model = DAL.GetObjetoById<Cidade>(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastrar(Cidade model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.nome = model.nome.ToUpper();
            try
            {
                var existe = DAL.GetObjeto<Cidade>(string.Format("nome='{1}'", model.nome)) ?? new Cidade();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Cidade já existe!", "Alerta");
                    return View();
                }
                long id = DAL.Gravar(model);

                if (model.id > 0 && id == 0)
                {
                    this.AddNotification("Cidade alterada!", "Sucesso");
                }
                else
                {
                    this.AddNotification("Cidade cadastrada!", "Sucesso");
                }
            }
            catch (Exception e)
            {
                this.AddNotification("Erro:" + e.Message, "Erro");
            }
            return View();
        }

        // GET: Regiao
        public ActionResult Consultar()
        {
            return View(DAL.ListarObjetos<Pais>());
        }

        [HttpPost]
        public ActionResult Deletar(int id = 0)
        {
            var model = new Cidade();
            if (id > 0)
            {
                model = DAL.GetObjeto<Cidade>(string.Format("id={1}", id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

        [HttpGet]
        [OutputCache(Duration = 30)]
        public JsonResult GetCidades(string term)
        {
            List<Lista> list = DAL.ListarObjetos<Cidade>(term.Equals("") ? "" : string.Format("nome like '%{0}%'",term ) , "nome").Select(i => new Lista { id = i.id, text = i.nome.ToUpper() }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


    }
}