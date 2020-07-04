using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Dominio;
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pListadoArticulos
    {
        private static pListadoArticulos _instancia = null;

        public static pListadoArticulos Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new pListadoArticulos();
                }
                return _instancia;
            }
        }

        private pListadoArticulos() { }

        public int CantidadArticulos()
        {
            string consulta = "select count(*) from Articulos;";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            int cantidad = 0;
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                foreach (DataRow row in tabla)
                {
                    object[] elementos = row.ItemArray;
                    cantidad = int.Parse(elementos[0].ToString());
                }
            }
            return cantidad;
        }


        public List<Articulo> ListadoDeArticulos(string pFiltro, string pTipoArticulo)
        {
            string consulta = "Select a.* from Articulos a, Accesorios acc where" + " a.Id_Articulo = acc.Id_Accesorio";
            string consultaInstrumento = "Select * from Instrumentos i, Articulos a where i.Id_Instrumento = a.Id_Articulo;";

            if (pFiltro != "" && pFiltro != null)
            {
                if (pTipoArticulo == "Instrumento")
                {
                    List<string> ConsultasSql = this.ConsultaSql(pFiltro);
                    consultaInstrumento = ConsultasSql[1];
                    consulta = "";
                }
                else
                {
                    List<string> ConsultasSql = this.ConsultaSql(pFiltro);
                    consulta = ConsultasSql[0];
                    consultaInstrumento = "";
                }
            }
            List<Articulo> listaArticulos = new List<Articulo>();
            if (consulta != "")
            {
                DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
                if (datos.Tables[0].Rows.Count > 0)
                {
                    DataRowCollection tabla = datos.Tables[0].Rows;
                    foreach (DataRow row in tabla)
                    {
                        Dominio.Accesorio unAccesorio = new Dominio.Accesorio();
                        object[] elementos = row.ItemArray;
                        unAccesorio.Id = int.Parse(elementos[0].ToString());
                        unAccesorio.Nombre = elementos[1].ToString();
                        unAccesorio.Descripcion = elementos[2].ToString();
                        int idFabricante = int.Parse(elementos[3].ToString());
                        unAccesorio.Fabricante = Controladora.Instancia.BuscarFabricante(idFabricante);
                        unAccesorio.FotoPrincipal = elementos[4].ToString();
                        unAccesorio.Precio = int.Parse(elementos[5].ToString());
                        unAccesorio.Stock = int.Parse(elementos[6].ToString());
                        listaArticulos.Add(unAccesorio);
                    }
                }
            }
            if (consultaInstrumento != "")
            {
                DataSet datosInstrumento = Conexion.Instancia.InicializarSeleccion(consultaInstrumento);
                if (datosInstrumento.Tables[0].Rows.Count > 0)
                {
                    DataRowCollection Tabla = datosInstrumento.Tables[0].Rows;
                    foreach (DataRow fila in Tabla)
                    {
                        object[] element = fila.ItemArray;
                        Dominio.Instrumento unInstrumento = new Dominio.Instrumento();
                        unInstrumento.Id = int.Parse(element[0].ToString());
                        unInstrumento.FechaFabricacion = Convert.ToDateTime(element[1].ToString());
                        unInstrumento.Descuento = int.Parse(element[2].ToString());
                        unInstrumento.Destacado = Convert.ToBoolean(element[3].ToString());
                        unInstrumento.VideoYoutube = element[4].ToString();
                        int idSubtipo = int.Parse(element[5].ToString());
                        unInstrumento.SubTipo = Controladora.Instancia.BuscarSubTipo(idSubtipo);
                        unInstrumento.Nombre = element[7].ToString();
                        unInstrumento.Descripcion = element[8].ToString();
                        int IdFabricante = int.Parse(element[9].ToString());
                        unInstrumento.Fabricante = Controladora.Instancia.BuscarFabricante(IdFabricante);
                        unInstrumento.FotoPrincipal = element[10].ToString();
                        unInstrumento.Precio = int.Parse(element[11].ToString());
                        unInstrumento.Stock = int.Parse(element[12].ToString());
                        listaArticulos.Add(unInstrumento);
                    }

                }
            }
            return listaArticulos;
        }
        public List<Articulo> ListadoDeArticulosOrdenadoPorDestacados()
        {
            string consultaInstrumento = "Select * from Instrumentos i, Articulos a where i.Id_Instrumento = a.Id_Articulo and i.Destacado_Instrumento=1;";
            DataSet datosInstrumento = Conexion.Instancia.InicializarSeleccion(consultaInstrumento);
            List<Articulo> listadoArticulos = new List<Articulo>();
            if (datosInstrumento.Tables[0].Rows.Count > 0)
            {
                DataRowCollection Tabla = datosInstrumento.Tables[0].Rows;
                foreach (DataRow fila in Tabla)
                {
                    object[] element = fila.ItemArray;
                    Dominio.Instrumento unInstrumento = new Dominio.Instrumento();
                    unInstrumento.Id = int.Parse(element[0].ToString());
                    unInstrumento.FechaFabricacion = Convert.ToDateTime(element[1].ToString());
                    unInstrumento.Descuento = int.Parse(element[2].ToString());
                    unInstrumento.Destacado = Convert.ToBoolean(element[3].ToString());
                    unInstrumento.VideoYoutube = element[4].ToString();
                    int idSubtipo = int.Parse(element[5].ToString());
                    unInstrumento.SubTipo = Controladora.Instancia.BuscarSubTipo(idSubtipo);
                    unInstrumento.Nombre = element[7].ToString();
                    unInstrumento.Descripcion = element[8].ToString();
                    int IdFabricante = int.Parse(element[9].ToString());
                    unInstrumento.Fabricante = Controladora.Instancia.BuscarFabricante(IdFabricante);
                    unInstrumento.FotoPrincipal = element[10].ToString();
                    unInstrumento.Precio = int.Parse(element[11].ToString());
                    unInstrumento.Stock = int.Parse(element[12].ToString());
                    listadoArticulos.Add(unInstrumento);
                }
            }
            return listadoArticulos;
        }

        private List<string> ConsultaSql(string pFiltro)
        {
            List<string> listaConLasConsultas = new List<string>();
            if (pFiltro == "PrecioAsc")
            {
                string consultaAccesorio = "Select a.* from Articulos a, Accesorios acc where" + " a.Id_Articulo = acc.Id_Accesorio order by (a.Precio_Articulo) desc";
                string consultaInstrumento = "Select * from Instrumentos i, Articulos a where i.Id_Instrumento = a.Id_Articulo order by (a.Precio_Articulo) desc";
                listaConLasConsultas.Add(consultaAccesorio);
                listaConLasConsultas.Add(consultaInstrumento);
            }

            else if (pFiltro == "PrecioDesc")
            {
                string consultaAccesorio = "Select a.* from Articulos a, Accesorios acc where" + " a.Id_Articulo = acc.Id_Accesorio order by (a.Precio_Articulo) asc";
                string consultaInstrumento = "Select * from Instrumentos i, Articulos a where i.Id_Instrumento = a.Id_Articulo order by (a.Precio_Articulo) asc";
                listaConLasConsultas.Add(consultaAccesorio);
                listaConLasConsultas.Add(consultaInstrumento);
            }
            else if (pFiltro == "Descuento")
            {
                listaConLasConsultas.Add("Cualquier pavada");
               string consultaInstrumento = "Select * from Instrumentos i, Articulos a where i.Id_Instrumento = a.Id_Articulo and  i.Descuento_Instrumento !=0 order by (i.Descuento_Instrumento) desc";

                listaConLasConsultas.Add(consultaInstrumento);
            }

            return listaConLasConsultas;
        }
    

        public List<string> ListarNombresSubtipos()
        {
            string consulta = "Select nombre_Subtipo from SubTipos;";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            List<string> listaDeNombres = new List<string>();
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection table = datos.Tables[0].Rows;
                foreach (DataRow fila in table)
                {
                    object[] elementos = fila.ItemArray;
                    listaDeNombres.Add(elementos[0].ToString());
                }
                return listaDeNombres;
            }
            return listaDeNombres;
        }

        public List<string> ListaNombresTiposs()
        {
            string consulta = "Select nombre_Tipo from Tipos;";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            List<string> listaDeNombres = new List<string>();
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection table = datos.Tables[0].Rows;
                foreach (DataRow fila in table)
                {
                    object[] elementos = fila.ItemArray;
                    listaDeNombres.Add(elementos[0].ToString());
                }
                return listaDeNombres;
            }
            return listaDeNombres;
        }

        public List<string> ListaNombresFabricantes()
        {
            string consulta = "Select nombre_Fabricante from Fabricantes;";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            List<string> listaDeNombres = new List<string>();
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection table = datos.Tables[0].Rows;
                foreach (DataRow fila in table)
                {
                    object[] elementos = fila.ItemArray;
                    listaDeNombres.Add(elementos[0].ToString());
                }
                return listaDeNombres;
            }
            return listaDeNombres;
        }
    }
}