using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPrivada
{
    public partial class frmInicioSeccionPrivada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void AdministradorActivo()
        {
            int idAdmin = int.Parse(Session["AdministradorLogeado"].ToString());
            Dominio.Controladoras.ControladoraAdministrador unaControladoraAdmin = new Dominio.Controladoras.ControladoraAdministrador();
            Dominio.Administrador unAdministrador = unaControladoraAdmin.BuscarAdministrador(idAdmin);
            this.lblAdministradorActivo.Text = "Bienvenido " + unAdministrador.CorreoElectronico;

        }
    }
}