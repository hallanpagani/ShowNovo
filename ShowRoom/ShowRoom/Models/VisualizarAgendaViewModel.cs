using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowRoom.Models
{
    public class VisualizarAgendaViewModel
    {
        public int filtro_marca { get; set; }
        public string filtro_nm_marca { get; set; }
        public int filtro_colecao { get; set; }
        public string filtro_nm_colecao { get; set; }
        public int filtro_cliente { get; set; }
        public string filtro_nm_cliente { get; set; }
        public int filtro_servico { get; set; }
        public string filtro_nm_servico { get; set; }
        public bool expandido { get; set; }

        public VisualizarAgendaViewModel()
        {

        }
    }
}