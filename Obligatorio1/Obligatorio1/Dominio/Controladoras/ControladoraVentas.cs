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

            if (!this.ComprobarExistenciaCarrito(pItem.Articulo.Id)) // Evitas que se repita el articulo
            {

                return Persistencia.Controladora.Instancia.AltaCarrito(pItem, pIdCliente);
            }

            return false;
        }
        public bool BajaCarrito(int pIdCliente)
        {
            return Persistencia.Controladora.Instancia.BajaCarrito(pIdCliente);

        }
        public List<Item> ListarCarritoParaCliente(int pIdCliente)
        {
            return Persistencia.Controladora.Instancia.ListadeItemsCarrito(pIdCliente);
        }

        public bool BajaArticuloCarrito(int pIdArticulo, int pIdCliente)
        {
            return Persistencia.Controladora.Instancia.BajaArticuloCarrito(pIdArticulo, pIdCliente);
        }


        public bool ComprobarExistenciaCarrito(int pIdArticulo)
        {
            return Persistencia.Controladora.Instancia.ComprobarExistenciaCarrito(pIdArticulo);

        }

    }
}