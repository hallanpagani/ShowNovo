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
    public class VendedorController : AppController
    {
        [HttpGet]
        public ActionResult Cadastrar(int id = 0)
        {
            var model = new Vendedor();
            if (id > 0)
            {
                model = DAL.GetObjetoById<Vendedor>(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastrar(Vendedor model)
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
                var existe = DAL.GetObjeto<Vendedor>(string.Format("id_conta={0} and razao='{1}'", UsuarioLogado.IdConta, model.razao)) ?? new Vendedor();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Vendedor já existe!", "Alerta");
                    return View();
                }
                long id = DAL.Gravar(model);

                if (model.id > 0 && id == 0)
                {
                    this.AddNotification("Vendedor alterado!", "Sucesso");
                }
                else
                {
                    this.AddNotification("Vendedor cadastrado!", "Sucesso");
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
            return View(DAL.ListarObjetos<Vendedor>(string.Format("id_conta={0}", UsuarioLogado.IdConta)));
        }

        [HttpPost]
        public ActionResult Deletar(int id = 0)
        {
            var model = new Vendedor();
            if (id > 0)
            {
                model = DAL.GetObjeto<Vendedor>(string.Format("id_conta={0} and id={1}", UsuarioLogado.IdConta, id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

        [HttpGet]
        [OutputCache(Duration = 30)]
        public JsonResult GetVendedor(string term)
        {
            List<Lista> list = DAL.ListarObjetos<Vendedor>(string.Format("id_conta={0}", UsuarioLogado.IdConta), "id").Select(i => new Lista { id = i.id, text = i.fantasia.ToUpper() }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}