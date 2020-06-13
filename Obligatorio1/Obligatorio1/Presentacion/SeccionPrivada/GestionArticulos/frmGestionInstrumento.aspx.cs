﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio1.Dominio;

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
                this.ListarFabricantes();
                this.ListarFotosAdicionales();
                this.ListarColoresSeleccionados();
                this.ListarDescuentos();
                this.ListarSubtipos();

            }
        }
    
        private void ListarColores()
        {
            Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
            this.dplListarColores.DataSource = null;
            this.dplListarColores.DataSource = unaControladora.Listar();
            this.dplListarColores.DataBind();

        }

        private void ListarColoresModal()
        {
            Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
            this.gvListaColores.DataSource = null;
            this.gvListaColores.DataSource = unaControladora.Listar();
            this.gvListaColores.DataBind();

        }

        private void ListarFabricantes()
        {
            Dominio.Controladoras.ControladoraFabricante unControladorFabricante = new Dominio.Controladoras.ControladoraFabricante();
            this.dplListaFabricante.DataSource = null;
            this.dplListaFabricante.DataSource = unControladorFabricante.Listar();
            this.dplListaFabricante.DataBind();

        }

        private void ListarSubtipos()
        {
            Dominio.Controladoras.ControladoraSubTipos unaControlaSubtipo = new Dominio.Controladoras.ControladoraSubTipos();
            this.dplListarSubtipo.DataSource = null;
            this.dplListarSubtipo.DataSource = unaControlaSubtipo.Listar();
            this.dplListarSubtipo.DataBind();
        }

        
        private void LimpiarCampos()
        {
            this.txtNombre.Text = "";
            this.txtPrecio.Text = "";
            this.txtDescripcion.Text = "";
            this.txtFechaFabricacion.Text = "";
            this.txtStock.Text = "";
            this.txtVideoYoutube.Text = "";

        }
        private void ListarDescuentos()
        {

            List<int> descuentos = new List<int>();

            descuentos.Add(15);
            descuentos.Add(25);
            descuentos.Add(50);

            this.dplListaDescuentos.DataSource = null;
            this.dplListaDescuentos.DataSource = descuentos;
            this.dplListaDescuentos.DataBind();

        }

        private List<Color> ListaColores
        {
            get { return Session["ListaColores"] as List<Color>; }
            set { Session["ListaColores"] = value; }
         }
       
        private void ListarColoresSeleccionados()
        {
            this.gvListaColores.DataSource = null;
            this.gvListaColores.DataSource = ListaColores;
            this.gvListaColores.DataBind();
        }



        protected void btnAltaColor_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombreColor.Text;
            string CodigoColor = this.txtCodigoColor.Text;


            Dominio.Controladoras.ControladoraColor unaControladora = new Dominio.Controladoras.ControladoraColor();
            Dominio.Color unColor = new Dominio.Color(nombre, CodigoColor);

            if (unaControladora.Alta(unColor))
            {
                this.lblMensajeColor.MensajeActivo(1, "EL color se agrego con exito");
                this.ListarColores();
                this.txtNombreColor.Text = "";

            }
            else
            {
                this.lblMensajeColor.MensajeActivo(2, "El color no se ha podido agregar");
                this.txtNombreColor.Text = "";
            }

        }

        private List<Dominio.FotosAdicionales> ListaFotosAdicionales// es un accesor

        {
            get { return Session["ListaFotosAd"] as List<Dominio.FotosAdicionales>; }
            set { Session["ListaFotosAd"] = value; }

        }
      
        private List<Color> AsignarColoresParaAlta()
        {
            List<Color> ListasColores = new List<Color>();

            foreach (Color unColor in ListaColores)
            {
                ListaColores.Add(unColor);
            }
            return ListasColores;
        }
        
        private void ListarFotosAdicionales()
        {
            this.gvListarImagenesAdicionales.DataSource = null;
            this.gvListarImagenesAdicionales.DataSource = ListaFotosAdicionales; //mismo nombre que el metodo accesor.
            this.gvListarImagenesAdicionales.DataBind();
        }
        private List<Dominio.FotosAdicionales> AsignarFotosParaAlta()
        {
            List<Dominio.FotosAdicionales> lista = new List<Dominio.FotosAdicionales>();

            foreach (Dominio.FotosAdicionales unaFoto in ListaFotosAdicionales)
            {
                lista.Add(unaFoto);
            }

            return lista;       /*Recibe la lista de fotos, con esa lista de fot s crea una lista vacia de fotos*/

        }

        protected void dplListarColores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dplListarColores.SelectedIndex > 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#ModalColores').modal();", true); /*Abre Modal*/


            }
        }
    }
}
         