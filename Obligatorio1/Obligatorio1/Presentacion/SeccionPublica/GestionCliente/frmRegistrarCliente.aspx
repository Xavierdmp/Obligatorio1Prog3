<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrarCliente.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPublica.GestionCliente.frmRegistrarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <section class="DivPrincipal">
            <div class="row text-center">
                <div class="col-md-12">
                    <div class="fas fa-user"></div>
                    <span class="TituloLogin">Registrarse</span>
                    <hr />
                </div>
            </div>
            <div class="row">
                <article class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Nombre" Font-Bold="False"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass=" form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe Ingresar Nombre" ForeColor="Red" ValidationGroup="vgRegistrar" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Telefono"></asp:Label>
                        <asp:TextBox ID="txtTelefono" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe Ingresar un Telefono" ForeColor="Red" ValidationGroup="vgRegistrar" ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Cedula Identidad"></asp:Label>
                        <asp:TextBox ID="txtCedulaIdentidad" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar su CI" ForeColor="Red" ControlToValidate="txtCedulaIdentidad" ValidationGroup="vgRegistrar"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Direccion"></asp:Label>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe Ingresar una Direccion" ForeColor="Red" ValidationGroup="vgRegistrar" ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>
                    </div>
                </article>
                <aside class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Apellido"></asp:Label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe Ingresar un Apellido" ForeColor="Red" ControlToValidate="txtApellido" ValidationGroup="vgRegistrar"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label7" runat="server" Text="Correo" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debe Ingresar correo" ControlToValidate="txtCorreo" ForeColor="Red" ValidationGroup="vgRegistrar"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="txtContraseña1" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Debe Ingresar contraseña" ForeColor="Red" ValidationGroup="vgRegistrar" ControlToValidate="txtContraseña1"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label9" runat="server" Text="Confirme contraseña"></asp:Label>
                        <asp:TextBox ID="txtContraseña2" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="las Contraseñas deben coincidir" ControlToCompare="txtContraseña1" ControlToValidate="txtContraseña2" ForeColor="Red" ValidationGroup="vgRegistrar"></asp:CompareValidator>
                    </div>
                </aside>
            </div>
            <div class="row">
                <div class="col-md-12 text-center">
                    <usrMensaje:AsignarMensaje ID="lblMensaje" runat="server" />
                    <asp:Button ID="btnAlta" runat="server" Text="Alta" Width="366px" CssClass="btn btn-primary" OnClick="btnAlta_Click" ValidationGroup="vgRegistrar" />
                </div>
            </div>
        </section>
    </div>


</asp:Content>
