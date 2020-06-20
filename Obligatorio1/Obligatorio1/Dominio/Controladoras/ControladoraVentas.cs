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
            return Persistencia.Controladora.Instancia.AltaCarrito(pItem, pIdCliente);

        }
        public bool BajaCarrito(int pIdCliente)
        {
            return Persistencia.Controladora.Instancia.BajaCarrito(pIdCliente);

        }
        public List<Item> ListarCarritoParaCliente(int pIdCliente)
        {
            return Persistencia.Controladora.Instancia.ListadeItemsCarrito(pIdCliente);
        }

    }
}