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
        private int IdArticuloSeleccionado
        {
            get {
                int resultado = 0;
                int.TryParse(Session["ColorSeleccionado"].ToString(), out resultado);
                return resultado;
            }
            set { Session["ColorSeleccionado"] = value; }
        }
 

        private void CargarCarrito()
        {
            int IdClienteConectado = int.Parse(Session["ClienteLogueado"].ToString());
            Dominio.Controladoras.ControladoraVentas unaControladora = new Dominio.Controladoras.ControladoraVentas();

            List<Dominio.Item> listaCarrito = unaControladora.ListaCarritoParaCliente(IdClienteConectado);
            int precioTotal = 0;
            foreach(Dominio.Item unItem in listaCarrito)
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
                cantidad.Text = "Cantidad: " + unItem.Cantidad;
                vacio.Controls.Add(cantidad);

                info.Controls.Add(vacio);
                Label precio = new Label();
                precio.CssClass = "Precio";
                precio.Text = "$" + unItem.Articulo.Precio + " ";

                Dominio.Instrumento unInstrumento = unItem.Articulo as Dominio.Instrumento;
                info.Controls.Add(precio);
                if (unInstrumento != null)
                {
                    if(unInstrumento.Descuento > 0)
                    {
                        Label descuento = new Label();
                        descuento.CssClass = "CarritoDescuento";
                        descuento.Text = "off %" + unInstrumento.Descuento.ToString();
                        info.Controls.Add(descuento);
                    }
                    Label color = new Label();
                    color.CssClass = "ColorCarrito";
                    color.Text = unItem.Color.Nombre;
                }

                LinkButton cambiarCantidad = new LinkButton();
                cambiarCantidad.CssClass = "CambiarCantidadCarrito";
                cambiarCantidad.Click += this.cambiarCantidad_Click;
                cambiarCantidad.ID = unItem.Articulo.Nombre;
                cambiarCantidad.Text = "Cambiar cantidad";
                info.Controls.Add(cambiarCantidad);
                
                columnaInfo.Controls.Add(info);

                ItemCarrito.Controls.Add(columnaImg);
                ItemCarrito.Controls.Add(columnaInfo);
                contenedorCarrito.Controls.Add(ItemCarrito);
                this.ContenedorProductos.Controls.Add(contenedorCarrito);
                precioTotal += unItem.Precio;
            }
            this.lblPrecioTotal.Text = "$" + precioTotal.ToString();

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

        protected void cambiarCantidad_Click(object sender, EventArgs e)
        {
            LinkButton clickeado = (LinkButton)sender;
            Dominio.Controladoras.ControladoraInstrumentos controladoraInstrumento = new Dominio.Controladoras.ControladoraInstrumentos();
            Dominio.Controladoras.ControladoraAccesorio unaControladoraAccesorio = new Dominio.Controladoras.ControladoraAccesorio();
            Dominio.Controladoras.ControladoraVentas unaControladoraVentas = new Dominio.Controladoras.ControladoraVentas();
            int IdArticulo = unaControladoraVentas.IdArticuloSegunSuNombre(clickeado.ID);
            Dominio.Instrumento unInstrumento = controladoraInstrumento.Buscar(IdArticulo);
            Dominio.Accesorio unAccesorio = unaControladoraAccesorio.Buscar(IdArticulo);
            if (unInstrumento != null)
            {
                IdArticuloSeleccionado = IdArticulo;
                int IdClienteConectado = int.Parse(Session["ClienteLogueado"].ToString());
                int stockDisponible = unaControladoraVentas.CantidadColorDisponibleParaCambiar(IdArticulo, IdClienteConectado);
                this.lblStockDisponibleInstrumento.Text = "| stock disponible: "  + stockDisponible + "|";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#ModalInstrumentos').modal();", true);
            }
            else if(unAccesorio != null)
            {
                IdArticuloSeleccionado = IdArticulo;
                this.lblCantidadDisponibleAccesorio.Text = "| stock disponible: " + unAccesorio.Stock +"|";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#ModalAccesorios').modal();", true);
            }
        }

        protected void btnConfirmarNuevaCantidadAccesorio_Click(object sender, EventArgs e)
        {
            Dominio.Controladoras.ControladoraAccesorio unaControladoraAccesorio = new Dominio.Controladoras.ControladoraAccesorio();
            Dominio.Accesorio unAccesorio = unaControladoraAccesorio.Buscar(IdArticuloSeleccionado);
            int IdClienteConectado = int.Parse(Session["ClienteLogueado"].ToString());
            Dominio.Controladoras.ControladoraVentas unaControladoraVentas = new Dominio.Controladoras.ControladoraVentas();
            int cantidadNueva = int.Parse(this.txtCantidadAccesorio.Text);
            int precioNuevo = unAccesorio.Precio * cantidadNueva;
<<<<<<< HEAD
            if(unaControladoraVentas.ModificarCantidadCarrito(IdArticuloSeleccionado,IdClienteConectado,cantidadNueva, precioNuevo))
=======
            if (cantidadNueva > 0 && cantidadNueva <= unAccesorio.Stock)
>>>>>>> 36ef8c5... se arreglo el comprobar link de youtube en el frm instrumentos
            {

            }
            else
            {

            }
        }

        protected void btnConfrimarNuevaCantidadInstrumento_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

=======
            int IdClienteConectado = int.Parse(Session["ClienteLogueado"].ToString());
            Dominio.Controladoras.ControladoraInstrumentos unaControladoraInstrumento = new Dominio.Controladoras.ControladoraInstrumentos();
            Dominio.Instrumento unInstrumento = unaControladoraInstrumento.Buscar(IdArticuloSeleccionado);
            Dominio.Controladoras.ControladoraCarrito unaControladoraCarrito = new Dominio.Controladoras.ControladoraCarrito();
            int cantidadNueva = int.Parse(this.txtNuevaCantidadINstrumento.Text);
            int precio = unInstrumento.Precio * cantidadNueva;
            int StockDisponibleDadoElColor = unaControladoraCarrito.CantidadColorDisponibleParaCambiar(IdArticuloSeleccionado, IdClienteConectado);
            if(cantidadNueva >0 && cantidadNueva <= StockDisponibleDadoElColor)
            {
                if (unaControladoraCarrito.ModificarCantidadCarrito(IdArticuloSeleccionado, IdClienteConectado, cantidadNueva, precio))
                {
                    this.ContenedorProductos.Controls.Clear();
                    this.CargarCarrito();
                }
            } 
            else
            {
                this.lblMensaje.MensajeActivo(2, "No hay stock disponible para la cantidad seleccionada:  " + cantidadNueva + " para: el Instrumento " + unInstrumento.Nombre);
            }
>>>>>>> 36ef8c5... se arreglo el comprobar link de youtube en el frm instrumentos
        }
    }
}