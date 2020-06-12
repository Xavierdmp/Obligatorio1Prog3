<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/SeccionPrivada/SiteMasterPrivate/frmPrivate.Master" AutoEventWireup="true" CodeBehind="frmEliminarCliente.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPrivada.Gestion_Clientes.frmEliminarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid text-center">
        <div class="row">
            <div class="col-md-12">
                <h2>Lista de  Clientes </h2>
            </div>
            <div class="row">

                <div class="col-md-12">
                    <asp:GridView ID="gvListaDeClientes" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="gvListaDeClientes_SelectedIndexChanged" AutoGenerateColumns="False" HorizontalAlign="Center">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField AccessibleHeaderText="Id" DataField="IdCliente" HeaderText="Id" />
                            <asp:BoundField AccessibleHeaderText="Nombre" DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField AccessibleHeaderText="Apellido" DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField AccessibleHeaderText="Cedula Identidad" DataField="CedulaIdentidad" HeaderText="Cedula Identidad" />
                            <asp:BoundField AccessibleHeaderText="Direccion" DataField="Direccion" HeaderText="Direccion" />
                            <asp:BoundField AccessibleHeaderText="Telefono" DataField="Telefono" HeaderText="Telefono" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>

                    <br />



                </div>
            </div>


        </div>
            <usrMensaje:AsignarMensaje ID="lblMensaje" runat="server" />
    </div>

     <!-- Modal -->
    <div class="modal" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Confirmar eliminacion</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body text-center">
                    <asp:Label ID="Label1" runat="server" Text="ID" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblId" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Nombre" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Apellido" Font-Bold="True"></asp:Label>
                   <asp:Label ID="lblApellido" runat="server" Text="Label"> </asp:Label>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Cedula de Identidad" Font-Bold="True"></asp:Label>
                     <asp:Label ID="lblCedulaIdentidad" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Direccion" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblDireccion" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Telefono" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblTelefono" runat="server" Text="Label"></asp:Label>
                </div>
                
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Salir</button>
                    <asp:Button ID="btnBaja" runat="server"  class="btn btn-danger" Text="Eliminar" OnClick="btnBaja_Click" />
                </div>

            </div>
        </div>
    </div>


</asp:Content>
