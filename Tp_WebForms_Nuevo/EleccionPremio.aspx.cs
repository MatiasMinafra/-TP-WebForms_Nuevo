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
            ArticuloNegocio artNeg = new ArticuloNegocio();
            var lista = artNeg.Listar();

            foreach (var art in lista)
            {
                var imagenes = artNeg.ListarImagenes(art.Id);

                HtmlGenericControl card = new HtmlGenericControl("div");
                card.Attributes["class"] = "col-md-4 mb-4";

                string idImgPrincipal = "imgPrincipal_" + art.Id;

                string html = $@"
 <div class='card shadow-sm p-2'>

     <img id='{idImgPrincipal}' src='{imagenes[0]}' 
          class='img-main w-100' />

     <div class='card-body'>
         <h5 class='card-title text-center'>{art.Nombre}</h5>
         <p class='card-text text-center'>{art.Descripcion}</p>

         <p class='text-center' style='font-size:14px; color:#007BFF; font-weight:500;'>
             Hacé clic en una imagen para verla en grande
         </p>

         <div class='d-flex justify-content-center flex-wrap mt-3'>
 ";


                foreach (string img in imagenes)
                {
                    html += $@"
                <img src='{img}' 
                     class='miniatura'
                     onclick=""cambiarImagenPrincipal('{idImgPrincipal}', '{img}')"" />";
                }

                html += $@"
                </div>

                <div class='text-center mt-3'>
                    <a href='FormularioCliente.aspx?idArticulo={art.Id}' 
                       class='btn btn-primary w-100'>
                        Elegir premio
                    </a>
                </div>

            </div>
        </div>";

                card.InnerHtml = html;
                cardsContainer.Controls.Add(card);
            }
        }
    }
}