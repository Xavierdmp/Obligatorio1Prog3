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
        public List<Articulo> ListadoDeArticulos()
        {
            string consulta = "Select a.* from Articulos a, Accesorios acc where" + " a.Id_Articulo = acc.Id_Accesorio";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            List<Articulo> listaArticulos = new List<Articulo>();
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
            string consultaInstrumento = "Select * from Instrumentos i, Articulos a where i.Id_Instrumento = a.Id_Articulo;";
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

            return listaArticulos;
        }

    }
}