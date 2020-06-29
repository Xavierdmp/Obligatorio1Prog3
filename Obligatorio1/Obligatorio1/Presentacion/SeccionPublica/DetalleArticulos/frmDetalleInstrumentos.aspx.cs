using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPublica.DetalleArticulos
{
    public partial class frmDetalleInstrumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                this.GenerarInformacion();
        }

        private void GenerarInformacion()
        {
            int IdAccesorio = int.Parse(Session["InstrumentoDetalle"].ToString());
            Dominio.Controladoras.ControladoraInstrumentos unaControladora = new Dominio.Controladoras.ControladoraInstrumentos();
            Dominio.Instrumento unInstrumento = unaControladora.Buscar(IdAccesorio);
            List<Dominio.FotosAdicionales> listaFotosAd = unaControladora.ListarFotosAdicionalesParaInstrumento(IdAccesorio);

            if (listaFotosAd.Count > 0)
            {
                foreach (Dominio.FotosAdicionales unaFoto in listaFotosAd)
                {
                    ImageButton imagenOpcional = new ImageButton();
                    imagenOpcional.ImageUrl = unaFoto.Url;
                    imagenOpcional.CssClass = "ImagenesOpcionales";
                    this.ImagenesOpcionales.Controls.Add(imagenOpcional);
                    imagenOpcional.Attributes.Add("onmouseover", "changeImage(this)");

                }
                ImageButton imagenOpcionaFotoPrincipal = new ImageButton();
                imagenOpcionaFotoPrincipal.ImageUrl = unInstrumento.FotoPrincipal;
                imagenOpcionaFotoPrincipal.CssClass = "ImagenesOpcionales";
                imagenOpcionaFotoPrincipal.Attributes.Add("onmouseover", "changeImage(this)");
                this.ImagenesOpcionales.Controls.Add(imagenOpcionaFotoPrincipal);
            }
            List<Dominio.Color> listaColores = unaControladora.ListarColoresParaInstrumento(IdAccesorio);

            foreach(Dominio.Color unColor in listaColores)
            {
                Button Color = new Button();
                Color.ID = unColor.Id.ToString();
                Color.Attributes.Add("runat", "server");
                Color.BackColor = System.Drawing.Color.FromName(unColor.Codigo);
                Color.CssClass = "ColoresDetalle";
                Color.Click += btnSelecinarColor_Click;
                this.ContenedorColores.Controls.Add(Color);
            }
            this.lblNombre.Text = unInstrumento.Nombre;
            this.lblDescripcion.Text = unInstrumento.Descripcion;

            this.lblFabricante.Text = unInstrumento.Fabricante.Nombre;
            this.lblPrecio.Text = "$" + unInstrumento.Precio;
            this.ImagenPrincipal.ImageUrl = unInstrumento.FotoPrincipal;
            this.MostrarVideo(unInstrumento.VideoYoutube);
            this.GenerarListaAccesorios(unInstrumento.Id); 
        }

        protected void btnConfirmarCantidadStock_Click(object sender, EventArgs e)
        {
            Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
            int IdColor = int.Parse(Session["ColorSeleccionado"].ToString());
            Dominio.Color unColor = unaControladora.Buscar(IdColor);
            int cantidad = int.Parse(this.txtNuevaCantidad.Text);
            Session["CantidadSeleccionada"] = cantidad;
        }

        protected void btnSelecinarColor_Click(object sender, EventArgs e)
        {
            Button Seleccionado = (Button)sender;
            int IdColor = int.Parse(Seleccionado.ID);
            Session["ColorSeleccionado"] = IdColor;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#CantidadStock').modal();", true);
        }


        protected void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            if (Session["ClienteLogueado"] != null)
            {
                int IdAccesorio = int.Parse(Session["InstrumentoDetalle"].ToString());
                Dominio.Controladoras.ControladoraInstrumentos unaControladora = new Dominio.Controladoras.ControladoraInstrumentos();
                Dominio.Instrumento unInstrumento = unaControladora.Buscar(IdAccesorio);
                int IdColor = int.Parse(Session["ColorSeleccionado"].ToString());
                Dominio.Controladoras.ControladoraColor unaControladoraColor = new Dominio.Controladoras.ControladoraColor();
                Dominio.Color unColor = unaControladoraColor.Buscar(IdColor);
                int IdClienteLogueado = int.Parse(Session["ClienteLogueado"].ToString());
                Dominio.Controladoras.ControladoraVentas unaControladoraVentas = new Dominio.Controladoras.ControladoraVentas();
                int cantidad = int.Parse(Session["CantidadSeleccionada"].ToString());
                Dominio.Item unItem = new Dominio.Item(unInstrumento, cantidad, unColor);
                if (unaControladoraVentas.AltaCarrito(unItem, IdClienteLogueado))
                {
                    this.lblMensaje.MensajeActivo(1, "Se agrego con exito al carrito");
                }
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "Inicie sesion para agregar al carrito");
            }
        }

        private void MostrarVideo(string pUrl)

        {
            var posicionCapturar = 0;

            string urlVideo = "";
            foreach (Char unCaracter in pUrl)
            {

                if (posicionCapturar == 1)
                {
                    urlVideo += unCaracter;
                }
                if (unCaracter == '=')
                {
                    posicionCapturar = 1;
                }

            }
            this.VideoPresentacion.Attributes.Add("src", "https://www.youtube.com/embed/" + urlVideo);


        }


        private void GenerarListaAccesorios(int pIdInstrumento)
        {
            Dominio.Controladoras.ControladoraInstrumentos unaControladora = new Dominio.Controladoras.ControladoraInstrumentos();


            List<Dominio.Accesorio> listaAccesorios = unaControladora.ListarAccesorioParaDetalleInstrumento(pIdInstrumento);

            foreach (Dominio.Accesorio unAccesorio in listaAccesorios)
            {
                Panel swiperSlide = new Panel();
                swiperSlide.CssClass = "swiper-slide";

                Panel contenedorImagen = new Panel();
                ImageButton Imagen = new ImageButton();
                Imagen.ImageUrl = unAccesorio.FotoPrincipal;
                Imagen.CssClass = " text-center ImagenSlider";
                contenedorImagen.Controls.Add(Imagen);

                Panel contenedortexto = new Panel();
                contenedortexto.CssClass = "text-center TextoSlider";

                Label precio = new Label();
                precio.Text = "$" + unAccesorio.Precio;
                precio.CssClass = "PrecioSlider";
                contenedortexto.Controls.Add(precio);

                Label nombre = new Label();
                nombre.CssClass = "TituloSlider";
                nombre.Text = unAccesorio.Nombre;


                contenedortexto.Controls.Add(nombre);
                swiperSlide.Controls.Add(contenedorImagen);
                swiperSlide.Controls.Add(contenedortexto);
                this.ContenedorAccesorios.Controls.Add(swiperSlide);
            }

            this.ContenedorAccesorios.DataBind();

            }
      
        }

    }
