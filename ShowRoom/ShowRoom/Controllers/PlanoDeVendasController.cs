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
    public class PlanoDeVendasController : AppController
    {
        // GET: Regiao
        [HttpGet]
        public ActionResult Cadastrar(int id = 0)
        {

            if (Settings.hasPermission(Settings.MENU_PLANODEVENDAS_CADASTRAR, UsuarioLogado.Perfil))
            {
                var model = new PlanoDeVendas();
                if (id > 0)
                {
                    model = DAL.GetObjetoById<PlanoDeVendas>(id);
                }
                return View(model);
            }
            else
            {
                return View("~/views/Shared/error.cshtml");
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(PlanoDeVendas model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.id_usuario = Convert.ToInt64(UsuarioLogado.IdUsuario);
            model.id_conta = Convert.ToInt64(UsuarioLogado.IdConta);
            try
            {
                var existe = DAL.GetObjeto<PlanoDeVendas>(string.Format("id={0}", model.id)) ?? new PlanoDeVendas();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Plano de vendas já existe!", "Alerta");
                    return View(model);
                }
                long id = DAL.Gravar(model);

                if (model.id > 0 && id == 0)
                {
                    this.AddNotification("Plano de vendas alterado!", "Sucesso");
                }
                else
                {
                    this.AddNotification("Plano de vendas cadastrado!", "Sucesso");
                }
            }
            catch (Exception e)
            {
                this.AddNotification("Erro:" + e.Message, "Erro");
            }

            var obj = new PlanoDeVendas();
            obj.marca = model.marca;
            obj.nm_marca = model.nm_marca;
            obj.colecao = model.colecao;
            obj.nm_colecao = model.nm_colecao;
            obj.valorcolecaoatual = model.valorcolecaoatual;
            return View(obj);
        }

        [HttpPost]
        public ActionResult Deletar(int id = 0)
        {
            var model = new PlanoDeVendas();
            if (id > 0)
            {
                model = DAL.GetObjeto<PlanoDeVendas>(string.Format("id={0}", id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

        [HttpGet]
        public ActionResult Consultar()
        {
            ListaPlanoDeVendasViewModel model = new ListaPlanoDeVendasViewModel();

            //código para trazer os eventos do mês
            DateTime dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            model.DataInicio = dataInicial.ToString("dd/MM/yyyy");
            model.DataFinal = dataFinal.ToString("dd/MM/yyyy");

            List<PlanoDeVendas> eventosDb = PlanoDeVendasDAL.GetListaPlanoDeVendas(Convert.ToInt64(UsuarioLogado.IdConta),
                                            dataInicial.Ticks, dataFinal.Ticks, model.filtro_marca, model.filtro_colecao, model.filtro_cliente, 0, 0).ToList();
            model.ListarPlanoDeVendas = eventosDb;

            return View(model);
        }

        [HttpPost]
        public ActionResult Consultar(ListaPlanoDeVendasViewModel obj)
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

            ListaPlanoDeVendasViewModel model = new ListaPlanoDeVendasViewModel();
            model.filtro_colecao = obj.filtro_colecao;
            model.filtro_nm_colecao = obj.filtro_nm_colecao;
            model.filtro_marca = obj.filtro_marca;
            model.filtro_nm_marca = obj.filtro_nm_marca;
            model.filtro_cliente = obj.filtro_cliente;
            model.filtro_nm_cliente = obj.filtro_nm_cliente;

            model.DataInicio = obj.DataInicio;
            model.DataFinal = obj.DataFinal;

            List<PlanoDeVendas> eventosDb = PlanoDeVendasDAL.GetListaPlanoDeVendas(Convert.ToInt64(UsuarioLogado.IdConta), 
                                            dataInicial.Ticks, dataFinal.Ticks, model.filtro_marca, model.filtro_colecao, model.filtro_cliente, 0, 0).ToList();

            model.ListarPlanoDeVendas = eventosDb;

            return View("Listar", model);
        }


    }
}