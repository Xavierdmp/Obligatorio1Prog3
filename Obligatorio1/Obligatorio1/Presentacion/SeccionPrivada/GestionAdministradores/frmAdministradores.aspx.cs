using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPrivada.GestionAdministradores
{
    public partial class frmAdministradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ListarAdmininstradores();
                this.AdministradorConPermisos();
            }
        }
        private void ListarAdmininstradores()
        {
            Dominio.Controladoras.ControladoraAdministrador unaControladoraAdmin = new Dominio.Controladoras.ControladoraAdministrador();
            this.gvListarAdministradores.DataSource = null;
            this.gvListarAdministradores.DataSource = unaControladoraAdmin.Listar();
            this.gvListarAdministradores.DataBind();
        }
        private void AdministradorConPermisos()
        {
            int IdAdmin = int.Parse(Session["AdministradorLogeado"].ToString());
            Dominio.Controladoras.ControladoraAdministrador unaControladoraAdmin = new Dominio.Controladoras.ControladoraAdministrador();
            Dominio.Administrador unAdministrador = unaControladoraAdmin.Buscar(IdAdmin);
            if (unAdministrador.Permisos)
            {
                this.btnEliminarAdmninstrador.Visible = true;
            }
            
        }

        private bool VerificarCamposNoOcupados()
        {
            if (this.txtCorreoElectronico.Text != "" || this.txtContraseña.Text != "")
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
            this.txtCorreoElectronico.Text = "";
            this.txtContraseña.Text = "";
            this.txtConfirmarContraseña.Text = "";
            this.txtCorreoElectronico.Focus();
        }
        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (this.VerificarCamposNoOcupados())
            {
                string correoelectronico = this.txtCorreoElectronico.Text;
                string confirmarContraseña = this.txtConfirmarContraseña.Text;
                string contraseña = this.txtContraseña.Text;


                if (contraseña == confirmarContraseña)
                {
                    Dominio.Controladoras.ControladoraAdministrador unaControladoraAdmin = new Dominio.Controladoras.ControladoraAdministrador();
                    Dominio.Administrador unAdministrador = new Dominio.Administrador(correoelectronico, contraseña);

                    if (unaControladoraAdmin.Alta(unAdministrador))
                    {
                        this.lblMensaje.MensajeActivo(1, "Ha sido dado de alta");
                        this.ListarAdmininstradores();
                        this.LimpiarCampos();
                    }
                    else
                    {
                        this.lblMensaje.MensajeActivo(2, "No se ha podado dar de alta");
                    }
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "Las contraseñas deben ser iguales");
                }


            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "Complete todos los campos");
            }

        }

        protected void btnEliminarAdmninstrador_Click(object sender, EventArgs e)
        {
            if (this.VerificarCamposNoOcupados())
            {
                GridViewRow row = this.gvListarAdministradores.SelectedRow;
                int id = int.Parse(row.Cells[2].Text);

                int IdAdmin = int.Parse(Session["AdministradorLogeado"].ToString());
                if (IdAdmin != id)
                {
                    Dominio.Controladoras.ControladoraAdministrador unaControladoraAdmin = new Dominio.Controladoras.ControladoraAdministrador();

                    if (unaControladoraAdmin.Baja(id))
                    {
                        this.lblMensaje.MensajeActivo(1, "Ha sido dado de baja Correctamente");
                        this.LimpiarCampos();
                        this.ListarAdmininstradores();

                    }
                    else
                    {
                        this.lblMensaje.MensajeActivo(2, "No se ha podido dar de baja");
                    }
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "No te puedes eliminar a ti mismo");
                }

            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "Seleccione un administrador de la lista de Administradores");
            }
        }

        
        protected void gvListarAdministradores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdAdmin = int.Parse(Session["AdministradorLogeado"].ToString());
            GridViewRow row = this.gvListarAdministradores.SelectedRow;
            int id = int.Parse(row.Cells[2].Text);
            if (IdAdmin != id)
            {
                Dominio.Controladoras.ControladoraAdministrador unaControladoraAdmin = new Dominio.Controladoras.ControladoraAdministrador();
                Dominio.Administrador unAdministrador = unaControladoraAdmin.Buscar(id);
                this.txtCorreoElectronico.Text = unAdministrador.CorreoElectronico;
                this.txtContraseña.Text = unAdministrador.Contraseña;
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "No te puedes eliminar a ti mismo");
            }
        }
    }
}