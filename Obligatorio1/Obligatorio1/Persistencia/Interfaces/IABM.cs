using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1.Persistencia.Interfaces
{
    interface IABM<T> /*t es genera para todos los objetos*/
        {
        bool Alta(T pT); /*porque alta recibe un objeto*/ /*Primero objeto luego parametro*/ 
        bool Baja(int pId);
        bool Modificar(T pT);/*porque modificar tambien recibe un objeto*/







        }
}
