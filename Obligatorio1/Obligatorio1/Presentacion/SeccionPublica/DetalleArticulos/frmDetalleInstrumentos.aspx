<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDetalleInstrumentos.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPublica.DetalleArticulos.frmDetalleInstrumentos" %>

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
                <asp:Label ID="lblStock" runat="server" Text="Seleccione un color: "></asp:Label>
                <br />
                <asp:Panel ID="ContenedorColores" runat="server"></asp:Panel>
                <br />
                <usrMensaje:AsignarMensaje ID="lblMensaje" runat="server"></usrMensaje:AsignarMensaje>
                <br />
                <asp:Button ID="btnAgregarAlCarrito" CssClass="AgregarCarritoInstrumento btn btn-primary" runat="server" Text="Agregar al Carrito" OnClick="btnAgregarAlCarrito_Click" />
            </article>
        </article>
        <article class="row">
            <article class="col-md-12">

                <div class="embed-responsive embed-responsive-16by9">
                    <h4>Video Presentacion</h4>
                    <iframe id="VideoPresentacion" runat="server" class="embed-responsive-item"></iframe>
                </div>


            </article>

        </article>
       <div class="swiper-container text-center">
        <asp:Panel ID="ContenedorAccesorios" CssClass="swiper-wrapper" runat="server"></asp:Panel>
        </div>
    </section>    
  
  
    <div class="modal" id="CantidadStock" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenteredLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalCenteredLabel">Seleccione una cantidad para comprar</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="Label3" runat="server" Text="Cantidad"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtNuevaCantidad" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnConfirmarCantidadStock" OnClick="btnConfirmarCantidadStock_Click" runat="server" class="btn btn-success" Text="Confirmar" />
                </div>
            </div>
        </div>
    </div>

    <script>
        var swiper = new Swiper('.swiper-container', {
            slidesPerView: 4,
            spaceBetween: 20,
            pagination: {
                el: '.swiper-pagination',
                clickable: true,
            },
        });
                function changeImage(sndr) {
            var changeImage = document.getElementById('<%=ImagenPrincipal.ClientID%>');
                        changeImage.src = sndr.src;
                    };
    </script>
</asp:Content>
