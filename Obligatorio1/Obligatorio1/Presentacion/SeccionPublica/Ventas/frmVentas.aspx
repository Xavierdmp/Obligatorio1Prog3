<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVentas.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPublica.Ventas.frmVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="container-fluid">
        <section class="row">
            <article class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                <asp:DropDownList ID="dplListaPaises" CssClass="form-controlV2" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="dplListaCiudades" CssClass="form-controlV2" runat="server"></asp:DropDownList>
                <hr />
                <div class="InfoTarjeta">
                    <asp:TextBox ID="txtNumeroTarjeta" placeholder="Numero de tarjeta" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtNombreYApellido" placeholder="Nombre y apellido" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtFechaExpiracion" placeholder="Fecha expiracion" CssClass="form-controlV2" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtCodigoSeguridad" placeholder="Codigo de seguridad" CssClass="form-controlV2" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:TextBox ID="txtCedulaTitularTarjeta" placeholder="Cl del titular de la tarjeta" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </article>
            <aside class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
            </aside>
        </section>
        <section class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <asp:Button ID="btnComprar" CssClass="btn btn-primary" runat="server" Text="Comprar" />
            </article>
        </section>

    </section>
</asp:Content>
