using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Dominio;
namespace Obligatorio1.Persistencia
{
    public class Controladora
    {
        private static Controladora _instancia;

        public static Controladora Instancia
        {
            get {
                if (_instancia == null)
                {
                    _instancia = new Controladora();
                }
                return _instancia;
            }
        }


        #region "Fabricante"

        public bool ComprobarExistenciaFabricante(string pNombre)
        {
            return pFabricante.Instancia.ComprobarExistencia(pNombre);
        }
        public Fabricante BuscarFabricante(int pId)
        {
            return pFabricante.Instancia.Buscar(pId);
        }
        public bool AltaFabricante(Fabricante pFabri)
        {
            return pFabricante.Instancia.Alta(pFabri);
        }
        public bool BajaFabricante(int pId)
        {
            return pFabricante.Instancia.Baja(pId);
        }
        public bool ModificarFabricante(Fabricante pFabricantes)
        {
            return pFabricante.Instancia.Modificar(pFabricantes);
        }
        public List<Fabricante> ListarFabricantes()
        {
            return pFabricante.Instancia.Listar();
        }
        #endregion


        #region "Tipos"
        public bool ComprobarExistenciaTipo(string pNombre)
        {
            return pTipo.Instancia.ComprobarExistencia(pNombre);
        }
        public Tipo BuscarTipo(int pid)
        {
            return pTipo.Instancia.Buscar(pid);
        }
        public bool AltaTipo(Tipo pTipos)
        {
            return pTipo.Instancia.Alta(pTipos);
        }
        public bool BajaTipo(int pId)
        {
            return pTipo.Instancia.Baja(pId);
        }
        public bool ModificarTipo(Tipo pTipos)
        {
            return pTipo.Instancia.Modificar(pTipos);
        }
        public List<Tipo> ListarTipo()
        {
            return pTipo.Instancia.Listar();
        }
        #endregion

        #region "SubTipos"
        public bool ComprobarExistenciaSubTipo(string pNombre)
        {
            return pSubTipo.Instancia.ComprobarExistencia(pNombre);
        }
        public SubTipo BuscarSubTipo(int pId)
        {
            return pSubTipo.Instancia.Buscar(pId);
        }
        public bool AltaSubTipo(SubTipo pSubtipo)
        {
            return pSubTipo.Instancia.Alta(pSubtipo);
        }
        public bool BajaSubTipo(int pId)
        {
            return pSubTipo.Instancia.Baja(pId);
        }
        public bool ModificarSubTipo(SubTipo pSubtipo)
        {
            return pSubTipo.Instancia.Modificar(pSubtipo);
        }

        public List<SubTipo> ListarSubtipos()
        {
            return pSubTipo.Instancia.Listar();
        }
        #endregion
    }
}