using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.Autenticación
{
    public partial class frmIniciarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool ComprobarCampos()
        {
            if(this.txtContraseña.Text !=""|| this.txtCorreo.Text != "")
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
            this.txtContraseña.Text = "";
            this.txtContraseña.Text = "";
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (this.ComprobarCampos())
            {
                string correo = this.txtCorreo.Text;
                string contraseña = this.txtContraseña.Text;

                Dominio.Controladoras.ControladoraLogin unLogin = new Dominio.Controladoras.ControladoraLogin();
                int idCliente = unLogin.IniciarSesionCliente(correo, contraseña);
                int IdAdministrador = unLogin.IniciarSesionAdministradores(correo, contraseña);
                if (idCliente != -1)
                {
                    Session["ClienteLogeado"] = idCliente;
                    Response.Redirect("~/Default.aspx");
                }
                else if (IdAdministrador != -1)
                {
                    Session["AdministradorLogeado"] = IdAdministrador;
                    Response.Redirect("~/Presentacion/SeccionPrivada/frmInicioSeccionPrivada.aspx");
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "No se pudo iniciar sesion");
                    this.LimpiarCampos();
                }

            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "Debes completar todos los campos");
            }
        }


    }
}