using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio
{
    public class Accesorio:Articulo
    {

        public Accesorio(string pNombre, string pDescripcion, Fabricante pFabricante,
                        string pFotoPrincipal, List<string> pFotosAdicionales,
                        int pPrecio, SubTipo pSubtipo, int pStock)
            :base(pNombre,pDescripcion,pFabricante,pFotoPrincipal,pFotosAdicionales,pPrecio,pSubtipo,pStock)
        {

        }

        public Accesorio(string pNombre, string pDescripcion, Fabricante pFabricante,
                        string pFotoPrincipal, int pPrecio, SubTipo pSubtipo,int pStock)
            : base(pNombre, pDescripcion, pFabricante, pFotoPrincipal, pPrecio, pSubtipo,pStock)
        {

        }

        public Accesorio()
        {

        }
    }
}