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
    public class SemanaColecaoController : AppController
    {
        [HttpGet]
        public ActionResult Cadastrar(int id = 0)
        {
            var model = new ColecaoSemana();
            if (id > 0)
            {
                model = DAL.GetObjetoById<ColecaoSemana>(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastrar(ColecaoSemana model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.id_usuario = Convert.ToInt64(UsuarioLogado.IdUsuario);
            model.id_conta = Convert.ToInt64(UsuarioLogado.IdConta);
            try
            {
                var existe = DAL.GetObjeto<ColecaoSemana>(string.Format("id_conta={0} and id_colecao='{1}'", UsuarioLogado.IdConta, model.id_colecao)) ?? new ColecaoSemana();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Semanas da Coleção já existe!", "Alerta");
                    return View();
                }
                long id = DAL.Gravar(model);

                if (model.id > 0 && id == 0)
                {
                    this.AddNotification("Semanas da Coleção alterada!", "Sucesso");
                }
                else
                {
                    this.AddNotification("Semanas da Coleção cadastrada!", "Sucesso");
                }
            }
            catch (Exception e)
            {
                this.AddNotification("Erro:" + e.Message, "Erro");
            }
            return View();
        }

        public ActionResult Consultar()
        {
            return View(DAL.ListarObjetos<ColecaoSemana>(string.Format("id_conta={0}", UsuarioLogado.IdConta)));
        }

        [HttpPost]
        public ActionResult Deletar(int id = 0)
        {
            var model = new ColecaoSemana();
            if (id > 0)
            {
                model = DAL.GetObjeto<ColecaoSemana>(string.Format("id_conta={0} and id={1}", UsuarioLogado.IdConta, id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

        [HttpGet]
        [OutputCache(Duration = 30)]
        public JsonResult GetSemanasColecao(string term)
        {
            List<Lista> list = DAL.ListarObjetos<ColecaoSemana>((term ?? "").Equals("") ? 
                            string.Format("id_conta={0}", UsuarioLogado.IdConta) : 
                            string.Format("id_conta={0} ", UsuarioLogado.IdConta)
                            , "id").Select(i => new Lista { id = i.id, text = i.nm_colecao.ToUpper() }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}