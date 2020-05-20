using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia.Interfaces;
using Obligatorio1.Dominio;
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pTipo : IABM<Tipo>, IBuscar<Tipo>
    {
        /*nombre*/

      private static pTipo _instancia;

        public static pTipo Instancia
        {

            get
            {
                if (_instancia == null)
                {
                    _instancia = new pTipo();
                }
                return _instancia;
            }
        }

        public bool ComprobarExistencia(string pNombre)
        {
            string sql = "select * from tipos where nombre_Tipo =" +  "'" + pNombre + "'" + ";";

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

        public Tipo Buscar(int pId)
        {
            string sql = "select * from Tipo where id_Tipo =" + pId + ";";

            DataSet datos = Conexion.Instancia.InicializarSeleccion(sql);

            Dominio.Tipo unTipo = new Tipo();


            if (datos != null)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;


                foreach (DataRow row in tabla)
                {
                    object[] elementos = row.ItemArray;
                    unTipo.Id = int.Parse(elementos[0].ToString());
                    unTipo.Nombre = elementos[1].ToString();

                }
                return unTipo;

            }
            return null;
        }


        public bool Alta(Tipo pTipo)
        {
            return Conexion.Instancia.InicializarConsulta("insert into Tipos values(" + "'" + pTipo.Nombre + "')");
                      
        }
        public bool Baja(int pId)
        {
            return Conexion.Instancia.InicializarConsulta("delete from Tipos where id_Tipos =" + pId);
            
        }
        public bool Modificar(Tipo pTipo)
        {
            return Conexion.Instancia.InicializarConsulta("update from Tipos set nombre_tipo =" + "'" + pTipo.Nombre + "'" + "where id_Tipo =" + pTipo.Id);
        }

        public List<Tipo> Listar()
        {
            string seleccion = "select * from Tipos";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(seleccion);



            List<Tipo> unaListaTipo = new List<Tipo>();

            if (datos != null)
            {
                DataRowCollection tablas = datos.Tables[0].Rows;
                {
                    foreach (DataRow row in tablas)
                    {
                        Dominio.Tipo unTipo = new Tipo();

                        object[] elementos = row.ItemArray;

                        unTipo.Id = int.Parse(elementos[0].ToString());
                        unTipo.Nombre = elementos[1].ToString();

                        unaListaTipo.Add(unTipo);

                    }
                    return unaListaTipo;
                }
            }
            return unaListaTipo;

        } 



    }
}