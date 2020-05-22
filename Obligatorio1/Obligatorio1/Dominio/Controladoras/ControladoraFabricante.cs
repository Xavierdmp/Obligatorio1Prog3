using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia;
namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraFabricante
    {
        public bool ComprobarExistenciaFabricante(string pNombre)
        {
            return Controladora.Instancia.ComprobarExistenciaFabricante(pNombre);
        }

        public Fabricante BuscarFabricante(int pId)
        {
            return Controladora.Instancia.BuscarFabricante(pId);
        }

        public bool AltaFabricante(Fabricante pFabricante)
        {
            if (!this.ComprobarExistenciaFabricante(pFabricante.Nombre))
            {
                return Controladora.Instancia.AltaFabricante(pFabricante);
            }
            else
            {
                return false;
            }
        }

        public bool BajaFabricante(int pId)
        {
            Dominio.Fabricante unFabricante = this.BuscarFabricante(pId);
            if (unFabricante != null)
            {
                return Controladora.Instancia.BajaFabricante(pId);
            }
            return false;
        }
        public bool ModificarFabricante(Fabricante pFabricante)
        {
            Dominio.Fabricante unFabricante = this.BuscarFabricante(pFabricante.Id);
            if (unFabricante != null)
            {
                return Controladora.Instancia.ModificarFabricante(pFabricante);
            }
            else
            {
                return false;
            }
        }
        public List<Fabricante> ListaFabricantes()
        {
            return pFabricante.Instancia.Listar();
        }
    }
}