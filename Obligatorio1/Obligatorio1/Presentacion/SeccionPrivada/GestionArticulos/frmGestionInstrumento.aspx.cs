using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        protected void btnAltaColor_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombreColor.Text;
            string CodigoColor = this.txtCodigoColor.Text;

            Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
            Dominio.Color unColor = new Dominio.Color(nombre,CodigoColor);
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
    }
}