using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia;
using Obligatorio1.Dominio.Intefaces;
namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraCliente:IABMLBC<Cliente>
    {
        public List<Cliente> Listar()
        {
            return Controladora.Instancia.ListarClientes();
        }

        public bool ComprobarExistencia(string pCedula)
        {
            return Controladora.Instancia.ComprobarExisteCliente(pCedula);
        }

        public Cliente Buscar(int pId)
        {
            return Controladora.Instancia.BuscarCliente(pId);
        }

        public bool Alta(Cliente pCliente)
        {
            if (!this.ComprobarExistencia(pCliente.CedulaIdentidad))
            {
                return Controladora.Instancia.AltaCliente(pCliente);
            }
            else
            {
                return false;
            }
        }

        public bool Baja(int pId)
        {
            Dominio.Cliente unCliente = this.Buscar(pId);
            if (unCliente != null)
            {
                return Controladora.Instancia.BajaCliente(pId);
            }
            else
            {
                return false;
            }
        }

        public bool Modificar(Cliente pCliente)
        {
            Dominio.Cliente unCliente = this.Buscar(pCliente.Id);
            if (unCliente != null)
            {
                return Controladora.Instancia.ModificarCliente(pCliente);
            }
            return false;
        }
    }
}