using ShowRoomModelo.classes;
using ShowRoomModelo.model.generico;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Security;

namespace ShowRoomModelo.model.pagar
{
    [Table("pagar")]
    public class Pagar // : BaseUGrav
    {

        [Required]
        [Column("ds_usuario")]
        public string Usuario { get; set; }

        [Required]
        [Column("id_conta")]
        public long IdConta { get; set; }

        [Key]
        [AutoInc]
        [Required]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column("vl_titulo")]
        [Range(0, double.PositiveInfinity, ErrorMessage = "O valor deve ser maior que zero!")]
        public decimal Valor { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column("vl_saldo")]
        [Range(0, double.PositiveInfinity, ErrorMessage = "O valor deve ser maior que zero!")]
        public decimal Saldo { get; set; }

        [Required]
        [Column("ds_categoria")]
        [Display(Name = "Nome da categoria")]
        public string NmCategoria { get; set; }

        [Column("ds_marcacao")]
        public string Marcacao { get; set; }

        [Column("ds_documento")]
        public string DsDocumento { get; set; }

        [DataType(DataType.Date)]
        [Column("dt_emissao")]
        [Display(Name = "Emissão")]
        public DateTime DataEmissao { get; set; }

        [DataType(DataType.Date)]
        [Column("dt_vencimento")]
        [Display(Name = "Emissão")]
        public DateTime DataVencimento { get; set; }

        public FinanceiroBaixa FinanceiroBaixa;

        [OnlyInsert]
        [Required]
        [Column("dt_inclusao")]
        public DateTime DataInc { get; set; }

        [OnlyInsert]
        [Required]
        [Column("hr_inclusao")]
        public TimeSpan HoraInc { get; set; }

        public Pagar()
        {
            DataInc = Fuso.GetDateNow();
            HoraInc = Fuso.GetTimeNow();
            FinanceiroBaixa = new FinanceiroBaixa();
            DataEmissao = Fuso.GetDateNow();
            DataVencimento = Fuso.GetDateNow();
            Marcacao = null;
            DsDocumento = null;
            Saldo = 0;

            FormsIdentity ident = HttpContext.Current.User.Identity as FormsIdentity;
            if (ident != null)
            {
                FormsAuthenticationTicket ticket = ident.Ticket;
                string userDataString = ticket.UserData;
                string[] userDataPieces = userDataString.Split("|".ToCharArray());
                Usuario = userDataPieces[0];
                IdConta = Convert.ToInt64(userDataPieces[1]);

            }

        }
    }
}
