using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Tp_WebForms_Nuevo
{
    public partial class FormularioCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validar que venga el premio seleccionado
                if (Request.QueryString["idArticulo"] == null)
                {
                    Response.Redirect("IngresoVoucher.aspx");
                    return;
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            var cliente = negocio.ObtenerPorDocumento(txtDNI.Text.Trim());

            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCP.Text = cliente.CP.ToString();

                lblMensaje.Text = "Cliente encontrado. Datos cargados automáticamente.";
            }
            else
            {
                lblMensaje.Text = "No existe un cliente con ese DNI. Cargá tus datos.";
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            ClienteNegocio cliNeg = new ClienteNegocio();
            VoucherNegocio vouNeg = new VoucherNegocio();

            if (!ValidarCampos())
                return;

            
            Cliente cli = new Cliente
            {
                Documento = txtDNI.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Ciudad = txtCiudad.Text.Trim(),
                CP = int.Parse(txtCP.Text.Trim())
            };

            int idCliente = cliNeg.Guardar(cli);

            
            string codigo = Session["codigoVoucher"].ToString();
            int idArticulo = int.Parse(Request.QueryString["idArticulo"]);

            vouNeg.RegistrarCanje(codigo, idCliente, idArticulo);

            Response.Redirect("Exito.aspx");
        }

        private bool ValidarCampos()
        {
           
            if (string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtCiudad.Text) ||
                string.IsNullOrWhiteSpace(txtCP.Text))
            {
                lblError.Text = "Completá todos los campos.";
                return false;
            }

            
            int dniTemp;
            if (!int.TryParse(txtDNI.Text.Trim(), out dniTemp))
            {
                lblError.Text = "El DNI debe ser numérico.";
                return false;
            }

           
            int cpTemp;
            if (!int.TryParse(txtCP.Text.Trim(), out cpTemp))
            {
                lblError.Text = "El Código Postal debe ser numérico.";
                return false;
            }

            
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                lblError.Text = "El email no tiene un formato válido.";
                return false;
            }

            
            lblError.Text = "";
            return true;
        }
    }
}