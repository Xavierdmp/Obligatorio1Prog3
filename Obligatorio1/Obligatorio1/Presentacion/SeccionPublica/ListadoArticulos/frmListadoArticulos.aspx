<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListadoArticulos.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPublica.ListadoArticulos.frmListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="container-fluid">
        <section class="row text-center FiltrosListado">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <asp:DropDownList ID="dplListarSubtipos" CssClass="form-controlV2" runat="server">
                    <asp:ListItem Value="Seleccione un subtipo">Filtrar por subtipo</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="dplListarTipos" CssClass="form-controlV2" runat="server">
                    <asp:ListItem Value="Seleccione un tipo">Filtrar por tipo</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="dplDestacado" CssClass="form-controlV2" runat="server">
                    <asp:ListItem Value="filtrar por destacado">Filtrar por destacado</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="dplOferta" CssClass="form-controlV2" runat="server">
                    <asp:ListItem>Filtrar por oferta</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="dplFabricantes" CssClass="form-controlV2" runat="server">
                    <asp:ListItem>Filtrar por fabricante</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="dplOrdenar" CssClass="form-controlV2" runat="server">
                    <asp:ListItem>filtrar por orden</asp:ListItem>
                </asp:DropDownList>
                 <asp:Button ID="btnFiltrarLista" runat="server" class="btn btn-primary buttonFiltrar" Text="Filtrar"/>
            </article>
        </section>
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
