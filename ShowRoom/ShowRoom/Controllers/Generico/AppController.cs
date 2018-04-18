using ShowRoom;
using System.Security.Claims;
using System.Web.Mvc;

namespace Conciliacao.Controllers.Generico
{
    public abstract class AppController : Controller
    {
        public AppUsuario UsuarioLogado
        {
            get
            {
                return new AppUsuario(this.User as ClaimsPrincipal);
            }
        }
    }
}