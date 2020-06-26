using System;
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
                IndicePaginado = 0; // Comienza el paginado.


            }
            this.ListadoPaginado(IndicePaginado);

        }
        private int IndicePaginado        {            get
            {                int result = 0;                if (Session["InicioPaginado"] != null)                {

                    int.TryParse(Session["InicioPaginado"].ToString(), out result);                }                return result;            }            set            {                Session["InicioPaginado"] = value;            }        }
        private void ListadoPaginado(int pIndice)
        {
            
            Dominio.Controladoras.ControladoraListado listados = new Dominio.Controladoras.ControladoraListado();
            List<Dominio.Articulo> listaPaginada = listados.Paginado(pIndice);
            foreach (Dominio.Articulo unArticulo in listaPaginada)
            {
                Panel ContenedorImagen = new Panel();
                ImageButton ImagenPrincipal = new ImageButton();
                ImagenPrincipal.Click += btnVerDetalleClick;

                ImagenPrincipal.ImageUrl = unArticulo.FotoPrincipal;
                ImagenPrincipal.CssClass = "ImagenPrincipal";
                ImagenPrincipal.ID = unArticulo.Id.ToString();
                ContenedorImagen.Controls.Add(ImagenPrincipal);

                Panel ContenedorTexto = new Panel();
                ContenedorTexto.CssClass = "ContenedorTexto";
                Label Precio = new Label();
                Precio.Text = "$ " + unArticulo.Precio.ToString() + " ";
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
                IndicePaginado = 5;
            }
                int indiceAnterior = IndicePaginado;
                IndicePaginado = indiceAnterior + indiceAnterior;
                if (listados.CantidadFilas(indiceAnterior))
                {
                    this.ListadoPaginado(indiceAnterior);
                }
                else
                {
                    this.ListadoPaginado(indiceAnterior);
                    this.btnSiguiente.Enabled = false;
                }

            }
        
        protected void btnVerDetalleClick(object sender, ImageClickEventArgs e)
        {
            ImageButton ImagenSeleccionada = (ImageButton) sender;   //captura que imagen se hizo clic, para saber si es intrumento o articulo

            int idArticulo = int.Parse(ImagenSeleccionada.ID);
            Dominio.Controladoras.ControladoraAccesorio unacontroladoraAccesorio = new Dominio.Controladoras.ControladoraAccesorio(); // Instanciamos para saber si es articulo accesorio
            Dominio.Controladoras.ControladoraInstrumentos unaControladoraInstrumento = new Dominio.Controladoras.ControladoraInstrumentos();

            if (unaControladoraInstrumento.Buscar(idArticulo) != null)
            {
                Session["InstrumentoDetalle"] = idArticulo;

            }
            else if (unacontroladoraAccesorio.Buscar(idArticulo) != null)
            {
                Session["AccesorioDetalle"] = idArticulo;
                Response.Redirect("~/Presentacion/SeccionPublica/DetallesArticulos/frmDetalleAccesorio.aspx"); //Al presionar un articulo lo lleva a esa imagen.

            }


        }
        
     
        
    }
}
 