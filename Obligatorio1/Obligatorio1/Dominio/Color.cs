using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio
{
    public class Color
    {
        private int _id;
        private string _nombre;
        private int _cantidad;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public Color(string pNombre)
        {
            this.Nombre = pNombre;
        }
        public Color(string pNombre,int pCantidad)
        {
            this.Nombre = pNombre;
            this.Cantidad = pCantidad;
        }
        public Color()
        {

        }
    }
}