using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_WebForms_Nuevo
{
    public partial class ErrorVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tipo = Request.QueryString["tipo"];

                if (tipo == "notfound")
                    lblMensaje.Text = "El código ingresado no existe.";
                else if (tipo == "usado")
                    lblMensaje.Text = "El voucher ya fue utilizado.";
                else
                    lblMensaje.Text = "Ocurrió un error inesperado.";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresoVoucher.aspx");
        }
    }
}