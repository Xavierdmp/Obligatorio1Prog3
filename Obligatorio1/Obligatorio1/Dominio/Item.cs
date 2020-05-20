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

        public int IdColor
        {
            get { return _idColor; }
            set { _idColor = value; }
        }

      public int Id
        {
            get { return _id; }
            set { _id = value; } 
        }
        
        public Instrumento Instrumentos
        {
            get { return _instrumento; }
            set { _instrumento = value; }
        }
        public Accesorio Accesorio
        {
            get { return _accesorio; }
            set { _accesorio = value; } 
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public int idInstrumento // poara la grilla
        {
            get { return _instrumento.Id; }
        }

        public int IdAccesorio // para la grila de accesorio
        {
            get { return _accesorio.Id; }
        }

        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }




        public int RetornarArticulo
        {
            get
            {
                if (Accesorio != null)
                {
                    return _accesorio.Id;
                }
                else
                {
                    return _instrumento.Id;

                }
            }

        }

       


        private int CalcularPrecioTotal(int pCantidad) // Calcula el precio total de un Item. Private Int porque se usa
                                             // dentro de esa clase. 
        {
            int total = 0;

            if (this.Accesorio != null)
            {
                total = this.Accesorio.Precio * pCantidad;
            }

            return total;
        }

        public Item(Instrumento pInstrumento, int pCantidad, int pColor)
        {
            this._idColor = pColor;
            this.Instrumentos = pInstrumento;
            this.Cantidad = pCantidad;
            this.Precio = this.CalcularPrecioTotal(pCantidad); // Asignas el precio es para mostrar 

        }

        public Item(Accesorio pAccesorio, int pCantidad, int pColor)
        {
            this._idColor = pColor;
            this.Accesorio = pAccesorio;
            this.Cantidad = pCantidad;
            this.Precio = this.CalcularPrecioTotal(pCantidad);
        }



        public Item()
        {

        }

    }
}