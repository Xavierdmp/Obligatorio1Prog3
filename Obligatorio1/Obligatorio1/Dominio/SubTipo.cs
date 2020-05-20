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


        public Tipo tipoInstrumento
        {
            get { return _tipo; }
            set { _tipo = value; }
        }


        public string NombreTipo // Tipo un accesorio tipo get que retorna un tipo bajo nombre. 
        {
            get { return _tipo.Nombre; }

        }

        public SubTipo(string pNombre, Tipo pTipo) // Es el objeto que vas a dar de alta. UN objeto dentro de otro
        {
            this.Nombre = pNombre;
            this.tipoInstrumento = pTipo;
        }


        public SubTipo()
        {

        }


        }
    }
