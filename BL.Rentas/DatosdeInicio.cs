using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.Contrasena = "123";
            usuarioAdmin.PuedeVerProductos = true;
            usuarioAdmin.PuedeVerClientes = true;
           // usuarioAdmin.PuedeVerRentas = true;
            usuarioAdmin.PuedeVerProveedores = true;
            usuarioAdmin.PuedeVerCompras = true;
            usuarioAdmin.PuedeVerFacturas = true;

            usuarioAdmin.PuedeVerReportes = true;
            contexto.Usuarios.Add(usuarioAdmin);


            var usuario1 = new Usuario();
            usuario1.Nombre = "usuario";
            usuario1.Contrasena = "456";
            usuario1.PuedeVerProductos = true;
            usuario1.PuedeVerClientes = true;
            //usuario1.PuedeVerRentas = true;
            usuario1.PuedeVerProveedores = false;
            usuario1.PuedeVerCompras =false;
            usuario1.PuedeVerFacturas = false;

            usuario1.PuedeVerReportes = false;

            contexto.Usuarios.Add(usuario1);



            var ciudad1 = new Ciudad();
            ciudad1.Descripcion = "SPS";
            contexto.Ciudad.Add(ciudad1);

            var ciudad2 = new Ciudad();
            ciudad2.Descripcion = "El Progreso";
            contexto.Ciudad.Add(ciudad2);

            var ciudad3 = new Ciudad();
            ciudad3.Descripcion = "La Lima";
            contexto.Ciudad.Add(ciudad3);

            var ciudad4 = new Ciudad();
            ciudad4.Descripcion = "Santa Rita";
            contexto.Ciudad.Add(ciudad4);

            /*  var cliente2 = new Cliente();
              cliente2.Nombre = "Tony Stark";
              contexto.Clientes.Add(cliente2);*/

            var categoria1 = new Categoria();
            categoria1.Descripcion = "Acción y Aventura";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Deportes";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Disparo";
            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria4.Descripcion = "Educativos";
            contexto.Categorias.Add(categoria4);

            var tipo1 = new Tipo();
            tipo1.Descripcion = "Consolas";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Video Juegos";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Accesorios";
            contexto.Tipos.Add(tipo3);


            base.Seed(contexto);
        }
    }
}
