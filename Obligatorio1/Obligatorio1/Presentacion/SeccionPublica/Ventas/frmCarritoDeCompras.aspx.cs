using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPublica.Ventas
{
    public partial class frmCarritoDeCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.CargarCarrito();
            }
            else
            {
                this.CargarCarrito();
            }
        }
 

        private void CargarCarrito()
        {
            int IdClienteConectado = int.Parse(Session["ClienteLogueado"].ToString());
            Dominio.Controladoras.ControladoraVentas unaControladora = new Dominio.Controladoras.ControladoraVentas();

            List<Dominio.Item> listaCarrito = unaControladora.ListaCarritoParaCliente(IdClienteConectado);

            int PrecioTotal = 0;

            foreach (Dominio.Item unItem in listaCarrito)
            {
                Panel contenedorCarrito = new Panel();
                contenedorCarrito.CssClass = "contanedorCarrito";
                Panel ItemCarrito = new Panel();
                ItemCarrito.CssClass = "row ItemCarrito";

                Panel columnaImg = new Panel();
                columnaImg.CssClass = "col-md-4 col-4 col-sm-4";
                ImageButton imagen = new ImageButton();
                imagen.ImageUrl = unItem.Articulo.FotoPrincipal;
                imagen.CssClass = "ImagenPrueba";
                columnaImg.Controls.Add(imagen);

                Panel columnaInfo = new Panel();
                columnaInfo.CssClass = "col-md-8 col-8 col-sm-8";

                Panel info = new Panel();
                info.CssClass = "Info";
                Button cerrar = new Button();
                cerrar.CssClass = "Cerrar close";
                cerrar.Attributes.Add("arial-label", "Close");
                cerrar.Text = "×";
                cerrar.ID = unItem.Articulo.Id.ToString();
                cerrar.Click += this.Eliminar_Producto_Click;

                info.Controls.Add(cerrar);
                Label titulo = new Label();
                titulo.CssClass = "Titulo";
                titulo.Text = unItem.Articulo.Nombre;
                info.Controls.Add(titulo);

                Panel vacio = new Panel();
                Label cantidad = new Label();
                cantidad.CssClass = "CambiarCantidad";
                cantidad.Text = "Cambiar Cantidad";
                vacio.Controls.Add(cantidad);

                info.Controls.Add(vacio);
                Label precio = new Label();
                precio.CssClass = "Precio";
                precio.Text = "$" + unItem.Articulo.Precio;

                info.Controls.Add(precio);
                columnaInfo.Controls.Add(info);

                ItemCarrito.Controls.Add(columnaImg);
                ItemCarrito.Controls.Add(columnaInfo);
                contenedorCarrito.Controls.Add(ItemCarrito);

                this.ContenedorProductos.Controls.Add(contenedorCarrito);
                PrecioTotal += unItem.Precio;

            }
            this.LblPrecioTotal.Text = PrecioTotal.ToString();

        }

        protected void Eliminar_Producto_Click(object sender, EventArgs e)
        {
            Button clickeado = (Button)sender;
            int IdArticulo = int.Parse(clickeado.ID);
            int IdClienteConectado = int.Parse(Session["ClienteLogueado"].ToString());
            Dominio.Controladoras.ControladoraVentas unaControladora = new Dominio.Controladoras.ControladoraVentas();
            if (unaControladora.BajaArticuloCarrito(IdArticulo, IdClienteConectado))
            {
                this.ContenedorProductos.Controls.Clear();
                this.CargarCarrito();
            }
        }

    }
}