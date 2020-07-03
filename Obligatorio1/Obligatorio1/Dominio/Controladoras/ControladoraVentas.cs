using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia;
using Obligatorio1.Dominio.Intefaces;

namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraVentas:IABMLBC<Venta>
    {
        private static ControladoraVentas _instancia = null;
        
        public static ControladoraVentas Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ControladoraVentas();
                }
                return _instancia;
            }
        }

        public ControladoraVentas()
        {

        }
              


        public List<string> ListarPaises()
        {
            return Persistencia.Controladora.Instancia.ListaPais();
        }

        public List<string> ListarCiudad(string Ciudad)
        {
            return Persistencia.Controladora.Instancia.ListaCiudad(Ciudad);
        }


        public Venta Buscar(int pIdVenta)
        {
            return Persistencia.Controladora.Instancia.BuscarVenta(pIdVenta);

        }
        public bool Baja(int pIdVenta)
        {
            return Persistencia.Controladora.Instancia.BajaVenta(pIdVenta);
        }
        public bool Modificar(int pIdVenta)
        {
            return true;
        }

        public bool ComprobarExistencia(string pTexto)
        {
            throw new NotImplementedException();
        }

        public List<Venta> Listar()
        {
            return Persistencia.Controladora.Instancia.ListadodeVentas();
        }

        public bool Alta(Venta pVenta)
        {
            return Controladora.Instancia.AltaVenta(pVenta);
        }

        public bool Modificar(Venta pT)
        {
            throw new NotImplementedException();
        }
    }
}