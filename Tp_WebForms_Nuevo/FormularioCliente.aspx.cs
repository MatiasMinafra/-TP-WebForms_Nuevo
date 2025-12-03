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

            // Crear / actualizar cliente
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

            // Registrar participación
            string codigo = Session["codigoVoucher"].ToString();
            int idArticulo = int.Parse(Request.QueryString["idArticulo"]);

            vouNeg.RegistrarCanje(codigo, idCliente, idArticulo);

            Response.Redirect("Exito.aspx");
        }

        private bool ValidarCampos()
        {
            if (txtDNI.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" ||
                txtEmail.Text == "" || txtDireccion.Text == "" ||
                txtCiudad.Text == "" || txtCP.Text == "")
            {
                lblError.Text = "Completá todos los campos.";
                return false;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                lblError.Text = "Email inválido.";
                return false;
            }

            return true;
        }
    }
}