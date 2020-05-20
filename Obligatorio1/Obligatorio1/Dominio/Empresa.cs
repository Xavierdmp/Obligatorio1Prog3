using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia;

namespace Obligatorio1.Dominio
{
    public class Empresa
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
            if (!this.ComprobarExistenciaFabricante(pFabricante.Nombre))/*Comprobando que no exista un fabricante con es emismo nombre*/
            {
                return Controladora.Instancia.AltaFabricante(pFabricante);/*retorna un verdadero o falso*/
            }
            return false;/*SI es diferente a comprobar existencia */

        }

        public bool BajaFabricante(int pid)
        {
            Dominio.Fabricante unfabricante = this.BuscarFabricante(pid);
            if (unfabricante != null)
            {
                return Controladora.Instancia.BajaFabricante(pid);

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
            return false;

        }

        public List<Fabricante> ListarFabricante()
        {
            return pFabricante.Instancia.Listar();
        }


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
            if(unTipo != null)
            {
                return Controladora.Instancia.ModificarTipo(pTipo);

            }
            return false;

        }

        public List<Tipo> ListaTipo()
        {
            return pTipo.Instancia.Listar();
        }
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