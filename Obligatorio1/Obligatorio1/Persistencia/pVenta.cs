using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Persistencia.Interfaces;
using Obligatorio1.Dominio;
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pVenta : IABM<Venta>, IBuscar<Venta>
    {
        private static pVenta _instancia = null;
        protected const string UltimaId = "Declare @UltimaId int;Set @UltimaId= ident_current('Ventas');";

        public static pVenta Instancia
        {
            get {
                if(_instancia == null)
                {
                    _instancia = new pVenta();
                }
                return _instancia;
            }
        }

        public bool Alta(Venta pVenta)
        {
            int estadoActivado = 1;
            List<string> transaccion = new List<string>();
            transaccion.Add("Insert into Ventas values(" + "'" +pVenta.Fecha +"'," + pVenta.Cliente.Id +"," + 
                                                        pVenta.MontoTotal +",'" + pVenta.Tarjeta +"','" +
                                                        pVenta.Pais + "'," + estadoActivado +",'" + pVenta.Ciudad +"');");

            foreach (Item unItem in pVenta.ListaItems)
            {
                if (unItem.Color != null) {
                    transaccion.Add(UltimaId + "Insert into Ventas_tienen_Articulos values(" + "@UltimaId" + "," + unItem.Articulo.Id + "," + unItem.Cantidad + "," + unItem.Precio + "," + unItem.Color.Id + ");");
                }
                else
                {
                    transaccion.Add(UltimaId + "Insert into Ventas_tienen_Articulos(Id_Venta,Id_Articulo,Cantidad_Articulo,Precio_Articulo) values(" + "@UltimaId" + "," + unItem.Articulo.Id + "," + unItem.Cantidad + "," + unItem.Precio +");");
                }
            }
            transaccion.Add("delete from CarritoCompras where Id_Cliente =" + pVenta.Cliente.Id);
            return Conexion.Instancia.EjecutarTransaccionSql(transaccion);
        }

        public bool Baja(int pId)
        {
            return Conexion.Instancia.InicializarConsulta("Update Ventas set Estado_Venta =0 where Id_Venta =" + pId);
        }

        public Venta Buscar(int pId)
        {
            string consulta = "Select * from Ventas where Id_Venta=" + pId;
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                Dominio.Venta unaVenta = new Venta();
                foreach (DataRow row in tabla)
                {
                    object[] elementos = row.ItemArray;
                    unaVenta.Id = int.Parse(elementos[0].ToString());
                    unaVenta.Fecha = Convert.ToDateTime(elementos[1].ToString());
                    int IdCliente = int.Parse(elementos[2].ToString());
                    unaVenta.Cliente = Controladora.Instancia.BuscarCliente(IdCliente);
                    unaVenta.MontoTotal = int.Parse(elementos[3].ToString());
                    unaVenta.Tarjeta = elementos[4].ToString();
                    unaVenta.Pais = elementos[5].ToString();
                    unaVenta.Ciudad = elementos[7].ToString();

                }
                return unaVenta;
            }
            return null;
        }

        public List<Venta> ListarVentas()
        {
            string consulta = "Select * from ventas where Estado_Venta =1";
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            List<Venta> ListarVentas = new List<Venta>();
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                
                foreach (DataRow row in tabla)
                {
                    Dominio.Venta unaVenta = new Venta();
                    object[] elementos = row.ItemArray;
                    unaVenta.Id = int.Parse(elementos[0].ToString());
                    unaVenta.Fecha = Convert.ToDateTime(elementos[1].ToString());
                    int IdCliente = int.Parse(elementos[2].ToString());
                    unaVenta.Cliente = Controladora.Instancia.BuscarCliente(IdCliente);
                    unaVenta.MontoTotal = int.Parse(elementos[3].ToString());
                    unaVenta.Tarjeta = elementos[4].ToString();
                    unaVenta.Pais = elementos[5].ToString();
                    unaVenta.Ciudad = elementos[7].ToString();
                    ListarVentas.Add(unaVenta);

                }
                return ListarVentas;
            }
            return ListarVentas;
        }

        public bool ComprobarExistencia(string pTexto)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Venta pT)
        {
            throw new NotImplementedException();
        }
    }
}