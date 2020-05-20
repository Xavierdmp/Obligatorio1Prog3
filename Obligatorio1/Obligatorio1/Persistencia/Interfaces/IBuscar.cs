using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1.Persistencia.Interfaces
{
    interface IBuscar<T>
    {
        bool ComprobarExistencia(string pTexto);

        T Buscar(int pId); /* Esto es lo que hace el programa no como lo hace */
            

            
        }
   }

