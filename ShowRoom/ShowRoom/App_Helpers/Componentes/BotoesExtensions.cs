﻿using System.Web;
using System.Web.Mvc;

namespace ShowRoom.App_Helpers.Componentes
{
    public static class BotoesExtensions
    {
        #region botoes
        public static IHtmlString BotaoSalvar(this HtmlHelper html)
        {
            return new HtmlString("<button  id=\"btnsalvar\" class=\"btn btn-success\" onclick=\"Gravando(this);\"  ><i class=\"fa fa-check\"></i>  Gravar</button>");
        }

        public static IHtmlString BotaoCancelar(this HtmlHelper html)
        {
            return new HtmlString("<button  class=\"btn btn-default\"><i class=\"fa fa-check\"></i>  Gravar</button>");
        }

        public static IHtmlString BotaoSubmit(this HtmlHelper html, string texto = "Gravar")
        {
            return new HtmlString("<button class=\"btn btn-primary\" onclick=\"Gravando(this);\" ><i class=\"fa fa-check\"></i>  " + texto + "</button>");
        }

        public static IHtmlString BotaoFiltrar(this HtmlHelper html, string texto = "Filtrar")
        {
            return new HtmlString("<button class=\"btn btn-primary waves-effect waves-light\" onclick=\"Filtrando(this);\" >" + texto + "</button>");
        }

        public static IHtmlString BotaoVerde(this HtmlHelper html, string texto = "Adicionar novo", string rota = "#")
        {
            return new HtmlString("<a href=" + rota + "><button class=\"btn btn-success\"; style=\"margin-bottom:2px\"><i class=\"fa fa-plus-circle\"></i>  " + texto + " </button></a>");
        }

        public static IHtmlString BotaoVoltar(this HtmlHelper html, string rota = "#", string texto = "Voltar")
        {
            return new HtmlString("<a href=" + rota + " class=\"btn btn-warning\"; style=\"margin-bottom:2px\" ><i class=\"fa fa-plus-circle\"></i>  " + texto + "</a>");
        }

        #endregion
    }
}