<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListadoArticulos.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPublica.ListadoArticulos.frmListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="container-fluid">
        <asp:Panel ID="ContenedorPrincipal" CssClass="row text-center ContenedorPrincipalListado" runat="server"></asp:Panel>

        <section class="row text-center">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <div class="btn-group btn-group-lg" role="group" aria-label="Basic example">
                    <asp:Button ID="btnIncio" runat="server" class="btn btn-primary" Text="Inicio" OnClick="btnIncio_Click" />
                    <asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-primary" Text="Siguiente" OnClick="btnSiguiente_Click1" />
                    <asp:Button ID="btnFinal" runat="server" class="btn btn-primary" Text="Final" OnClick="btnFinal_Click" />
                </div>
            </article>
        </section>

    </section>

</asp:Content>
