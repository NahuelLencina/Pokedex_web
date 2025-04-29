<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PokemonsLista.aspx.cs" Inherits="pokedex_web.PokemonsLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <h1>Lista pokemons... 🙌</h1>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label runat="server" Text="Filtrar"></asp:Label>
                        <asp:TextBox ID="txtFiltroRapido" runat="server" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtFiltroRapido_TextChanged"></asp:TextBox>
                    </div>
                </div>

                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-3">
                        <asp:CheckBox Text="Filtro Avanzado 🔍" CssClass="" ID="chkAvanzado" runat="server"
                            AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
                    </div>
                </div>

                <% if (FiltroAvanzado) { %>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Campo" ID="ddlCampo" runat="server" />
                            <asp:DropDownList runat="server" CssClass="form-control">
                                <asp:ListItem Text="Nombre" />
                                <asp:ListItem Text="Tipo" />
                                <asp:ListItem Text="Número" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label runat="server" Text="Criterio"></asp:Label>
                            <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Filtro" runat="server" />
                            <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Estado" runat="server" />
                            <asp:TextBox ID="txtEstado" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <% } %>

                <asp:GridView ID="dgvPokemons" runat="server" DataKeyNames="Id"
                    CssClass="table" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged"
                    OnPageIndexChanging="dgvPokemons_PageIndexChanging"
                    AllowPaging="true" PageSize="3">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                        <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Acción" />
                    </Columns>
                </asp:GridView>

                <div>
                    <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-outline-primary mt-3" runat="server" Text="Agregar ➕" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
