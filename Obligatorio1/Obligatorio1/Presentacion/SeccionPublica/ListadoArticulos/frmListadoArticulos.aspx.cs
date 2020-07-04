using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio1.Presentacion.SeccionPublica.ListadoArticulos
{
    public partial class frmListadoArticulos : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                IndicePaginado = 0;
                IndiceAnterior = 0;
                if (Session["FiltrarListaDestacado"] != null)
                {
                    List<string> lista = new List<string>();
                    lista.Add(Session["FiltrarListaDestacado"].ToString());
                    this.ListadoPaginado(IndiceAnterior, lista, "Instrumento");
                    Session["FiltrarListaDestacado"] = null;
                }
                else if(Session["FiltrarListaPrecioAsc"] != null)
                {
                    List<string> lista = new List<string>();
                    lista.Add(Session["FiltrarListaPrecioAsc"].ToString());
                    this.ListadoPaginado(IndiceAnterior, lista,"Instrumento");
                    Session["FiltrarListaPrecioAsc"] = null;
                }
                else if (Session["FiltrarListaPrecioDesc"] != null)
                {
                    List<string> lista = new List<string>();
                    lista.Add(Session["FiltrarListaPrecioDesc"].ToString());
                    this.ListadoPaginado(IndiceAnterior, lista, "Instrumento");
                    Session["FiltrarListaPrecioDesc"] = null;
                }
                else if(Session["FiltrarListaDescuento"] != null)
                {
                    List<string> lista = new List<string>();
                    lista.Add(Session["FiltrarListaDescuento"].ToString());
                    this.ListadoPaginado(IndiceAnterior, lista, "Instrumento");
                    Session["FiltrarListaDescuento"] = null;
                }
                else if (Session["FiltrarListaAccesorioPrecioAsc"] != null)
                {
                    List<string> lista = new List<string>();
                    lista.Add(Session["FiltrarListaAccesorioPrecioAsc"].ToString());
                    this.ListadoPaginado(IndiceAnterior, lista, "Accesorio");
                    Session["FiltrarListaAccesorioPrecioAsc"] = null;
                }
                else if(Session["FiltrarListaAccesorioPrecioDesc"] != null)
                {
                    List<string> lista = new List<string>();
                    lista.Add(Session["FiltrarListaAccesorioPrecioDesc"].ToString());
                    this.ListadoPaginado(IndiceAnterior, lista, "Accesorio");
                    Session["FiltrarListaAccesorioPrecioDesc"] = null;
                }
                else
                {
                    this.ListadoPaginado(IndiceAnterior,null,"");
                }
                //this.GenerarListasFiltrado();
            }
            else
            {
                if (Session["FiltrarListaDestacado"] != null)
                {
                    List<string> lista = new List<string>();
                    lista.Add(Session["FiltrarListaDestacado"].ToString());
                    this.ListadoPaginado(IndiceAnterior, lista,"Instrumento");
                }
                 else if(Session["FiltrarListaPrecioAsc"] != null)
                {
                    List<string> lista = new List<string>();
                    lista.Add(Session["FiltrarListaPrecioAsc"].ToString());
                    this.ListadoPaginado(IndiceAnterior, lista,"Instrumento");
                }
                else if (Session["FiltrarListaPrecioDesc"] != null)
                {
                    List<string> lista = new List<string>();
                    lista.Add(Session["FiltrarListaPrecioDesc"].ToString());
                    this.ListadoPaginado(IndiceAnterior, lista, "Instrumento");
                }
                else if (Session["FiltrarListaDescuento"] != null)
                {
                    List<string> lista = new List<string>();
                    lista.Add(Session["FiltrarListaDescuento"].ToString());
                    this.ListadoPaginado(IndiceAnterior, lista, "Instrumento");
                }
                else if (Session["FiltrarListaAccesorioPrecioAsc"] != null)
                {
                    List<string> lista = new List<string>();
                    lista.Add(Session["FiltrarListaAccesorioPrecioAsc"].ToString());
                    this.ListadoPaginado(IndiceAnterior, lista, "Accesorio");
                }
                else if (Session["FiltrarListaAccesorioPrecioDesc"] != null)
                {
                    List<string> lista = new List<string>();
                    lista.Add(Session["FiltrarListaAccesorioPrecioDesc"].ToString());
                    this.ListadoPaginado(IndiceAnterior, lista, "Accesorio");
                }
                else
                {
                    this.ListadoPaginado(IndiceAnterior, null,"");
                }
            }
        }


        private int IndicePaginado
        {
            get {
                int result = 0;
                if (Session["InicioPaginado"] != null)
                {
                    
                     int.TryParse(Session["InicioPaginado"].ToString(),out result);
                }
                return result;
            }
            set
            {
                Session["InicioPaginado"] = value;
            }
        }

        private int IndiceAnterior
        {
            get
            {
                int result = 0;
                if (Session["IndiceAnterior"] != null)
                {

                    int.TryParse(Session["IndiceAnterior"].ToString(), out result);
                }
                return result;
            }
            set
            {
                Session["IndiceAnterior"] = value;
            }
        }

        private Dominio.Controladoras.ControladoraListado InstanciaControladoraPaginado
        {
            get
            {
                return Dominio.Controladoras.ControladoraListado.Instancia;
            }
        }
        private void ListadoPaginado(int pIndice,List<string> pLista,string pTipoArticulo)
        {
            
            this.ContenedorPrincipal.Controls.Clear();
            List<Dominio.Articulo> listaPaginada = InstanciaControladoraPaginado.Paginado(pIndice,pLista,pTipoArticulo);
            foreach (Dominio.Articulo unArticulo in listaPaginada)
            {
                Panel ContenedorImagen = new Panel();
                ImageButton ImagenPrincipal = new ImageButton();
                ImagenPrincipal.Click += btnVerDetalle_Click;
                
                ImagenPrincipal.ImageUrl = unArticulo.FotoPrincipal;
                ImagenPrincipal.CssClass = "img-fluid ImagenPrincipal";
                ImagenPrincipal.ID = unArticulo.Id.ToString();
                ContenedorImagen.Controls.Add(ImagenPrincipal);
                Panel ContenedorTexto = new Panel();
                ContenedorTexto.CssClass = "ContenedorTexto";
                Label Precio = new Label();
                Precio.Text = "$ " + unArticulo.Precio.ToString() +" " ;
                Precio.CssClass = "Precio";
                Label Nombre = new Label();
                Nombre.Text = unArticulo.Nombre;
                Nombre.CssClass = "Nombre";

                Dominio.Instrumento unInstrumento = unArticulo as Dominio.Instrumento;
                if (unInstrumento != null)
                {
                    Label Oferta = new Label();
                    if (unInstrumento.Descuento != 0)
                    {
                        Oferta.Text = "%" + unInstrumento.Descuento.ToString();
                        Oferta.CssClass = "OfertaInstrumento";
                        ContenedorTexto.Controls.Add(Precio);
                        ContenedorTexto.Controls.Add(Oferta);
                        ContenedorTexto.Controls.Add(Nombre);
                    }
                    else
                    {
                        ContenedorTexto.Controls.Add(Precio);
                        ContenedorTexto.Controls.Add(Nombre);
                    }
                    if (unInstrumento.Destacado)
                    {
                        Label Destacado = new Label();
                        Destacado.CssClass = "InstrumentoDestacado";
                        Destacado.Text = "Destacado";
                        ContenedorTexto.Controls.Add(Destacado);
                    }
                }

                else
                {
                    ContenedorTexto.Controls.Add(Precio);
                    ContenedorTexto.Controls.Add(Nombre);
                }
                    Panel ContenedorArticulos = new Panel();

                    ContenedorArticulos.CssClass = "ContenedorArticulos text-center";

                    ContenedorArticulos.Controls.Add(ContenedorImagen);
                    ContenedorArticulos.Controls.Add(ContenedorTexto);

                    this.ContenedorPrincipal.Controls.Add(ContenedorArticulos);
                }
            this.ContenedorPrincipal.DataBind();
        }

        protected void btnSiguiente_Click1(object sender, EventArgs e)
        {
            
            if (IndicePaginado == 0)
            {
                IndicePaginado = 13;
            }
            IndiceAnterior = IndicePaginado;
            IndicePaginado += IndiceAnterior;
            if (InstanciaControladoraPaginado.CantidadFilas(IndiceAnterior))
            {
    
                //this.ListadoPaginado(IndiceAnterior);
            }
            else
            {
                //this.ListadoPaginado(IndiceAnterior);
                //this.btnSiguiente.Enabled = false;
            }
        }

        protected void btnVerDetalle_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imagenSeleccionada = (ImageButton)sender;
            int IdArticulo = int.Parse(imagenSeleccionada.ID);
            Dominio.Controladoras.ControladoraAccesorio unaControladoraAccesiorio = new Dominio.Controladoras.ControladoraAccesorio();
            Dominio.Controladoras.ControladoraInstrumentos unaControladoraInstrumento = new Dominio.Controladoras.ControladoraInstrumentos();
            
            if(unaControladoraAccesiorio.Buscar(IdArticulo) != null)
            {
                Session["AccesorioDetalle"] = IdArticulo;
                Response.Redirect("~/Presentacion/SeccionPublica/DetalleArticulos/frmDetalleAccesorio.aspx");
            }
            else if(unaControladoraInstrumento.Buscar(IdArticulo)!= null)
            {
                Session["InstrumentoDetalle"] = IdArticulo;
                Response.Redirect("~/Presentacion/SeccionPublica/DetalleArticulos/frmDetalleInstrumentos.aspx");
            }

        }

        protected void btnIncio_Click(object sender, EventArgs e)
        {
            IndiceAnterior = 0;
            this.btnSiguiente.Enabled = true;
            IndicePaginado = 0;
            //this.ListadoPaginado(IndiceAnterior);
        }

        protected void btnFinal_Click(object sender, EventArgs e)
        {
            int cantidadAMostrar = 12;
            int CantidadElementosTotales = InstanciaControladoraPaginado.CantidadTotalesArticulos();
            int mostrar  = CantidadElementosTotales  - cantidadAMostrar - 1;
            IndicePaginado = CantidadElementosTotales- mostrar;
            IndiceAnterior = IndicePaginado;
            this.btnSiguiente.Enabled = false;
            //this.ListadoPaginado(IndiceAnterior);
        }


        private void GenerarListasFiltrado()
        {
            this.dplListarSubtipos.DataSource = null;
            this.dplListarSubtipos.DataSource = InstanciaControladoraPaginado.ListadoDeNombresSubtipos();
            this.dplListarSubtipos.DataBind();

            this.dplListarTipos.DataSource = null;
            this.dplListarTipos.DataSource = InstanciaControladoraPaginado.ListadoDeNombresTipos();
            this.dplListarTipos.DataBind();

            this.dplFabricantes.DataSource = null;
            this.dplFabricantes.DataSource = InstanciaControladoraPaginado.ListadoDeNombresFabricantes();
            this.dplFabricantes.DataBind();

            this.dplDestacado.Items.Add("Destacado");
            this.dplDestacado.Items.Add("No Destacado");
            this.dplDestacado.DataBind();

            const string decuento15 = "15% OFF";
            const string decuento25 = "25% OFF";
            const string decuento50 = "50% OFF";

            this.dplOferta.Items.Add(decuento15);
            this.dplOferta.Items.Add(decuento25);
            this.dplOferta.Items.Add(decuento50);
            this.dplOferta.DataBind();

            this.dplOrdenar.Items.Add("Ordenar por Nombre");
            this.dplOrdenar.Items.Add("Orden por fecha fabricacion");
            this.dplOrdenar.DataBind();
        }





    }
}