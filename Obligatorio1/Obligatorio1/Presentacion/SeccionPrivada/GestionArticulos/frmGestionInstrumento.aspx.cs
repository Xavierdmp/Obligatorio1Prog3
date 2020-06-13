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
                this.ListarDescuentos();
                this.ListarSubtipos();
                this.ListarInstrumentos();

            }
        }

        private void ListarColores()
        {
            Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
            this.dplListarColores.DataSource = null;
            this.dplListarColores.DataSource = unaControladora.Listar();
            this.dplListarColores.DataBind();

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
            Dominio.Controladoras.ControladoraFabricante unControladorFabricante = new Dominio.Controladoras.ControladoraFabricante();
            this.dplListaFabricante.DataSource = null;
            this.dplListaFabricante.DataSource = unControladorFabricante.Listar();
            this.dplListaFabricante.DataBind();

        }

        private void ListarSubtipos()
        {
            Dominio.Controladoras.ControladoraSubTipos unaControlaSubtipo = new Dominio.Controladoras.ControladoraSubTipos();
            this.dplListarSubtipo.DataSource = null;
            this.dplListarSubtipo.DataSource = unaControlaSubtipo.Listar();
            this.dplListarSubtipo.DataBind();
        }


        private void LimpiarCampos()
        {
            this.txtNombre.Text = "";
            this.txtPrecio.Text = "";
            this.txtDescripcion.Text = "";
            this.txtFechaFabricacion.Text = "";
            this.txtStock.Text = "";
            this.txtVideoYoutube.Text = "";
            if (this.ListaFotosAdicionales != null)
            {
                this.ListaFotosAdicionales.Clear();
              
            }
            this.ListaColores.Clear();
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



        protected void btnAltaColor_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombreColor.Text;
            string CodigoColor = this.txtCodigoColor.Text;


            Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
            Dominio.Color unColor = new Dominio.Color(nombre, CodigoColor);

            if (unaControladora.Alta(unColor))
            {
                this.lblMensajeColor.MensajeActivo(1, "EL color se agrego con exito");
                this.ListarColores();
                this.txtNombreColor.Text = "";

            }
            else
            {
                this.lblMensajeColor.MensajeActivo(2, "El color no se ha podido agregar");
                this.txtNombreColor.Text = "";
            }

        }

        private List<Dominio.FotosAdicionales> ListaFotosAdicionales// es un accesor

        {
            get { return Session["ListaFotosAd"] as List<Dominio.FotosAdicionales>; }
            set { Session["ListaFotosAd"] = value; }

        }

        private List<Color> AsignarColoresParaAlta()
        {
            List<Color> ListasColores = new List<Color>();

            foreach (Color unColor in ListaColores)
            {
                ListasColores.Add(unColor);
            }
            return ListasColores;
        }

        private void ListarFotosAdicionales()
        {
            this.gvListarImagenesAdicionales.DataSource = null;
            this.gvListarImagenesAdicionales.DataSource = ListaFotosAdicionales; //mismo nombre que el metodo accesor.
            this.gvListarImagenesAdicionales.DataBind();
        }

        private List<Dominio.FotosAdicionales> AsignarFotosParaAlta()
        {
            List<Dominio.FotosAdicionales> lista = new List<Dominio.FotosAdicionales>();

            foreach (Dominio.FotosAdicionales unaFoto in ListaFotosAdicionales)
            {
                lista.Add(unaFoto);
            }

            return lista;   /*Recibe la lista de fotos, con esa lista de fot s crea una lista vacia de fotos*/

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
            if (this.dplListarColores.SelectedIndex > 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#ModalColores').modal();", true); /*Abre Modal*/

                string fila = this.dplListarColores.SelectedItem.ToString();
                string[] partes = fila.Split(' ');
                int IdColor = int.Parse(partes[1]);

                Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
                Dominio.Color unColor = unaControladora.Buscar(IdColor); /*Instancia y buscas el id el color*/
                Session["ColorSeleccionado"] = unColor;
            }
        }

        private bool SeEncuentraColorEnLaLista(Color pColor)
        {
            foreach (Color unColor in ListaColores)
            {
                if (unColor.Id == pColor.Id)
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
            if (ListaColores == null) //Si la lista del accesor esta vacia le asigno una nueva lista con un nuevo color.
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
        }

        protected void gvListarColoresSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = this.gvListarColoresSeleccionados.SelectedRow;

            int id = int.Parse(fila.Cells[1].Text);

            Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
            Dominio.Color unColor = unaControladora.Buscar(id);

            ListaColores.Remove(unColor);
            this.ListarColoresSeleccionados();



        }

        protected void btnAgregarImagenAdicional_Click(object sender, EventArgs e)
        {
            if (this.fuFotosAdicionales.HasFile)
            {

                string UrlFotos = "~/Imagenes/FotosAdicionales/" + this.fuFotosAdicionales.FileName;
                this.fuFotosAdicionales.SaveAs(Server.MapPath(UrlFotos));//Imagenes sean guardadas en un servidor con funcion MapPath y Url que se pasa.


                Dominio.FotosAdicionales unaFotoAdicional = new Dominio.FotosAdicionales(UrlFotos);

                if (ListaFotosAdicionales == null)
                {
                    List<FotosAdicionales> Listafotos = new List<FotosAdicionales>();
                    Listafotos.Add(unaFotoAdicional);

                    ListaFotosAdicionales = Listafotos;  // Asigno foto a lista.


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

            string nombre = this.txtNombre.Text;
            string descripcion = this.txtDescripcion.Text;


            string ObjetoFabricante = this.dplListaFabricante.SelectedItem.ToString();
            string[] partesFabricantes = ObjetoFabricante.Split(' ');

            int idFabricante = int.Parse(partesFabricantes[1]);

            Dominio.Controladoras.ControladoraFabricante unaControladoraFabricante = new Dominio.Controladoras.ControladoraFabricante();

            Dominio.Fabricante unFabricante = unaControladoraFabricante.Buscar(idFabricante);

            int precio = int.Parse(this.txtPrecio.Text);
            int stock = int.Parse(this.txtStock.Text);
            string UrlVideo = this.txtVideoYoutube.Text;
            DateTime Fechafabricacion = Convert.ToDateTime(this.txtFechaFabricacion.Text);

            bool destacado = this.btnEsDestacado.Checked ? true : false;

            string ObjetoSubtipo = this.dplListarSubtipo.SelectedItem.ToString();
            string[] partesSubtipo = ObjetoSubtipo.Split(' ');
            int idSubtipo = int.Parse(partesSubtipo[1].ToString());

            Dominio.Controladoras.ControladoraSubTipos unaControladoraSubtipo = new Dominio.Controladoras.ControladoraSubTipos();
            Dominio.SubTipo unSubtipo = unaControladoraSubtipo.Buscar(idSubtipo);

            List<Color> listaColores = this.AsignarColoresParaAlta();
            Dominio.Controladoras.ControladoraInstrumentos unaControladoraInstrumento = new Dominio.Controladoras.ControladoraInstrumentos();

            if (this.fuImagenPrincipal.HasFile)
            {
                string UrlFotoPrincipal = "~/Imagenes/ImgPrincipalInstrumento/" + this.fuImagenPrincipal.FileName;
                this.fuImagenPrincipal.SaveAs(Server.MapPath(UrlFotoPrincipal)); // Para que guarde la imagen

                Dominio.Instrumento unInstrumento = new Dominio.Instrumento(nombre,descripcion,unFabricante,UrlFotoPrincipal,precio,unSubtipo,stock,Fechafabricacion,UrlVideo,listaColores,destacado);

                if (this.dplListaDescuentos.SelectedIndex > 0) // significa que se selecciono un descuento
                {

                    int descuento = int.Parse(this.dplListaDescuentos.SelectedItem.Value); // El valor de esa lista lo asigne a esa lista,

                    unInstrumento.Descuento = descuento; //asigna el descuento al instrumeto;

                    if (ListaFotosAdicionales != null)
                    {
                        List<FotosAdicionales> ListaFotosAdi = this.AsignarFotosParaAlta();
                        unInstrumento.ListaFotosAdicionales = ListaFotosAdi;

                    }

                    if (unaControladoraInstrumento.Alta(unInstrumento))
                    {
                        this.lblMensaje.MensajeActivo(1, "El instrumento se agrego con exito");
                        this.LimpiarCampos();
                        this.ListarInstrumentos();
                        this.ListarFotosAdicionales();
                        this.ListarColoresSeleccionados();
                    }
                    else

                    {
                        this.lblMensaje.MensajeActivo(2, " EL instrumento no se ha podido agregar");

                    }
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "Seleccione una imagen principal ");
                }

                
                }

            }

    }   


    }




         