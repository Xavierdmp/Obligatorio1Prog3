using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio
{
    public class Instrumento:Articulo
    {
        private DateTime _fechaFabricacion;
        private string _UrlVideoYoutube;
        private int _descuento;
        private List<string> _listaColores;
        private bool _destacado = false;  /* */

        
        public bool Destacado
        {
            get { return _destacado; }
            set { _destacado = value; }
        }

        public List<string> ListaColores
        {
            get { return _listaColores; }
            set { _listaColores = value; }

        }


        public DateTime Fechafabricacion
        {
            get { return _fechaFabricacion; }
            set { _fechaFabricacion = value; }
        }
        
        public string UrlVideoYoutube
        {
            get { return _UrlVideoYoutube; }
            set { _UrlVideoYoutube = value; }

        }
        public int Descuento
        {
            get { return _descuento; }
            set { _descuento = value;}
        }


        public Instrumento(string pNombre, string pDescripcion, Fabricante pFabricante, string pFotoPrincipal,

                      List<string> pListaFotosAdicionales, int pPrecio, SubTipo pSubtipo, int pDescuento, DateTime pFecha, string pUrlVideo, 
                     List<string> pListarColor, bool pDestacados)

            :base(pNombre,pDescripcion,pFabricante,pFotoPrincipal,pListaFotosAdicionales, pPrecio,pSubtipo)
        {

            this.Descuento = pDescuento;
            this.Fechafabricacion = pFecha;
            this.UrlVideoYoutube = pUrlVideo;
            this._destacado = pDestacados;
            this.ListaColores = pListarColor;
          
        }



        public Instrumento(string pNombre, string pDescripcion, Fabricante pFabricante, string pFotoPrincipal,
                          int pPrecio, SubTipo pSubtipo, DateTime pFecha, string pUrlVideo, int pDescuento,
                          List<string> pListarColor, bool pDestacados)
            :base(pNombre, pDescripcion,pFabricante,pFotoPrincipal,pPrecio,pSubtipo)
        {
            this.Descuento = pDescuento;
            this.Fechafabricacion = pFecha;
            this.UrlVideoYoutube = pUrlVideo;
            this.Destacado = pDestacados;
            this.ListaColores = pListarColor;

        }

        public Instrumento()
        {

        }

    }
}