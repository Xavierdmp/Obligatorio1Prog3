﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPrivada.Gestion_Clientes
{
    public partial class frmEliminarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListarClientes();

        }
      


        private void ListarClientes()

        { 
           
         Dominio.Controladoras.ControladoraCliente ControladoraCliente = new Dominio.Controladoras.ControladoraCliente();
         this.gvListaDeClientes.DataSource = null;
         this.gvListaDeClientes.DataSource = ControladoraCliente.Listar();
         this.gvListaDeClientes.DataBind();
        }

        protected void gvListaDeClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.gvListaDeClientes.SelectedRow;
            Dominio.Controladoras.ControladoraCliente ControladoraCliente = new Dominio.Controladoras.ControladoraCliente();
            int Id = int.Parse(row.Cells[1].Text);
            Dominio.Cliente unCliente = ControladoraCliente.Buscar(Id);
            this.lblId.Text = unCliente.Id.ToString();
            this.lblNombre.Text = unCliente.Nombre;
            this.lblApellido.Text = unCliente.Apellido; ;
            this.lblDireccion.Text = unCliente.Direccion;
            this.lblTelefono.Text = unCliente.Telefono.ToString(); ;
            this.lblCedulaIdentidad.Text = unCliente.CedulaIdentidad;
            
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#exampleModal').modal();", true);

        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.lblId.Text);

            Dominio.Controladoras.ControladoraCliente unControladoraCliente = new Dominio.Controladoras.ControladoraCliente();

            if (unControladoraCliente.Baja(id))
            {
                ListarClientes();
                this.lblMensaje.MensajeActivo(1, "se ha dado Baja");
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "No se ha dado de baja");
            }


           
        }

        }
             
           


    
   

        }
