using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPrivada.GestionTipos
{
    public partial class frmTiposInstrumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ListarTipo();
            }
        }

        private void LimpiarCampos()
        {
            this.txtNombre.Text = "";
            this.txtNombre.Focus();
        }

        private void ListarTipo()
        {
            Dominio.Controladoras.ControladoraTipo unaControladoraTipo = new Dominio.Controladoras.ControladoraTipo();
            this.GvListarTipos.DataSource = null;
            this.GvListarTipos.DataSource = unaControladoraTipo.Listar();
            this.GvListarTipos.DataBind();
        }

        private bool VerificarCampos()
        {
            if (this.txtNombre.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnAltaTipo_Click(object sender, EventArgs e)
        {

            if (VerificarCampos())
            {
                string nombre = this.txtNombre.Text;
                Dominio.Controladoras.ControladoraTipo unaControladoraTipo = new Dominio.Controladoras.ControladoraTipo();
                Dominio.Tipo unTipo = new Dominio.Tipo(nombre);
                if (unaControladoraTipo.Alta(unTipo))
                {
                    this.lblMensaje.MensajeActivo(1, "Se ha ingresado con exito");
                    this.ListarTipo();
                    this.LimpiarCampos();
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "No se ha podido ingresar");
                }
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "Complete todos los campos");
            }
        }

        protected void btnEliminarTipo_Click(object sender, EventArgs e)
        {
            if (this.VerificarCampos())
            {
                GridViewRow Row = this.GvListarTipos.SelectedRow;
                int Id = int.Parse(Row.Cells[1].Text);
                Dominio.Controladoras.ControladoraTipo unTipo = new Dominio.Controladoras.ControladoraTipo();
                if (unTipo.Baja(Id))
                {
                    this.lblMensaje.MensajeActivo(1, " Ha sido dado de baja");
                    this.ListarTipo();
                    this.LimpiarCampos();
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "No se ha podido dar de baja");
                    this.LimpiarCampos();
                }
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "Debe seleccionar un tipo para dar de baja");
            }
        }

        protected void btnModficar_Click(object sender, EventArgs e)
        {
            if (this.VerificarCampos())
            {
                GridViewRow Row = this.GvListarTipos.SelectedRow;
                int Id = int.Parse(Row.Cells[1].Text);
                Dominio.Controladoras.ControladoraTipo ControladoraTipo = new Dominio.Controladoras.ControladoraTipo();
                string nombre = this.txtNombre.Text;
                Dominio.Tipo unTipo = ControladoraTipo.Buscar(Id);
                unTipo.Nombre = nombre;
                if (ControladoraTipo.Modificar(unTipo))
                {
                    this.lblMensaje.MensajeActivo(1, "Se ha modificado con exito");
                    this.ListarTipo();
                    this.LimpiarCampos();
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "no se ha podido modificar con exito");
                }
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "Debe seleccionar un tipo");
            }

        }

        protected void GvListarTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow Row = this.GvListarTipos.SelectedRow;
            int Id = int.Parse(Row.Cells[1].Text);
            Dominio.Controladoras.ControladoraTipo ControladoraTipo = new Dominio.Controladoras.ControladoraTipo();
            Dominio.Tipo unTipo = ControladoraTipo.Buscar(Id);
            this.txtNombre.Text = unTipo.Nombre;
        }
    }
}
