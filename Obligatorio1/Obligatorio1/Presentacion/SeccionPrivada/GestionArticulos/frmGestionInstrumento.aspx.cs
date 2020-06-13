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
            }
        }

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
            this.txtStock.Text = "";
            this.txtVideoYoutube.Text = "";
            this.txtNombre.Focus();
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
    }
}