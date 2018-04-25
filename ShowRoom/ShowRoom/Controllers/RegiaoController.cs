using Conciliacao.Controllers.Generico;
using ShowRoom.App_Helpers.Componentes;
using ShowRoomModelo.model.cadastros;
using ShowRoomPersistencia.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShowRoom.Controllers
{
    [Authorize]
    public class RegiaoController : AppController
    {
        // GET: Regiao
        [HttpGet]
        public ActionResult Cadastrar(int id = 0)
        {
            var model = new Regiao();
            if (id > 0)
            {
                model = DAL.GetObjetoById<Regiao>(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastrar(Regiao model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Regiao = model.Regiao.ToUpper();
            model.nome = model.nome.ToUpper();
            model.id_usuario = Convert.ToInt64(UsuarioLogado.IdUsuario);
            model.id_conta = Convert.ToInt64(UsuarioLogado.IdConta);
            try
            {
                var existe = DAL.GetObjeto<Regiao>(string.Format("id_conta={0} and nome='{1}'", UsuarioLogado.IdConta, model.nome)) ?? new Regiao();
                if (existe.id > 0 && model.id == 0)
                {
                    this.AddNotification("Região já existe!", "Alerta");
                    return View();
                }
                long id = DAL.Gravar(model);

                if (model.id > 0 && id == 0)
                {
                    this.AddNotification("Regiao alterada!", "Sucesso");
                }
                else
                {
                    this.AddNotification("Regiao cadastrada!", "Sucesso");
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
            return View(DAL.ListarObjetos<Regiao>(string.Format("id_conta={0}", UsuarioLogado.IdConta)));
        }

        [HttpPost]
        public ActionResult Deletar(int id = 0)
        {
            var model = new Regiao();
            if (id > 0)
            {
                model = DAL.GetObjeto<Regiao>(string.Format("id_conta={0} and id={1}", UsuarioLogado.IdConta, id));
                DAL.Excluir(model);
            }
            return RedirectToAction("Consultar");
        }

    }
}