using Conciliacao.Controllers.Generico;
using ShowRoom.App_Helpers.Componentes;
using ShowRoom.Models;
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
    public class AgendamentoController : AppController
    {
        // GET: Regiao
        [HttpGet]
        public ActionResult Cadastrar(int id = 0)
        {
            var model = new Agendamento();
            if (id > 0)
            {
                model = DAL.GetObjetoById<Agendamento>(id);
            }
            return View(model);
        }

        // GET: Agenda
        public ActionResult AgendaVisualizar(VisualizarAgendaViewModel obj)
        {
            return View(obj);
        }

        [HttpPost]
        public ActionResult Cadastrar(Agendamento model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           /* model.regiao = model.regiao.ToUpper(); 
            model.nome = model.nome.ToUpper(); */
           // model.id_usuario = Convert.ToInt64(UsuarioLogado.IdUsuario);
           // model.id_conta = Convert.ToInt64(UsuarioLogado.IdConta);
            try
            {
                var existe = DAL.GetObjeto<Agendamento>(string.Format("id={0}", model.id)) ?? new Agendamento();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Agendamento já existe!", "Alerta");
                    return View();
                }
                long id = DAL.Gravar(model);

                if (model.id > 0 && id == 0)
                {
                    this.AddNotification("Agendamento alterada!", "Sucesso");
                }
                else
                {
                    this.AddNotification("Agendamento cadastrado!", "Sucesso");
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
            return View(DAL.ListarObjetos<Agendamento>());
        }

        [HttpPost]
        public ActionResult Deletar(int id = 0)
        {
            var model = new Agendamento();
            if (id > 0)
            {
                model = DAL.GetObjeto<Agendamento>(string.Format("id={0}", id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

        [HttpGet]
        [OutputCache(Duration = 30)]
        public JsonResult GetAgendamentos(string term)
        {
            List<Lista> list = DAL.ListarObjetos<Agendamento>((term ?? "").Equals("") ? "" : string.Format("id like '%{0}%'", term), "id").Select(i => new Lista { id = i.id, text = i.id.ToString().ToUpper() }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}