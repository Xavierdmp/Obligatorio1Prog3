using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPublica.DetallesArticulos
{
    public partial class frmDetalleAccesorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MostrarDatos();
        }

        private void MostrarDatos()
        {
            int idAccesorio = int.Parse(Session["AccesorioDetalle"].ToString());
            Dominio.Controladoras.ControladoraAccesorio unaControladora = new Dominio.Controladoras.ControladoraAccesorio();
            Dominio.Accesorio unAccesorio = unaControladora.Buscar(idAccesorio);
            //Cargar los datos

            List<Dominio.FotosAdicionales> ListaFotosAd = unaControladora.ListarFotosAdicionalesAccesorio(idAccesorio);// trae de la bd las fotos del accesorio

            if (ListaFotosAd.Count > 0)
            {

                foreach (Dominio.FotosAdicionales unaFoto in ListaFotosAd)
                {
                    ImageButton imagenOpcional = new ImageButton();
                    imagenOpcional.ImageUrl = unaFoto.Url;
                    imagenOpcional.CssClass = "ImagenesOpcionales";
                    this.ImagenesOpcionales.Controls.Add(imagenOpcional);
                    imagenOpcional.Attributes.Add("onmouseover", "changeImage(this)");

                }

            }
            this.lblNombre.Text = unAccesorio.Nombre;
            this.lblDescripcion.Text = unAccesorio.Descripcion;

            this.lblFabricante.Text = unAccesorio.Fabricante.Nombre;
            this.lblPrecio.Text = "$" + unAccesorio.Precio;
            this.ImagenPrincipal.ImageUrl = unAccesorio.FotoPrincipal; // Asignando la url del Accesorio al imagebutton           
        }

        protected void btnConfirmarCantidadStock_Click(object sender, EventArgs e)
        {

            int cantidadstock = int.Parse(this.txtCantidad.Text);
            Session["CantidadStockSeleccionada"] = cantidadstock;
        }

        protected void dplSeleccioneStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dplSeleccioneStock.SelectedIndex != 10)
            {
                string item = this.dplSeleccioneStock.SelectedValue;
                string[] PartesItem = item.Split(' ');
                int cantidad = int.Parse(PartesItem[0]);

                Session["CantidadStockSeleccionada"] = cantidad;
            }

            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#CantidadStock').modal();", true);

            }

        }

        protected void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            if (Session["ClienteLogueado"] != null)
            {
                
                int idAccesorio = int.Parse(Session["AccesorioDetalle"].ToString());
                Dominio.Controladoras.ControladoraAccesorio unaControladora = new Dominio.Controladoras.ControladoraAccesorio();
                Dominio.Accesorio unAccesorio = unaControladora.Buscar(idAccesorio);

                int cantidad = int.Parse(Session["CantidadStockSeleccionada"].ToString());
                Dominio.Item unItem = new Dominio.Item(unAccesorio, cantidad);
                Session["CarritoDeCompras"] = unItem;
                int idClienteConectado = int.Parse(Session["ClienteLogueado"].ToString());

                if (cantidad <= unAccesorio.Stock) //para saber si hay stock en el carrito

                {


                    Dominio.Controladoras.ControladoraVentas unaControladoraVentas = new Dominio.Controladoras.ControladoraVentas();

                    if (unaControladoraVentas.AltaCarrito(unItem, idClienteConectado))
                    {
                        this.lblMensaje.MensajeActivo(1, "se agrego al carrito");
                    }

                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "No hay stock disponible");
                }
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "Debes iniciar sesion para agregar productos");
            }
        }

    }
}