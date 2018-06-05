using Conciliacao.Controllers.Generico;
using ShowRoom.App_Helpers.Componentes;
using ShowRoom.Models;
using ShowRoomModelo.model.cadastros;
using ShowRoomModelo.model.generico;
using ShowRoomPersistencia.banco;
using ShowRoomPersistencia.model;
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

            if (Settings.hasPermission(Settings.MENU_AGENDA_CADASTRAR, UsuarioLogado.Perfil))
            {
                var model = new Agendamento();
                if (id > 0)
                {
                    model = DAL.GetObjetoById<Agendamento>(id);
                }
                return View(model);
            }
            else
            {
                return View("~/views/Shared/error.cshtml");
            }
        }

        // GET: Agenda
        public ActionResult AgendaVisualizarExpandido(VisualizarAgendaViewModel obj)
        {
            var model = obj ?? new VisualizarAgendaViewModel();
            obj.expandido = true;
            return View("AgendaVisualizar", model);
        }

        public ActionResult AgendaVisualizar(VisualizarAgendaViewModel obj)
        {
            obj.expandido = false;
            return View(obj);
        }

        [HttpPost]
        public ActionResult Cadastrar(Agendamento model)
        {
            TimeSpan time;

           /* TimeSpan add22h = new TimeSpan(22, 0, 0);
            TimeSpan add7h = new TimeSpan(7, 0, 0); */

            if (!TimeSpan.TryParse(model.hr_agenda, out time))
            {
                ModelState.AddModelError("hr_agenda", "Horário inválido, preencha corretamente!");
                return View(model);

            } /* else if ((time < add7h) || (time > add22h))
            {
                ModelState.AddModelError("hr_agenda", "Horário inválido, deve estar entre as 7h e 22h!");
                return View(model);
            } */

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.id_usuario = Convert.ToInt64(UsuarioLogado.IdUsuario);
            model.id_conta = Convert.ToInt64(UsuarioLogado.IdConta);
            try
            {
                var existe = DAL.GetObjeto<Agendamento>(string.Format("id={0}", model.id)) ?? new Agendamento();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Agendamento já existe!", "Alerta");
                    return View(model);
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

            var obj = new Agendamento();
            return View(obj);
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

        public ActionResult ListarAgenda(string start, string end, int? id_marca, int? id_colecao, int? id_cliente, int? id_cidade, int? id_grupo, string tp_calendario)
        {
            //código para trazer os eventos do mês
            DateTime dataInicial = Convert.ToDateTime(start);
            DateTime dataFinal = Convert.ToDateTime(end);
            if ((dataInicial - dataFinal).TotalDays > -2)
            {
                dataFinal = dataInicial;
            }

            List<Agendamento> eventosDb = AgendamentoDAL.GetAgendaEventos(Convert.ToInt64(UsuarioLogado.IdConta), dataInicial.Ticks, dataFinal.Ticks, id_marca , id_colecao, id_cliente, id_cidade, id_grupo).
                Where(item => !(item.tp_status == 999)).ToList();

            var obj = new List<int>();
            obj.Add(eventosDb.Count());
           /* obj.Add(eventosDb.Count(item => (item.tp_status == 1)));
            obj.Add(eventosDb.Count(item => (item.tp_status == 2)));
            obj.Add(eventosDb.Count(item => (item.tp_status == 3)));
            obj.Add(eventosDb.Count(item => (item.tp_status == 4)));*/

            var eventos = from e in eventosDb ?? new List<Agendamento>()
                          select new
                          {
                              e.id,
                              dt_agenda = e.dt_agenda.ToString().Substring(0, 10).Trim(),
                              hr_agenda = e.hr_agenda.Substring(0, 5).Trim(),
                             // e.vl_servico,
                              e.nm_cliente,
                              e.nm_colecao,
                              e.nm_marca,
                              e.cliente,
                              e.colecao,
                              e.marca,
                              e.tp_status,
                              e.status_cliente,
                              atendeshowroom = e.atendeshowroom ? "SIM" : "NÃO",
                              reservasuite = e.reservasuite? "SIM" : "NÃO",
                              clientenovo = e.clientenovo ? "SIM" : "NÃO",
                              //  e.sessao_atual,
                              title = e.nm_cliente, //e.hr_agenda.Substring(0, 5).Trim() + " " +
                              start = new DateTime((e.dt_agenda?? DateTime.MinValue).Year, (e.dt_agenda ?? DateTime.MinValue).Month, (e.dt_agenda ?? DateTime.MinValue).Day, TimeSpan.Parse(e.hr_agenda).Hours, TimeSpan.Parse(e.hr_agenda).Minutes, TimeSpan.Parse(e.hr_agenda).Seconds).ToString("s"),
                              end = new DateTime((e.dt_agenda ?? DateTime.MinValue).Year, (e.dt_agenda ?? DateTime.MinValue).Month, (e.dt_agenda ?? DateTime.MinValue).Day, TimeSpan.Parse(e.hr_agenda).Hours, TimeSpan.Parse(e.hr_agenda).Minutes, TimeSpan.Parse(e.hr_agenda).Seconds).AddHours(0.5).ToString("s"),
                              color = e.cor_marca,
                              Totais = obj
                          };

            return Json(eventos.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditarAgenda(string id, string id_marca, string id_cliente, string id_colecao, string dt_agenda, string hr_agenda, string tp_status)
        {

            // if (Convert.ToInt32(tp_status) == 999) /// excluir
            // {
            //    var x = _restClient.DelAgendaPorId(Convert.ToInt32(id));
            //    this.AddNotification(x.Mensagem, NotificationType.Sucesso);
            //   return Json(new { Sucesso = true }, JsonRequestBehavior.AllowGet);
            // } 

            var obj = new Agendamento
            {
                id = Convert.ToInt32(id),
                cliente = Convert.ToInt32(id_cliente),
                marca = Convert.ToInt32(id_marca),
                colecao = Convert.ToInt32(id_colecao),
                dt_agenda = Convert.ToDateTime(dt_agenda),
                hr_agenda = hr_agenda,
                tp_status = Convert.ToInt32(tp_status)
            };

            var Respostas = DAL.Gravar(obj);
           /* if (!Respostas.Sucesso)
            {
                this.AddNotification(@"Não foi possível editar a agenda, favor entrar em contato com o suporte técnico!" + Environment.NewLine + Respostas.Mensagem, NotificationType.Erro);
                return Json(new { Sucesso = false }, JsonRequestBehavior.AllowGet);
            } */
            return Json(new { Sucesso = true }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ListarAgendaGeral()
        {
            ListaAgendaViewModel model = new ListaAgendaViewModel();

            //código para trazer os eventos do mês
            DateTime dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            model.DataInicio = dataInicial.ToString("dd/MM/yyyy");
            model.DataFinal = dataFinal.ToString("dd/MM/yyyy");

            List<Agendamento> eventosDb = AgendamentoDAL.GetAgendaEventos(Convert.ToInt64(UsuarioLogado.IdConta), dataInicial.Ticks, dataFinal.Ticks, 0, 0, 0, 0, 0).Where(item => !(item.tp_status == 999)).ToList();
            model.ListarAgenda = eventosDb;

            return View(model);
        }

        [HttpPost]
        public ActionResult ListarAgendaGeral(ListaAgendaViewModel obj)
        {

            string dtInicio = obj.DataInicio;
            string dtFinal = obj.DataFinal;
            DateTime dataInicial;
            DateTime dataFinal;

            if (string.IsNullOrEmpty(dtInicio))
            {
                dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            }
            else
            {
                dataInicial = Convert.ToDateTime(dtInicio);
            }

            if (string.IsNullOrEmpty(dtFinal))
            {
                dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            }
            else
            {
                dataFinal = Convert.ToDateTime(dtFinal);
            }

            ListaAgendaViewModel model = new ListaAgendaViewModel();
            model.filtro_colecao = obj.filtro_colecao;
            model.filtro_nm_colecao = obj.filtro_nm_colecao;
            model.filtro_marca = obj.filtro_marca;
            model.filtro_nm_marca = obj.filtro_nm_marca;
            model.filtro_cliente = obj.filtro_cliente;
            model.filtro_nm_cliente = obj.filtro_nm_cliente;

            model.DataInicio = obj.DataInicio;
            model.DataFinal = obj.DataFinal;

            List<Agendamento> eventosDb = AgendamentoDAL.GetAgendaEventos(Convert.ToInt64(UsuarioLogado.IdConta), dataInicial.Ticks, dataFinal.Ticks, model.filtro_marca, model.filtro_colecao, model.filtro_cliente, 0, 0).
                 Where(item => !(item.tp_status == 999)).ToList();

            model.ListarAgenda = eventosDb;

            return View("ListarAgendaGeral", model);
        }


    }
}