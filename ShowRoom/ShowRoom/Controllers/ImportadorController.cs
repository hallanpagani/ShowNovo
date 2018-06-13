using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conciliacao.Controllers.Generico;
using ShowRoom.App_Helpers.Componentes;
using ShowRoomModelo.model.cadastros;
using ShowRoomPersistencia.banco;

namespace ShowRoom.Controllers
{
    public class ImportadorController : AppController
    {
        private const int INDICE_CNPJ = 0;
        private const int INDICE_IE = 1;
        private const int INDICE_STATUS = 2;
        private const int INDICE_RAZAO_SOCIAL = 3;
        private const int INDICE_NOME_FANTASIA = 4;
        private const int INDICE_DATA_FUNDACAO = 5;
        private const int INDICE_EMAIL1 = 6;
        private const int INDICE_EMAIL2 = 7;
        private const int INDICE_FONE1 = 8;
        private const int INDICE_FONE2 = 9;
        private const int INDICE_CONTATO = 10;
        private const int INDICE_ENDERECO_CIDADE = 11;
        private const int INDICE_ENDERECO_CEP = 12;
        private const int INDICE_ENDERECO_BAIRRO = 13;
        private const int INDICE_ENDERECO_COMPLETO = 14;
        private const int INDICE_ENDERECO_CORREDOR = 15;
        private const int INDICE_ENDERECO_NUMERO = 16;
        private const int INDICE_FACEBOOK = 17;
        private const int INDICE_INSTAGRAM = 18;
        private const int INDICE_URL = 19;

        // GET: Importador
        public ActionResult Abrir()
        {
            return View("~/views/importador/abrir.cshtml");
        }

        [HttpPost]
        public ActionResult Importar(HttpPostedFileBase uploadFile)
        {
            var cliente = new Cliente();

            if (uploadFile != null)
            {
                try
                {
                    StreamReader csvreader = new StreamReader(uploadFile.InputStream);

                    if (uploadFile.FileName.EndsWith(".txt") || uploadFile.FileName.EndsWith(".csv"))
                    {
                        while (!csvreader.EndOfStream)
                        {
                            var linha = csvreader.ReadLine();
                            var estrutura = linha.Split(';');
                            cliente.cnpj = estrutura[INDICE_CNPJ];
                            cliente.ie = estrutura[INDICE_IE];
                            cliente.status = Convert.ToInt32(INDICE_STATUS);
                            cliente.razao = estrutura[INDICE_RAZAO_SOCIAL].ToUpper();
                            cliente.fantasia = estrutura[INDICE_NOME_FANTASIA].ToUpper();
                            cliente.contato = estrutura[INDICE_CONTATO].ToUpper();
                            cliente.fone1 = estrutura[INDICE_FONE1];
                            cliente.fone2 = estrutura[INDICE_FONE2];
                            cliente.cep = estrutura[INDICE_ENDERECO_CEP];
                            cliente.bairro = estrutura[INDICE_ENDERECO_BAIRRO].ToUpper();
                            cliente.numero = estrutura[INDICE_ENDERECO_NUMERO];
                            cliente.endereco = estrutura[INDICE_ENDERECO_COMPLETO].ToUpper();
                            cliente.corredor = estrutura[INDICE_ENDERECO_CORREDOR];
                            cliente.nm_cidade = estrutura[INDICE_ENDERECO_CIDADE].ToUpper();
                            cliente.email = estrutura[INDICE_EMAIL1];
                            cliente.email2 = estrutura[INDICE_EMAIL2];
                            cliente.fundacao = Convert.ToDateTime(estrutura[INDICE_DATA_FUNDACAO]);
                            cliente.facebook = estrutura[INDICE_FACEBOOK].ToUpper();
                            cliente.instagram = estrutura[INDICE_INSTAGRAM].ToUpper();
                            cliente.www = estrutura[INDICE_URL].ToUpper();

                            cliente.id_usuario = Convert.ToInt64(UsuarioLogado.IdUsuario);
                            cliente.id_conta = Convert.ToInt64(UsuarioLogado.IdConta);

                            var existe = DAL.GetObjeto<Cliente>(string.Format("id_conta={0} and razao='{1}'", UsuarioLogado.IdConta, cliente.razao)) ?? new Cliente();
                            if ((existe.id > 0 && cliente.id == 0))
                            {
                                // Ignora.
                            }
                            else
                            {
                                DAL.Gravar(cliente);
                            }
                        }

                        this.AddNotification("Importação realizada com sucesso !.", "Sucesso");
                    }
                    else
                    {
                        this.AddNotification("Extensão inválida para importação. Utilize CSV ou TXT.", "Erro");
                        return Abrir();
                    }
                }

                catch (Exception ex)
                {
                    this.AddNotification("Erro:" + ex.Message, "Erro");
                    return Abrir();
                }
            }
            return Abrir();
        }
    }
}