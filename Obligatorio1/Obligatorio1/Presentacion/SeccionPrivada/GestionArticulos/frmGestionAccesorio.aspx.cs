using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPrivada.GestionArticulos
{
    public partial class frmGestionAccesorio : System.Web.UI.Page
    {
        private const int maximoTamañoImagen = 3145784;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ListarAccesorios();
                this.ListarFabricantes();
                this.ListarSubtiposDeInstrumentos();
                this.LimpiarListasParaAlta();
                this.ListaFotosAdicionales(); 
            }
            this.CargarImagenPrincipal();
        }

        private void LimpiarCampos()
        {
            this.txtDescripcion.Text = "";
            this.txtNombre.Text = "";
            this.txtPrecio.Text = "";
            this.txtStock.Text = "";
            this.txtNombre.Focus();
        }
        private void LimpiarListasParaAlta()
        {
            if (ListarFotosAdicionales != null)
            {
                ListarFotosAdicionales.Clear();
            }
            if (ListaSubtiposSeleccionados != null)
            {
                this.ListaSubtiposSeleccionados.Clear();
            }
        }

        private void ListarSubtiposDeInstrumentos()
        {
            Dominio.Controladoras.ControladoraSubTipos unaControladora = new Dominio.Controladoras.ControladoraSubTipos();
            this.dplListarSubtipo.DataSource = null;
            this.dplListarSubtipo.DataSource = unaControladora.Listar();
            this.dplListarSubtipo.DataBind();
        }
        private void ListarFabricantes()
        {
            Dominio.Controladoras.ControladoraFabricante unaControladora = new Dominio.Controladoras.ControladoraFabricante();
            this.dplListaFabricante.DataSource = null;
            this.dplListaFabricante.DataSource = unaControladora.Listar();
            this.dplListaFabricante.DataBind();
        }
        private void ListarAccesorios()
        {
            Dominio.Controladoras.ControladoraAccesorio unaControladora = new Dominio.Controladoras.ControladoraAccesorio();
            this.gvListarAccesorios.DataSource = null;
            this.gvListarAccesorios.DataSource = unaControladora.Listar();
            this.gvListarAccesorios.DataBind();
        }

        private void ListarSubtiposSeleccionados()
        {
            this.gvListarSubtiposDeAccesorio.DataSource = null;
            this.gvListarSubtiposDeAccesorio.DataSource = this.ListaSubtiposSeleccionados;
            this.gvListarSubtiposDeAccesorio.DataBind();
        }

        private List<Dominio.FotosAdicionales> ListarFotosAdicionales
        {
            get { return Session["FotosAdicionales"] as List<Dominio.FotosAdicionales>; }
            set { Session["FotosAdicionales"] = value; }
        }

        private List<Dominio.SubTipo> ListaSubtiposSeleccionados
        {
            get { return Session["SubtiposSeleccionados"] as List<Dominio.SubTipo>; }
            set { Session["SubtiposSeleccionados"] = value; }
        }

        private List<Dominio.SubTipo> ListarSubtiposParaDarDeAlta(List<Dominio.SubTipo> pListaSubtipos)
        {
            List<Dominio.SubTipo> lista = new List<Dominio.SubTipo>();
            foreach(Dominio.SubTipo unSubtipo in pListaSubtipos)
            {
                lista.Add(unSubtipo);
            }
            return lista;
        }

        private List<Dominio.FotosAdicionales> ListaConFotosAdicionalesParaAlta(List<Dominio.FotosAdicionales> pLista)
        {
            List<Dominio.FotosAdicionales> lista = new List<Dominio.FotosAdicionales>();
            foreach(Dominio.FotosAdicionales unaUrl in pLista)
            {
                lista.Add(unaUrl);
            }
            return lista;
        }


        private void CargarImagenPrincipal()
        {
            if (this.fuImagenPrincipal.HasFile)
            {
                string Extension = System.IO.Path.GetExtension(fuImagenPrincipal.PostedFile.FileName);
                if (Extension == ".PNG" || Extension == ".png" || Extension == ".JPG" || Extension == ".jpg")
                {
                    if (this.fuImagenPrincipal.FileName.Length < 150 && this.fuImagenPrincipal.PostedFile.ContentLength <= maximoTamañoImagen)
                    {
                        this.fuImagenPrincipal.SaveAs(Server.MapPath("~/Imagenes/ImgPrincipalAcessorios/" + this.fuImagenPrincipal.FileName));
                        UrlFotoPrincipal = "~/Imagenes/ImgPrincipalAcessorios/" + this.fuImagenPrincipal.FileName;
                        this.MostrarFotoPrincipal.ImageUrl = UrlFotoPrincipal;
                    }
                    else
                    {
                        this.lblMensaje.MensajeActivo(2, "Imagen no permitida");
                    }
                }
                else
                {
                    this.lblMensaje.MensajeActivo(2, "Solo se permiten imagenes .PNG");
                }
            }
        }

        private string UrlFotoPrincipal
        {
            get { return Session["ImagenPrincipal"] as string; }
            set { Session["ImagenPrincipal"] = value; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.dplListaFabricante.SelectedIndex > 0 && this.dplListarSubtipo.SelectedIndex >0 && this.UrlFotoPrincipal !="")
            {
                Dominio.Controladoras.ControladoraFabricante unaControladoraFabricante = new Dominio.Controladoras.ControladoraFabricante();
                Dominio.Controladoras.ControladoraAccesorio unaControladoraAccesorio = new Dominio.Controladoras.ControladoraAccesorio();
                string nombre = this.txtNombre.Text;
                string descripcion = this.txtDescripcion.Text;
                int precio = int.Parse(this.txtPrecio.Text);
                int stock = int.Parse(this.txtStock.Text);

                string ObjetoFabricante = this.dplListaFabricante.SelectedItem.ToString();
                string[] arrayFabricante = ObjetoFabricante.Split(' ');
                int idFabricante = int.Parse(arrayFabricante[1]);
                Dominio.Fabricante unFabricante = unaControladoraFabricante.Buscar(idFabricante);

                List<Dominio.SubTipo> listaSubtipos = this.ListarSubtiposParaDarDeAlta(ListaSubtiposSeleccionados);
                if (ListarFotosAdicionales == null)
                    {
                        Dominio.Accesorio unAccesorio = new Dominio.Accesorio(nombre, descripcion, unFabricante, UrlFotoPrincipal, precio, stock,listaSubtipos);
                        if (unaControladoraAccesorio.Alta(unAccesorio))
                        {
                            this.lblMensaje.MensajeActivo(1, "El accesorio se registro con exito");
                            this.LimpiarCampos();
                            this.ListarAccesorios();
                            ListaSubtiposSeleccionados.Clear();
                            this.ListarSubtiposSeleccionados();
                            this.MostrarFotoPrincipal.ImageUrl = null;
                            UrlFotoPrincipal = "";
                        }
                        else
                        {
                            this.lblMensaje.MensajeActivo(2, "El accesorio no se pudo registrar");
                            this.LimpiarCampos();
                            this.MostrarFotoPrincipal.ImageUrl = null;
                            UrlFotoPrincipal = "";
                        }
                    }
                    else
                    {
                        List<Dominio.FotosAdicionales> listaFotosAdicionales = this.ListaConFotosAdicionalesParaAlta(ListarFotosAdicionales);
                        Dominio.Accesorio unAccesorio = new Dominio.Accesorio(nombre, descripcion, unFabricante, UrlFotoPrincipal, listaFotosAdicionales, precio, stock, listaSubtipos);
                        if (unaControladoraAccesorio.Alta(unAccesorio))
                        {
                            this.lblMensaje.MensajeActivo(1, "El accesorio se registro con exito");
                            this.LimpiarCampos();
                            this.ListarAccesorios();
                            ListaSubtiposSeleccionados.Clear();
                            this.ListarSubtiposSeleccionados();
                            ListarFotosAdicionales.Clear();
                            this.ListaFotosAdicionales();
                            this.MostrarFotoPrincipal.ImageUrl = null;
                            UrlFotoPrincipal = "";
                        }
                        else
                        {
                            this.lblMensaje.MensajeActivo(2, "El accesorio no se pudo registrar");
                            this.LimpiarCampos();
                            this.MostrarFotoPrincipal.ImageUrl = null;
                            UrlFotoPrincipal = "";
                        }
                    }
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "Seleccione un fabricante u un subtipo");
            }
        }
        protected void btnAgregarImagenAdicional_Click(object sender, EventArgs e)
        {
            if (this.fuFotosAdicionales.HasFile)
            {
                string Extension = System.IO.Path.GetExtension(fuFotosAdicionales.PostedFile.FileName);
                if (Extension == ".PNG" || Extension == ".png" || Extension == ".JPG" || Extension == ".jpg")
                {
                    if (this.fuFotosAdicionales.FileName.Length < 150 && this.fuFotosAdicionales.PostedFile.ContentLength <= maximoTamañoImagen)
                    {
                        string urlImagen = "~/Imagenes/FotosAdicionales/" + this.fuFotosAdicionales.FileName;
                        this.fuFotosAdicionales.SaveAs(Server.MapPath("~/Imagenes/FotosAdicionales/" + this.fuFotosAdicionales.FileName));
                        Dominio.FotosAdicionales unaFotoAdicional = new Dominio.FotosAdicionales(urlImagen);
                        if (ListarFotosAdicionales == null)
                        {
                            List<Dominio.FotosAdicionales> lista = new List<Dominio.FotosAdicionales>();
                            lista.Add(unaFotoAdicional);
                            ListarFotosAdicionales = lista;
                        }
                        else
                        {
                            ListarFotosAdicionales.Add(unaFotoAdicional);
                        }
                        this.ListaFotosAdicionales();
                    }
                }
            }
        }
        private void ListaFotosAdicionales()
        {
            this.gvListarImagenesAdicionales.DataSource = null;
            this.gvListarImagenesAdicionales.DataSource = ListarFotosAdicionales;
            this.gvListarImagenesAdicionales.DataBind();
        }

        protected void gvListarImagenesAdicionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.gvListarImagenesAdicionales.SelectedRow;
            Image img = row.Cells[1].Controls[0] as Image;
            string url = img.ImageUrl;
            Dominio.FotosAdicionales unaFotoAdicional = new Dominio.FotosAdicionales(url);
            ListarFotosAdicionales.Remove(unaFotoAdicional);
            this.ListaFotosAdicionales();
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            GridViewRow row = this.gvListarAccesorios.SelectedRow;
            int id = int.Parse(row.Cells[1].Text);
            Dominio.Controladoras.ControladoraAccesorio unaControladoraAccesorio = new Dominio.Controladoras.ControladoraAccesorio();
            if (unaControladoraAccesorio.Baja(id))
            {
                this.lblMensaje.MensajeActivo(1,"Accesorio eliminado con exito");
                this.ListarAccesorios();
                this.LimpiarCampos();
                this.ListaSubtiposSeleccionados.Clear();
                this.ListarSubtiposSeleccionados();
                this.MostrarFotoPrincipal.ImageUrl = null;
                UrlFotoPrincipal = "";
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "El accesorio no se pudo dar de baja");
            }
            if(ListarFotosAdicionales != null)
            {
                this.ListarFotosAdicionales.Clear();
                this.ListaFotosAdicionales();

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.dplListaFabricante.SelectedIndex > 0 && this.dplListarSubtipo.SelectedIndex > 0 && this.Session["ImagenPrincipal"] != null)
            {
                Dominio.Controladoras.ControladoraFabricante unaControladoraFabricante = new Dominio.Controladoras.ControladoraFabricante();
                Dominio.Controladoras.ControladoraSubTipos unaControladoraSubtipo = new Dominio.Controladoras.ControladoraSubTipos();
                Dominio.Controladoras.ControladoraAccesorio unaControladoraAccesorio = new Dominio.Controladoras.ControladoraAccesorio();
                GridViewRow row = this.gvListarAccesorios.SelectedRow;
                int id = int.Parse(row.Cells[1].Text);
                Dominio.Accesorio unAccesorio = unaControladoraAccesorio.Buscar(id);
                string nombre = this.txtNombre.Text;
                string descripcion = this.txtDescripcion.Text;
                int precio = int.Parse(this.txtPrecio.Text);
                int stock = int.Parse(this.txtStock.Text);

                string ObjetoFabricante = this.dplListaFabricante.SelectedItem.ToString();
                string[] arrayFabricante = ObjetoFabricante.Split(' ');
                int idFabricante = int.Parse(arrayFabricante[1]);
                Dominio.Fabricante unFabricante = unaControladoraFabricante.Buscar(idFabricante);

                string ObjetoSubtipo = this.dplListarSubtipo.SelectedItem.ToString();
                string[] partesSubtipo = ObjetoSubtipo.Split(' ');
                int idSubtipo = int.Parse(partesSubtipo[1]);
                Dominio.SubTipo unSubtipo = unaControladoraSubtipo.Buscar(idSubtipo);
                unAccesorio.Nombre = nombre;
                unAccesorio.Descripcion = descripcion;
                unAccesorio.Precio = precio;
                unAccesorio.Stock = stock;
                unAccesorio.ListarSubtipos = ListaSubtiposSeleccionados;
                unAccesorio.Fabricante = unFabricante;
                    if (ListarFotosAdicionales == null)
                    {
                        unAccesorio.FotoPrincipal = UrlFotoPrincipal;
                        if (unaControladoraAccesorio.Modificar(unAccesorio))
                        {
                            this.lblMensaje.MensajeActivo(1, "El accesorio se registro con exito");
                            this.LimpiarCampos();
                            this.ListarAccesorios();
                            ListarFotosAdicionales.Clear();
                            ListaSubtiposSeleccionados.Clear();
                            this.ListarSubtiposSeleccionados();
                            this.ListaFotosAdicionales();
                            this.MostrarFotoPrincipal.ImageUrl = null;
                            UrlFotoPrincipal = "";

                        }
                        else
                        {
                            this.lblMensaje.MensajeActivo(2, "El accesorio no se pudo registrar");
                            this.LimpiarCampos();
                            this.MostrarFotoPrincipal.ImageUrl = null;
                            UrlFotoPrincipal = "";
                        }
                    }
                    else
                    {
                        List<Dominio.FotosAdicionales> listaFotosAdicionales = this.ListaConFotosAdicionalesParaAlta(ListarFotosAdicionales);
                        unAccesorio.ListaFotosAdicionales = listaFotosAdicionales;
                        if (unaControladoraAccesorio.Modificar(unAccesorio))
                        {
                            this.lblMensaje.MensajeActivo(1, "El accesorio se registro con exito");
                            this.LimpiarCampos();
                            this.ListarAccesorios();
                            ListarFotosAdicionales.Clear();
                            ListaSubtiposSeleccionados.Clear();
                            this.ListarSubtiposSeleccionados();
                            this.ListaFotosAdicionales();
                            this.MostrarFotoPrincipal.ImageUrl = null;
                            UrlFotoPrincipal = "";
                        }
                        else
                        {
                            this.lblMensaje.MensajeActivo(2, "El accesorio no se pudo registrar");
                            this.LimpiarCampos();
                            this.MostrarFotoPrincipal.ImageUrl = null;
                            UrlFotoPrincipal = "";
                        }
                    }
            }
            else
            {
                this.lblMensaje.MensajeActivo(2, "Seleccione un fabricante u un subtipo");
            }
        }

        protected void gvListarAccesorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.gvListarAccesorios.SelectedRow;
            int id = int.Parse(row.Cells[1].Text);
            Dominio.Controladoras.ControladoraAccesorio unaControladoraAccesorio = new Dominio.Controladoras.ControladoraAccesorio();
            Dominio.Accesorio unAccesorio = unaControladoraAccesorio.Buscar(id);
            this.txtNombre.Text = unAccesorio.Nombre;
            this.txtDescripcion.Text = unAccesorio.Descripcion;
            this.txtPrecio.Text = unAccesorio.Precio.ToString();
            this.txtStock.Text = unAccesorio.Stock.ToString();
            ListarFotosAdicionales = unaControladoraAccesorio.ListarFotosAdicionalesAccesorio(id);
            this.ListaFotosAdicionales();
            ListaSubtiposSeleccionados = unaControladoraAccesorio.ListarSubTiposParaAccesorio(id);
            this.ListarSubtiposSeleccionados();
            this.MostrarFotoPrincipal.ImageUrl = unAccesorio.FotoPrincipal;
        }

        protected void dplListarSubtipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dplListarSubtipo.SelectedIndex > 0)
            {
                string SubtipoItem = this.dplListarSubtipo.SelectedItem.ToString();
                string[] partesSubtipo = SubtipoItem.Split(' ');
                int IdSubtipo = int.Parse(partesSubtipo[1]);
                Dominio.Controladoras.ControladoraSubTipos ControladoraSubtipo = new Dominio.Controladoras.ControladoraSubTipos();
                Dominio.SubTipo unSubtipo = ControladoraSubtipo.Buscar(IdSubtipo);

                if (ListaSubtiposSeleccionados == null)
                {
                    List<Dominio.SubTipo> lista = new List<Dominio.SubTipo>();
                    lista.Add(unSubtipo);
                    ListaSubtiposSeleccionados = lista;
                }
                else
                {
                    if (!this.ComprobarSiSeEncuentra(unSubtipo.Id))
                    {
                        ListaSubtiposSeleccionados.Add(unSubtipo);
                    }
                }
                this.ListarSubtiposSeleccionados();
            }
        }

        private bool ComprobarSiSeEncuentra(int pId)
        {
            foreach(Dominio.SubTipo unSubtipo in ListaSubtiposSeleccionados)
            {
                if(unSubtipo.Id == pId)
                {
                    return true;
                }
            }
            return false;
        }
        protected void gvListarSubtiposDeAccesorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dplListarSubtipo.SelectedIndex > 0)
            {
                GridViewRow fila = this.gvListarSubtiposDeAccesorio.SelectedRow;
                int IdSubtipo = int.Parse(fila.Cells[1].Text);
                Dominio.Controladoras.ControladoraSubTipos unaControladoraSubtipo = new Dominio.Controladoras.ControladoraSubTipos();
                Dominio.SubTipo unSubtipo = unaControladoraSubtipo.Buscar(IdSubtipo);
                ListaSubtiposSeleccionados.Remove(unSubtipo);
                this.ListarSubtiposSeleccionados();
            }
        }
    }
}