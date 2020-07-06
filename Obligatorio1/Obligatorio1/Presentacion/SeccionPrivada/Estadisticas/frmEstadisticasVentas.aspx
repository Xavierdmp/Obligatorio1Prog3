<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/SeccionPrivada/SiteMasterPrivate/frmPrivate.Master" AutoEventWireup="true" CodeBehind="frmEstadisticasVentas.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPrivada.Estadisticas.frmEstadisticasVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="container-fluid">
        <section class="row text-center">
            <article class="col-md-12">
                <h1>Estadisticas sobre ventas</h1>
            </article>
        </section>
        <section class="row text-center">
            <article class="col-md-12">
                <asp:TextBox ID="txtFechaDesde" class="form-controlV2" placeholder="Fecha" TextMode="Date" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtFechaHasta" class="form-controlV2" TextMode="Date" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltrar" CssClass="btn btn-primary" runat="server" Text="Filtrar" />
            </article>
        </section>
        <section class="row">
            <article class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gvListarVentas" runat="server" HorizontalAlign="Center" CssClass="table" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="None" Width="846px" EmptyDataText="No hay instrumentos registrados" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnSelectedIndexChanged="gvListarVentas_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ControlStyle-Font-Size="2em" AccessibleHeaderText="Ver detalle" HeaderText="Ver detalle" SelectText="&lt;i class=&quot;fas fa-expand-alt&quot;&gt;&lt;/i&gt;">
                                <ControlStyle Font-Size="1.5em" ForeColor="green"></ControlStyle>

                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                            <asp:BoundField AccessibleHeaderText="Id Venta" DataField="Id" HeaderText="Id Venta" />
                            <asp:BoundField AccessibleHeaderText="Costo" DataField="MontoTotal" HeaderText="Costo" />
                            <asp:BoundField AccessibleHeaderText="Nombre cliente" DataField="NombreCliente" HeaderText="Nombre cliente" />
                            <asp:BoundField AccessibleHeaderText="Fecha venta" DataField="Fecha" HeaderText="Fecha venta" />
                            <asp:BoundField AccessibleHeaderText="Pais Cliente" DataField="Pais" HeaderText="Pais Cliente" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />
                    </asp:GridView>
                </div>
            </article>
        </section>






        <div class="modal" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title text-center" id="exampleModalLabel">Detalle de Venta</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                    <div class="modal-body text-center">
                        <asp:Label ID="Label1" Font-Bold="true" runat="server" Text="Id venta: "></asp:Label>
                        <asp:Label ID="lblIdVenta" runat="server" Text="Label"></asp:Label>
                        <br />
                        <asp:Label ID="Label3" Font-Bold="true" runat="server" Text="Fecha venta: "></asp:Label>
                        <asp:Label ID="lblFechaVenta" runat="server" Text="Label"></asp:Label>
                        <br />
                        <asp:Label ID="Label5" Font-Bold="true" runat="server" Text="Nombre Cliente: "></asp:Label>
                        <asp:Label ID="lblNombreCliente" runat="server" Text="Label"></asp:Label>
                        <br />

                        <asp:Label ID="Label7" Font-Bold="true" runat="server" Text="Monto total: "></asp:Label>
                        <asp:Label ID="lblMontoTotal" runat="server" Text="Label"></asp:Label>
                        <br />

                        <asp:Label ID="Label9" Font-Bold="true" runat="server" Text="Pais: "></asp:Label>
                        <asp:Label ID="lblNombrePais" runat="server" Text="Label"></asp:Label>
                        <br />

                        <asp:Label ID="Label11" Font-Bold="true" runat="server" Text="Ciudad: "></asp:Label>
                        <asp:Label ID="lblCiudad" runat="server" Text="Label"></asp:Label>
                        <br />

                        <asp:Label ID="Label13" Font-Bold="true" runat="server" Text="Tarjeta: "></asp:Label>
                        <asp:Label ID="lblTarjeta" runat="server" Text="Label"></asp:Label>
                        <br />


                        <h3 class="text-center">Lista de Articulos</h3>
                        <div class="table-responsive">
                            <asp:GridView ID="gvListaDeItemsComprados" runat="server" HorizontalAlign="Center" CssClass="table" BackColor="White" BorderColor="#336666" GridLines="None" EmptyDataText="No hay instrumentos registrados" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnSelectedIndexChanged="gvListarVentas_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField AccessibleHeaderText="Nombre Articulo" DataField="NombreArticulo" HeaderText="Nombre Articulo" />
                                    <asp:BoundField AccessibleHeaderText="Cantidad" DataField="Cantidad" HeaderText="Cantidad" />
                                    <asp:BoundField AccessibleHeaderText="Precio" DataField="Precio" HeaderText="Precio" />
                                    <asp:BoundField AccessibleHeaderText="Nombre Color" DataField="NombreColor" HeaderText="Nombre Color" />
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#333333" />
                                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

    </section>



</asp:Content>
