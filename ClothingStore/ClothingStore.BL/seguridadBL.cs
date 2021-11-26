using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BL
{
    public class seguridadBL
    {
        Contexto _Contexto;
        public List<Usuario> ListadeUsuarios { get; set; }


        public seguridadBL()
        {
            _Contexto = new Contexto();
            ListadeUsuarios = new List<Usuario>();

        }
        public List<Usuario> ObtenerUsuarios()
        {
            ListadeUsuarios = _Contexto.Usuarios
                .ToList();

            return ListadeUsuarios;

        }


        public bool Autorizar(string nombreUsuario, string contrasena)

        {
            
            var contrasenaEncriptada = Encriptar.CodificarContrasena(contrasena);
            var usuarios = _Contexto.Usuarios.ToList()
                .FirstOrDefault(r => r.Nombre == nombreUsuario &&
                r.Contrasena == contrasenaEncriptada);

            if (usuarios != null)
            {
                return true;
            }
            return false;
        }
        

    }

    public static class Encriptar
    {
        public static string CodificarContrasena(string contrasena)
        {
            var salt = "UNAH";

            byte[] bIn = Encoding.Unicode.GetBytes(contrasena);
            byte[] bSalt = Convert.FromBase64String(salt);
            byte[] bAll = new byte[bSalt.Length + bIn.Length];

            Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length);
            Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length);
            HashAlgorithm s = HashAlgorithm.Create("SHA512");
            byte[] bRet = s.ComputeHash(bAll);

            return Convert.ToBase64String(bRet);
        }
    }
}
