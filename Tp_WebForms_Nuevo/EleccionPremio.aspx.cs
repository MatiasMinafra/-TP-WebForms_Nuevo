using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Tp_WebForms_Nuevo
{
    public partial class EleccionPremio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarPremios();
        }

        private void CargarPremios()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            var lista = negocio.Listar();

            foreach (var art in lista)
            {
                var imagenes = negocio.ListarImagenes(art.Id);
                string imagen = imagenes.Count > 0 ? imagenes[0] : "https://via.placeholder.com/300";

                HtmlGenericControl col = new HtmlGenericControl("div");
                col.Attributes["class"] = "col-md-4 mb-4";

                col.InnerHtml =
                $@"
                    <div class='card h-100'>
                        <img src='{imagen}' class='card-img-top' style='height:200px; object-fit:cover;' />
                        <div class='card-body'>
                            <h5 class='card-title'>{art.Nombre}</h5>
                            <p class='card-text'>{art.Descripcion}</p>
                            <a href='FormularioCliente.aspx?idArticulo={art.Id}' class='btn btn-primary w-100'>
                                Elegir este premio
                            </a>
                        </div>
                    </div>
                ";

                cardsContainer.Controls.Add(col);
            }
        }
    }
}