using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPrivada.GestionAdministradores
{
    public partial class frmModificarAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdministradorConectado();
        }
        private void AdministradorConectado()
        {
            int IdAdmin = int.Parse(Session["AdministradorLogeado"].ToString());
            Dominio.Controladoras.ControladoraAdministrador unaControladoraAdmin = new Dominio.Controladoras.ControladoraAdministrador();
            Dominio.Administrador unAdministrador = unaControladoraAdmin.BuscarAdministrador(IdAdmin);
            this.txtCorreoElectronico.Text = unAdministrador.CorreoElectronico;
        }

        protected void btnModificarAdministrador_Click(object sender, EventArgs e)
        {
                string correoelectronico = this.txtCorreoElectronico.Text;
                string contraseña = this.txtContraseña.Text;
                string confirmarcontraseña = this.txtConfirmarContraseña.Text;
            Dominio.Controladoras.ControladoraAdministrador unaControladoraAdmin = new Dominio.Controladoras.ControladoraAdministrador();
            int IdAdmin = int.Parse(Session["AdministradorLogeado"].ToString());
                Dominio.Administrador unAdministrador = unaControladoraAdmin.BuscarAdministrador(IdAdmin);

                unAdministrador.CorreoElectronico = correoelectronico;
                unAdministrador.Contraseña = contraseña;
                string confirmarContraseña = this.txtConfirmarContraseña.Text;
                if (contraseña == confirmarContraseña)
                {
                    if (unaControladoraAdmin.ModificarAdministrador(unAdministrador))
                    {
                        this.lblMensaje.MensajeActivo(1, "Se ha modificado con exito");
                        this.LimpiarDatos();
                    }
                    else
                    {
                        this.lblMensaje.MensajeActivo(2, "No se ha modificado ");
                    }
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "Las contraseñas deben coincidir ");
                }
            }

        private void LimpiarDatos()        {            this.txtCorreoElectronico.Text = "";            this.txtConfirmarContraseña.Text = "";
            this.txtConfirmarContraseña.Text = "";
        }

    }
}