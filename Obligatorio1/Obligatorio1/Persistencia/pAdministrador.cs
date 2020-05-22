using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Dominio;
using Obligatorio1.Persistencia.Interfaces;
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pAdministrador : IABM<Administrador>, IBuscar<Administrador>
    {
        private static pAdministrador _instancia;

        public static pAdministrador Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new pAdministrador();
                }
                return _instancia;
            }
        }

        public bool ComprobarExistencia(string pCorreoElectronico)
        {
            string select = "Select * from Administradores where Correo_Electronico_Admin=" + "'" + pCorreoElectronico + "'";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(select);
            if (datos.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Administrador Buscar(int pId)
        {
            string Consulta = "Select * from Administradores where Id_Admin=" + pId;
            DataSet datos = Conexion.Instancia.InicializarSeleccion(Consulta);
            if(datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                Dominio.Administrador unAdmin = new Administrador();
                foreach(DataRow row in tabla)
                {
                    object[] elementos = row.ItemArray;
                    unAdmin.Id = int.Parse(elementos[0].ToString());
                    unAdmin.CorreoElectronico = elementos[1].ToString();
                    unAdmin.Contraseña = elementos[2].ToString();
                    unAdmin.Permisos = Convert.ToBoolean(elementos[3].ToString());
                }
                return unAdmin;
            }
            else
            {
                return null;
            }
        }

        public bool Alta(Administrador pAdministrador)
        {
            int bit = pAdministrador.Permisos ? 1 : 0;
            return Conexion.Instancia.InicializarConsulta("Exec AltaAdministrador " + "'" + pAdministrador.CorreoElectronico + "','" +
                                                          pAdministrador.Contraseña + "'," + bit);
        }
        public bool Baja(int pId)
        {
            return Conexion.Instancia.InicializarConsulta("delete from Administradores where Id_Admin=" + pId);
        }

        public bool Modificar(Administrador pAdministrador)
        {
            return Conexion.Instancia.InicializarConsulta("Update Administradores set Correo_Electronico_Admin= " + "'" + pAdministrador.CorreoElectronico +"'," +
                                                          "Contraseña_Admin= " + "'" + pAdministrador.Contraseña +"' where Id_Admin=" + pAdministrador.Id);
        }

        public List<Administrador> ListarAdministradores()
        {
            string Consulta = "Select * from Administradores";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(Consulta);
            List<Administrador> listaAdministradores = new List<Administrador>();
            if(datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                foreach(DataRow row in tabla)
                {
                    Dominio.Administrador unAdmin = new Administrador();
                    object[] element = row.ItemArray;
                    unAdmin.Id = int.Parse(element[0].ToString());
                    unAdmin.CorreoElectronico = element[1].ToString();
                    unAdmin.Contraseña = element[2].ToString();
                    unAdmin.Permisos =Convert.ToBoolean(element[3].ToString());
                    listaAdministradores.Add(unAdmin);
                }
                return listaAdministradores;
            }
            return listaAdministradores;
        }
    }
}