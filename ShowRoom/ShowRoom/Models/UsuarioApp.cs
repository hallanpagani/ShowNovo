using Microsoft.AspNet.Identity.EntityFramework;

namespace ShowRoom.Models
{
    public class UsuarioApp: IdentityUser
    {
        public long IdConta;
        public string Perfil;
    }
}