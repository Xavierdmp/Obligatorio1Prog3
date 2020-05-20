using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia.Interfaces; /*using escrito*/
using Obligatorio1.Dominio;/*escrito*/
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pFabricante : IABM<Fabricante>, IBuscar<Fabricante>
    {
        private static pFabricante _instancia;

        public static pFabricante Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new pFabricante();
                }
                return _instancia;
            }
        }


        public bool ComprobarExistencia(string pNombre)
        {
            string sql = "select * from Fabricantes where nombre_Fabricante=" + "'" + pNombre + "'" + ";";

            DataSet datos = Conexion.Instancia.InicializarSeleccion(sql);

            if (datos.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        

        public Fabricante Buscar(int pId)
        {
            string sql = "select * from Fabricantes where id_Fabricante =" + pId + ";";

            DataSet datos = Conexion.Instancia.InicializarSeleccion(sql);

            Dominio.Fabricante unFabricante = new Fabricante();


            if (datos != null)
            {
                 DataRowCollection tabla = datos.Tables[0].Rows;


                foreach (DataRow row in tabla)
                {
                    object[] elementos = row.ItemArray;
                    unFabricante.Id = int.Parse(elementos[0].ToString());
                    unFabricante.Nombre = elementos[1].ToString();
                    unFabricante.Direccion = elementos[2].ToString();
                    unFabricante.CorreoElectronico = elementos[3].ToString();
                }
                return unFabricante;
            }
            return null;
        }

        public bool Alta(Fabricante pFabricante)
        {
            return Conexion.Instancia.InicializarConsulta("exect AltaFabricante " + "'" + pFabricante.Nombre + "','" + pFabricante.Direccion + "','" + pFabricante.CorreoElectronico + "';");

        }

        public bool Baja(int pId)/*Comilla simple es cuando no es texto*/
        {
            return Conexion.Instancia.InicializarConsulta("delete from Fabricantes where id_Fabricante =" + pId);
        }

        public bool Modificar(Fabricante pFabricante)
        {
            return Conexion.Instancia.InicializarConsulta("exec ModificarFabricante " + "'" + pFabricante.Nombre + "','" + pFabricante.Direccion + "','" + pFabricante.CorreoElectronico + "';"); 
        }

        public List<Fabricante> Listar()
        {
            string Seleccion = "select * from Fabricantes";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(Seleccion);


            List<Fabricante> UnaListadeFabricante = new List<Fabricante>();

           

            if (datos != null)
            {
                DataRowCollection  tablas= datos.Tables[0].Rows;
                { 
                    
                foreach (DataRow row in tablas)
                {
                        Dominio.Fabricante unFabricante = new Fabricante();
                       

                        object[] elementos = row.ItemArray;

                    unFabricante.Id = int.Parse(elementos[0].ToString());
                    unFabricante.Nombre = elementos[1].ToString();
                    unFabricante.Direccion = elementos[2].ToString();
                    unFabricante.CorreoElectronico = elementos[3].ToString();

                        UnaListadeFabricante.Add(unFabricante);
                    }

                    return UnaListadeFabricante; /*Una si lo encuentra */
            }


        }
            return UnaListadeFabricante; /*devuelve la lista vacia*/

        }
 

    }

}