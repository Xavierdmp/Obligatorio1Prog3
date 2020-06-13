﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Dominio;
using Obligatorio1.Persistencia.Interfaces;
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pColor : IABM<Color>, IBuscar<Color>

    {
        public static pColor _instancia;

        public static pColor Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new pColor();

                }
                return _instancia;
            }

        }

        public bool Baja(int pId)
        {
            throw new NotImplementedException();
        }

        public Color Buscar(int pId)
        {
            throw new NotImplementedException();
        }

        public bool ComprobarExistencia(string pNombre)
        {
            string consulta = "select * from Colores where Nombre_Color=" + "'" + pNombre + "'";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            if (datos.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool Alta(Color pColor)
        {
            return Conexion.Instancia.InicializarConsulta("Insert into Colores values(" + "'" + pColor.Nombre + "','" + pColor.Codigo + "');");

        }


        public List<Color> ListarColores()
        {
            List <Color> lista = new List<Color>();

            string consulta = "Select * from Colores";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);

            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                foreach (DataRow fila in tabla)
                {
                    Dominio.Color unColor = new Dominio.Color();
                    object[] elementos = fila.ItemArray;
                    unColor.Id = int.Parse(elementos[0].ToString());
                    unColor.Nombre = elementos[1].ToString();
                    unColor.Codigo = elementos[2].ToString();
                    lista.Add(unColor);
                }
                return lista;

            }
            return lista;
        }

        public bool Modificar(Color pT)
        {
            throw new NotImplementedException();
        }
    }
}
