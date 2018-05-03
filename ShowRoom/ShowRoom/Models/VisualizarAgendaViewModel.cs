using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowRoom.Models
{
    public class VisualizarAgendaViewModel
    {
        public int filtro_grupo { get; set; }
        public string filtro_nm_grupo { get; set; }
        public int filtro_colaborador { get; set; }
        public string filtro_nm_colaborador { get; set; }
        public int filtro_cliente { get; set; }
        public string filtro_nm_cliente { get; set; }
        public int filtro_servico { get; set; }
        public string filtro_nm_servico { get; set; }

        public VisualizarAgendaViewModel()
        {

        }
    }
}