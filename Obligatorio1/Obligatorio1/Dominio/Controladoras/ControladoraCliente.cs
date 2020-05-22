using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia;
namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraCliente
    {
        public List<Cliente> ListaClientes()
        {
            return Controladora.Instancia.ListarClientes();
        }

        public bool ComprobarExisteCliente(string pCedula)
        {
            return Controladora.Instancia.ComprobarExisteCliente(pCedula);
        }

        public Cliente BuscarCliente(int pId)
        {
            return Controladora.Instancia.BuscarCliente(pId);
        }

        public bool AltaCliente(Cliente pCliente)
        {
            if (!this.ComprobarExisteCliente(pCliente.CedulaIdentidad))
            {
                return Controladora.Instancia.AltaCliente(pCliente);
            }
            else
            {
                return false;
            }
        }

        public bool BajaCliente(int pId)
        {
            Dominio.Cliente unCliente = this.BuscarCliente(pId);
            if (unCliente != null)
            {
                return Controladora.Instancia.BajaCliente(pId);
            }
            else
            {
                return false;
            }
        }

        public bool ModificarCliente(Cliente pCliente)
        {
            Dominio.Cliente unCliente = this.BuscarCliente(pCliente.Id);
            if (unCliente != null)
            {
                return Controladora.Instancia.ModificarCliente(pCliente);
            }
            return false;
        }
    }
}