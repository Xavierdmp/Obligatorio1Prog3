<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListadoArticulos.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPublica.ListadoArticulos.frmListadoArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section class="container-fluid">
            <asp:Panel ID="ContenedorPrincipal" CssClass="row text-center ContenedorPrincipalListado" runat="server"></asp:Panel>
            
         <asp:Button ID="Button1" runat="server" Text="Siguiente" OnClick="Button1_Click" />

    </section>
</asp:Content>
