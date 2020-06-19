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
            // this.GenerarListadoAccesorio();
            //this.GenerarListadoInstrumentos();
            if (Session["InicioPaginado"] == null)
            {
                Session["InicioPaginado"] = 0;
                this.ListadoPaginado(0);
            }

        }

        private void GenerarListadoAccesorio()
        {
            this.ContenedorPrincipal.Controls.Clear();
            Dominio.Controladoras.ControladoraAccesorio unaControladoraAccesorio = new Dominio.Controladoras.ControladoraAccesorio();

            foreach (Dominio.Accesorio unAccesorio in unaControladoraAccesorio.Listar())
            {
                Panel ContenedorImagen = new Panel();
                ImageButton ImagenPrincipal = new ImageButton();
                ImagenPrincipal.ImageUrl = unAccesorio.FotoPrincipal;
                ImagenPrincipal.CssClass = "ImagenPrincipal";

                ContenedorImagen.Controls.Add(ImagenPrincipal);

                Panel ContenedorTexto = new Panel();
                ContenedorTexto.CssClass = "ContenedorTexto";
                Label Precio = new Label();
                Precio.Text = "$ " + unAccesorio.Precio.ToString();
                Precio.CssClass = "Precio";
                Label Nombre = new Label();
                Nombre.Text = unAccesorio.Nombre;
                Nombre.CssClass = "Nombre";

                
                ContenedorTexto.Controls.Add(Precio);
                ContenedorTexto.Controls.Add(Nombre);

                Panel ContenedorArticulos = new Panel();
                ContenedorArticulos.CssClass = "ContenedorArticulos col-md-9 text-center";
                ContenedorArticulos.Attributes.Add("Style","outline: none; width: 240px;");

                ContenedorArticulos.Controls.Add(ContenedorImagen);
                ContenedorArticulos.Controls.Add(ContenedorTexto);

                this.ContenedorPrincipal.Controls.Add(ContenedorArticulos);
            }
        }

        private void GenerarListadoInstrumentos()
        {
            Dominio.Controladoras.ControladoraInstrumentos unaControladoraInstrumentos = new Dominio.Controladoras.ControladoraInstrumentos();

                foreach (Dominio.Instrumento unInstrumento in unaControladoraInstrumentos.Listar())
                {
                    Panel ContenedorImagen = new Panel();
                    ImageButton ImagenPrincipal = new ImageButton();
                    ImagenPrincipal.ImageUrl = unInstrumento.FotoPrincipal;
                    ImagenPrincipal.CssClass = "ImagenPrincipal";

                    ContenedorImagen.Controls.Add(ImagenPrincipal);

                    Panel ContenedorTexto = new Panel();
                    ContenedorTexto.CssClass = "ContenedorTexto";
                    Label Precio = new Label();
                    Precio.Text = "$ " + unInstrumento.Precio.ToString();
                    Precio.CssClass = "Precio";
                    Label Nombre = new Label();
                    Nombre.Text = unInstrumento.Nombre;
                    Nombre.CssClass = "Nombre";


                    ContenedorTexto.Controls.Add(Precio);
                    ContenedorTexto.Controls.Add(Nombre);

                    Panel ContenedorArticulos = new Panel();
                    ContenedorArticulos.CssClass = "ContenedorArticulos col-md-9 text-center";
                    ContenedorArticulos.Attributes.Add("Style", "outline: none; width: 240px;");

                    ContenedorArticulos.Controls.Add(ContenedorImagen);
                    ContenedorArticulos.Controls.Add(ContenedorTexto);

                    this.ContenedorPrincipal.Controls.Add(ContenedorArticulos);
                }
        }
        private void ListadoPaginado(int pIndice)
        {
                Dominio.Controladoras.ControladoraListado listados = new Dominio.Controladoras.ControladoraListado();
                foreach (Dominio.Articulo unArticulo in listados.Paginado(pIndice))
                {
                    Panel ContenedorImagen = new Panel();
                    ImageButton ImagenPrincipal = new ImageButton();
                    ImagenPrincipal.ImageUrl = unArticulo.FotoPrincipal;
                    ImagenPrincipal.CssClass = "ImagenPrincipal";

                    ContenedorImagen.Controls.Add(ImagenPrincipal);

                    Panel ContenedorTexto = new Panel();
                    ContenedorTexto.CssClass = "ContenedorTexto";
                    Label Precio = new Label();
                    Precio.Text = "$ " + unArticulo.Precio.ToString();
                    Precio.CssClass = "Precio";
                    Label Nombre = new Label();
                    Nombre.Text = unArticulo.Nombre;
                    Nombre.CssClass = "Nombre";


                    ContenedorTexto.Controls.Add(Precio);
                    ContenedorTexto.Controls.Add(Nombre);

                    Panel ContenedorArticulos = new Panel();
                    ContenedorArticulos.CssClass = "ContenedorArticulos col-md-9 text-center";
                    ContenedorArticulos.Attributes.Add("Style", "outline: none; width: 240px;");

                    ContenedorArticulos.Controls.Add(ContenedorImagen);
                    ContenedorArticulos.Controls.Add(ContenedorTexto);

                    this.ContenedorPrincipal.Controls.Add(ContenedorArticulos);
                }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Dominio.Controladoras.ControladoraListado listados = new Dominio.Controladoras.ControladoraListado();
            if (Session["IndiceSiguiente"] == null)
            {
                Session["IndiceSiguiente"] = 5;
            }
            int IndiceAnterior = int.Parse(Session["IndiceSiguiente"].ToString());
            Session["IndiceSiguiente"] = IndiceAnterior + IndiceAnterior;
            if (listados.CantidadFilas(IndiceAnterior))
            {
                this.ListadoPaginado(IndiceAnterior);
            }
            else
            {
                this.btnSiguiente.Enabled = false;
            }
        }
        
    }
}