using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Dominio;
using Obligatorio1.Persistencia.Interfaces;
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pInstrumento : IABM<Instrumento>, IBuscar<Instrumento>
    {
        private static pInstrumento _instancia;

        const string UltimaId = "Declare @UltimaId int; Set @UltimaId = @@Identity";//INserta en instrumento
        const string UltimaIdInstrumento = "Declare @UltimaIdInst int; Set @UltimaIdIns = ident_current('Instrumentos')";  //Instrumento tiene colores

        private List<string> transaccion = new List<string>();

        public static pInstrumento Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new pInstrumento(); // Retorna la instancia del instrumento

                }
                return Instancia;
            }
        }

        public bool ComprobarExistencia(string pNombre)
        {
            string Consulta = "Select a.* from Articulos a, Instrumentos i" + " " + "where a.Id_Instrumentos = i.Id_Articulo and a.Nombre_Articulo=" + "'" + pNombre + "';";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(Consulta);

            if (datos.Tables[0].Rows.Count > 0)
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
            string Consulta = "Select * from Instrumentos i, Articulos a where i.Id_Instrumento = a.Id_Articulo and i.Id_Instrumento=" + pId;
            DataSet datos = Conexion.Instancia.InicializarSeleccion(Consulta);
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                Dominio.Instrumento unInstrumento = new Dominio.Instrumento();

                foreach (DataRow fila in tabla)
                {
                    object[] element = fila.ItemArray;
                    unInstrumento.Id = int.Parse(element[0].ToString());
                    unInstrumento.FechaFabricacion = Convert.ToDateTime(element[1].ToString());
                    unInstrumento.Descuento = int.Parse(element[2].ToString());
                    unInstrumento.Destacado = Convert.ToBoolean(element[3].ToString());
                    unInstrumento.VideoYoutube = element[4].ToString();
                    int idSubTipo = int.Parse(element[5].ToString());

                    unInstrumento.SubTipo = Controladora.Instancia.BuscarSubTipo(idSubTipo);
                    unInstrumento.Nombre = element[7].ToString();
                    unInstrumento.Descripcion = element[8].ToString();

                    int idFabricante = int.Parse(element[9].ToString());
                    unInstrumento.Fabricante = Controladora.Instancia.BuscarFabricante(pId);
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
            string procedure = "Exec AltaArticulos " + "'" + pInstrumento.Nombre + "', '" + pInstrumento.Descripcion + "', "
                                      + pInstrumento.Fabricante.Id + " ,'" + pInstrumento.FotoPrincipal + "',"
                                      + pInstrumento.Precio + "," + pInstrumento.Stock + ";";


            string procedureInstrumento = UltimaId + "Exec AltaInstrumento " + "@UltimaId" + "," + pInstrumento.FechaFabricacion + "'," + pInstrumento.Descuento + "," + pInstrumento.Destacado + ",'" + pInstrumento.VideoYoutube + "'," + pInstrumento.SubTipo.Id + ";";

            transaccion.Add(procedure);
            transaccion.Add(procedureInstrumento);//Alta Instrumento

            foreach (Color unColor in pInstrumento.ListaDeColores)
            {
                transaccion.Add(UltimaIdInstrumento + "Exec AltaInstrumentosTienenColores " + "@UltimaIdIns" + "," + unColor.Id + "," + unColor.Cantidad);
            }
            if (pInstrumento.ListaFotosAdicionales != null)
            {

                foreach (FotosAdicionales unaFoto in pInstrumento.ListaFotosAdicionales)
                {
                    transaccion.Add(UltimaIdInstrumento + "Insert into Articulos_Tienen_Fotos_Adicionales values+(" + "@UltimaIdIns" + ",'" + unaFoto.Url + "')");
                }
                
            }
            return Conexion.Instancia.EjecutarTransaccionSql(transaccion);
        }

        public List<Instrumento> ListarInstrumentos()
        {
            string Consulta = "Select * from Instrumentos i, Articulos a where i.Id_Instrumento = a.Id_Articulo;";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(Consulta);
            List<Instrumento> ListadeInstrumentos = new List<Instrumento>();

            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
            

                foreach (DataRow fila in tabla)
                {
                     object[] element = fila.ItemArray; // para cada vez que recorra 

                    Dominio.Instrumento unInstrumento = new Dominio.Instrumento();
                    unInstrumento.Id = int.Parse(element[0].ToString());
                    unInstrumento.FechaFabricacion = Convert.ToDateTime(element[1].ToString());
                    unInstrumento.Descuento = int.Parse(element[2].ToString());
                    unInstrumento.Destacado = Convert.ToBoolean(element[3].ToString());
                    unInstrumento.VideoYoutube = element[4].ToString();
                    int idSubTipo = int.Parse(element[5].ToString());

                    unInstrumento.SubTipo = Controladora.Instancia.BuscarSubTipo(idSubTipo);
                    unInstrumento.Nombre = element[7].ToString();
                    unInstrumento.Descripcion = element[8].ToString();

                    int idFabricante = int.Parse(element[9].ToString());
                    unInstrumento.Fabricante = Controladora.Instancia.BuscarFabricante(idFabricante);
                    unInstrumento.FotoPrincipal = element[10].ToString();
                    unInstrumento.Precio = int.Parse(element[11].ToString());
                    unInstrumento.Stock = int.Parse(element[12].ToString());

                    ListadeInstrumentos.Add(unInstrumento);
                }
                return ListadeInstrumentos;

            }
            return ListadeInstrumentos;
        }

    
           

    public bool Baja(int pId)
    {
            return true;   
    }

    public bool Modificar(Instrumento pT)
    {
            return true;
    }



}

}

