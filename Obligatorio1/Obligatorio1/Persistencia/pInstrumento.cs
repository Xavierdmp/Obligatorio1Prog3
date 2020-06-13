using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Dominio;
using Obligatorio1.Persistencia.Interfaces;
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pInstrumento: IABM<Instrumento>, IBuscar<Instrumento>
    {
        private static pInstrumento _instancia;
        const string UltimaId = "Declare @UltimaId int; Set @UltimaId = @@Identity;";
        const string UltimaIdInstrumento = "Declare @UltimaIdIns int; Set @UltimaIdIns = ident_current('Articulos');";
        private List<string> transaccion = new List<string>();
        public static pInstrumento Instancia
        {
            get
            {
                if(_instancia == null)
                {
                    _instancia = new pInstrumento();
                }
                return _instancia;
            }
        }

        public bool ComprobarExistencia(string pNombre)
        {
            string consulta = "Select a.* from Articulos a, Instrumentos i"  + " " +
                "where a.Id_Articulo = i.Id_Instrumento and a.Nombre_Articulo=" + "'" + pNombre + "';";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            if(datos.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Instrumento Buscar(int pId)
        {
            string consulta = "Select * from Instrumentos i, Articulos a where i.Id_Instrumento = a.Id_Articulo and I.Id_Articulo =" + pId;
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            if(datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection Tabla = datos.Tables[0].Rows;
                Dominio.Instrumento unInstrumento = new Dominio.Instrumento();
                foreach(DataRow fila in Tabla)
                {
                    object[] element = fila.ItemArray;
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
                }
                return unInstrumento;
            }
            return null;
        }

        public bool Alta(Instrumento pInstrumento)
        {
            transaccion.Clear();

            string procedure = "Exec AltaArticulos " + "'" + pInstrumento.Nombre + "','" + pInstrumento.Descripcion + "',"
                          + pInstrumento.Fabricante.Id + " ,'" + pInstrumento.FotoPrincipal + "',"
                          + pInstrumento.Precio + "," + pInstrumento.Stock + ";";

            string procedureInstrumento = UltimaId + "Exec AltaInstrumento " + "@UltimaId" + ",'" + pInstrumento.FechaFabricacion + "'," +
                                                      pInstrumento.Descuento + "," + pInstrumento.Destacado + ",'" + pInstrumento.VideoYoutube + 
                                                      "'," + pInstrumento.SubTipo.Id + ";";
            transaccion.Add(procedure);
            transaccion.Add(procedureInstrumento);

            foreach(Color unColor in pInstrumento.ListaDeColores)
            {
                transaccion.Add(UltimaIdInstrumento + "insert into Instrumentos_tienen_Colores values( " + "@UltimaIdIns" + "," + unColor.Id + "," + unColor.Cantidad +");");
            }
            if (pInstrumento.ListaFotosAdicionales != null)
            {
                foreach (FotosAdicionales unaFoto in pInstrumento.ListaFotosAdicionales)
                {
                    transaccion.Add(UltimaIdInstrumento + "Insert into Articulos_tienen_Fotos_Adicionales values(" + "@UltimaIdIns" + ",'" + unaFoto.Url + "')");
                }
            }
            return Conexion.Instancia.EjecutarTransaccionSql(transaccion);

        }
        public List<Instrumento> ListarInstrumentos()
        {
            string consulta = "Select * from Instrumentos i, Articulos a where i.Id_Instrumento = a.Id_Articulo;";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            List<Instrumento> listaDeInstrumentos = new List<Instrumento>();
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection Tabla = datos.Tables[0].Rows;
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
                    listaDeInstrumentos.Add(unInstrumento);
                }
                return listaDeInstrumentos;
            }
            return listaDeInstrumentos;
        }


        public bool Baja(int pId)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Instrumento pT)
        {
            throw new NotImplementedException();
        }
    }
}