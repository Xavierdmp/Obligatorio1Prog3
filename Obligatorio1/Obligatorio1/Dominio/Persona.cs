using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Obligatorio1.Dominio
{
    public abstract class Persona
    {
        private int _id;
        private string _correoElectronico;
        private string _contraseña;
        private string _key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string CorreoElectronico
        {
            get { return _correoElectronico; }
            set { _correoElectronico = value; }
        }
        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        public Persona(string pCorreo, string pContraseña)
        {
            this.CorreoElectronico = pCorreo;
            this.Contraseña = this.Ecriptar(pContraseña,_key);
        }
        public Persona()
        {

        }
        
        private string Ecriptar(string pPass, string pClave)
        {
            byte[] KeyArray;
            byte[] encriptar = Encoding.UTF8.GetBytes(pPass);
            KeyArray = Encoding.UTF8.GetBytes(pClave);

            var tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = KeyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform Transform = tdes.CreateEncryptor();
            byte[] resultado = Transform.TransformFinalBlock(encriptar, 0, encriptar.Length);
            tdes.Clear();

            return Convert.ToBase64String(resultado, 0, resultado.Length);
        }

    }
}