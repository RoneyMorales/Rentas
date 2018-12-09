using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ProveedoresBL
    {
        Contexto _contexto;
        public BindingList<Proveedor> ListaProveedores { get; set; }

        public ProveedoresBL()
        {
            _contexto = new Contexto();
            ListaProveedores = new BindingList<Proveedor>();


        }

        public BindingList<Proveedor> ObtenerProveedor()
        {
            _contexto.Proveedor.Load();
            ListaProveedores = _contexto.Proveedor.Local.ToBindingList();

            return ListaProveedores;
        }

        public bool GuardarProveedor(Proveedor proveedor)
        {
            if (proveedor.ID == 0)
            {
                proveedor.ID = ListaProveedores.Max(item => item.ID) + 1;
            }

            _contexto.SaveChanges();
            return true;

        }

        public object GuardarProveedor(Producto proveedores)
        {
            throw new NotImplementedException();
        }

        public void AgregarProveedor()
        {
            var nuevoProveedor = new Proveedor();
            ListaProveedores.Add(nuevoProveedor);
        }

        public bool EliminarProveedor(int ID)
        {
            foreach (var proveedor in ListaProveedores.ToList())
            {
                if (proveedor.ID == ID)
                {
                    ListaProveedores.Remove(proveedor);
                    _contexto.SaveChanges();
                    return true;
                }
            }
             return false;
         }
            /*foreach (var proveedor in ListaProveedores)
            {
                if (proveedor.ID == ID)
                {
                    ListaProveedores.Remove(proveedor);
                    _contexto.SaveChanges();
                    return true;
                }*/
            }

            //return false;
        }


        public class Proveedor
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
            public string Correo { get; set; }
            public bool Activo { get; set; }
        }
    

