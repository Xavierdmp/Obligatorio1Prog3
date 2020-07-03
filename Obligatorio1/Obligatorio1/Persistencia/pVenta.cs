using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Dominio;
using Obligatorio1.Persistencia.Interfaces;
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pVenta : IABM<Venta>, IBuscar<Venta>
    {

        private static pVenta _instancia = null;

        protected const string UltimaId = "Declare @UltimaId int ; Set @UltimaId= ident_current('Ventas');";

        public static pVenta Instancia
        {
            get
            {
                if (_instancia == null)
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
            transaccion.Add("Insert into Ventas values(" + "'" + pVenta.Fecha + "'," + pVenta.Cliente.Id + "," +
                                                        pVenta.MontoTotal + ",'" + pVenta.Tarjeta + "','" +
                                                        pVenta.Pais + "'," + estadoActivado + ",'" + pVenta.Ciudad + "');");

            foreach (Item unItem in pVenta.ListaItems)
            {
                if (unItem.Color != null)
                {
                    transaccion.Add(UltimaId + "Insert into Ventas_tienen_Articulos values(" + "@UltimaId" + "," + unItem.Articulo.Id + "," + unItem.Cantidad + "," + unItem.Precio + "," + unItem.Color.Id + ");");
                }
                else
                {
                    transaccion.Add(UltimaId + "Insert into Ventas_tienen_Articulos(Id_Venta,Id_Articulo,Cantidad_Articulo,Precio_Articulo) values(" + "@UltimaId" + "," + unItem.Articulo.Id + "," + unItem.Cantidad + "," + unItem.Precio + ");");
                }
            }
            transaccion.Add("delete from CarritoCompras where Id_Cliente =" + pVenta.Cliente.Id);
            return Conexion.Instancia.EjecutarTransaccionSql(transaccion);
        }

        public bool Baja(int pId)
        {
            return Conexion.Instancia.InicializarConsulta("updte Ventas set Estado_Venta =0 where Id_Venta =" + pId);
        }

        public Venta Buscar(int pId)
        {
            string consulta = "select * from ventas where Id_Venta=" + pId;
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);


            if (datos.Tables[0].Rows.Count > 0)
            {
                Dominio.Venta unaVenta = new Venta();

                DataRowCollection table = datos.Tables[0].Rows;
                foreach (DataRow row in table)
                {
                    object[] element = row.ItemArray;

                    unaVenta.Id = int.Parse(element[0].ToString());
                    unaVenta.Fecha = Convert.ToDateTime(element[1].ToString());
                    int idCliente = int.Parse(element[2].ToString());
                    unaVenta.Cliente = Controladora.Instancia.BuscarCliente(idCliente);
                    unaVenta.MontoTotal = int.Parse(element[3].ToString());
                    unaVenta.Tarjeta = element[4].ToString();
                    unaVenta.Pais = element[5].ToString();
                    unaVenta.Ciudad = element[7].ToString();


                }
                return unaVenta;


            }

            return null;
        }

        public List<Venta> ListadeVentas()
        {
            string consulta = "select * from ventas where Estado_Venta =1;";

            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);

            List<Venta> ListadeVentas = new List<Venta>();


            if (datos.Tables[0].Rows.Count > 0)
            {


                DataRowCollection table = datos.Tables[0].Rows;
                foreach (DataRow row in table)
                {
                    object[] element = row.ItemArray;

                    Dominio.Venta unaVenta = new Venta();

                    unaVenta.Id = int.Parse(element[0].ToString());
                    unaVenta.Fecha = Convert.ToDateTime(element[1].ToString());
                    int idCliente = int.Parse(element[2].ToString());
                    unaVenta.Cliente = Controladora.Instancia.BuscarCliente(idCliente);
                    unaVenta.MontoTotal = int.Parse(element[3].ToString());
                    unaVenta.Tarjeta = element[4].ToString();
                    unaVenta.Pais = element[5].ToString();
                    unaVenta.Ciudad = element[7].ToString();

                    ListadeVentas.Add(unaVenta);

                }
                return ListadeVentas;


            }

            return ListadeVentas;
        }

        public bool Modificar(Venta pT)
        {
            throw new NotImplementedException();
        }


        public bool ComprobarExistencia(string pTexto)
        {
            throw new NotImplementedException();
        }


    }
}
