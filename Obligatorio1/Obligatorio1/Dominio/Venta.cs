using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio
{
    public class Venta
    {
        private int _id;
        private DateTime _fecha;
        private List<Item> _listadeItems;
        private Cliente _cliente;
        private int _montototal;
        private string _tarjeta; //Credito o debito//
        private string _pais;

        public string Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }

        private int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private DateTime Fecha
         {
            get { return _fecha; }
            set { _fecha = value; }

        }
        private int MontoTotal
        {
            get { return _montototal; }
            set { _montototal = value; }
        }

        public string Tarjeta
        {
            get { return _tarjeta; }
            set { _tarjeta = value; }
        }
        public List<Item> ListaItem
        {
            get { return _listadeItems; }
            set { _listadeItems = value; }
        }
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value;}
        }

        public int idCliente
        {
            get { return Cliente.Id; }
        }

        private int CalcularMontoTotal(List<Item> pLista) // Calcular el precio total de
                                                            //Todos los items que el cliente compro//
        {
            int total = 0;
            foreach (Item unItem in _listadeItems)
            {
                total += unItem.Precio; /*total = total*unItem.precio*/

            }
            return total;
        }

        public Venta(DateTime pFecha, List<Item> pListaItems, Cliente pCliente, string pTarjeta, string pPais)
        {
            this.Fecha = pFecha;
            this.ListaItem = pListaItems;
            this.Pais = pPais;
            this.Cliente = pCliente;
            this.Tarjeta = pTarjeta;
            this.MontoTotal = this.CalcularMontoTotal(pListaItems);

        }
        public Venta()
        {

        }



       

        



    }
}