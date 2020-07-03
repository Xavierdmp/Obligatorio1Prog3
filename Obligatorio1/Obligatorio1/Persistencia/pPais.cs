using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia.Interfaces;
using Obligatorio1.Dominio;
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pPais
    {
        private static pPais _instancia = null;

        public static pPais Instancia
        {

            get
            {
                if (_instancia == null)
                {
                    _instancia = new pPais();
                }
                return _instancia;
            }
        }

        private pPais()
        {

        }

        public List<string> ListarPais()
        {
            string consulta = "select PaisNombre from Pais";
            DataSet data = Conexion.Instancia.InicializarSeleccion(consulta);

            List<string> ListaPais = new List<string>();

            if (data.Tables[0].Rows.Count > 0)
            {
                DataRowCollection table = data.Tables[0].Rows;
                foreach (DataRow row in table)
                {
                    object[] element = row.ItemArray;

                    ListaPais.Add(element[0].ToString().TrimEnd(' ')); 


                }

            }
            return ListaPais;

        }


        public List<string> ListarCiudad(string pNombrePais)
        {

            string consulta = "select c.CiudadNombre from Ciudad c , Pais p where p.paiscodigo = c.paiscodigo and p.paisnombre=" + "'" + pNombrePais + "'" ;
            DataSet data = Conexion.Instancia.InicializarSeleccion(consulta);

            List<string> ListaCiudad = new List<string>();

            if (data.Tables[0].Rows.Count > 0)
            {
                DataRowCollection table = data.Tables[0].Rows;
                foreach (DataRow row in table)
                {
                    object[] element = row.ItemArray;

                    ListaCiudad.Add(element[0].ToString().TrimEnd(' ')); // Quita Espacios Caracteres.




                }
            }
            return ListaCiudad;
        }
    }
}