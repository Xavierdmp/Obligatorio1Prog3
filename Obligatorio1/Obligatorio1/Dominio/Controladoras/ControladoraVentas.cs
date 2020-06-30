using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraVentas
    {
       
        public List<string> ListarPaises()
        {
            return Persistencia.Controladora.Instancia.ListarPaises();
        }

        public List<string> ListarCiudadesDado(string pNombrePais)
        {
            return Persistencia.Controladora.Instancia.ListarCiudades(pNombrePais);
        }

    }
}