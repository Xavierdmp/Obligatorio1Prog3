using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Dominio;
using System.Data;
namespace Obligatorio1.Persistencia
{
    public class pCarrito
    {
        private static pCarrito _instancia = null;

        public static pCarrito Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new pCarrito();
                }
                return _instancia;
            }

        }
        private pCarrito() { }

        public bool AltaCarrito(Item pItem, int pIdCliente)
        {
            Dominio.Instrumento unInstrumento = pItem.Articulo as Instrumento;
            Dominio.Accesorio unAccesorio = pItem.Articulo as Accesorio;
            if (unAccesorio != null)
            {
                return Conexion.Instancia.InicializarConsulta("Insert into CarritoCompras(Id_Cliente,Id_Articulo,Cantidad) values(" + pIdCliente + "," + pItem.Articulo.Id + "," + pItem.Cantidad + ");");
            }
            else
            {
                return Conexion.Instancia.InicializarConsulta("Insert into CarritoCompras(Id_Cliente,Id_Articulo,Cantidad,Id_Color) values(" + pIdCliente + "," + pItem.Articulo.Id + "," + pItem.Cantidad + "," + pItem.Color.Id + ");");
            }
                
            
        }

        public List<Item> ListaCarrito(int pIdCliente)
        {
            string consulta = "Select cc.* from CarritoCompras cc,Clientes c where cc.Id_Cliente = c.Id_Cliente and cc.Id_Cliente=" + pIdCliente;
            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);
            List<Item> ListadoDeItems = new List<Item>();
            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;

                foreach (DataRow row in tabla)
                {
                    Dominio.Item unItem = new Item();
                    object[] elementos = row.ItemArray;

                    int IdArticulo = int.Parse(elementos[2].ToString());
                    Dominio.Instrumento unInstrumento = Controladora.Instancia.BuscarInstrumento(IdArticulo);
                    Dominio.Accesorio unAccesorio = Controladora.Instancia.BuscarAccesorio(IdArticulo);

                    if(unInstrumento == null)
                    {
                        unItem.Articulo = unAccesorio;
                    }
                    else
                    {
                        unItem.Articulo = unInstrumento;
                    }
                    unItem.Cantidad = int.Parse(elementos[3].ToString());
                    ListadoDeItems.Add(unItem);
                }
                return ListadoDeItems;
            }
            return ListadoDeItems;
        }
        public bool EliminarCarrito(int pIdCliente)
        {
            return Conexion.Instancia.InicializarConsulta("delete from CarritoCompras where Id_Cliente=" + pIdCliente);
        }

        public bool EliminarArticuloDeCarrito(int pIdArticulo,int pIdCliente)
        {
            return Conexion.Instancia.InicializarConsulta("delete from CarritoCompras where Id_Articulo=" + pIdArticulo + " and Id_Cliente=" + pIdCliente);
        }

    }
}