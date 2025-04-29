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
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtId.Enabled = false;
            ConfirmaEliminacion = false;

            if (Request.QueryString["Id"]!=null)
            {
                btnEliminar.Visible = true;
                btnInactivar.Visible = true;
            }
            else
            {
                btnEliminar.Visible = false;
                btnInactivar.Visible = false;
            }

            try
            //Configuración inicial de pantalla
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    List<Elemento> lista = negocio.listar();

                    ddlTipo.DataSource = lista;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    ddlDebilidad.DataSource = lista;
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();
                }

                String id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    // List<Pokemon> lista = negocio.listar(id);
                    // Pokemon seleccionado = lista[0];

                    // otra forma es la siguiente,
                    // cuando resuelvas la lista. Dame el primero
                    Pokemon seleccionado = (negocio.listar(id))[0];
                    
                    // Guardo pokemon seleccionado en session
                    Session.Add("pokeSeleccionado", seleccionado);
                    // Pre carga de los campos del pokemon

                    TxtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtNumero.Text = seleccionado.Numero.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion;
                    TxtImagenUrl.Text = seleccionado.UrlImagen;

                    ddlTipo.SelectedValue = seleccionado.Tipo.id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.id.ToString();
                    TxtImagenUrl_TextChanged(sender, e);

                    if (!seleccionado.Activo)
                    {
                        btnInactivar.Text = "Reactivar";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon nuevo = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = TxtImagenUrl.Text;

                nuevo.Tipo = new Elemento();
                nuevo.Tipo.id = int.Parse(ddlTipo.SelectedValue);
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.id = int.Parse(ddlDebilidad.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(TxtId.Text);
                    negocio.modificarConSP(nuevo);
                }
                else
                    negocio.agregarConSP(nuevo);

                Response.Redirect("PokemonsLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }


        //protected void btnEliminar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //PokemonNegocio negocio = new PokemonNegocio();
        //        //negocio.eliminar(int.Parse(TxtId.Text));
        //        //Response.Redirect("PokemonsLista.aspx");


        //    }
        //    catch (Exception ex)
        //    {
        //        Session.Add("error", ex);
        //    }
        //}

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminacion_Click(object sender, EventArgs e)
        {

            try
            {
                if (ChxConfirmaEliminacion.Checked)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    negocio.eliminar(int.Parse(TxtId.Text));
                    Response.Redirect("PokemonsLista.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];
                negocio.eliminarLogico(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("PokemonsLista.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("Error",ex);
            }
        }

        protected void TxtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = TxtImagenUrl.Text;
        }
    }
}