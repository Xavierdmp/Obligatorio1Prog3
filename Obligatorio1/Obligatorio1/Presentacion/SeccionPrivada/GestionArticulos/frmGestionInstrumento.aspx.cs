using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio1.Dominio;
namespace Obligatorio1.Presentacion.SeccionPrivada.GestionArticulos
{
    public partial class frmGestionInstrumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ListarColores();
                this.ListarColoresModal();
                this.ListarFabricantes();
                this.ListarFotosAdicionales();
                this.ListarColoresSeleccionados();
                this.ListarSubtipos();
                this.ListarDescuentos();
                this.ListarInstrumentos();
            }
            this.CargarImagenPrincipal();
        }
        private const int maximoTamañoImagen = 3145784;

        private void ListarColores()
        {
            Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
            this.dplListarColores.DataSource = null;
            this.dplListarColores.DataSource = unaControladora.Listar();
            this.dplListarColores.DataBind();
        }
        private void LimpiarCampos()
        {
            this.txtNombre.Text = "";
            this.txtDescripcion.Text = "";
            this.txtFechaFabricacion.Text = "";
            this.txtPrecio.Text = "";
            this.txtVideoYoutube.Text = "";
            this.txtNombre.Focus();
            if (ListaFotosAdicionales != null)
            {
                this.ListaFotosAdicionales.Clear();
            }
            this.ListaColores.Clear();
        }

        private void ListarColoresModal()
        {
            Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
            this.gvListaColores.DataSource = null;
            this.gvListaColores.DataSource = unaControladora.Listar();
            this.gvListaColores.DataBind();
        }
        private void ListarFabricantes()
        {
            Dominio.Controladoras.ControladoraFabricante unaControladora = new Dominio.Controladoras.ControladoraFabricante();
            this.dplListaFabricante.DataSource = null;
            this.dplListaFabricante.DataSource = unaControladora.Listar();
            this.dplListaFabricante.DataBind();
        }

        private void ListarSubtipos()
        {
            Dominio.Controladoras.ControladoraSubTipos unaControladora = new Dominio.Controladoras.ControladoraSubTipos();
            this.dplListarSubtipo.DataSource = null;
            this.dplListarSubtipo.DataSource = unaControladora.Listar();
            this.dplListarSubtipo.DataBind();
        }
        private void ListarDescuentos()
        {
            List<int> descuentos = new List<int>();
            descuentos.Add(15);
            descuentos.Add(25);
            descuentos.Add(50);
            this.dplListaDescuentos.DataSource = null;
            this.dplListaDescuentos.DataSource = descuentos;
            this.dplListaDescuentos.DataBind();
        }

        private string UrlFotoPrincipal
        {
            get { return Session["ImagenPrincipal"] as string; }
            set { Session["ImagenPrincipal"] = value; }
        }

        private void CargarImagenPrincipal()
        {
            if (this.fuImagenPrincipal.HasFile)
            {
                string Extension = System.IO.Path.GetExtension(fuImagenPrincipal.PostedFile.FileName);
                if (Extension == ".PNG" || Extension == ".png")
                {
                    if (this.fuImagenPrincipal.FileName.Length < 150 && this.fuImagenPrincipal.PostedFile.ContentLength <= maximoTamañoImagen)
                    {
                        this.fuImagenPrincipal.SaveAs(Server.MapPath("~/Imagenes/ImgPrincipalInstrumento/" + this.fuImagenPrincipal.FileName));
                        UrlFotoPrincipal = "~/Imagenes/ImgPrincipalInstrumento/" + this.fuImagenPrincipal.FileName;
                        this.MostrarFotoPrincipal.ImageUrl = UrlFotoPrincipal;
                    }
                    else
                    {
                        this.lblMensaje.MensajeActivo(2, "Imagen no permitida");
                    }
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "Solo se permiten imagenes .PNG");
                }
            }
        }

        protected void btnAltaColor_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombreColor.Text;
            string CodigoColor = this.txtCodigoColor.Text;

            Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
            Dominio.Color unColor = new Dominio.Color(nombre, CodigoColor);
            if (unaControladora.Alta(unColor))
            {
                this.lblMensajeColor.MensajeActivo(1, "El color se agrego con exito");
                this.ListarColoresModal();
                this.txtNombreColor.Text = "";
            }
            else
            {
                this.lblMensajeColor.MensajeActivo(2, "El color no se pudo agregar");
                this.txtNombreColor.Text = "";
            }
        }

        private List<FotosAdicionales> ListaFotosAdicionales
        {
            get { return Session["ListaFotosAd"] as List<FotosAdicionales>; }
            set { Session["ListaFotosAd"] = value; }
        }
        private void ListarFotosAdicionales()
        {
            this.gvListarImagenesAdicionales.DataSource = null;
            this.gvListarImagenesAdicionales.DataSource = ListaFotosAdicionales;
            this.gvListarImagenesAdicionales.DataBind();
        }
        private List<FotosAdicionales> AsignarFotosParaAlta()
        {
            List<FotosAdicionales> lista = new List<FotosAdicionales>();
            foreach(FotosAdicionales unaFoto in ListaFotosAdicionales)
            {
                lista.Add(unaFoto);
            }
            return lista;
        }

        private List<Color> ListaColores
        {
            get { return Session["ListaColores"] as List<Color>; }
            set { Session["ListaColores"] = value; }
        }
        private void ListarColoresSeleccionados()
        {
            this.gvListarColoresSeleccionados.DataSource = null;
            this.gvListarColoresSeleccionados.DataSource = ListaColores;
            this.gvListarColoresSeleccionados.DataBind();
        }
        private List<Color> AsignarColoresParaAlta()
        {
            List<Color> lista = new List<Color>();
            foreach(Color unColor in ListaColores)
            {
                lista.Add(unColor);
            }
            return lista;
        }

        private void ListarInstrumentos()
        {
            Dominio.Controladoras.ControladoraInstrumentos unaControladora = new Dominio.Controladoras.ControladoraInstrumentos();
            this.gvListarInstrumentos.DataSource = null;
            this.gvListarInstrumentos.DataSource = unaControladora.Listar();
            this.gvListarInstrumentos.DataBind();
        }

        protected void dplListarColores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.dplListarColores.SelectedIndex > 0) {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#ModalColores').modal();", true);
               

                string fila = this.dplListarColores.SelectedItem.ToString();
                string[] partes = fila.Split(' ');
                int IdColor = int.Parse(partes[1]);

                Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
                Dominio.Color unColor = unaControladora.Buscar(IdColor);
                Session["ColorSeleccionado"] = unColor;
            }
        }

        private bool SeEncuentraColorEnLaLista(Color pColor)
        {
            foreach(Color unColor in ListaColores)
            {
                if(unColor.Id == pColor.Id)
                {
                    return true;
                }
            }
            return false;
        }

        protected void btnAgregarCantidad_Click(object sender, EventArgs e)
        {
            int cantidad = int.Parse(this.txtCantidad.Text);
            Dominio.Color unColor = Session["ColorSeleccionado"] as Color;
            unColor.Cantidad = cantidad;

            if (ListaColores == null)
            {
                List<Color> lista = new List<Color>();
                lista.Add(unColor);
                ListaColores = lista;
            }
            else
            {
                if (!this.SeEncuentraColorEnLaLista(unColor))
                {
                    ListaColores.Add(unColor);
                }
            }
            this.ListarColoresSeleccionados();
            this.txtCantidad.Text = "";
        }

        protected void gvListarColoresSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = this.gvListarColoresSeleccionados.SelectedRow;
            int Id = int.Parse(fila.Cells[1].Text);
            Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
            Dominio.Color unColor = unaControladora.Buscar(Id);
            ListaColores.Remove(unColor);
            this.ListarColoresSeleccionados();
        }

        protected void btnAgregarImagenAdicional_Click(object sender, EventArgs e)
        {
            if (this.fuFotosAdicionales.HasFile)
            {
                string urlFoto = "~/Imagenes/FotosAdicionales/" + this.fuFotosAdicionales.FileName;
                this.fuFotosAdicionales.SaveAs(Server.MapPath(urlFoto));
                Dominio.FotosAdicionales unaFotoAdicional = new Dominio.FotosAdicionales(urlFoto);
                if(ListaFotosAdicionales == null)
                {
                    List<FotosAdicionales> lista = new List<FotosAdicionales>();
                    lista.Add(unaFotoAdicional);
                    ListaFotosAdicionales = lista;
                }
                else
                {
                    ListaFotosAdicionales.Add(unaFotoAdicional);
                }

            }
            this.ListarFotosAdicionales();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (this.dplListaFabricante.SelectedIndex > 0 && this.dplListarSubtipo.SelectedIndex > 0 && this.UrlFotoPrincipal != "")
            {
                string nombre = this.txtNombre.Text;
                string descripcion = this.txtDescripcion.Text;
                string ObjetoFabricante = this.dplListaFabricante.SelectedItem.ToString();
                string[] partesFabricante = ObjetoFabricante.Split(' ');
                int idFabricante = int.Parse(partesFabricante[1]);
                Dominio.Controladoras.ControladoraFabricante unaControladoraFabricante = new Dominio.Controladoras.ControladoraFabricante();
                Dominio.Fabricante unFabricante = unaControladoraFabricante.Buscar(idFabricante);
                int precio = int.Parse(this.txtPrecio.Text);
                string urlVideo = this.txtVideoYoutube.Text;
                DateTime fechaFabricacion = Convert.ToDateTime(this.txtFechaFabricacion.Text);
                bool destacado = this.btnEsDestacado.Checked ? true : false;

                string ObjetoSubtipo = this.dplListarSubtipo.SelectedItem.ToString();
                string[] partesSubtipo = ObjetoSubtipo.Split(' ');
                int idSubtipo = int.Parse(partesSubtipo[1]);
                Dominio.Controladoras.ControladoraSubTipos unaControladoraSubtipo = new Dominio.Controladoras.ControladoraSubTipos();
                Dominio.SubTipo unSubtipo = unaControladoraSubtipo.Buscar(idSubtipo);
                int stock = 0;
                List<Color> listaColores = this.AsignarColoresParaAlta();
                Dominio.Controladoras.ControladoraInstrumentos unaControladoraInstrumento = new Dominio.Controladoras.ControladoraInstrumentos();
                Dominio.Instrumento unInstrumento = new Dominio.Instrumento(nombre, descripcion, unFabricante, UrlFotoPrincipal, precio, unSubtipo, stock, fechaFabricacion, urlVideo, listaColores, destacado);
                unInstrumento.CalcularStock();
                if (this.dplListaDescuentos.SelectedIndex > 0)
                {
                    int descuento = int.Parse(this.dplListaDescuentos.SelectedValue);
                    unInstrumento.Descuento = descuento;
                }
                if (ListaFotosAdicionales != null)
                {
                    List<FotosAdicionales> listaFotosAd = this.AsignarFotosParaAlta();
                    unInstrumento.ListaFotosAdicionales = listaFotosAd;
                }
                if (unaControladoraInstrumento.Alta(unInstrumento))
                {
                    this.lblMensaje.MensajeActivo(1, "El instrumento se agrego con exito");
                    this.LimpiarCampos();
                    this.ListarInstrumentos();
                    this.ListarFotosAdicionales();
                    this.ListarColoresSeleccionados();
                    UrlFotoPrincipal = "";
                    this.MostrarFotoPrincipal.ImageUrl = null;
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "El instrumento no se se agrego");
                }
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "seleccione un fabricante,subtipo y imagen principal");
            }
        }

        protected void gvListarInstrumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = this.gvListarInstrumentos.SelectedRow;
            int idInstrumento = int.Parse(fila.Cells[1].Text);
            Dominio.Controladoras.ControladoraInstrumentos unaControladora = new Dominio.Controladoras.ControladoraInstrumentos();
            Dominio.Instrumento unInstrumento = unaControladora.Buscar(idInstrumento);

            this.txtNombre.Text = unInstrumento.Nombre;
            this.txtDescripcion.Text = unInstrumento.Descripcion;
            this.txtPrecio.Text = unInstrumento.Precio.ToString();
            this.txtVideoYoutube.Text = unInstrumento.VideoYoutube;
            this.txtFechaFabricacion.Text = String.Format("{0:yyyy-MM-dd}", unInstrumento.FechaFabricacion);
            List<Color> listColores = unaControladora.ListarColoresParaInstrumento(idInstrumento);
            List<FotosAdicionales> listaFotosAd = unaControladora.ListarFotosAdicionalesParaInstrumento(idInstrumento);
            if(listaFotosAd != null)
            {
                ListaFotosAdicionales = listaFotosAd;
                this.ListarFotosAdicionales();
            }
            ListaColores = listColores;
            this.ListarColoresSeleccionados();
            this.MostrarFotoPrincipal.ImageUrl = unInstrumento.FotoPrincipal;


        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            GridViewRow fila = this.gvListarInstrumentos.SelectedRow;
            int idInstrumento = int.Parse(fila.Cells[1].Text);
            Dominio.Controladoras.ControladoraInstrumentos unaControladora = new Dominio.Controladoras.ControladoraInstrumentos();
            if (unaControladora.Baja(idInstrumento))
            {
                this.lblMensaje.MensajeActivo(1, "Instrumento eliminado con exito");
                this.LimpiarCampos();
                this.ListarInstrumentos();
                this.ListarFotosAdicionales();
                this.ListarColoresSeleccionados();
                UrlFotoPrincipal = "";
                this.MostrarFotoPrincipal.ImageUrl = null;
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "El Instrumento no se pudo eliminar");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.dplListaFabricante.SelectedIndex > 0 && this.dplListarSubtipo.SelectedIndex > 0 && this.UrlFotoPrincipal != "")
            {
                GridViewRow fila = this.gvListarInstrumentos.SelectedRow;
                int idInstrumento = int.Parse(fila.Cells[1].Text);

                string nombre = this.txtNombre.Text;
                string descripcion = this.txtDescripcion.Text;

                string ObjetoFabricante = this.dplListaFabricante.SelectedItem.ToString();
                string[] partesFabricante = ObjetoFabricante.Split(' ');
                int idFabricante = int.Parse(partesFabricante[1]);
                Dominio.Controladoras.ControladoraFabricante unaControladoraFabricante = new Dominio.Controladoras.ControladoraFabricante();
                Dominio.Fabricante unFabricante = unaControladoraFabricante.Buscar(idFabricante);
                int precio = int.Parse(this.txtPrecio.Text);
                string urlVideo = this.txtVideoYoutube.Text;
                DateTime fechaFabricacion = Convert.ToDateTime(this.txtFechaFabricacion.Text);
                bool destacado = this.btnEsDestacado.Checked ? true : false;

                string ObjetoSubtipo = this.dplListarSubtipo.SelectedItem.ToString();
                string[] partesSubtipo = ObjetoSubtipo.Split(' ');
                int idSubtipo = int.Parse(partesSubtipo[1]);
                Dominio.Controladoras.ControladoraSubTipos unaControladoraSubtipo = new Dominio.Controladoras.ControladoraSubTipos();
                Dominio.SubTipo unSubtipo = unaControladoraSubtipo.Buscar(idSubtipo);

                List<Color> listaColores = this.AsignarColoresParaAlta();
                Dominio.Controladoras.ControladoraInstrumentos unaControladoraInstrumento = new Dominio.Controladoras.ControladoraInstrumentos();

                Dominio.Instrumento unInstrumento = unaControladoraInstrumento.Buscar(idInstrumento);
                unInstrumento.Nombre = nombre;
                unInstrumento.Descripcion = descripcion;
                unInstrumento.Precio = precio;
                unInstrumento.SubTipo = unSubtipo;
                unInstrumento.Fabricante = unFabricante;
                unInstrumento.FechaFabricacion = fechaFabricacion;
                unInstrumento.FotoPrincipal = UrlFotoPrincipal;
                unInstrumento.Destacado = destacado;

                if (this.dplListaDescuentos.SelectedIndex > 0)
                {
                    int descuento = int.Parse(this.dplListaDescuentos.SelectedValue);
                    unInstrumento.Descuento = descuento;
                }
                if (ListaFotosAdicionales != null)
                {
                    List<FotosAdicionales> listaFotosAd = this.AsignarFotosParaAlta();
                    unInstrumento.ListaFotosAdicionales = listaFotosAd;
                }
                unInstrumento.ListaDeColores = listaColores;
                if (unaControladoraInstrumento.Modificar(unInstrumento))
                {
                    this.lblMensaje.MensajeActivo(1, "El instrumento se modifico con exito");
                    this.LimpiarCampos();
                    this.ListarInstrumentos();
                    this.ListarFotosAdicionales();
                    this.ListarColoresSeleccionados();
                    UrlFotoPrincipal = "";
                    this.MostrarFotoPrincipal.ImageUrl = null;
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "El instrumento no se se puedo modificar");
                }
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "seleccione un fabricante,subtipo y imagen principal");
            }
        }
    }
}