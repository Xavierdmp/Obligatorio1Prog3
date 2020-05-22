<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/SeccionPrivada/SiteMasterPrivate/frmPrivate.Master" AutoEventWireup="true" CodeBehind="frmTiposInstrumentos.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPrivada.GestionTipos.frmTiposInstrumentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid text-center">

        <div class="row text-center">
            <div class="col-md-12">
                <h1>Gestion de Tipos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">

                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Nombre : "></asp:Label>
                    <br>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="EstiloTexbox"></asp:TextBox>
                    <br />
                    <br />
                    <usrMensaje:AsignarMensaje ID="lblMensaje" runat="server"></usrMensaje:AsignarMensaje>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Button ID="btnAltaTipo" runat="server" CssClass="btn btn-success" Text="Ingresar" OnClick="btnAltaTipo_Click" />
                <asp:Button ID="btnEliminarTipo" runat="server" CssClass="btn btn-danger" Text=" Eliminar" OnClick="btnEliminarTipo_Click" />
                <asp:Button ID="btnModficar" runat="server" CssClass="btn btn-success" Text=" Modificar" OnClick="btnModficar_Click" />

            </div>
        </div>
        <br />
        <br />

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="GvListarTipos" runat="server" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GvListarTipos_SelectedIndexChanged" Width="536px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>

            </div>
        </div>

    </div>
</asp:Content>
