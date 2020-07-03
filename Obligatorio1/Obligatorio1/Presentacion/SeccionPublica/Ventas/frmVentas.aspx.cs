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
            if (!this.IsPostBack)
            {
                 this.GenerarArticulos();
                this.ListarPaises();
            }
        }


        private void GenerarArticulos()
        {
            Dominio.Controladoras.ControladoraCarrito unaControladora = new Dominio.Controladoras.ControladoraCarrito();

            int idClienteConectado = int.Parse(Session["ClienteLogueado"].ToString());

            List<Dominio.Item> ListadeArticulos = unaControladora.ListaCarritoParaCliente(idClienteConectado);

            int montototal = 0;


            foreach (Dominio.Item unItem in ListadeArticulos)
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

                celdaPrecio.Text = unItem.Precio.ToString();

                fila.Cells.Add(celdaImagen);
                fila.Cells.Add(celdaCantidad);
                fila.Cells.Add(celdaPrecio);


                this.ContenedorArticulos.Rows.Add(fila);

                montototal += unItem.Precio;



            }
            this.lblPrecioTotal.Text = "Precio total " + montototal;



        }

        private Dominio.Controladoras.ControladoraVentas Instancia()
        {
            return Dominio.Controladoras.ControladoraVentas.Instancia;
        }

        private void ListarPaises()
        {
            this.dpListaPais.DataSource = null;
            this.dpListaPais.DataSource = this.Instancia().ListarPaises();
            this.dpListaPais.DataBind();
        }

        private void ListarCIudades(string pNombreCiudad)
        {
            this.dpListaCiudad.DataSource = null;
            this.dpListaCiudad.DataSource = this.Instancia().ListarCiudad(pNombreCiudad);
            this.dpListaCiudad.DataBind();

        } 

                

        protected void dpListaPais_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(this.dpListaPais.SelectedIndex > 0)
            {
                string NombrePais = this.dpListaPais.SelectedValue;
                Session["PaisSeleccionado"] = NombrePais;
                this.ListarCIudades(NombrePais);

            }
            


        }

        protected void dpListaCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dpListaCiudad.SelectedIndex > 0)
            {
                string NombreCiudad = this.dpListaCiudad.SelectedValue;
                Session["CiudadSeleccionada"] = NombreCiudad;
                
            }
        }

        protected void btnComprar_Click1(object sender, EventArgs e)
        {
            string numeroTarjeta = txtNumeroTarjeta.Text;
            string pais = Session["PaisSeleccionado"].ToString();
            string ciudad = Session["CiudadSeleccionada"].ToString();
            DateTime fecha = DateTime.Now;

            Dominio.Controladoras.ControladoraCarrito unacontroladoraCarrito = new Dominio.Controladoras.ControladoraCarrito();

            int clienteconectado = int.Parse(Session["ClienteLogueado"].ToString());

            List<Dominio.Item> ListaArticulos = unacontroladoraCarrito.ListaCarritoParaCliente(clienteconectado);

            Dominio.Controladoras.ControladoraCliente unacontroladoraCliente = new Dominio.Controladoras.ControladoraCliente();

            Dominio.Cliente unCliente = unacontroladoraCliente.Buscar(clienteconectado);

            Dominio.Venta unaventa = new Dominio.Venta(fecha,ListaArticulos,unCliente,numeroTarjeta,pais,ciudad);

            if (this.Instancia().Alta(unaventa))
            {
               
            }

             
               


        }

    }
}