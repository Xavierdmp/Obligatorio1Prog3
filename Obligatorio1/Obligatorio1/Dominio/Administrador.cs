using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio
{
    public class Administrador:Persona // para que herede
    {
        private bool _permisos;


        public bool Permisos
        {
            get { return  _permisos; }
            set { _permisos = value; }
               
        }
        public Administrador(string pCorreoElectronico, string pContraseña)
            :base (pCorreoElectronico,pContraseña )
        {
            this.Permisos = false; // bloques de codigo porque solo un administrador tenia permisos para dar de alta
        }
        public Administrador()
        {

        }

    }
}