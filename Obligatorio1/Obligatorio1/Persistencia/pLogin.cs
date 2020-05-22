using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Obligatorio1.Persistencia
{
    public class pLogin
    {
        private static pLogin _instancia;

        public static pLogin Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new pLogin();
                }
                return _instancia;
            }
        }

        public int IdAdministradorLogin(string pCorreo, string pContraseña)
        {
            string consulta = "Select * from Administradores where Correo_Electronico_Admin=" + "'" + pCorreo + "' " + "and Contraseña_Admin= " + "'" + pContraseña + "'";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);

            Dominio.Administrador unAdministrador = new Dominio.Administrador();
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection table = datos.Tables[0].Rows;
                foreach (DataRow row in table)
                {
                    object[] posiciones = row.ItemArray;
                    unAdministrador.Id = int.Parse(posiciones[0].ToString());
                }
                return unAdministrador.Id;
            }
            return -1;
        }

        public int IdClienteLogin(string pCorreo, string pContraseña)
        {
            string consulta = "Select * from Clientes where Correo_Electronico_Cliente=" + "'" + pCorreo + "' " + "and Contraseña_Cliente= " + "'" + pContraseña + "'";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);

            Dominio.Cliente unCliente = new Dominio.Cliente();
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection table = datos.Tables[0].Rows;
                foreach (DataRow row in table)
                {
                    object[] posiciones = row.ItemArray;
                    unCliente.Id = int.Parse(posiciones[0].ToString());
                }
                return unCliente.Id;
            }
            return -1;
        }
    }
}