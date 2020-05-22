using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Dominio;
using Obligatorio1.Persistencia.Interfaces;
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pCliente
    {
        private static pCliente _instancia;

        public static pCliente Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new pCliente();
                }
                return _instancia;

            }
        }

        public bool ComprobarExistencia(string pCedula)
        {
            string introduccion = "Select * from Clientes where Cedula_Identidad_Cliente=" + "'" + pCedula + "'";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(introduccion);

            if (datos.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public Cliente Buscar(int pId)
        {
            string introduccion = "Select * from Clientes where Id_Cliente=" + pId;
            DataSet data = Conexion.Instancia.InicializarSeleccion(introduccion);

            Dominio.Cliente unCLiente = new Cliente();
            if (data != null)
            {
                DataRowCollection table = data.Tables[0].Rows;
                foreach (DataRow row in table)
                {
                    object[] element = row.ItemArray;

                    unCLiente.Id = int.Parse(element[0].ToString());
                    unCLiente.CorreoElectronico = element[1].ToString();
                    unCLiente.Nombre = element[2].ToString();
                    unCLiente.Apellido = element[3].ToString();
                    unCLiente.CedulaIdentidad = element[4].ToString();
                    unCLiente.Direccion = element[5].ToString();
                    unCLiente.Telefono = int.Parse(element[6].ToString());
                    unCLiente.Contraseña = element[7].ToString();



                }
                return unCLiente;
            }

            return null;



        }

        public bool Alta(Cliente pCliente)
        {
            return Conexion.Instancia.InicializarConsulta("exec AltaCliente " + "'" + pCliente.CorreoElectronico + "','" + pCliente.Contraseña + "','" + pCliente.Nombre + "','"
                                                            + pCliente.Apellido + "','" + pCliente.CedulaIdentidad + "','" +
                                                            pCliente.Direccion + "'," + pCliente.Telefono + ";");
        }

        public bool Baja(int pId)
        {
            return Conexion.Instancia.InicializarConsulta("delete from Clientes where Id_Cliente=" + pId);
        }

        public bool Modificar(Cliente pCliente)
        {
            return Conexion.Instancia.InicializarConsulta("exec ModificarCliente " + "'" + pCliente.CorreoElectronico + "','" + pCliente.Contraseña + "','" + pCliente.Nombre + "','" + pCliente.Apellido + "','" + pCliente.CedulaIdentidad + "','" + pCliente.Direccion + "'," + pCliente.Telefono + " where Id_Cliente= " + pCliente.Id);

        }

        public List<Cliente> Listar()
        {
            string introduccion = "Select * from Clientes";
            DataSet data = Conexion.Instancia.InicializarSeleccion(introduccion);
            List<Cliente> ListadeCLientes = new List<Cliente>();

            if (data != null)
            {
                DataRowCollection table = data.Tables[0].Rows;
                foreach (DataRow row in table)
                {
                    object[] element = row.ItemArray;

                    Dominio.Cliente unCLiente = new Cliente();
                    unCLiente.Id = int.Parse(element[0].ToString());
                    unCLiente.CorreoElectronico = element[1].ToString();
                    unCLiente.Nombre = element[2].ToString();
                    unCLiente.Apellido = element[3].ToString();
                    unCLiente.CedulaIdentidad = element[4].ToString();
                    unCLiente.Direccion = element[5].ToString();
                    unCLiente.Telefono = int.Parse(element[6].ToString());
                    unCLiente.Contraseña = element[7].ToString();

                    ListadeCLientes.Add(unCLiente);


                }
                return ListadeCLientes;
            }
            return ListadeCLientes;
        }

    }
}


