using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPublica.Ventas
{
    public partial class frmVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GenerarArticulos();
            this.ListarPaises();
            
        }

        private void GenerarArticulos()
        {
            Dominio.Controladoras.ControladoraCarrito unaControladora = new Dominio.Controladoras.ControladoraCarrito();
            int IdClienteConectado = int.Parse(Session["ClienteLogueado"].ToString());

            List<Dominio.Item> listaArticulos = unaControladora.ListaCarritoParaCliente(IdClienteConectado);
            int montoTotal = 0;
            foreach(Dominio.Item unItem in listaArticulos)
            {
                TableRow fila = new TableRow();
                TableCell celdaImagen = new TableCell();
                Image imagen = new Image();
                imagen.ImageUrl = unItem.Articulo.FotoPrincipal;
                imagen.CssClass = "ImagenItemsVentas";
                TableCell celdaCantidad = new TableCell();
                TableCell celdaPrecio = new TableCell();
                celdaImagen.Controls.Add(imagen);
                celdaCantidad.Text = unItem.Cantidad.ToString();
                celdaPrecio.Text = "$" + unItem.Precio;

                fila.Cells.Add(celdaImagen);
                fila.Cells.Add(celdaCantidad);
                fila.Cells.Add(celdaPrecio);
                this.ContenedorArticulos.Rows.Add(fila);
                montoTotal += unItem.Precio;
            }
            this.lblPrecioTotal.Text = "Precio Total: " + " $" +montoTotal;

        }

        private Dominio.Controladoras.ControladoraVentas Instancia()
        {
            return Dominio.Controladoras.ControladoraVentas.Instancia;
        }

        private void ListarPaises()
        {
            this.dplListaPaises.DataSource = null;
            this.dplListaPaises.DataSource = this.Instancia().ListarPaises();
            this.dplListaPaises.DataBind();
        }

        private void ListarCiudades(string pNombrePais)
        {
            this.dplListaCiudades.DataSource = null;
            this.dplListaCiudades.DataSource = this.Instancia().ListarCiudadesDadoPais(pNombrePais);
            this.dplListaCiudades.DataBind();
        }

        protected void dplListaPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.dplListaPaises.SelectedIndex > 0)
            {
                string nombrePais = this.dplListaPaises.SelectedValue;
                Session["PaisSeleccionado"] = nombrePais;
                this.dplListaCiudades.ClearSelection();
                this.dplListaCiudades.Items.Clear();
                this.ListarCiudades(nombrePais);

            }
        }

        protected void dplListaCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.dplListaCiudades.SelectedIndex > 0)
            {
                string nombreCiudad = this.dplListaCiudades.SelectedValue;
                Session["CiudadSeleccionada"] = nombreCiudad;
            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Dominio.Controladoras.ControladoraCarrito unaControladoraCarrito = new Dominio.Controladoras.ControladoraCarrito();
            Dominio.Controladoras.ControladoraCliente unaControladoraCliente = new Dominio.Controladoras.ControladoraCliente();
            int IdClienteConectado = int.Parse(Session["ClienteLogueado"].ToString());

            string numeroTarjeta = this.txtNumeroTarjeta.Text;
            string pais = Session["PaisSeleccionado"].ToString();
            string ciudad = Session["CiudadSeleccionada"].ToString();
            DateTime fecha = DateTime.Now;
            List<Dominio.Item> listaArticulos = unaControladoraCarrito.ListaCarritoParaCliente(IdClienteConectado);
            Dominio.Cliente unCliente = unaControladoraCliente.Buscar(IdClienteConectado);

            Dominio.Venta unaVenta = new Dominio.Venta(fecha,listaArticulos,unCliente,numeroTarjeta,pais,ciudad);

            if (this.Instancia().Alta(unaVenta))
            {

            }
        }
    }
}