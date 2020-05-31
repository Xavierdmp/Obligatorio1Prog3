using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.GestionSubTipos
{
    public partial class frmSubtipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ListarSubtipos();
                this.ListarTiposInstrumentos();
            }
        }
        private void ListarSubtipos()
        {
            Dominio.Controladoras.ControladoraSubTipos ControladoraSubTipos = new Dominio.Controladoras.ControladoraSubTipos();
            this.gvListarSubtipos.DataSource = null;
            this.gvListarSubtipos.DataSource = ControladoraSubTipos.Listar();
            this.gvListarSubtipos.DataBind();
        }

        private void ListarTiposInstrumentos()
        {
            Dominio.Controladoras.ControladoraTipo unaControladoraTipo = new Dominio.Controladoras.ControladoraTipo();
            this.dplListaTipos.DataSource = null;
            this.dplListaTipos.DataSource = unaControladoraTipo.Listar();
            this.dplListaTipos.DataBind();
        }
        private bool ComprobarDatos()
        {
            if(this.txtNombre.Text != "" || this.dplListaTipos.SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void LimpiarCampos()
        {
            this.txtNombre.Text = "";
            this.txtNombre.Text = "";
            this.ListarTiposInstrumentos();
        }
        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (this.dplListaTipos.SelectedValue != "Seleccione un Tipo de instrumento")
            {
                if (this.ComprobarDatos())
                {
                    string nombre = this.txtNombre.Text;
                    string ItemTipoInstrumento = this.dplListaTipos.SelectedItem.ToString();
                    string[] partesItem = ItemTipoInstrumento.Split(' ');
                    int IdTipo = int.Parse(partesItem[1]);
                    Dominio.Controladoras.ControladoraTipo unaControladoraTipo = new Dominio.Controladoras.ControladoraTipo();
                    Dominio.Controladoras.ControladoraSubTipos unaControladoraSubTipo = new Dominio.Controladoras.ControladoraSubTipos();
                    Dominio.Tipo unTipo = unaControladoraTipo.Buscar(IdTipo);
                    Dominio.SubTipo unSubtipo = new Dominio.SubTipo(nombre, unTipo);
                    if (unaControladoraSubTipo.Alta(unSubtipo))
                    {
                        this.lblMensaje.MensajeActivo(1, "Subtipo ingresado con exito");
                        this.LimpiarCampos();
                        this.ListarSubtipos();
                    }
                    else
                    {
                        this.lblMensaje.MensajeActivo(2, "No se pudo ingresar");
                        this.ListarSubtipos();
                    }
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "Complete todos los datos");
                }
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if(this.txtNombre.Text != "" && this.gvListarSubtipos.SelectedIndex > -1)
            {
                GridViewRow row = this.gvListarSubtipos.SelectedRow;
                int id = int.Parse(row.Cells[1].Text);
                Dominio.Controladoras.ControladoraSubTipos unaControladoraSubtipo = new Dominio.Controladoras.ControladoraSubTipos();
                if (unaControladoraSubtipo.Baja(id))
                {
                    this.LimpiarCampos();
                    this.ListarSubtipos();
                    this.lblMensaje.MensajeActivo(1, "Subtipo eliminado con exito");
                }
                else
                {
                    this.lblMensaje.MensajeActivo(1, "El subtipo no se pudo eliminar");
                    this.LimpiarCampos();
                }
            }
            else
            {
                this.lblMensaje.MensajeActivo(1, "Seleccione un Subtipo de la lista");
            }
        }

        protected void gvListarSubtipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.gvListarSubtipos.SelectedRow;
            int id = int.Parse(row.Cells[1].Text);
            Dominio.Controladoras.ControladoraSubTipos unaControladoraSubtipo = new Dominio.Controladoras.ControladoraSubTipos();
            this.txtNombre.Text = unaControladoraSubtipo.Buscar(id).Nombre;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text != "" && this.dplListaTipos.SelectedValue !="Seleccione un Tipo de instrumento" && this.gvListarSubtipos.SelectedRow !=null)
            {
                GridViewRow row = this.gvListarSubtipos.SelectedRow;
                int id = int.Parse(row.Cells[1].Text);
                Dominio.Controladoras.ControladoraSubTipos unaControladoraSubtipo = new Dominio.Controladoras.ControladoraSubTipos();
                Dominio.SubTipo unSubtipo = unaControladoraSubtipo.Buscar(id);

                string nombre = this.txtNombre.Text;
                string ItemTipoInstrumento = this.dplListaTipos.SelectedItem.ToString();
                string[] partesItem = ItemTipoInstrumento.Split(' ');
                int IdTipo = int.Parse(partesItem[1]);
                Dominio.Controladoras.ControladoraTipo unaControladoraTipo = new Dominio.Controladoras.ControladoraTipo();

                Dominio.Tipo unTipo = unaControladoraTipo.Buscar(IdTipo);

                unSubtipo.Nombre = nombre;
                unSubtipo.TipoInstrumento = unTipo;

                if (unaControladoraSubtipo.Modificar(unSubtipo))
                {
                    this.LimpiarCampos();
                    this.ListarSubtipos();
                    this.lblMensaje.MensajeActivo(1, "Subtipo modificado con exito");
                }
                else
                {
                    this.lblMensaje.MensajeActivo(1, "El subtipo no se pudo modificar");
                    this.LimpiarCampos();
                }
            }
            else
            {
                this.lblMensaje.MensajeActivo(1, "Seleccione un Subtipo de la lista");
            }
        }
    }
}