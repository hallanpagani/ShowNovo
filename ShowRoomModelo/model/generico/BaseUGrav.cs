using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Web;

namespace ShowRoomModelo.model.generico
{
    public partial class BaseUGrav : BaseID
    {
        [Required]
        [Column("id_usuario")]
        public long Usuario { get; set; }

        public BaseUGrav()
        {
            var claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
            try
            {
                Usuario = Convert.ToInt64(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier ?? "0").Value);
            }
            catch (Exception e)
            {
                Usuario = 0;
            }
        }

    }


}
