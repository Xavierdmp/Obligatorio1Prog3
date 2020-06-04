<%@ Page Title="Inciciar Sesion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmIniciarSesion.aspx.cs" Inherits="Obligatorio1.Presentacion.Autenticación.frmIniciarSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid text-center DivPrincipal">
        <div class="row">
            <div class="col-md-12">
                <div class="fas fa-user"></div>
                <span class="TituloLogin">Iniciar Sesion</span>
                <hr />
            </div>
            <div class="row SectionLogin">
                <div class="col-md-12">
                    <div class="group-form">
                      <asp:TextBox ID="txtCorreo" runat="server" placeholder="Tu email" CssClass="InputsLogin" TextMode="Email"></asp:TextBox>
                        <br />
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="debe completar todos los campos" ForeColor="#990000" ValidationGroup="vgLogin" ControlToValidate="txtCorreo"></asp:RequiredFieldValidator>
                    </div>
                    <div class="group-form">
                        <asp:TextBox ID="txtContraseña" runat="server" placeholder="Contraseña" CssClass="InputsLogin" TextMode="Password"></asp:TextBox>
                        <br />
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="debe completar todos los campos" ForeColor="#990000" ValidationGroup="vgLogin" ControlToValidate="txtContraseña"></asp:RequiredFieldValidator>
                        <br />
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
                    <usrmensaje:asignarmensaje ID="lblMensaje" runat="server"></usrmensaje:asignarmensaje>
                </div>
        </div>
    </div>


    </div>
</asp:Content>
