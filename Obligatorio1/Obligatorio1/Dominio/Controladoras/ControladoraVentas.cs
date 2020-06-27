using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraVentas
    {
        public bool AltaCarrito(Item pItem, int pIdCliente)
        {
            if (!this.comprobarExistenciaCarrito(pItem.Articulo.Id))
            {
                return Persistencia.Controladora.Instancia.AltaCarrito(pItem, pIdCliente);
            }
            return false;
        }

        public bool BajaCarrito(int pIdCliente)
        {
            return Persistencia.Controladora.Instancia.BajaCarrito(pIdCliente);
        }
        public List<Item> ListaCarritoParaCliente(int pIdCliente)
        {
            return Persistencia.Controladora.Instancia.ListaItemsCarrito(pIdCliente);
        }

        public bool BajaArticuloCarrito(int pIdArticulo,int pIdCliente)
        {
            return Persistencia.Controladora.Instancia.BajaArticuloCarrito(pIdArticulo, pIdCliente);
        }

        public bool comprobarExistenciaCarrito(int pIdArticulo)
        {
            return Persistencia.Controladora.Instancia.ComprobarExistenciaCarrito(pIdArticulo);
        }
    }
}