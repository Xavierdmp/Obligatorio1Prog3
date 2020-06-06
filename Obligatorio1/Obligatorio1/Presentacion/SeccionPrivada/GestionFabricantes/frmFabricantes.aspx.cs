using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPrivada.GestionFabricantes
{
    public partial class frmFabricantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ListarFabricantes();
            }
        }

        private void ListarFabricantes()
        {
            Dominio.Controladoras.ControladoraFabricante unFabricante = new Dominio.Controladoras.ControladoraFabricante();
            this.gvListarFabricantes.DataSource = null;
            this.gvListarFabricantes.DataSource = unFabricante.Listar();
            this.gvListarFabricantes.DataBind();
        }

        private void LimpiarCampos()
        {
            this.txtNombre.Text = "";
            this.txtDireccion.Text = "";
            this.txtCorreoElectronico.Text = "";
            this.txtNombre.Focus();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string direccion = this.txtDireccion.Text;
            string correoelectronico = this.txtCorreoElectronico.Text;
            Dominio.Controladoras.ControladoraFabricante unaControladoraFabricante = new Dominio.Controladoras.ControladoraFabricante();
            Dominio.Fabricante unFabricante = new Dominio.Fabricante(nombre, direccion, correoelectronico);
            if (unaControladoraFabricante.Alta(unFabricante))
            {
                this.lblMensaje.MensajeActivo(1, "se ha ingresado con exito");
                this.ListarFabricantes();
                this.LimpiarCampos();
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "no se ha ingresado con exito");
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            GridViewRow Row = this.gvListarFabricantes.SelectedRow;
            int id = int.Parse(Row.Cells[1].Text);
            Dominio.Controladoras.ControladoraFabricante unFabricante = new Dominio.Controladoras.ControladoraFabricante();
            if (unFabricante.Baja(id))
            {
                this.lblMensaje.MensajeActivo(1, "Se ha podido eliminar");
                this.ListarFabricantes();
                this.LimpiarCampos();
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "no se ha podido eliminar");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            GridViewRow Row = this.gvListarFabricantes.SelectedRow;
            int Id = int.Parse(Row.Cells[1].Text);
            Dominio.Controladoras.ControladoraFabricante controladoraFabricante = new Dominio.Controladoras.ControladoraFabricante();
            string nombre = this.txtNombre.Text;
            string correo = this.txtCorreoElectronico.Text;
            string direccion = this.txtDireccion.Text;
            Dominio.Fabricante unFabricante = controladoraFabricante.Buscar(Id);

            unFabricante.Nombre = nombre;
            unFabricante.CorreoElectronico = correo;
            unFabricante.Direccion = direccion;

            if (controladoraFabricante.Modificar(unFabricante))
            {
                this.lblMensaje.MensajeActivo(1, "Se ha modificado con exito");
                this.ListarFabricantes();
                this.LimpiarCampos();
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "no se ha podido modificar ");
            }
        }

        protected void gvListarFabricantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.gvListarFabricantes.SelectedRow;
            int Id = int.Parse(row.Cells[1].Text);
            Dominio.Controladoras.ControladoraFabricante ControladoraFabricante = new Dominio.Controladoras.ControladoraFabricante();
            Dominio.Fabricante unFabricante = ControladoraFabricante.Buscar(Id);
            this.txtNombre.Text = unFabricante.Nombre;
            this.txtDireccion.Text = unFabricante.Direccion;
            this.txtCorreoElectronico.Text = unFabricante.CorreoElectronico;
        }
    }
}