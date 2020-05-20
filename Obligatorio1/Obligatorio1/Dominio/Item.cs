using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio
{
    public class Item
    {
        private int _id;
        private Instrumento _instrumento;
        private Accesorio _accesorio;
        private int _cantidad;
        private int _precio;
        private int _idColor;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Instrumento Instrumento
        {
            get { return _instrumento; }
            set { _instrumento = value; }
        }
        public Accesorio Acessorio
        {
            get { return _accesorio; }
            set { _accesorio = value; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        //public int IdInstrumento
        //{
        //    get { return _instrumento.Id; }
        //}
        //public int IdAccesorio
        //{
        //    get { return _accesorio.Id; }
        //}

        public int RetornarIdArticulo
        {
           get { if (this.Acessorio != null)
                {
                    return _accesorio.Id;
                }
           else
                {
                    return _instrumento.Id;
                }
            }
        }
        public int IdColor
        {
            get{ return _idColor;}
            set { _idColor = value; }
        }
        private int CalcularPrecioTotal(int pCantidad)
        {
            int total = 0;
            if(this.Acessorio != null)
            {
                total = this.Acessorio.Precio * pCantidad;
            }
            else
            {
                total = this.Instrumento.Precio * pCantidad;
            }
            return total;
        }
        public Item(Instrumento pInstrumento,int pCantidad, int pIdColor)
        {
            this.Instrumento = pInstrumento;
            this.Cantidad = pCantidad;
            this.Precio = this.CalcularPrecioTotal(pCantidad);
            this.IdColor = pIdColor;
        }
        public Item(Accesorio pAccesorio,int pCantidad, int pIdColor)
        {
            this.Acessorio = pAccesorio;
            this.Cantidad = pCantidad;
            this.Precio = this.CalcularPrecioTotal(pCantidad);
            this.IdColor = pIdColor;
        }
        public Item()
        {

        }


    }
}