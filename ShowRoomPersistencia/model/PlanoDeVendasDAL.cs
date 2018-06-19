using ShowRoomModelo.model.cadastros;
using ShowRoomPersistencia.banco;
using System;
using System.Collections.Generic;

namespace ShowRoomPersistencia.model
{
    public static class PlanoDeVendasDAL
    {
        public static IEnumerable<PlanoDeVendas> GetListaPlanoDeVendas(long idconta, long dt_ini, long dt_fim, int? idmarca, int? idcolecao, int? idcliente, int? idcidade, int? idgrupo)
        {
            var u = new PlanoDeVendas();
            var f = new Filtros(u);
            string filtro = "";
            f.Add(() => u.id_conta, idconta, FiltroExpressao.Igual);
            // f.Add(() => u.dt_agenda, new DateTime(dt_ini), FiltroExpressao.MaiorIgual);

           /* if (dt_fim != 0)
            {
                f.Add(() => u.dt_agenda, new DateTime(dt_fim), FiltroExpressao.MenorIgual);
            } */
            if ((idmarca??0) != 0)
            {
                f.Add(() => u.marca, idmarca, FiltroExpressao.Igual);
            }
            if ((idcliente ?? 0) != 0)
            {
                f.Add(() => u.cliente, idcliente, FiltroExpressao.Igual);
            }
            if ((idcolecao ?? 0) != 0)
            {
                f.Add(() => u.colecao, idcolecao, FiltroExpressao.Igual);
            }
          /*  if ((idgrupo ?? 0) != 0)
            {
                filtro = string.Format(" and id_servico in (select s.id from cadastro_servico s where s.id_grupo={0})", idgrupo);
            }*/

            return DAL.ListarObjetos<PlanoDeVendas>(f.ToString() + filtro, "id desc");
        }
    }
}
