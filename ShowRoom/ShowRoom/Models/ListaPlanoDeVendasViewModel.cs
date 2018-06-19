using ShowRoomModelo.model.cadastros;
using System.Collections.Generic;

namespace ShowRoom.Models
{
    public class ListaPlanoDeVendasViewModel
    {

        public int filtro_colecao { get; set; }
        public string filtro_nm_colecao { get; set; }
        public int filtro_marca { get; set; }
        public string filtro_nm_marca { get; set; }
        public int filtro_cliente { get; set; }
        public string filtro_nm_cliente { get; set; }

        public string DataInicio { get; set; }
        public string DataFinal { get; set; }

        public IEnumerable<PlanoDeVendas> ListarPlanoDeVendas { get; set; }

        public ListaPlanoDeVendasViewModel()
        {
            ListarPlanoDeVendas = new List<PlanoDeVendas>();
        }
    }
}