﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Dominio.Intefaces;
namespace Obligatorio1.Dominio.Controladoras
{
    public class ControladoraInstrumentos : IABMLBC<Instrumento>
    {
        public bool Alta(Instrumento pInstrumentos)
        {
            if (!this.ComprobarExistencia(pInstrumentos.Nombre))
            {
                return Persistencia.Controladora.Instancia.AltaInstrumento(pInstrumentos);
            }
            return false;
        }

        public bool Baja(int pId)
        {
            return Persistencia.Controladora.Instancia.BajaInstrumento(pId);
        }

        public Instrumento Buscar(int pId)
        {
            return Persistencia.Controladora.Instancia.BuscarInstrumento(pId);
        }

        public bool ComprobarExistencia(string pNombre)
        {
            return Persistencia.Controladora.Instancia.ComprobarExistenciaInstrumento(pNombre);
        }

        public List<Instrumento> Listar()
        {
            return Persistencia.Controladora.Instancia.ListarInstrumentos();
        }

        public bool Modificar(Instrumento pT)
        {
            return Persistencia.Controladora.Instancia.ModificarInstrumento(pT);
        }

        public List<FotosAdicionales> ListarFotosAdicionalesParaInstrumento(int pId)
        {
            return Persistencia.Controladora.Instancia.FotosAdicionalesDadoInstrumento(pId);
        }

        public List<Color> ListarColoresParaInstrumento(int pId)
        {
            return Persistencia.Controladora.Instancia.ColoresDadoInstrumento(pId);
        }
    }
}