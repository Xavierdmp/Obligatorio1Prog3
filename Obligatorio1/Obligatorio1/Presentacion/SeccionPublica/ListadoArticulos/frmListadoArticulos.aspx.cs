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
            this.GenerarListadoAccesorio();
        }

        private void GenerarListadoAccesorio()
        {
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
                //style="outline: none; width: 240px;
                ContenedorArticulos.Attributes.Add("Style","outline: none; width: 240px;");

                ContenedorArticulos.Controls.Add(ContenedorImagen);
                ContenedorArticulos.Controls.Add(ContenedorTexto);

                this.ContenedorPrincipal.Controls.Add(ContenedorArticulos);
            }
        }
    }
}