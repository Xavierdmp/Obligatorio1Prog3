<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCarritoDeCompras.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPublica.Ventas.frmCarritoDeCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="container-fluid">
        <h4 style="margin-top: 50px;">Carrito de compras</h4>
        <hr />
        <asp:Panel ID="ContenedorProductos" runat="server"></asp:Panel>
        <article class="row">
            <article class="col-md-12">
                
                <asp:Label ID="LblPrecioTotal" runat="server" Text="Label"></asp:Label>


            </article>
        </article>
    </section>

</asp:Content>
