﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/SeccionPrivada/SiteMasterPrivate/frmPrivate.Master" AutoEventWireup="true" CodeBehind="frmGestionInstrumento.aspx.cs" Inherits="Obligatorio1.Presentacion.SeccionPrivada.GestionArticulos.frmGestionInstrumento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">

        <div class="row text-center" style="margin-bottom: 20px;">
            <div class="col-md-12">
                <h1>Gestion de Instrumento</h1>
            </div>
        </div>
        <section class="row" style="margin-top: 50px;">
            <article class="col-md-3">
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Nombre" Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" placeholder="Ingrese nombre" class="form-control" Width="281px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio" ForeColor="#CC3300" ValidationGroup="vgGestion"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Descripcion" Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Ingrese una descripcion" class="form-control" TextMode="MultiLine" Width="281px" Height="35px" Style="resize: none;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="La descripcion es obligatoria" ForeColor="#CC3300" ValidationGroup="vgGestion"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Fabricante" Font-Bold="True"></asp:Label>
                    <asp:DropDownList ID="dplListaFabricante" runat="server" class="form-control" Width="281px" AutoPostBack="True" AppendDataBoundItems="True">
                        <asp:ListItem>Seleccione un fabricante</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Imagen principal" Font-Bold="True"></asp:Label>
                    <asp:FileUpload ID="fuImagenPrincipal" runat="server" class="form-control" Width="281px" ToolTip="Seleccione una imagen principal" />
                </div>
            </article>
            <article class="col-md-3">
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Precio" Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="txtPrecio" runat="server" placeholder="Ingrese un Precio" class="form-control" Width="281px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPrecio" ErrorMessage="El precio es obligatorio" ForeColor="#CC3300" ValidationGroup="vgGestion"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Stock" Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="txtStock" runat="server" placeholder="Ingrese stock" class="form-control" Width="281px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStock" ErrorMessage="El stock es obligatorio" ForeColor="#CC3300" ValidationGroup="vgGestion"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Subtipo" Font-Bold="True"></asp:Label>
                    <asp:DropDownList ID="dplListarSubtipo" runat="server" class="form-control" Width="280px" AutoPostBack="True" AppendDataBoundItems="True">
                        <asp:ListItem>Seleccione un subtipo de instrumento</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </article>
            <aside class="col-md-6 text-center">
                <br />
                <div class="DivFotosAdicionales">
                    <div class="form-group">
                        <asp:Label ID="Label10" runat="server" Text="Las fotos adicionales son opcionales" Font-Bold="True" CssClass="TextoFotoAdicional"></asp:Label>
                    </div>
                    <hr />
                    <div class="form-group table-responsive">
                        <asp:Label ID="Label8" runat="server" Text="Fotos Adicionales" Font-Bold="True" CssClass="TextoFotoAdicional"></asp:Label>
                        <asp:FileUpload ID="fuFotosAdicionales" runat="server" class="form-control cargarFotosAdicionales" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnAgregarImagenAdicional" runat="server" class="btn btn-success" Text="Agregar foto adicional" />
                    </div>
                    <div class="form-group table-responsive">
                        <asp:GridView ID="gvListarImagenesAdicionales" runat="server" EmptyDataText="No hay imagenes adicionales" ShowHeaderWhenEmpty="True" Height="16px" Width="57px" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:CommandField SelectText="&lt;i class=&quot;fas fa-trash&quot;&gt;&lt;/i&gt;" ShowSelectButton="True" AccessibleHeaderText="Eliminar" HeaderText="Eliminar" />
                                <asp:ImageField DataImageUrlField="Url" HeaderText="Imagen">
                                    <ControlStyle Height="50px" Width="120px" />
                                </asp:ImageField>
                                <asp:BoundField AccessibleHeaderText="Url" DataField="Url" HeaderText="Url">
                                    <ControlStyle Font-Size="5px" />
                                </asp:BoundField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </div>
                </div>
            </aside>
        </section>
        <section class="row">
            <article class="col-md-3">
                <div class="form-group">
                    <asp:Label ID="Label11" runat="server" Text="Fecha Fabricacion" Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="txtFechaFabricacion" runat="server" placeholder="Ingrese Fecha" class="form-control" Width="281px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label13" runat="server" Text="Url Video" Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="txtVideoYoutube" runat="server" placeholder="Ingrese una url" class="form-control" Width="281px" TextMode="Url"></asp:TextBox>
                </div>
            </article>

            <article class="col-md-3">
                <div class="form-group">
                    <asp:Label ID="Label12" runat="server" Text="Descuento" Font-Bold="True"></asp:Label>
                    <asp:DropDownList ID="dplListaDescuentos" runat="server" AppendDataBoundItems="True" class="form-control" Width="281px" AutoPostBack="True">
                        <asp:ListItem>Seleccione un descuento</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label14" runat="server" Text="Destacado" Font-Bold="True"></asp:Label>
                    <asp:DropDownList ID="dplDestacado" runat="server" AppendDataBoundItems="True" class="form-control" Width="281px" AutoPostBack="True">
                        <asp:ListItem Value="Seleccione si es destacado"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </article>
            <aside class="col-md-6">
                <div class="form-group">
                    <asp:Label ID="Label15" runat="server" Text="Colores: " Font-Bold="True"></asp:Label>
                    <asp:DropDownList ID="dplListarColores" runat="server" class="form-control" Width="281px" AppendDataBoundItems="True" AutoPostBack="True">
                        <asp:ListItem>Seleccionar un Color</asp:ListItem>
                    </asp:DropDownList>
                        <asp:Button ID="btnAgregarColor" runat="server" Text="Agregar Color"  CssClass="AgregarColor btn btn-success"/>
                </div>
            </aside>
        </section>

        <section class="row text-center">
            <div class="col-md-12">
                <usrMensaje:AsignarMensaje ID="lblMensaje" runat="server" />
                <br />
                <asp:Button ID="btnAlta" runat="server" Text="Registar" class="btn btn-success" ValidationGroup="vgGestion" />
                <asp:Button ID="btnBaja" runat="server" Text="Eliminar" class="btn btn-danger" ValidationGroup="vgGestion" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-primary" ValidationGroup="vgGestion" />
            </div>
        </section>
        <section class="row text-center">
            <div class="col-md-12">
                <asp:Label ID="Label9" runat="server" Text="Lista de accesorios" Font-Bold="True"></asp:Label>
                <br />
                <div class="table-responsive">
                    <asp:GridView ID="gvListarAccesorios" runat="server" HorizontalAlign="Center" CssClass="table" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="None" Width="846px" EmptyDataText="No hay accesorios registrados" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" AccessibleHeaderText="Editar-Modificar" HeaderText="Editar-Modificar" SelectText="&lt;i class=&quot;far fa-edit&quot;&gt;&lt;/i&gt;">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                            <asp:BoundField AccessibleHeaderText="Id" DataField="Id" HeaderText="Id" />
                            <asp:BoundField AccessibleHeaderText="Nombre" DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField AccessibleHeaderText="Descripcion" DataField="Descripcion" HeaderText="Descripcion" />
                            <asp:BoundField AccessibleHeaderText="IdFabricante" DataField="IdFabricante" HeaderText="IdFabricante" />
                            <asp:BoundField AccessibleHeaderText="Precio" DataField="Precio" HeaderText="Precio" />
                            <asp:BoundField AccessibleHeaderText="Stock" DataField="Stock" HeaderText="Stock" />
                            <asp:BoundField AccessibleHeaderText="IdSubtipo" DataField="IdSubtipo" HeaderText="IdSubtipo" />
                            <asp:ImageField AccessibleHeaderText="FotoPrincipal" DataImageUrlField="FotoPrincipal" HeaderText="FotoPrincipal">
                                <ControlStyle Height="30px" Width="90px" />
                            </asp:ImageField>
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
        </section>

    </div>
</asp:Content>
