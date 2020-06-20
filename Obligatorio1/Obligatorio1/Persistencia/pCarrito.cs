using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Dominio;
using Obligatorio1.Persistencia.Interfaces;
using System.Data;

namespace Obligatorio1.Persistencia
{
    public class pCarrito
    {


        private static pCarrito _instancia;

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

        public bool AltaCarrito(Item pItem, int pIdCLiente)
        {
            return Conexion.Instancia.InicializarConsulta("Insert into CarritoCompras(Id_Cliente,Id_Articulo,Cantidad) values(" + pIdCLiente + "," + pItem.Articulo.Id + "," + pItem.Cantidad + ");");

        }
        public List<Item> ListaCarrito(int pIdCliente)
        {
            string consulta = " Select cc.* from CarritoCompras cc, Clientes c where cc.Id_Cliente = c.Id_Cliente and cc.Id_Cliente =" + pIdCliente;
            List<Item> ListadodeItems = new List<Item>();

            DataSet datos = Conexion.Instancia.InicializarSeleccion(consulta);

            if (datos.Tables[0].Rows.Count > 0)
            {
                DataRowCollection tabla = datos.Tables[0].Rows;

                foreach (DataRow row in tabla)
                {
                    Dominio.Item unItem = new Item();
                    object[] elementos = row.ItemArray;

                    int idArticulo = int.Parse(elementos[1].ToString());
                    Dominio.Instrumento unInstrumento = Controladora.Instancia.BuscarInstrumento(idArticulo);
                    Dominio.Accesorio unAccesorio = Controladora.Instancia.BuscarAccesorio(idArticulo);

                    if (unInstrumento == null)
                    {
                        unItem.Articulo = unAccesorio;

                    }
                    else
                    {
                        unItem.Articulo = unInstrumento;
                    }
                    unItem.Cantidad = int.Parse(elementos[3].ToString());
                    ListadodeItems.Add(unItem);
                }
                return ListadodeItems;
            }
            return ListadodeItems;
        }

        public bool EliminarCarrito(int pIdCliente)
        {
            return Conexion.Instancia.InicializarConsulta("delete from CarritoCompras where Id_Cliente=" + pIdCliente);
        }

       }
    }    
