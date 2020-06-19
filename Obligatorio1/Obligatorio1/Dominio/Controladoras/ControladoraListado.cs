using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraListado
    {
        private const int CantidadElementosAMostrar = 4;

        public List<Articulo> Paginado(int pPaginaInicio)
        {

                List<Articulo> ListadoArticulos = new List<Articulo>();
                ListadoArticulos = Persistencia.Controladora.Instancia.ListadoArticulos();
                int ContadorIndice = pPaginaInicio;
                int ContadorElementos = 0;

                int indiceInicio = 0;
                List<Articulo> ListaPaginada = new List<Articulo>();


                foreach (Articulo unArticulo in ListadoArticulos)
                {
                    indiceInicio += indiceInicio != ContadorIndice ? 1 : 0;
                    if (indiceInicio == ContadorIndice)
                    {
                        if (ContadorElementos < CantidadElementosAMostrar)
                        {
                            ContadorElementos++;
                            ListaPaginada.Add(unArticulo);
                        }
                    }
                }
                return ListaPaginada;
        }

        public bool CantidadFilas(int pIndex)
        {
            int cantidadFilas = Persistencia.Controladora.Instancia.CantidadArticulos();
            return pIndex <= cantidadFilas;
        }

    }
}