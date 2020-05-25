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
        private string _codigo;

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
        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public Color(string pNombre,string pCodigo)
        {
            this.Nombre = pNombre;
            this.Codigo = pCodigo;
        }
        public Color(string pNombre,int pCantidad,string pCodigo)
        {
            this.Nombre = pNombre;
            this.Cantidad = pCantidad;
            this.Codigo = pCodigo;
        }
        public Color()
        {

        }
    }
}