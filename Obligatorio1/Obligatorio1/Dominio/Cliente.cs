using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio
{
    public class Cliente : Persona // hereda de persona
    {
        private string _nombre;
        private string _apellido;
        private string _cedulaidentidad;
       
        private int _telefono;
        

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }

        }
        public string CedulaIdentididad
        {
            get { return _cedulaidentidad; }
            set { _cedulaidentidad = value; }
        }
      

        public int Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public Cliente(string pCorreo, string pContraseña, string pNombre, string pApellido, string pCedulaIdentididad,
                  string pDireccion, string pTelefono, string pPais)

           :base (pCorreo, pContraseña)
         {

        }

        public Cliente()
        {
            
        }

    }
}