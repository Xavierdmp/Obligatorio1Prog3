using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio1.Dominio;
namespace Obligatorio1.Persistencia
{
    public class Controladora
    {
        private static Controladora _instancia;

        public static Controladora Instancia
        {
            get {
                if (_instancia == null)
                {
                    _instancia = new Controladora();
                }
                return _instancia;
            }
        }


        #region "Fabricante"

        public bool ComprobarExistenciaFabricante(string pNombre)
        {
            return pFabricante.Instancia.ComprobarExistencia(pNombre);
        }
        public Fabricante BuscarFabricante(int pId)
        {
            return pFabricante.Instancia.Buscar(pId);
        }
        public bool AltaFabricante(Fabricante pFabri)
        {
            return pFabricante.Instancia.Alta(pFabri);
        }
        public bool BajaFabricante(int pId)
        {
            return pFabricante.Instancia.Baja(pId);
        }
        public bool ModificarFabricante(Fabricante pFabricantes)
        {
            return pFabricante.Instancia.Modificar(pFabricantes);
        }
        public List<Fabricante> ListarFabricantes()
        {
            return pFabricante.Instancia.Listar();
        }
        #endregion

        #region "Tipos"
        public bool ComprobarExistenciaTipo(string pNombre)
        {
            return pTipo.Instancia.ComprobarExistencia(pNombre);
        }
        public Tipo BuscarTipo(int pid)
        {
            return pTipo.Instancia.Buscar(pid);
        }
        public bool AltaTipo(Tipo pTipos)
        {
            return pTipo.Instancia.Alta(pTipos);
        }
        public bool BajaTipo(int pId)
        {
            return pTipo.Instancia.Baja(pId);
        }
        public bool ModificarTipo(Tipo pTipos)
        {
            return pTipo.Instancia.Modificar(pTipos);
        }
        public List<Tipo> ListarTipo()
        {
            return pTipo.Instancia.Listar();
        }
        #endregion

        #region "SubTipos"
        public bool ComprobarExistenciaSubTipo(string pNombre)
        {
            return pSubTipo.Instancia.ComprobarExistencia(pNombre);
        }
        public SubTipo BuscarSubTipo(int pId)
        {
            return pSubTipo.Instancia.Buscar(pId);
        }
        public bool AltaSubTipo(SubTipo pSubtipo)
        {
            return pSubTipo.Instancia.Alta(pSubtipo);
        }
        public bool BajaSubTipo(int pId)
        {
            return pSubTipo.Instancia.Baja(pId);
        }
        public bool ModificarSubTipo(SubTipo pSubtipo)
        {
            return pSubTipo.Instancia.Modificar(pSubtipo);
        }

        public List<SubTipo> ListarSubtipos()
        {
            return pSubTipo.Instancia.Listar();
        }
        #endregion

        #region "Administradores"

        public bool ComprobarExistenciaAdmin(string pCorreo)
        {
            return pAdministrador.Instancia.ComprobarExistencia(pCorreo);
        }

        public Administrador BuscarAdministrador(int pId)
        {
            return pAdministrador.Instancia.Buscar(pId);
        }

        public bool AltaAdministradores(Administrador pAdmin)
        {
            return pAdministrador.Instancia.Alta(pAdmin);
        }
        public bool BajaAdministrador(int pId)
        {
            return pAdministrador.Instancia.Baja(pId);
        }
        public bool ModificarAdministrador(Administrador pAdmin)
        {
            return pAdministrador.Instancia.Modificar(pAdmin);
        }
        public List<Administrador> ListarAdministradores()
        {
            return pAdministrador.Instancia.ListarAdministradores();
        }
        #endregion

        #region Clientes

        public bool ComprobarExisteCliente(string pCeduladeIdentidad)
        {
            return pCliente.Instancia.ComprobarExistencia(pCeduladeIdentidad);
        }

        public Cliente BuscarCliente(int pId)
        {
            return pCliente.Instancia.Buscar(pId);
        }

        public bool AltaCliente(Cliente pCli)
        {
            return pCliente.Instancia.Alta(pCli);
        }

        public bool BajaCliente(int pId)
        {
            return pCliente.Instancia.Baja(pId);

        }
        public bool ModificarCliente(Cliente pClie)
        {
            return pCliente.Instancia.Modificar(pClie);
        }
        public List<Cliente> ListarClientes()
        {
            return pCliente.Instancia.Listar();
        }

        #endregion

        #region "Iniciar Sesion"

        public int InciarSesionAdmin(string pCorreo,string pContraseña)
        {
            return pLogin.Instancia.IdAdministradorLogin(pCorreo, pContraseña);
        }
        public int InciarSesionCliente(string pCorreo, string pContraseña)
        {
            return pLogin.Instancia.IdClienteLogin(pCorreo, pContraseña);
        }

        #endregion
    }
}