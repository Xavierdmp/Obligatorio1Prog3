<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrarCliente.aspx.cs" Inherits="Obligatorio1.Presentacion.Seccion_Publica.Gestion_Clientes.frmRegistrarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row text-center">
            <div class="col-md-12">
                <h1>Gestion Registrar Clientes</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                 <div class="form-group">
                     <asp:Label ID="Label1" runat="server" CssClass="form-control form-control-lg" Text="Nombre" Font-Bold="False"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" ValidationGroup="vgRegistrarClientes"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe Ingresar Nombre" ForeColor="Red" ValidationGroup="vgRegistrarClientes" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
               </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Apellido" CssClass="form-control form-control-lg"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" ValidationGroup="vgRegistrarClientes"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe Ingresar un Apellido" ForeColor="Red" ControlToValidate="txtApellido" ValidationGroup="vgRegistrarClientes"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Cedula Identidad" CssClass="form-control form-control-lg"></asp:Label>
                    <asp:TextBox ID="txtCedulaIdentidad" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar su CI" ForeColor="Red" ControlToValidate="txtCedulaIdentidad" ValidationGroup="vgRegistrarClientes"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Direccion" CssClass="form-control form-control-lg"></asp:Label>
                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe Ingresar una DIreccion" ForeColor="Red" ValidationGroup="vgRegistrarClientes" ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Telefono" CssClass="form-control form-control-lg"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtTelefono" runat="server" Height="22px" TextMode="Number"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe Ingresar un Telefono" ForeColor="Red" ValidationGroup="vgRegistrarClientes" ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Genero" CssClass="form-control form-control-lg"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtGenero" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debe Ingresar un Genero" ForeColor="Red" ValidationGroup="vgRegistrarClientes"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Correo" CssClass="form-control form-control-lg"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email"></asp:TextBox>
                    <br />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Debe Ingresar un Correo Electronico" ControlToValidate="txtCorreo" ForeColor="Red" ValidationGroup="vgRegistrarCliente"></asp:RequiredFieldValidator>

                </div>
                <div class="form-group">
                    <asp:Label ID="Label8" runat="server" Text="Contraseña"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtContraseña1" runat="server" ValidationGroup="vgRegistrarCliente" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Falta ingresar contraseña" ValidationGroup="vgRegistrarCliente" ControlToValidate="txtCorreo" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label9" runat="server" Text="Ingrese de nuevo contraseña"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtContraseña2" runat="server" TextMode="Password" ValidationGroup="vgRegistrarCliente"></asp:TextBox>
                    <br />
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="las Contraseñas deben coincidir" ControlToCompare="txtContraseña1" ControlToValidate="txtContraseña2" ForeColor="Red"></asp:CompareValidator>
                </div>
                <div class="col-md-12 text-center">
                    <asp:Button ID="btnAlta" runat="server" Text="Alta" Width="366px" CssClass="btn-success active" OnClick="btnAlta_Click" ValidationGroup="vgRegistrarClientes" />
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
