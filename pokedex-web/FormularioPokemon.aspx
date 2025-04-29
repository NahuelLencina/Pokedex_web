<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="pokedex_web.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id: </label>
                <asp:TextBox ID="TxtId" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNumero" class="form-label">Número: </label>
                <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
            </div>
            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Tipo: </label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlDebilidad" class="form-label">Debilidad: </label>
                <asp:DropDownList ID="ddlDebilidad" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3 d-flex gap-2">
                <asp:Button ID="btnAceptar" CssClass="btn btn-outline-primary mt-3" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
               
                <a href="PokemonsLista.aspx" class="btn btn-outline-primary mt-3">Cancelar</a>
                <asp:Button ID="btnInactivar" OnClick="btnInactivar_Click" runat="server" cssClass="btn btn-warning mt-3" Text="Inactivar" />

            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" />
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen: </label>
                        <asp:TextBox ID="TxtImagenUrl" CssClass="form-control" AutoPostBack="true" OnTextChanged="TxtImagenUrl_TextChanged" runat="server" />
                    </div>
                    <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQ_gFWVSSx5oFzLf-8xpssrWraTLSYnAnsIMsK9boqDAsaDiTEYmdaPXCqLujleldKb_w&usqp=CAU"
                        runat="server" ID="imgPokemon" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate> 
            <div class="mb-3">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  OnClick="btnEliminar_Click1" CssClass="btn btn-danger" />
            </div>

            <%  if (ConfirmaEliminacion)
                { %>
                <div class="mb-3">
                    <asp:CheckBox ID="ChxConfirmaEliminacion" runat="server" Text="Confirmar Eliminación" />
                    <asp:Button ID="btnConfirmaEliminacion" runat="server" OnClick="btnConfirmaEliminacion_Click" Text="Eliminar" CssClass="btn btn-outline-danger" />
                 </div>
                 <% } %>

                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    </div>

</asp:Content>
