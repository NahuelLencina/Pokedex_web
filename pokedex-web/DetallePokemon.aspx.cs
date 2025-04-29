using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace pokedex_web
{
    public partial class DetallePokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PokemonNegocio negocio = new PokemonNegocio();
                String id = Request.QueryString["id"];
                Pokemon seleccionado = (negocio.listar(id)[0]);
                if (id != "")
                {
                    lblNombre.Text = seleccionado.Nombre;
                    lblNumero.Text = seleccionado.Numero.ToString();
                    lblTipo.Text = seleccionado.Tipo.ToString();
                    lblDebilidad.Text = seleccionado.Tipo.ToString();
                    lblDescripcion.Text = seleccionado.Descripcion;
                    imgDetalle.ImageUrl = seleccionado.UrlImagen;
                }
            }
        }
    }
}