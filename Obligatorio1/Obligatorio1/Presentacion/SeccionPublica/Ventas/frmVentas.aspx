<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVentas.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPublica.Ventas.frmVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="container-fluid">
        <section class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <asp:DropDownList ID="dplListaPaises" CssClass="form-controlV2" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="dplListaPaises_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un pais</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="dplListaCiudades" CssClass="form-controlV2" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="dplListaCiudades_SelectedIndexChanged">
                    <asp:ListItem>Seleccione una ciudad</asp:ListItem>
                </asp:DropDownList>
                <hr />
            </article>
        </section>
        <section class="row">
            <article class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                <div class="InfoTarjeta">
                    <asp:TextBox ID="txtNumeroTarjeta" onclick="CambioDeImagenes(1)" placeholder="Numero de tarjeta" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtNombreYApellido" onclick="CambioDeImagenes(3)" placeholder="Nombre y apellido" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtFechaExpiracion" onclick="CambioDeImagenes(4)" placeholder="Fecha expiracion" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtCodigoSeguridad" onclick="CambioDeImagenes(2)" placeholder="Codigo de seguridad" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtCedulaTitularTarjeta" placeholder="Cl del titular de la tarjeta" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </article>
            <article class="col-xs-5 col-sm-5 col-md-5 col-lg-5">
                <asp:Image ID="ImagenTarjeta" runat="server" CssClass="img-fluid ImagenesTarjetasVentas" />
            </article>
            <aside class="col-xs-5 col-sm-5 col-md-5 col-lg-5">
                <h4>Articulos</h4>
                <asp:Table ID="ContenedorArticulos" CssClass="table table-responsive" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>Articulo</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Precio</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
                <asp:Label ID="lblPrecioTotal" runat="server"></asp:Label>
            </aside>
        </section>
        <section class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <asp:Button ID="btnComprar" CssClass="btn btn-primary" runat="server" Text="Comprar" OnClick="btnComprar_Click" />
            </article>
        </section>

    </section>
</asp:Content>
