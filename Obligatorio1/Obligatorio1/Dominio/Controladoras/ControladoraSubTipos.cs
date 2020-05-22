using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia;
namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraSubTipos
    {
        public bool ComprobarExistenciaSubTipo(string pNombre)
        {
            return Controladora.Instancia.ComprobarExistenciaSubTipo(pNombre);
        }
        public SubTipo BuscarSubtipo(int pId)
        {
            return Controladora.Instancia.BuscarSubTipo(pId);
        }
        public bool AltaSubtipo(SubTipo pSubtipo)
        {
            if (!this.ComprobarExistenciaSubTipo(pSubtipo.Nombre))
            {
                return Controladora.Instancia.AltaSubTipo(pSubtipo);
            }
            else
            {
                return false;
            }
        }
        public bool BajaSubTipo(int pId)
        {
            Dominio.SubTipo unSubtipo = this.BuscarSubtipo(pId);
            if (unSubtipo != null)
            {
                return Controladora.Instancia.BajaSubTipo(pId);
            }
            else
            {
                return false;
            }
        }
        public bool ModificarSubTipo(SubTipo pSubtipo)
        {
            Dominio.SubTipo unSubtipo = this.BuscarSubtipo(pSubtipo.Id);
            if (unSubtipo != null)
            {
                return Controladora.Instancia.ModificarSubTipo(pSubtipo);
            }
            return false;
        }
        public List<SubTipo> ListarSubtipos()
        {
            return Controladora.Instancia.ListarSubtipos();
        }
    }
}