using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia;
namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraLogin
    {
        public int IniciarSesionAdministradores(string pCorreo, string pContraseña)
        {
            Dominio.Encryptar unaEncriptacion = new Dominio.Encryptar();
            return Controladora.Instancia.InciarSesionAdmin(pCorreo, unaEncriptacion.Ecriptar(pContraseña, unaEncriptacion._clave));
        }

        public int IniciarSesionCliente(string pCorreo, string pContraseña)
        {
            Dominio.Encryptar unaEncriptacion = new Dominio.Encryptar();
            return Controladora.Instancia.InciarSesionCliente(pCorreo, unaEncriptacion.Ecriptar(pContraseña, unaEncriptacion._clave));
        }
    }
}