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
                    unAccesorio.Stock = int.Parse(elementos[6].ToString());
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
                    unAccesorio.Stock = int.Parse(elementos[6].ToString());
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
                                      + pAccesorio.Precio + "," + pAccesorio.Stock + ";"))
            {
                int Id = this.TraerUltimaIdArticulo();
                if (Id != -1)
                {
                    if (Conexion.Instancia.InicializarConsulta("Insert into Accesorios values(" + Id + ");"))
                    {
                        if (pAccesorio.ListaFotosAdicionales != null)
                        {
                            this.InsertarFotosAdicionales(pAccesorio.ListaFotosAdicionales, Id);
                            if(pAccesorio.ListarSubtipos == null)
                            {
                                return true;
                            }
                        }
                        if(pAccesorio.ListarSubtipos != null)
                        {
                            return this.InsertarListaSubtipos(pAccesorio.ListarSubtipos, Id);
                        }
                    }
                }
            }
            return false;
        }

        private bool InsertarListaSubtipos(List<SubTipo> pLista,int pId)
        {
            foreach (SubTipo unSubtipo in pLista)
            {
                Conexion.Instancia.InicializarConsulta("Insert into Accesorio_tiene_Subtipos values(" + pId + "," + unSubtipo.Id + ");");
            }
            return true;
        }
        private bool InsertarFotosAdicionales(List<FotosAdicionales> pListar, int pId)
        {
            foreach (FotosAdicionales unaFotoAdicional in pListar)
            {
                Conexion.Instancia.InicializarConsulta("insert into Articulos_tienen_Fotos_Adicionales(Id_Articulo,Url_Imagen)" +
                                                         " values(" + pId + ",'" + unaFotoAdicional.Url + "')");
            }
            return true;
        }




        public bool Baja(int pId)        {            List<FotosAdicionales> listaFotosAd = this.ListarFotosAdicionalesParaAccesorio(pId);            List<SubTipo> listaSubtipos = this.ListarSubTiposDadoUnAccesorio(pId);            if (listaFotosAd.Count > 0)            {                this.EliminarFotosAdicionales(listaFotosAd, pId);                if (listaSubtipos.Count == 0)                {                    return true;                }            }            if (listaSubtipos.Count > 0)            {
                this.EliminarSubtipos(listaSubtipos, pId);
                if (Conexion.Instancia.InicializarConsulta("delete from Accesorios where Id_Accesorio=" + pId))                {                    return Conexion.Instancia.InicializarConsulta("delete from Articulo where Id_Articulo=" + pId);                }            }            return false;        }





    


    private bool EliminarFotosAdicionales(List<FotosAdicionales> pFotosAdicionales, int pId)
        {
            foreach (FotosAdicionales unaFotoAd in pFotosAdicionales)
            {
                Conexion.Instancia.InicializarConsulta("delete from Articulos_tienen_Fotos_Adicionales where Id_Articulo =" + pId + " ; ");
            }
       
        return true;
        }
        public bool EliminarSubtipos(List<SubTipo> pListaFotosSubtipo, int pId)
        {
            foreach (SubTipo unsubtipo in pListaFotosSubtipo)
            {
                Conexion.Instancia.InicializarConsulta("Delete from Accesorios_tiene_Subtipos where Id_Accesorios=" + pId);
            }
            return true;
        }



        public bool Modificar(Accesorio pAccesorio)
        {
            if (Conexion.Instancia.InicializarConsulta("exec ModificarArticulos " + pAccesorio.Id + ",'" + pAccesorio.Nombre + "','" +
                                                           pAccesorio.Descripcion + "'," + pAccesorio.Fabricante.Id + ",'" +
                                                           pAccesorio.FotoPrincipal + "'," + pAccesorio.Precio + "," + pAccesorio.Stock + ";"))
            {
                if (pAccesorio.ListaFotosAdicionales.Count > 0)
                {
                    this.EliminarFotosAdicionales(pAccesorio.ListaFotosAdicionales, pAccesorio.Id);
                    this.InsertarFotosAdicionales(pAccesorio.ListaFotosAdicionales, pAccesorio.Id);

                }
                if (pAccesorio.ListarSubtipos.Count > 0)
                {
                    this.EliminarSubtipos(pAccesorio.ListarSubtipos, pAccesorio.Id);
                    this.EliminarSubtipos(pAccesorio.ListarSubtipos, pAccesorio.Id);
                }
                return true;

                }
            return false;
                    
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

        public List<SubTipo> ListarSubTiposDadoUnAccesorio(int pId)
        {
            string instruccion = "select * from Accesorio_tiene_Subtipos where Id_Accesorio=" + pId + ";";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(instruccion);
            List<SubTipo> listaDeSubtipos = new List<SubTipo>();
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                foreach (DataRow row in tabla)
                {
                    object[] elementos = row.ItemArray;
                    Dominio.SubTipo unSubtipo = new SubTipo();
                    int idSubtipo = int.Parse(elementos[1].ToString());
                    unSubtipo = Controladora.Instancia.BuscarSubTipo(idSubtipo);
                    listaDeSubtipos.Add(unSubtipo);
                }
                return listaDeSubtipos;
            }
            return listaDeSubtipos;
        }
    }
}