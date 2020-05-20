using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio
{
    public abstract class Articulo
    {   
        private int _id;
        private string _nombre;
        private string _descripcion;
        private string _urlFotoPrincipal;
        public int _precio;
        private SubTipo _subtipo;
        private Fabricante _fabricante;
        private List<string> _listaUrlsFotosAdicionales;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public string FotoPrincipal
        {
            get { return _urlFotoPrincipal; }
            set { _urlFotoPrincipal = value; }
        }
       
        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public List<string> ListaFotosAdicionales
        {
            get { return _listaUrlsFotosAdicionales; }
            set { _listaUrlsFotosAdicionales = value; }
        }
        public SubTipo Subtipo
        {
            get { return _subtipo; }
            set { _subtipo = value; }
        }

        public Fabricante Fabricante
        {
            get { return _fabricante; }
            set { _fabricante = value; }
        }


        public int IdFabricante
        {
            get { return _fabricante.Id; }
        }
        public int IdSubtipo
        {
            get { return _subtipo.Id; }
        }

        public Articulo(string pNombre, string pDescripcion, Fabricante pFabricante, string pFotoPrincipal,
                          List<string> pListaFotosAdicionales, int pPrecio, SubTipo pSubtipo)
        {
            this.Nombre = pNombre;
            this.Descripcion = pDescripcion;
            this.Fabricante = pFabricante;
            this.FotoPrincipal = pFotoPrincipal;
            this.ListaFotosAdicionales = pListaFotosAdicionales;
            this.Precio = pPrecio;
            this.Subtipo = pSubtipo;

        }

        public Articulo(string pNombre, string pDescripcion, Fabricante pFabricante, string pFotoPrincipal,
                          int pPrecio, SubTipo pSubtipo)
        {
            this.Nombre = pNombre;
            this.Descripcion = pDescripcion;
            this.Fabricante = pFabricante;
            this.FotoPrincipal=pFotoPrincipal;
            this.Precio = pPrecio;
            this.Subtipo = pSubtipo;

        }
        public Articulo()
        {

        }


    }
}