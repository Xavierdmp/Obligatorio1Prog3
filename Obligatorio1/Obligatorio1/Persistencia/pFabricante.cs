﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia.Interfaces;
using Obligatorio1.Dominio;
using System.Data.SqlClient;
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
            string sql = "Select * from Fabricantes where nombre_Fabricante=" + "'" + pNombre + "'" + ";";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(sql);
            if(datos.Tables[0].Rows.Count > 0)
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
            string sql = "Select * from Fabricantes where id_Fabricante=" +  pId + ";";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(sql);
            Dominio.Fabricante unFabricante = new Fabricante();
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                foreach(DataRow row in tabla)
                {
                    object[] elementos = row.ItemArray;
                    unFabricante.Id = int.Parse(elementos[0].ToString());
                    unFabricante.Nombre = elementos[1].ToString();
                    unFabricante.Direccion = elementos[2].ToString();
                    unFabricante.CorreoElectronico = elementos[3].ToString();
                }
                return unFabricante;
            }
            else
            {
                return null;
            }
        }

        public bool Alta(Fabricante pFabricante)
        {
            return Conexion.Instancia.InicializarConsulta("Exec AltaFabricante " + "'" + pFabricante.Nombre + "','" + pFabricante.Direccion +
                                                           "','" + pFabricante.CorreoElectronico + "';");
        }
        public bool Baja(int pId)
        {
            if (!this.EstaFabricanteEnOtraTabla(pId)) // si no es clave foranea en otra tabla se da de baja
            {
                return Conexion.Instancia.InicializarConsulta("delete from Fabricantes where id_Fabricante=" + pId);
              
            }
            return false;
        }



        public bool Modificar(Fabricante pFabricante)
        {
            return Conexion.Instancia.InicializarConsulta("Exec ModificarFabricante " + pFabricante.Id + ",'" + pFabricante.Nombre + "','" + pFabricante.Direccion +
                                                           "','" + pFabricante.CorreoElectronico + "'");
        }
        private bool EstaFabricanteEnOtraTabla(int pId)
        {
            string consulta = "select f. * from Fabricantes f  where f.id_fabricante =" + pId + " and f.id_Fabricante in (select id_Fabricante from Articulos)";
            
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            if (datos.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        
    }

        public List<Fabricante> Listar()
        {
            string select = "Select * from Fabricantes";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(select);
            List<Fabricante> listaDeFabricantes = new List<Fabricante>();
            if(datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                foreach(DataRow row in tabla)
                {
                    Dominio.Fabricante unFabricante = new Fabricante();
                    object[] elementos = row.ItemArray;
                    unFabricante.Id = int.Parse(elementos[0].ToString());
                    unFabricante.Nombre = elementos[1].ToString();
                    unFabricante.Direccion = elementos[2].ToString();
                    unFabricante.CorreoElectronico = elementos[3].ToString();
                    listaDeFabricantes.Add(unFabricante);
                }
                return listaDeFabricantes;
            }
            else
            {
                return listaDeFabricantes;
            }
        }

    }
}