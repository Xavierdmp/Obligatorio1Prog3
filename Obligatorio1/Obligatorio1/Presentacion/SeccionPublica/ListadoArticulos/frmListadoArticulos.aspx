<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListadoArticulos.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPublica.ListadoArticulos.frmListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="ContenedorPrincipal" CssClass="row text-center ContenedorPrincipalListado" runat="server"></asp:Panel>

    <section class="container-fluid text-center">

        <section class="text-center">

            <div class="btn-group btn-group-lg" role="group" aria-label="Basic example">
                <button type="button" class="btn btn-primary">Inicio</button>
                <asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-primary" Text="Siguiente" OnClick="btnSiguiente_Click1" Width="98px" />
                <button type="button" class="btn btn-primary">Final</button>

            </div>
        </section>
    </section>

</asp:Content>
