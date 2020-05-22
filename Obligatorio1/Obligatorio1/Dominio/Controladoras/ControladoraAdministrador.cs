using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia;
namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraAdministrador
    {
       
        public List<Administrador> ListarAdministradores()
        {
            return Controladora.Instancia.ListarAdministradores();
        }
        public bool ComprobarExistenciaAdmin(string pCorreo)
        {
            return Controladora.Instancia.ComprobarExistenciaAdmin(pCorreo);
        }
        public Administrador BuscarAdministrador(int pId)
        {
            return Controladora.Instancia.BuscarAdministrador(pId);
        }
        public bool AltaAdministrador(Administrador pAdministrador)
        {
            if (!this.ComprobarExistenciaAdmin(pAdministrador.CorreoElectronico))
            {
                return Controladora.Instancia.AltaAdministradores(pAdministrador);
            }
            return false;
        }
        public bool BajaAdministrador(int pId)
        {
            return Controladora.Instancia.BajaAdministrador(pId);
        }
        public bool ModificarAdministrador(Administrador pAdmin)
        {
            Dominio.Encryptar unaEnrptacion = new Encryptar();
            pAdmin.Contraseña = unaEnrptacion.Ecriptar(pAdmin.Contraseña, unaEnrptacion._clave);
            return Controladora.Instancia.ModificarAdministrador(pAdmin);
        }

    }
}