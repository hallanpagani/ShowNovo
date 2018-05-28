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
    public class ClienteController : AppController
    {
        // GET: Regiao
        [HttpGet]
        public ActionResult Cadastrar(int id = 0)
        {
            if (Settings.hasPermission(Settings.MENU_CADASTRO_CLIENTES, UsuarioLogado.Perfil))
            {
                var model = new Cliente();
                if (id > 0)
                {
                    model = DAL.GetObjetoById<Cliente>(id);
                }
                return View(model);
            }
            else
            {   
                return View("~/views/Shared/error.cshtml");
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(Cliente model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            model.razao = model.razao.ToUpper();
            model.id_usuario = Convert.ToInt64(UsuarioLogado.IdUsuario);
            model.id_conta = Convert.ToInt64(UsuarioLogado.IdConta);
            try
            {
                var existe = DAL.GetObjeto<Cliente>(string.Format("id_conta={0} and razao='{1}'", UsuarioLogado.IdConta, model.razao)) ?? new Cliente();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Cliente já existe!", "Alerta");
                    return View();
                }
                long id = DAL.Gravar(model);

                if (model.id > 0 && id == 0)
                {
                    this.AddNotification("Cliente alterado!", "Sucesso");
                }
                else
                {
                    this.AddNotification("Cliente cadastrado!", "Sucesso");
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
            return View(DAL.ListarObjetos<Cliente>(string.Format("id_conta={0}", UsuarioLogado.IdConta)));
        }

        [HttpPost]
        public ActionResult Deletar(int id = 0)
        {
            var model = new Cliente();
            if (id > 0)
            {
                model = DAL.GetObjeto<Cliente>(string.Format("id_conta={0} and id={1}", UsuarioLogado.IdConta, id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

        [HttpGet]
        [OutputCache(Duration = 30)]
        public JsonResult GetCliente(string term)
        {
            List<Lista> list = DAL.ListarObjetos<Cliente>(string.Format( ((term ?? "").Equals("") ? "{0}" : "((razao like '%{0}%') or (fantasia like '%{0}%'))  and") + " id_conta={1}", (term ?? "").Equals("") ? "" : term, UsuarioLogado.IdConta), "id").Select(i => new Lista { id = i.id, text = i.razao.ToUpper() }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}