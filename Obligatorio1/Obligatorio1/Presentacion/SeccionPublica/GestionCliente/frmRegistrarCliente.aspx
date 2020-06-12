<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrarCliente.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPublica.GestionCliente.frmRegistrarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row text-center">
            <div class="col-md-12">
                <h1>Gestion&nbsp; Registrar Clientes</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Nombre" Font-Bold="False"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe Ingresar Nombre" ForeColor="Red" ValidationGroup="vgRegistrar" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Apellido"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe Ingresar un Apellido" ForeColor="Red" ControlToValidate="txtApellido" ValidationGroup="vgRegistrar"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Cedula Identidad"></asp:Label>
                    <asp:TextBox ID="txtCedulaIdentidad" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar su CI" ForeColor="Red" ControlToValidate="txtCedulaIdentidad" ValidationGroup="vgRegistrar"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Direccion"></asp:Label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe Ingresar una DIreccion" ForeColor="Red" ValidationGroup="vgRegistrar" ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Telefono"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtTelefono" runat="server" Height="22px" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe Ingresar un Telefono" ForeColor="Red" ValidationGroup="vgRegistrar" ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <br />
                </div>
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Correo"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                    <br />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Debe Ingresar un Correo Electronico" ControlToValidate="txtCorreo" ForeColor="Red" ValidationGroup="vgRegistrar"></asp:RequiredFieldValidator>

                </div>
                <div class="form-group">
                    <asp:Label ID="Label8" runat="server" Text="Contraseña"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtContraseña1" runat="server" ValidationGroup="vgRegistrarCliente" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Falta ingresar contraseña" ValidationGroup="vgRegistrar" ControlToValidate="txtCorreo" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label9" runat="server" Text="Ingrese de nuevo contraseña"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtContraseña2" runat="server" TextMode="Password" CssClass="form-control" ValidationGroup="vgRegistrarCliente"></asp:TextBox>
                    <br />
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="las Contraseñas deben coincidir" ControlToCompare="txtContraseña1" ControlToValidate="txtContraseña2" ForeColor="Red" ValidationGroup="vgRegistrar"></asp:CompareValidator>
                </div>
                <div class="col-md-12 text-center">
                    <asp:Button ID="btnAlta" runat="server" Text="Alta" Width="366px" CssClass="btn-success active" OnClick="btnAlta_Click" ValidationGroup="vgRegistrar" />
                    <br />
                    <br />
                    <usrMensaje:AsignarMensaje ID="lblMensaje" runat="server" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
