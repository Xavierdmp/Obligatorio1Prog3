using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia;
namespace Obligatorio1.Dominio
{
    public class Empresa
    {

        #region "ABM - LISTAR - BUSCAR FABRICANTE"
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
            if(!this.ComprobarExistenciaFabricante(pFabricante.Nombre))
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
            if(unFabricante != null)
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
        #endregion

        #region "ABM - LISTAR - BUSCAR -TIPO"

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
        #endregion

        #region "ABM - LISTAR - BUSCAR SUBTIPOS"

        public bool ComprobarExistenciaSubTipo(string pNombre)
        {
            return  Controladora.Instancia.ComprobarExistenciaSubTipo(pNombre);
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
            if(unSubtipo != null)
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
            if(unSubtipo != null)
            {
                return Controladora.Instancia.ModificarSubTipo(pSubtipo);
            }
            return false;
        }
        public List<SubTipo> ListarSubtipos()
        {
            return Controladora.Instancia.ListarSubtipos();
        }
        #endregion
    }
}