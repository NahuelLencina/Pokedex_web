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
    public partial class PokemonsLista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FiltroAvanzado = false;
                PokemonNegocio negocio = new PokemonNegocio();
                Session.Add("listaPokemons", negocio.listaConSP());
                CargarGrid();
            }
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var algo = dgvPokemons.SelectedRow.Cells[0].Text;
            string id = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?id=" + id);
            
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("FormularioPokemon.aspx");
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            CargarGrid();
        }


        // este Metodo carga el GripView
        private void CargarGrid()
        {
            dgvPokemons.DataSource = Session["listaPokemons"];
            dgvPokemons.DataBind();
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["listaPokemons"];
            List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()));
            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltroRapido.Text = "";
            txtFiltroRapido.Enabled = !FiltroAvanzado;
            CargarGrid();
        }
    }
}