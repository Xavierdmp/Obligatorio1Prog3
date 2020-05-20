using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio
{
    public class Instrumento:Articulo
    {
        private DateTime _fechaFabricacion;
        private string _urlVideoYoutube;
        private int _descuento;
        private List<string> _listaColores;
        private bool _destacado = false;

        public DateTime FechaFabricacion
        {
            get { return _fechaFabricacion; }
            set { _fechaFabricacion = value; }
        }
        public string VideoYoutube
        {
            get { return _urlVideoYoutube; }
            set { _urlVideoYoutube = value; }
        }
        public int Descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }
        public List<string> ListaDeColores
        {
            get { return _listaColores; }
            set { _listaColores = value; }
        }
        public bool Destacado
        {
            get { return _destacado; }
            set { _destacado = value; }
        }

        public Instrumento(string pNombre, string pDescripcion, Fabricante pFabricante,
                        string pFotoPrincipal, List<string> pFotosAdicionales,
                        int pPrecio, SubTipo pSubtipo, DateTime pFecha, string pUrlVideo,
                        int pDescuento,List<string> pListaColores, bool pDestacado)
            :base(pNombre,pDescripcion,pFabricante,pFotoPrincipal,pFotosAdicionales,pPrecio,pSubtipo)
        {
            this.FechaFabricacion = pFecha;
            this.VideoYoutube = pUrlVideo;
            this.Descuento = pDescuento;
            this.ListaDeColores = pListaColores;
            this.Destacado = pDestacado;
        }

        public Instrumento(string pNombre, string pDescripcion, Fabricante pFabricante,
                        string pFotoPrincipal,
                        int pPrecio, SubTipo pSubtipo, DateTime pFecha, string pUrlVideo,
                        int pDescuento, List<string> pListaColores, bool pDestacado)
            : base(pNombre, pDescripcion, pFabricante, pFotoPrincipal, pPrecio, pSubtipo)
        {
            this.FechaFabricacion = pFecha;
            this.VideoYoutube = pUrlVideo;
            this.Descuento = pDescuento;
            this.ListaDeColores = pListaColores;
            this.Destacado = pDestacado;
        }
        public Instrumento()
        {

        }

    }
}