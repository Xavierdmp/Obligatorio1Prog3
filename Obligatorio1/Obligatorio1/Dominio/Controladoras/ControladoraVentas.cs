using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia;
using Obligatorio1.Dominio.Intefaces;

namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraVentas
    {

        public List<string> ListarPaises()
        {
            return Persistencia.Controladora.Instancia.ListaPais();
        }

        public List<string> ListarCiudad(string Pais)
        {
            return Persistencia.Controladora.Instancia.ListaCiudad(Pais);
        }


    }
}