using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Obligatorio1.Persistencia
{
    public class Conexion
    {
        private static string _cadenaconexion;

        private static Conexion _instancia;

        public Conexion()
        {
            _cadenaconexion = WebConfigurationManager.ConnectionStrings["ConexionAplicacion"].ConnectionString; // Se encuentra en web config//





        }

        public static Conexion Instancia
        {
            get { if (_instancia == null)
                {
                    _instancia = new Conexion();
                }
                return _instancia;
            }
        }

        public static SqlConnection Conectar()

        {
            SqlConnection conexion = new SqlConnection(_cadenaconexion);
            try
            {
                conexion.Open();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            return conexion;
        }

        public bool InicializarConsulta(string pConsulta) /* DML*/
        {
            bool SeaplicaronCambios = false; // Inicializar para confirmar si se ha modificado alguna fila.
            /* si es true se aplicaron cambios sino devuelve false */

            try
            {
                SqlConnection conexion = Conectar();
                SqlCommand comandos = new SqlCommand();

                comandos.CommandText = pConsulta;
                comandos.CommandType = CommandType.Text; /*using*/



                comandos.Connection = conexion; // llamamos a la conexion

                SeaplicaronCambios = comandos.ExecuteNonQuery() > 0; // Para saber si se aplicaron correctamente en BDD


            }
            catch (Exception) // 2 tabuladores. Este metodo booleando para 
            {
                throw;
            }
            return SeaplicaronCambios;
        }


        public DataSet InicializarSeleccion(string pConsulta) // Todo lo que traemos de bdd se guarda en la dataset//
        {
            DataSet datos = null;

            SqlCommand ComandoSql = null;

            try
            {
                ComandoSql = new SqlCommand();
                ComandoSql.CommandText = pConsulta;
                ComandoSql.CommandType = CommandType.Text;

                datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter(ComandoSql);
                SqlConnection conexion = Conectar();
                adaptador.Fill(datos); //se pasa el dataset


            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }


    }

}
 
        


