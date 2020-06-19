using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPrivada.SiteMasterPrivate
{
    public partial class frmPrivate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdministradorConectado();
        }
        private void AdministradorConectado()
        {
            if (Session["AdministradorLogueado"] != null)
            {
                int IdAdmin = int.Parse(Session["AdministradorLogueado"].ToString());
                Dominio.Controladoras.ControladoraAdministrador unaControladoraAdmin = new Dominio.Controladoras.ControladoraAdministrador();
                Dominio.Administrador unAdministrador = unaControladoraAdmin.Buscar(IdAdmin);
                this.lblAdminConectado.Text = unAdministrador.CorreoElectronico;
            }
        }
    }
}