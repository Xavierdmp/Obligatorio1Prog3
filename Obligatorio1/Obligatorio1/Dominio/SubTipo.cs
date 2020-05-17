using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio
{
    public class SubTipo
    {
        private int _id;
        private string _nombre;
        private Tipo _tipo;

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
        public Tipo TipoInstrumento
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public string NombreTipo
        {
            get { return _tipo.Nombre; }
        }
        public SubTipo(string pNombre, Tipo pTipo)
        {
            this.Nombre = pNombre;
            this.TipoInstrumento = pTipo;
        }
        public SubTipo()
        {

        }


    }
}