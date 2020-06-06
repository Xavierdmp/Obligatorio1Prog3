using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia.Interfaces;
using Obligatorio1.Dominio;
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pAccesorio:IABM<Accesorio>, IBuscar<Accesorio>
    {
        private static pAccesorio _instancia;

        public static pAccesorio Instancia
        {
            get {
                if(_instancia == null)
                {
                    _instancia = new pAccesorio();
                }
                return _instancia;
            }
        }

        public bool ComprobarExistencia(string pNombre)
        {
            string instruccion = "Select a.* from Articulos a, Accesorios acc where Nombre_Articulo=" + "'" + pNombre + "' " +
                                  "and a.Id_Articulo = acc.Id_Accesorio";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(instruccion);
            if(datos.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Accesorio Buscar(int pId)
        {
            string instruccion = "Select a.* from Articulos a, Accesorios acc where Id_Articulo=" + pId + " " +
                                  "and a.Id_Articulo = acc.Id_Accesorio";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(instruccion);
            if(datos.Tables[0].Rows.Count > 0)
            {
                Dominio.Accesorio unAccesorio = new Dominio.Accesorio();
                DataRowCollection tabla = datos.Tables[0].Rows;
                foreach(DataRow row in tabla)
                {
                    object[] elementos = row.ItemArray;
                    unAccesorio.Id = int.Parse(elementos[0].ToString());
                    unAccesorio.Nombre = elementos[1].ToString();
                    unAccesorio.Descripcion = elementos[2].ToString();
                    int idFabricante = int.Parse(elementos[3].ToString());
                    unAccesorio.Fabricante = Controladora.Instancia.BuscarFabricante(idFabricante);
                    unAccesorio.FotoPrincipal = elementos[4].ToString();
                    unAccesorio.Precio = int.Parse(elementos[5].ToString());
                    int idSubTipo = int.Parse(elementos[6].ToString());
                    unAccesorio.SubtipoInstrumento = Controladora.Instancia.BuscarSubTipo(idSubTipo);
                    unAccesorio.Stock = int.Parse(elementos[7].ToString());
                }
                return unAccesorio;
            }
            return null;
        }

        public List<Accesorio> ListarAccesorios()
        {
            string instruccion = "Select a.* from Articulos a, Accesorios acc where" + " a.Id_Articulo = acc.Id_Accesorio";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(instruccion);
            List<Accesorio> listaDeAccesorios = new List<Accesorio>();
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
                    int idSubTipo = int.Parse(elementos[6].ToString());
                    unAccesorio.SubtipoInstrumento = Controladora.Instancia.BuscarSubTipo(idSubTipo);
                    unAccesorio.Stock = int.Parse(elementos[7].ToString());
                    listaDeAccesorios.Add(unAccesorio);
                }
                return listaDeAccesorios;
            }
            else
            {
                return listaDeAccesorios;
            }
        }
        private int TraerUltimaIdArticulo()
        {
            string instruccion = "select top 1 a.Id_Articulo from Articulos a order by a.Id_Articulo desc;";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(instruccion);
            
            if(datos.Tables[0].Rows.Count > 0)
            {
                int ultimaIdArticulo = 0;
                DataRowCollection tabla = datos.Tables[0].Rows;
                foreach(DataRow row in tabla)
                {
                    object[] elementos = row.ItemArray;
                    ultimaIdArticulo = int.Parse(elementos[0].ToString());
                }
                return ultimaIdArticulo;
            }
            return -1;
        }
        public bool Alta(Accesorio pAccesorio)
        {
            if (Conexion.Instancia.InicializarConsulta(
                "Exec AltaArticulos " + "'" + pAccesorio.Nombre + "','" + pAccesorio.Descripcion + "',"
                                      + pAccesorio.Fabricante.Id + " ,'" + pAccesorio.FotoPrincipal + "',"
                                      + pAccesorio.Precio + "," + pAccesorio.SubtipoInstrumento.Id + ","
                                      + pAccesorio.Stock + ";"))
            {
                int Id = this.TraerUltimaIdArticulo();
                if (Id != -1)
                {
                    if (pAccesorio.ListaFotosAdicionales != null)
                    {
                        if (Conexion.Instancia.InicializarConsulta("Insert into Accesorios values(" + Id + ");"))
                        {
                            foreach (FotosAdicionales unaFotoAdicional in pAccesorio.ListaFotosAdicionales)
                            {
                               Conexion.Instancia.InicializarConsulta("insert into Articulos_tienen_Fotos_Adicionales(Id_Articulo,Url_Imagen)" +
                                                                        " values(" + Id + ",'" + unaFotoAdicional.Url + "')");
                            }
                            return true;
                        }
                        
                    }
                    else
                    {
                        return Conexion.Instancia.InicializarConsulta("Insert into Accesorios values(" + Id + ");");
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;   
            }
            return false;
        }

        public bool Baja(int pId)
        {
            if (Conexion.Instancia.InicializarConsulta("delete from Accesorios where Id_Accesorio=" + pId))
            {

                    if (this.ListarFotosAdicionalesParaAccesorio(pId).Count > 0)
                    {
                        foreach (FotosAdicionales unaFotoAd in this.ListarFotosAdicionalesParaAccesorio(pId))
                        {
                            Conexion.Instancia.InicializarConsulta("delete from Articulos_tienen_Fotos_Adicionales where Id_Articulo =" + pId + " ; ");
                        }
                        return Conexion.Instancia.InicializarConsulta("delete from Articulos where Id_Articulo=" + pId);
                    }
                else
                {
                    return Conexion.Instancia.InicializarConsulta("delete from Articulos where Id_Articulo=" + pId);
                }
                
            }
            return false;
        }

        public bool Modificar(Accesorio pAccesorio)
        {
            if (Conexion.Instancia.InicializarConsulta("exec ModificarArticulos " + pAccesorio.Id + ",'" + pAccesorio.Nombre + "','" +
                                                           pAccesorio.Descripcion + "'," + pAccesorio.Fabricante.Id + ",'" +
                                                           pAccesorio.FotoPrincipal + "'," + pAccesorio.Precio + "," +
                                                           pAccesorio.SubtipoInstrumento.Id + "," + pAccesorio.Stock + ";"))
            {
                if (pAccesorio.ListaFotosAdicionales != null)
                {
                    foreach (FotosAdicionales unaFotoAd in pAccesorio.ListaFotosAdicionales)
                    {
                        Conexion.Instancia.InicializarConsulta("update Articulos_tienen_Fotos_Adicionales set Url_Imagen=" + "'" + unaFotoAd.Url + "'" + " where Id_Articulo=" + pAccesorio.Id + " ;");
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        
        }

        public List<FotosAdicionales> ListarFotosAdicionalesParaAccesorio(int pId)
        {
            string instruccion = "select * from Articulos_tienen_Fotos_Adicionales where Id_Articulo=" + pId + ";";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(instruccion);
            List<FotosAdicionales> listaFotosAdicionales = new List<FotosAdicionales>();
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                foreach (DataRow row in tabla)
                {
                    Dominio.FotosAdicionales unaFotoAdicional = new Dominio.FotosAdicionales();
                    object[] elementos = row.ItemArray;
                    unaFotoAdicional.Url = elementos[2].ToString();
                    listaFotosAdicionales.Add(unaFotoAdicional);
                }
                return listaFotosAdicionales;
            }
            else
            {
                return listaFotosAdicionales;
            }
        }

    }
}