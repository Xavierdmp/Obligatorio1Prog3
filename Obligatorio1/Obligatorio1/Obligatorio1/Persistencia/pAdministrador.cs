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
            string select = "Select * from Personas where Correo_Persona=" + "'" + pCorreoElectronico + "'";
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
            string Consulta = "Select * from Administradores a, Personas p where p.Id_Persona = a.Id_Admin and Id_Admin=" + pId;
            DataSet datos = Conexion.Instancia.InicializarSeleccion(Consulta);
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                Dominio.Administrador unAdmin = new Administrador();
                foreach (DataRow row in tabla)
                {
                    object[] elementos = row.ItemArray;
                    unAdmin.Id = int.Parse(elementos[0].ToString());
                    unAdmin.Permisos = Convert.ToBoolean(elementos[1].ToString());
                    unAdmin.CorreoElectronico = elementos[3].ToString();
                    unAdmin.Contraseña = elementos[4].ToString();
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
            if (Conexion.Instancia.InicializarConsulta("Insert into Personas values(" + "'" + pAdministrador.CorreoElectronico + "','" +
                                                          pAdministrador.Contraseña + "' )"))
            {
                int Id = this.UltimaIdPersona();
                if (Id != -1)
                {
                    return Conexion.Instancia.InicializarConsulta("Insert into Administradores values(" + Id + "," + bit + ");");
                }
            }
            return false;
        }
        public bool Baja(int pId)
        {
           if(Conexion.Instancia.InicializarConsulta("delete from Administradores where Id_Admin=" + pId))
           {
                return Conexion.Instancia.InicializarConsulta("delete from Personas where Id_Persona=" + pId);
           }
            return false;
        }

        public bool Modificar(Administrador pAdministrador)
        {
            return Conexion.Instancia.InicializarConsulta("Update Personas set Correo_Persona= " + "'" + pAdministrador.CorreoElectronico + "'," +
                                                          "Contraseña_Persona= " + "'" + pAdministrador.Contraseña + "' where Id_Persona=" + pAdministrador.Id);
        }

        public List<Administrador> ListarAdministradores()
        {
            string Consulta = "Select * from Administradores a, Personas p where a.Id_Admin = p.Id_Persona";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(Consulta);
            List<Administrador> listaAdministradores = new List<Administrador>();
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                foreach (DataRow row in tabla)
                {
                    Dominio.Administrador unAdmin = new Administrador();
                    object[] element = row.ItemArray;
                    unAdmin.Id = int.Parse(element[0].ToString());
                    unAdmin.Permisos = Convert.ToBoolean(element[1].ToString());
                    unAdmin.CorreoElectronico = element[3].ToString();
                    unAdmin.Contraseña = element[4].ToString();
                    listaAdministradores.Add(unAdmin);
                }
                return listaAdministradores;
            }
            return listaAdministradores;
        }

        private int UltimaIdPersona()
        {
            string consulta = "select top 1 p.Id_Persona from Personas p order by (Id_Persona) desc";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            if(datos.Tables[0].Rows.Count > 0)
            {
                int Id = 0;
                DataRowCollection tabla = datos.Tables[0].Rows;
                foreach(DataRow fila in tabla)
                {
                    object[] element = fila.ItemArray;
                    Id = int.Parse(element[0].ToString());
                }
                return Id;    
            }
            else
            {
                return -1;
            }
        }


    }
}