using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;


namespace Tp_WebForms_Nuevo
{
    public partial class IngresoVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();

            if (string.IsNullOrEmpty(codigo))
            {
                lblError.Text = "Ingresá un código.";
                return;
            }

            VoucherNegocio negocio = new VoucherNegocio();
            var voucher = negocio.ObtenerPorCodigo(codigo);

            if (voucher == null)
            {
                Response.Redirect("ErrorVoucher.aspx?tipo=notfound");
                return;
            }

            if (voucher.Usado)
            {
                Response.Redirect("ErrorVoucher.aspx?tipo=usado");
                return;
            }

            Session["codigoVoucher"] = voucher.CodigoVoucher;
            Response.Redirect("EleccionPremio.aspx");
        }


    }
}