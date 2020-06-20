using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPublica.Ventas
{
    public partial class frmCarritoDeCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarCarrito();
        }

        private void CargarCarrito()
        {
            int IdClienteConectado = int.Parse(Session["ClienteLogueado"].ToString());
            Dominio.Controladoras.ControladoraVentas unaControladoraVentas = new Dominio.Controladoras.ControladoraVentas();

            this.GridView1.DataSource = null;
            this.GridView1.DataSource = unaControladoraVentas.ListarCarritoParaCliente(IdClienteConectado);
            this.GridView1.DataBind();

        }

        private List<Dominio.Item> ListaDeCarrito
        {
            get { return Session["ListaCarrito"] as List<Dominio.Item>; }
            set { Session["ListaCarrito"] = value; }
        }   
       

    }
}