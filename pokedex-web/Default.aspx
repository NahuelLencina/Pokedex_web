<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pokedex_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Hola!</h1>
    <p>Llegaste al pokedex web, tu lugar pokemons...</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">

<%--        <%
            foreach (dominio.Pokemon poke in ListaPokemon)
            {
        %>
        <div class="col">
            <div class="card">
                <img src="<%: poke.UrlImagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: poke.Nombre %></h5>
                    <p class="card-text"> <%: poke.Descripcion %></p>
                    <p class="card-text"> <%: poke.Debilidad %></p>
                    <a href="DetallePokemon.aspx?id=<%: poke.Id %>"> Ver detalle</a>
                </div>
            </div>
        </div>

         <% } %>--%>

        <asp:Repeater ID="RepRepetidor" runat="server">
            <ItemTemplate>
                  <div class="col">
            <div class="card">
                <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%#Eval("Nombre")%></h5>
                    <p class="card-text"> <%#Eval("Descripcion")  %></p>
                    <p class="card-text"> <%#Eval("Debilidad")%></p>
                    <a href="DetallePokemon.aspx?id=<%#Eval("Id")%>"> Ver detalle</a>

                    <asp:Button ID="btnEjemplo" runat="server" Text="Ejemplo" CssClass="btn btn-outline-primary mt-3" CommandArgument='<%#Eval("Id")%>' CommandName="PokemonId" OnClick="btnEjemplo_Click"/>

                </div>
            </div>
        </div>
            </ItemTemplate>      
        </asp:Repeater>

    </div>

</asp:Content>
