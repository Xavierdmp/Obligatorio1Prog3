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
        private Color _color;

        //APLICAR POLIMORFISMO UTILIZANDO ARTICULOS EN VEZ DE INSTRUMENTO Y ACCESORIOS

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

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private int CalcularPrecioTotal(int pCantidad)
        {
            int total = 0;
            if (this.Acessorio != null)
            {
                total = this.Acessorio.Precio * pCantidad;
            }
            else
            {
                total = this.Instrumento.Precio * pCantidad;
            }
            return total;
        }

        public Item(Instrumento pInstrumento, int pCantidad, Color pColor)
        {
            this.Instrumento = pInstrumento;
            this.Cantidad = pCantidad;
            this.Precio = this.CalcularPrecioTotal(pCantidad);
            this.Color = pColor;
        }

        public Item(Accesorio pAccesorio, int pCantidad, Color pColor)
        {
            this.Acessorio = pAccesorio;
            this.Cantidad = pCantidad;
            this.Precio = this.CalcularPrecioTotal(pCantidad);
            this.Color = pColor;
        }

        public Item()
        {

        }


    }
}