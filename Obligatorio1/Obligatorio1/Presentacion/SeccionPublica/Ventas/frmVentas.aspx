<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVentas.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPublica.Ventas.frmVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="container-fluid">
        <section class="row">

            <article class="col-xs-7 col-sm-7 col-md-7 col-lg-7">
                <asp:DropDownList ID="dpListaPais" runat="server" CssClass="form-controlV2" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="dpListaPais_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="dpListaCiudad" runat="server" CssClass="form-controlV2" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="dpListaCiudad_SelectedIndexChanged"></asp:DropDownList>

                <div class="infotarjeta">
                    <asp:TextBox ID="txtNumeroTarjeta" onclick="CambioDeImagenes(1)" placeholder="Numero de tarjeta" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtNombreYApellido" onclick="CambioDeImagenes(3)" placeholder="Nombre y apellido" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Image ID="ImagenTarjeta" runat="server" CssClass="ImagenesTarjetasVentas" />
                    <br />
                    <asp:TextBox ID="txtFechaExpiracion" onclick="CambioDeImagenes(4)" placeholder="Fecha expiracion" CssClass="form-controlV2" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtCodigoSeguridad" onclick="CambioDeImagenes(2)" placeholder="Codigo de seguridad" CssClass="form-controlV2" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:TextBox ID="txtCedulaTitularTarjeta" placeholder="Cl del titular de la tarjeta" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </article>
            <aside class="col-xs-5 col-sm-5 col-md-5 col-lg-5">

                <h4>Articulos</h4>

                <asp:Table ID="ContenedorArticulos" CssClass="table table-responsive" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell> Articulos</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Centidad </asp:TableHeaderCell>
                        <asp:TableHeaderCell>Precio</asp:TableHeaderCell>
                    </asp:TableHeaderRow>

                </asp:Table>
                <asp:Label ID="lblPrecioTotal" runat="server" Text=""></asp:Label>

            </aside>

        </section>
        <section class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <asp:Button ID="btnComprar" CssClass="btn-primary" runat="server" Text="Comprar" OnClick="btnComprar_Click1" />




            </article>


        </section>
    </section>

</asp:Content>
