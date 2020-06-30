﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPublica.ListadoArticulos
{
    public partial class frmListadoArticulos : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                IndicePaginado = 0;
                IndiceAnterior = 0;
            }
            this.ListadoPaginado(IndiceAnterior);
        }
        private int IndicePaginado
        {

            get {
                int result = 0;
                if (Session["InicioPaginado"] != null)
                {
                    
                     int.TryParse(Session["InicioPaginado"].ToString(),out result);
                }
                return result;
            }
            set
            {
                Session["InicioPaginado"] = value;
            }
        }
        private int IndiceAnterior
        {

            get
            {
                int result = 0;
                if (Session["IndiceAnterior"] != null)
                {

                    int.TryParse(Session["IndiceAnterior"].ToString(), out result);
                }
                return result;
            }
            set
            {
                Session["IndiceAnterior"] = value;
            }
        }


        private void ListadoPaginado(int pIndice)
        {
            this.ContenedorPrincipal.Controls.Clear();
            Dominio.Controladoras.ControladoraListado listados = new Dominio.Controladoras.ControladoraListado();
            List<Dominio.Articulo> listaPaginada = listados.Paginado(pIndice);
            foreach (Dominio.Articulo unArticulo in listaPaginada)
            {
                Panel ContenedorImagen = new Panel();
                ImageButton ImagenPrincipal = new ImageButton();
                ImagenPrincipal.Click += btnVerDetalle_Click;
                
                ImagenPrincipal.ImageUrl = unArticulo.FotoPrincipal;
                ImagenPrincipal.CssClass = "ImagenPrincipal";
                ImagenPrincipal.ID = unArticulo.Id.ToString();
                ContenedorImagen.Controls.Add(ImagenPrincipal);
                Panel ContenedorTexto = new Panel();
                ContenedorTexto.CssClass = "ContenedorTexto";
                Label Precio = new Label();
                Precio.Text = "$ " + unArticulo.Precio.ToString() +" " ;
                Precio.CssClass = "Precio";
                Label Nombre = new Label();
                Nombre.Text = unArticulo.Nombre;
                Nombre.CssClass = "Nombre";

                Dominio.Instrumento unInstrumento = unArticulo as Dominio.Instrumento;
                if (unInstrumento != null)
                {
                    Label Oferta = new Label();
                    if (unInstrumento.Descuento != 0)
                    {
                        Oferta.Text = "%" + unInstrumento.Descuento.ToString();
                        Oferta.CssClass = "OfertaInstrumento";
                        ContenedorTexto.Controls.Add(Precio);
                        ContenedorTexto.Controls.Add(Oferta);
                        ContenedorTexto.Controls.Add(Nombre);
                    }
                    else
                    {
                        ContenedorTexto.Controls.Add(Precio);
                        ContenedorTexto.Controls.Add(Nombre);
                    }
                    if (unInstrumento.Destacado)
                    {
                        Label Destacado = new Label();
                        Destacado.CssClass = "InstrumentoDestacado";
                        Destacado.Text = "Destacado";
                        ContenedorTexto.Controls.Add(Destacado);
                    }

                }

                else
                {

                    ContenedorTexto.Controls.Add(Precio);
                    ContenedorTexto.Controls.Add(Nombre);
                }

                    Panel ContenedorArticulos = new Panel();
                    ContenedorArticulos.CssClass = "ContenedorArticulos col-md-9 text-center";
                    ContenedorArticulos.Attributes.Add("Style", "outline: none; width: 240px;");

                    ContenedorArticulos.Controls.Add(ContenedorImagen);
                    ContenedorArticulos.Controls.Add(ContenedorTexto);

                    this.ContenedorPrincipal.Controls.Add(ContenedorArticulos);
                }
            this.ContenedorPrincipal.DataBind();
        }

        protected void btnSiguiente_Click1(object sender, EventArgs e)
        {
            Dominio.Controladoras.ControladoraListado listados = new Dominio.Controladoras.ControladoraListado();
            if (IndicePaginado == 0)
            {
                IndicePaginado = 13;
            }
            //int indiceAnterior = IndicePaginado;
            //IndicePaginado = indiceAnterior + indiceAnterior;
            IndiceAnterior = IndicePaginado;
            IndicePaginado += IndiceAnterior;
            if (listados.CantidadFilas(IndiceAnterior))
            {
    
                this.ListadoPaginado(IndiceAnterior);
            }
            else
            {
                this.ListadoPaginado(IndiceAnterior);
                this.btnSiguiente.Enabled = false;
            }
        }

        protected void btnVerDetalle_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imagenSeleccionada = (ImageButton)sender;
            int IdArticulo = int.Parse(imagenSeleccionada.ID);
            Dominio.Controladoras.ControladoraAccesorio unaControladoraAccesiorio = new Dominio.Controladoras.ControladoraAccesorio();
            Dominio.Controladoras.ControladoraInstrumentos unaControladoraInstrumento = new Dominio.Controladoras.ControladoraInstrumentos();
            
            if(unaControladoraAccesiorio.Buscar(IdArticulo) != null)
            {
                Session["AccesorioDetalle"] = IdArticulo;
                Response.Redirect("~/Presentacion/SeccionPublica/DetalleArticulos/frmDetalleAccesorio.aspx");
            }
            else if(unaControladoraInstrumento.Buscar(IdArticulo)!= null)
            {
                Session["InstrumentoDetalle"] = IdArticulo;
                Response.Redirect("~/Presentacion/SeccionPublica/DetalleArticulos/frmDetalleInstrumentos.aspx");
            }

        }

        protected void btnIncio_Click(object sender, EventArgs e)
        {
            IndiceAnterior = 0;
            this.btnSiguiente.Enabled = true;
            IndicePaginado = 0;
            this.ListadoPaginado(IndiceAnterior);
        }

        protected void btnFinal_Click(object sender, EventArgs e)
        {
            Dominio.Controladoras.ControladoraListado listados = new Dominio.Controladoras.ControladoraListado();
            int cantidadAMostrar = 12;
            int CantidadElementosTotales = listados.CantidadTotalesArticulos();
            int mostrar  = CantidadElementosTotales  - cantidadAMostrar - 1;
            IndicePaginado = CantidadElementosTotales- mostrar;
            IndiceAnterior = IndicePaginado;
            this.btnSiguiente.Enabled = false;
            this.ListadoPaginado(IndiceAnterior);
            //

        }
    }
}