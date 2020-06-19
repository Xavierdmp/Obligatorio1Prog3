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
            string consulta = "Select * from Instrumentos i, Articulos a where i.Id_Instrumento = a.Id_Articulo and I.Id_Instrumento=" + pId;
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

            string procedureInstrumento = UltimaId + "Exec AltaInstrumento " + "@UltimaId" + ",'" + String.Format("{0:MM-dd-yyyy}",pInstrumento.FechaFabricacion) + "'," +
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

        public List<Color> TraerColoresParaInstrumentos(int pId)
        {
            string consulta = "Select * from Instrumentos_Tienen_Colores ic, Colores c where ic.Id_Color = c.Id_Color";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            List<Color> lista = new List<Color>();

            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection table = datos.Tables[0].Rows;
                foreach (DataRow row in table)
                {
                    object[] element = row.ItemArray;
                    Dominio.Color unColor = new Color();
                    unColor.Id = int.Parse(element[1].ToString());
                    unColor.Nombre = element[3].ToString();
                    unColor.Cantidad = int.Parse(element[2].ToString());
                    unColor.Codigo = element[5].ToString();
                }
                return lista;
                    
                     
                }
            return lista;
            }


        


    public List<FotosAdicionales> TraerFotosAdicionalesParaInstrumentos(int pId)
    {
        string consulta = "Select * from Articulos_tienen_Fotos_Adicionales where Id_Articulo=" + pId;

        DataSet date = Conexion.Instancia.InicializarSeleccion(consulta);
        List<FotosAdicionales> listaFotosAd = new List<FotosAdicionales>();
        if (date.Tables[0].Rows.Count > 0)
        {
            DataRowCollection table = date.Tables[0].Rows;
            foreach (DataRow row in table)
            {
                object[] element = row.ItemArray;
                Dominio.FotosAdicionales unaFoto = new Dominio.FotosAdicionales();
                unaFoto.Url = element[2].ToString();
                listaFotosAd.Add(unaFoto); 
            }
            return listaFotosAd;

        }

        return listaFotosAd;
    } 



        public bool Baja(int pId)
        {
            this.transaccion.Clear();
            string EliminarFotosAD = "Delete from Articulos_tienen_Fotos_Adicionales where Id_Articulo=" + pId;
            string EliminarColores = "Delete from Instrumentos_tienen_Colores where Id_Instrumento=" + pId;
            string EliminarArticulo = "Delete from Instrumentos where id_Instrumento=" + pId;
            string EliminarInstrumento = "Delete from Articulos where Id_Articulo=" + pId;

            transaccion.Add(EliminarFotosAD);
            transaccion.Add(EliminarColores);
            transaccion.Add(EliminarArticulo);
            transaccion.Add(EliminarInstrumento);

            return Conexion.Instancia.EjecutarTransaccionSql(transaccion);
                
            }
        public bool Modificar(Instrumento pInstrumento)
        {
            this.transaccion.Clear();
            string EliminarFotosAD = "Delete from Articulos_tienen_Fotos_Adicionales where Id_Articulo =" + pInstrumento.Id;
            string EliminarColores = "Delete from Instrumentos_tienen_Colores where Id_Instrumento=" + pInstrumento.Id;
            transaccion.Add(EliminarColores);
            foreach (Color unColor in pInstrumento.ListaDeColores)
            {
                transaccion.Add("insert into Instrumentos_tienen_Colores values( " + pInstrumento.Id + "," + unColor.Id + "," + unColor.Cantidad + ");");
            }
            if (pInstrumento.ListaFotosAdicionales != null)
            {
                transaccion.Add(EliminarFotosAD);
                foreach (FotosAdicionales unaFoto in pInstrumento.ListaFotosAdicionales)
                {
                    transaccion.Add("Insert into Articulos_tienen_Fotos_Adicionales values(" + pInstrumento.Id + ",'" + unaFoto.Url + "')");
                }
            }
            transaccion.Add("Exec ModificarInstrumento " + pInstrumento.Id + ",'" + pInstrumento.FechaFabricacion + "'," +
                            pInstrumento.Descuento + "," + pInstrumento.Destacado + ",'" + pInstrumento.VideoYoutube + "'," +
                            pInstrumento.SubTipo.Id + ";");
            transaccion.Add("Exec ModificarArticulos " + pInstrumento.Id + ",'" + pInstrumento.Nombre + "','" + pInstrumento.Descripcion + "'," +
                             pInstrumento.Fabricante.Id + ",'" + pInstrumento.FotoPrincipal + "'," + pInstrumento.Precio + "," + pInstrumento.Stock);
            return Conexion.Instancia.EjecutarTransaccionSql(transaccion);
        }


    }
    }
