using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia;
namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraTipo
    {
        public bool ComprobarExistenciaTipo(string pNombre)
        {
            return Controladora.Instancia.ComprobarExistenciaTipo(pNombre);
        }
        public Tipo BuscarTipo(int pId)
        {
            return Controladora.Instancia.BuscarTipo(pId);
        }
        public bool AltaTipo(Tipo pTipo)
        {
            if (!this.ComprobarExistenciaTipo(pTipo.Nombre))
            {
                return Controladora.Instancia.AltaTipo(pTipo);
            }
            return false;
        }

        public bool BajaTipo(int pId)
        {
            Dominio.Tipo unTipo = this.BuscarTipo(pId);
            if (unTipo != null)
            {
                return Controladora.Instancia.BajaTipo(pId);
            }
            return false;
        }

        public bool ModificarTipo(Tipo pTipo)
        {
            Dominio.Tipo unTipo = this.BuscarTipo(pTipo.Id);
            if (unTipo != null)
            {
                return Controladora.Instancia.ModificarTipo(pTipo);
            }
            return false;
        }

        public List<Tipo> ListaTipo()
        {
            return pTipo.Instancia.Listar();
        }
    }
}