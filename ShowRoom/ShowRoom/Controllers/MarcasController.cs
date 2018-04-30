using Conciliacao.Controllers.Generico;
using ShowRoom.App_Helpers.Componentes;
using ShowRoomModelo.model.cadastros;
using ShowRoomModelo.model.generico;
using ShowRoomPersistencia.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShowRoom.Controllers
{
    [Authorize]
    public class MarcasController : AppController
    {
        // GET: Marcas
        [HttpGet]
        public ActionResult Cadastrar(int id = 0)
        {
            var model = new Marca();
            if (id > 0)
            {
                model = DAL.GetObjetoById<Marca>(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastrar(Marca model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.marca = model.marca.ToUpper();
            model.nome = model.nome.ToUpper();
            model.id_usuario = Convert.ToInt64(UsuarioLogado.IdUsuario);
            model.id_conta = Convert.ToInt64(UsuarioLogado.IdConta);
            try
            {
                var existe = DAL.GetObjeto<Marca>(string.Format("id_conta={0} and nome='{1}'", UsuarioLogado.IdConta, model.nome)) ?? new Marca();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Marca já existe!", "Alerta");
                    return View();
                }
                long id = DAL.Gravar(model);

                if (model.id > 0 && id == 0)
                {
                    this.AddNotification("Marca alterada!", "Sucesso");
                }
                else
                {
                    this.AddNotification("Marca cadastrada!", "Sucesso");
                }
            }
            catch (Exception e)
            {
                this.AddNotification("Erro:" + e.Message, "Erro");
            }
            return View();
        }

        // GET: Marcas
        public ActionResult Consultar()
        {
            return View(DAL.ListarObjetos<Marca>(string.Format("id_conta={0}", UsuarioLogado.IdConta)));
        }

        [HttpPost]
        public ActionResult Deletar(int id = 0)
        {
            var model = new Marca();
            if (id > 0)
            {
                model = DAL.GetObjeto<Marca>(string.Format("id_conta={0} and id={1}", UsuarioLogado.IdConta, id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }


        [HttpGet]
        [OutputCache(Duration = 30)]
        public JsonResult GetMarcas(string term)
        {
            List<Lista> list = DAL.ListarObjetos<Marca>("", "id").Select(i => new Lista { id = i.id, text = i.nome.ToUpper() }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}