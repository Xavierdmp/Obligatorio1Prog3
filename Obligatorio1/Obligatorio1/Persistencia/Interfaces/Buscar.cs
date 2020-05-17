using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1.Persistencia.Interfaces
{
    interface Buscar<T>
    {
        bool ComprobarExistencia(string pTexto);
        T Buscar(int pId);
    }
}
