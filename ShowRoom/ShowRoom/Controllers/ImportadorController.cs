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
        // GET: Importador
        public ActionResult Abrir()
        {
            return View();
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
                            cliente.razao = estrutura[0];
                            cliente.fantasia = estrutura[1];
                            cliente.cnpj = estrutura[2];
                            cliente.ie = estrutura[3];
                            cliente.contato = estrutura[4];
                            cliente.fone1 = estrutura[5];
                            cliente.fone2 = estrutura[6];
                            cliente.cep = estrutura[7];
                            cliente.bairro = estrutura[8];
                            cliente.numero = estrutura[9];
                            cliente.endereco = estrutura[10];
                            cliente.corredor = estrutura[11];
                            cliente.cidade = Convert.ToInt64(estrutura[12]);
                            cliente.email = estrutura[13];
                            cliente.email2 = estrutura[14];
                            cliente.fundacao = Convert.ToDateTime(estrutura[15]);
                            cliente.facebook = estrutura[16];
                            cliente.instagram = estrutura[17];
                            cliente.www = estrutura[18];
                            cliente.status = Convert.ToInt32(estrutura[19]);
                            DAL.Gravar(cliente);
                        }
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
            this.AddNotification("Importação realizada com sucesso !.", "Sucesso");
            return Abrir();
        }
    }
}