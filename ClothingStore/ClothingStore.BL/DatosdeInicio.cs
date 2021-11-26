using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BL
{
    public class DatosdeInicio: CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var nuevoUsuario = new Usuario();
            nuevoUsuario.Nombre = "Admin";
            nuevoUsuario.Contrasena = Encriptar.CodificarContrasena("123");

            contexto.Usuarios.Add(nuevoUsuario);
           

            var nuevoUsuario2 = new Usuario();
            nuevoUsuario2.Nombre = "Arleth";
            nuevoUsuario2.Contrasena = Encriptar.CodificarContrasena("456");

            contexto.Usuarios.Add(nuevoUsuario2);
           

            var nuevoUsuario3 = new Usuario();
            nuevoUsuario3.Nombre = "Kevin";
            nuevoUsuario3.Contrasena = Encriptar.CodificarContrasena("789");

            contexto.Usuarios.Add(nuevoUsuario3);

            base.Seed(contexto);
        }
    }
}
