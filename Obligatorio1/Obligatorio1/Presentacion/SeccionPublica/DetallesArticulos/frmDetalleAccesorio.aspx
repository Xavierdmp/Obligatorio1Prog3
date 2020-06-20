<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDetalleAccesorio.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPublica.DetallesArticulos.frmDetalleAccesorio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="container-fluid SeccionPrincipal">
        <article class="row">
            <aside class="col-md-3 ImagenesAdicionales">
                <asp:Panel ID="ImagenesOpcionales" runat="server"></asp:Panel>
            </aside>
            <article class="col-md-5 ArticuloPrincipal">
                <asp:ImageButton ID="ImagenPrincipal" CssClass="ImagenPrincipalDetalle" runat="server" />
            </article>
            <article class="col-md-4 SeccionInformacion">
                <asp:Label ID="lblNombre" CssClass="TituloDetalle" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="Label1" CssClass="AyudantesTitulo" runat="server" Text="Descripcion: "></asp:Label>
                <asp:Label ID="lblDescripcion" CssClass="DescripcionDetalle" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="Label2" CssClass="AyudantesTitulo" runat="server" Text="Fabricante: "></asp:Label>
                <asp:Label ID="lblFabricante" CssClass="FabricanteDetalle" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="lblPrecio" runat="server" CssClass="PrecioDetalle" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="lblStock" runat="server" Text="Label"></asp:Label>
                <asp:DropDownList ID="dplSeleccioneStock" OnSelectedIndexChanged="dplSeleccioneStock_SelectedIndexChanged" runat="server" AppendDataBoundItems="True" AutoPostBack="True">
                    <asp:ListItem>1 Unidad</asp:ListItem>
                    <asp:ListItem>2 Unidades</asp:ListItem>
                    <asp:ListItem>3 Unidades</asp:ListItem>
                    <asp:ListItem>4 Unidades</asp:ListItem>
                    <asp:ListItem>5 Unidades</asp:ListItem>
                    <asp:ListItem>6 Unidades</asp:ListItem>
                    <asp:ListItem>7 Unidades</asp:ListItem>
                    <asp:ListItem>8 Unidades</asp:ListItem>
                    <asp:ListItem>9 Unidades</asp:ListItem>
                    <asp:ListItem>10 Unidades</asp:ListItem>
                       <asp:ListItem> + 10 unidades </asp:ListItem>

                </asp:DropDownList>
                <br />
     <usrMensaje:AsignarMensaje ID="lblMensaje" runat="server"></usrMensaje:AsignarMensaje>

                <asp:Button ID="btnAgregarAlCarrito" runat="server"   onclick="btnAgregarAlCarrito_Click"  Text="Agregar al Carrito" CssClass="btn-primary" Font-Overline="False" Width="100px" />

            </article>

        </article>
    </section>

    <!-- Modal -->
    <div class="modal" id="CantidadStock" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenteredLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalCenteredLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="Label3" runat="server" Text="Cantidad"></asp:Label>
                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnConfirmarCantidadStock" runat="server" Text="Confirmar" OnClick="btnConfirmarCantidadStock_Click" />

                </div>
            </div>
        </div>
    </div>

    <script>
        function changeImage(sndr) {
            var changeImage = document.getElementById('<%=ImagenPrincipal.ClientID%>');
            changeImage.src = sndr.src;
        }
    </script>
</asp:Content>
