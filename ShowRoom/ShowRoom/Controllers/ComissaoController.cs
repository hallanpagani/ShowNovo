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
    public class ComissaoController : AppController
    {
        // GET: Regiao
        [HttpGet]
        public ActionResult Cadastrar(int id = 0)
        {
            if (Settings.hasPermission(Settings.MENU_CADASTRO_COMISSAO, UsuarioLogado))
            {
                var model = new Comissao();
                if (id > 0)
                {
                    model = DAL.GetObjetoById<Comissao>(id);
                }
                return View(model);
            }
            else
            {
                return View("~/views/Shared/error.cshtml");
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(Comissao model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.id_usuario = Convert.ToInt64(UsuarioLogado.IdUsuario);
            model.id_conta = Convert.ToInt64(UsuarioLogado.IdConta);
            try
            {
                var existe = DAL.GetObjeto<Comissao>(string.Format("id_conta={0} and id_vendedor={1}", UsuarioLogado.IdConta, model.id_vendedor)) ?? new Comissao();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Comissão já existe!", "Alerta");
                    return View();
                }
                long id = DAL.Gravar(model);

                if (model.id > 0 && id == 0)
                {
                    this.AddNotification("Comissão alterada!", "Sucesso");
                }
                else
                {
                    this.AddNotification("Comissão cadastrada!", "Sucesso");
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
            return View(DAL.ListarObjetos<Comissao>(string.Format("id_conta={0}", UsuarioLogado.IdConta)));
        }

        [HttpPost]
        public ActionResult Deletar(int id = 0)
        {
            var model = new Comissao();
            if (id > 0)
            {
                model = DAL.GetObjeto<Comissao>(string.Format("id_conta={0} and id={1}", UsuarioLogado.IdConta, id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }
    }
}