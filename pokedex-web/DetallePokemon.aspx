<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetallePokemon.aspx.cs" Inherits="pokedex_web.DetallePokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container col-4">
        <div class="card shadow-lg rounded-4 d-flex justify-content-center align-items-center">
            <div class="card-body">
                <h5 class="card-title mb-1">
                  
                        <asp:Label ID="Label1" runat="server" Text="Descripción:" CssClass="fw-bold text-primary" style="height : 200px;"></asp:Label>
                   
                </h5>
            </div>
        </div>
    </div>

    <div class="container col-4">
        <div class="card shadow-lg rounded-4">

            <div class="row g-0">
                <!-- Imagen del Pokémon -->
                <div class="col-md-4 d-flex align-items-center justify-content-center p-4">
                    <asp:Image ID="imgDetalle"  runat="server" Width="100%" CssClass="img-fluid rounded-3 border" />
                </div>



                <!-- Información del Pokémon -->
                <div class="col-md-8">
                    <div class="card-body p-4">
                        <h2 class="card-title mb-3">
                            <asp:Label ID="lblNombre" runat="server" CssClass="fw-bold text-primary" />
                        </h2>
                        <p >
                            <strong>Número:</strong>
                            <asp:Label ID="lblNumero" runat="server" />
                        </p>
                        <p class="card-text">
                            <strong>Tipo:</strong>
                            <asp:Label ID="lblTipo" runat="server" />
                        </p>
                        <p class="card-text">
                            <strong>Debilidad:</strong>
                            <asp:Label ID="lblDebilidad" runat="server" />
                        </p>
                        <p class="card-text">
                            <strong>Descripción:</strong><br />
                            <asp:Label ID="lblDescripcion" runat="server" />
                        </p>
                        <a href="Default.aspx" class="btn btn-outline-primary mt-3">Volver</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
