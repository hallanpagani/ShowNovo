#region Using

using System.Globalization;
using System.Threading.Tasks;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using ShowRoomModelo.model.adm;
using ShowRoom.Models;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;
using System.Security.Principal;
using ShowRoomPersistencia.banco;

#endregion

namespace ShowRoom.Controllers.Acesso
{
    [Authorize]
    public class SistemaController : Controller
    {

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return System.Web.HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        // TODO: This should be moved to the constructor of the controller in combination with a DependencyResolver setup
        // NOTE: You can use NuGet to find a strategy for the various IoC packages out there (i.e. StructureMap.MVC5)
        // GET: /account/forgotpassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View("~/views/acesso/passwordesquecido.cshtml");
        }

        // GET: /account/login
        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Login(string returnUrl)
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            // Store the originating URL so we can attach it to a form field
            var viewModel = new AccountLoginModel { ReturnUrl = returnUrl };

            return View("~/views/acesso/login.cshtml",viewModel);
        }

        // POST: /account/login
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(AccountLoginModel viewModel)
        {
            // Ensure we have a valid viewModel to work with
            if (!ModelState.IsValid)
                return View("~/views/acesso/login.cshtml", viewModel);
            
            // Faz a busca pelo usuário na base.
            Usuario usuario = DAL.GetObjeto<Usuario>(string.Format("ds_login='{0}' and ds_senha='{1}'", viewModel.Email,viewModel.Password));

            // Se encontrou o usuário ...
            if (usuario != null)
            {
                // Busca a conta deste usuário.
                Conta conta = DAL.GetObjeto<Conta>(string.Format("id={0}", usuario.IdConta));

                // Se encontrou uma conta para o usuário ...
                if (conta != null)
                {
                    // Se conta ativada com sucesso ...
                    if (conta.is_ativo.Equals("Sim"))
                    {
                        // Prepare the identity with the provided information
                        if (usuario.Email != null)
                        {
                            // Se usuário ativo ...
                            if (usuario.is_ativo == 1)
                            {
                                // Carrega o perfil do usuário.
                                Perfil usuarioPerfil = DAL.GetObjeto<Perfil>(string.Format("cd_perfil={0}", usuario.IdPerfil));

                                // Se perfil encontrado ...
                                if (usuarioPerfil != null)
                                {
                                    var user = new UsuarioApp
                                    {
                                        UserName = usuario.NomeDoUsuario,
                                        Email = usuario.Email,
                                        Id = usuario.Id.ToString(CultureInfo.InvariantCulture),
                                        IdConta = usuario.IdConta,
                                        Perfil = usuarioPerfil.tp_perfil
                                    };

                                    // Verify if a user exists with the provided identity information
                                    //var user = await _manager.FindByEmailAsync(viewModel.Email);

                                    // Then create an identity for it and sign it in
                                    await SignInAsync(user, viewModel.RememberMe);

                                    // If the user came from a specific page, redirect back to it
                                    return RedirectToLocal(viewModel.ReturnUrl);
                                }
                                // Se perfil não encontrado.
                                else
                                {
                                    ModelState.AddModelError("", @"Perfil do usuário não encontrado. Procure o suporte !");
                                    return View("~/views/acesso/login.cshtml", viewModel);
                                }
                            }
                            // Se usuário não ativo ...
                            else
                            {
                                ModelState.AddModelError("", @"Usuário desativado. Procure o suporte para ativação !");
                                return View("~/views/acesso/login.cshtml", viewModel);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", @"E-mail não encontrado.");
                            return View("~/views/acesso/login.cshtml", viewModel);
                        }
                    }
                    // Se conta desativada ...
                    else
                    {
                        ModelState.AddModelError("", @"Conta desativada. Procure o suporte para ativação !");
                        return View("~/views/acesso/login.cshtml", viewModel);
                    }
                }

                // Se não encontro uma conta para o usuário ...
                else
                {
                    ModelState.AddModelError("", @"Conta de acesso inexistente !");
                    return View("~/views/acesso/login.cshtml", viewModel);
                }
            }
            else
            {
                ModelState.AddModelError("", @"Usuário ou senha inválidos !");
                return View("~/views/acesso/login.cshtml", viewModel);
            }
        }

        // GET: /account/error
        [AllowAnonymous]
        public ActionResult Error()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View();
        }

        // GET: /account/register
        [AllowAnonymous]
        public ActionResult Registro()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View("~/views/acesso/registro.cshtml", new AccountRegistrationModel());
        }

        // POST: /account/register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registro(AccountRegistrationModel viewModel)
        {
            return View();
        }

        // POST: /account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);

            // Second we clear the principal to ensure the user does not retain any authentication
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

            return RedirectToLocal();
        }

        private ActionResult RedirectToLocal(string returnUrl = "")
        {
            // If the return url starts with a slash "/" we assume it belongs to our site
            // so we will redirect to this "action"
            if (!returnUrl.IsNullOrWhiteSpace() && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            // If we cannot verify if the url is local to our host we redirect to a default location
            return RedirectToAction("index", "home");
        }

        private void AddErrors(System.Exception result)
        {
            // Add all errors that were returned to the page error collection
            ModelState.AddModelError("", result.ToString());
        }

        private void AddErrors(IdentityResult result)
        {
            // Add all errors that were returned to the page error collection
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }

        private async Task SignInAsync(UsuarioApp user, bool isPersistent)
        {
            var claims = new List<Claim>();
            // create *required* claims
            claims.Add(new Claim(ClaimTypes.GroupSid, user.IdConta.ToString()));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Role, user.Perfil));
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            // add to user here!
            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = isPersistent,
                ExpiresUtc = System.DateTime.UtcNow.AddDays(120)
            }, identity);
        
        }

        // GET: /account/lock
        [AllowAnonymous]
        public ActionResult Lock()
        {
            return View();
        }
    }
}