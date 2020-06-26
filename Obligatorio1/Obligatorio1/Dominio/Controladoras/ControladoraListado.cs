using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraListado
    {
        private const int CantidadElementoaMostrar = 4;

        public List<Articulo> Paginado(int pPaginaInicio)
        {

            List<Articulo> ListadodeArticulos = new List<Articulo>();//listado Articulo

            ListadodeArticulos = Persistencia.Controladora.Instancia.ListadoArticulos();

            List<Articulo> ListadoPaginado = new List<Articulo>();
            
            int ContadorIndice = pPaginaInicio;
            int ContadorElementos = 0;
            int indiceInicio = 0;


            foreach (Articulo unArticulo in ListadodeArticulos)
            {

                indiceInicio += indiceInicio != ContadorIndice ? 1 : 0; //? if 

                if (indiceInicio == ContadorIndice)
                {

                    if (ContadorElementos < CantidadElementoaMostrar)

                    {
                        ContadorElementos++;
                        ListadoPaginado.Add(unArticulo);


                    }
                    else
                    {
                        break;
                    }

                }
            }
            return ListadoPaginado;
        }
        public bool CantidadFilas(int pIndex)
        {
            int cantidadFilas = Persistencia.Controladora.Instancia.CantidadArticulos();
            return pIndex <= cantidadFilas - CantidadElementoaMostrar;
        }
    }
}

        