﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPublica.DetalleArticulos
{
    public partial class frmDetalleAccesorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MostrarDatos();
        }

        private void MostrarDatos()
        {
            int IdAccesorio = int.Parse(Session["AccesorioDetalle"].ToString());
            Dominio.Controladoras.ControladoraAccesorio unaControladora = new Dominio.Controladoras.ControladoraAccesorio();
            Dominio.Accesorio unAccesorio = unaControladora.Buscar(IdAccesorio);
            List<Dominio.FotosAdicionales> listaFotosAd = unaControladora.ListarFotosAdicionalesAccesorio(IdAccesorio);
            
            if(listaFotosAd.Count > 0)
            {
                foreach(Dominio.FotosAdicionales unaFoto in listaFotosAd)
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
            this.ImagenPrincipal.ImageUrl = unAccesorio.FotoPrincipal;

        }
        // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#exampleModal').modal();", true);

        protected void btnConfirmarCantidadStock_Click(object sender, EventArgs e)
        {
            int cantidadStock = int.Parse(this.txtNuevaCantidad.Text);
            Session["CantidadStockSeleccionada"] = cantidadStock;
        }


        protected void dplSeleccioneStock_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if (this.dplSeleccioneStock.SelectedIndex != 10)
            {
                string Item = this.dplSeleccioneStock.SelectedValue;
                string[] partesItem = Item.Split(' ');
                int Cantidad = int.Parse(partesItem[0]);
                Session["CantidadStockSeleccionada"] = Cantidad;
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
                int IdAccesorio = int.Parse(Session["AccesorioDetalle"].ToString());
                Dominio.Controladoras.ControladoraAccesorio unaControladora = new Dominio.Controladoras.ControladoraAccesorio();
                Dominio.Accesorio unAccesorio = unaControladora.Buscar(IdAccesorio);
                int cantidad = int.Parse(Session["CantidadStockSeleccionada"].ToString());
                Dominio.Item unItem = new Dominio.Item(unAccesorio, cantidad);
                int IdClienteConectado = int.Parse(Session["ClienteLogueado"].ToString());
                Dominio.Controladoras.ControladoraVentas unaControladoraVentas = new Dominio.Controladoras.ControladoraVentas();
                if (cantidad <= unAccesorio.Stock)
                {
                    if (unaControladoraVentas.AltaCarrito(unItem, IdClienteConectado))
                    {
                        this.lblMensaje.MensajeActivo(1, "Se agrego al carrito");
                    }
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "No hay stock disponible");
                }
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "Debes iniciar sesion para agregar productos al carrito");
            }


        }
    }
}