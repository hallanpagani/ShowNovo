using System.Security.Claims;

namespace ShowRoom
{
    public class AppUsuario : ClaimsPrincipal
    {
        public AppUsuario(ClaimsPrincipal principal)
            : base(principal)
        {
        }

        public string IdUsuario
        {
            get
            {
                return this.FindFirst(ClaimTypes.NameIdentifier).Value ?? "0";
            }
        }

        public string IdConta
        {
            get
            {
                return this.FindFirst(ClaimTypes.GroupSid).Value ?? "0";
            }
        }


        public string Nome
        {
            get
            {
                return this.FindFirst(ClaimTypes.Name).Value ?? "Relogue-se";
            }
        }

        public string Perfil
        {
            get
            {
                return this.FindFirst(ClaimTypes.Role).Value ?? "Administrador";
            }
        }
    }
}