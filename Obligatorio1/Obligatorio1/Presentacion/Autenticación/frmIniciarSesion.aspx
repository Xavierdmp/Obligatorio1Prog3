<%@ Page Title="Iniciar Sesion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmIniciarSesion.aspx.cs" Inherits="Obligatorio1.Presentacion.Autenticación.frmIniciarSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container-fluid text-center ">
            <section class=" DivPrincipal">
            <div class="row">
                <div class="col-md-12">
                    <div class="fas fa-user"></div>
                    <span class="TituloLogin">Iniciar Sesion</span>
                    <hr />
                </div>
            </div>
            <div class="row SectionLogin">
                <div class="col-md-12">
                    <div class="group-form">
                        <asp:TextBox ID="txtCorreo" runat="server" placeholder="Tu email" CssClass="InputsLogin" TextMode="Email" Width="220px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="debe completar todos los campos" ForeColor="#990000" ValidationGroup="vgLogin" ControlToValidate="txtCorreo"></asp:RequiredFieldValidator>
                    </div>
                    <div class="group-form">
                        <asp:TextBox ID="txtContraseña" runat="server" placeholder="Contraseña" CssClass="InputsLogin" TextMode="Password" Width="220px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="debe completar todos los campos" ForeColor="#990000" ValidationGroup="vgLogin" ControlToValidate="txtContraseña"></asp:RequiredFieldValidator>
                        <a href="#">Recuperar Contraseña</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Button ID="btnIniciarSesion" runat="server" Text="Confirmar" CssClass="ConfirmarLogin" OnClick="btnIniciarSesion_Click" ValidationGroup="vgLogin" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <usrMensaje:AsignarMensaje ID="lblMensaje" runat="server"></usrMensaje:AsignarMensaje>
                </div>
            </div>
                </section>
        </div>
   

</asp:Content>
