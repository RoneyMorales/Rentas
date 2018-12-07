using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace BL.Rentas
{
    public class ProductosBL
    {
        contexto _contexto;
        public BindingList<Producto> ListaProductos { get; set; }

        public ProductosBL()
        {
            _contexto = new contexto();
            ListaProductos = new BindingList<Producto>();

            
        }

       public BindingList<Producto> ObtenerProductos()
        {
            _contexto.Productos.Load();
            ListaProductos = _contexto.Productos.Local.ToBindingList();
            return ListaProductos;
        }

        //Funcion de busqueda

        public BindingList<Producto> Obtenerproductos(string descripcion)
        {
            _contexto.Productos.Where(producto=> producto.Descripcion.Contains(descripcion) == true).ToList();
            ListaProductos = _contexto.Productos.Local.ToBindingList();
            return ListaProductos;
        }
       
        //
     
        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarProducto(Producto producto)
        {
            var resultado = Validar(producto);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarProducto()
        {
            var nuevoProducto = new Producto();
            ListaProductos.Add(nuevoProducto);
        }

        public bool EliminarProducto(int id)
        {
            foreach (var producto in ListaProductos)
            {
                if (producto.Id == id)
                {
                    ListaProductos.Remove(producto);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Resultado Validar(Producto producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if(producto == null)
            {
                resultado.Mensaje = "Agregue producto valido";
                resultado.Exitoso = false;
                return resultado;
            }

            if (string.IsNullOrEmpty(producto.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripción";
                resultado.Exitoso = false;
            }

            if (producto.Existencia < 0)
            {
                resultado.Mensaje = "La existencia debe ser mayor que cero";
                resultado.Exitoso = false;
            }

            if (producto.Precio < 0)
            {
                resultado.Mensaje = "El precio debe ser mayor que cero";
                resultado.Exitoso = false;
            }

            return resultado;
        }

        //Actualizar Formulario
        public void RefrescarDatos(int productoId)
        {
            var producto = _contexto.Productos.Find(productoId);
            if (producto != null)
            {
                _contexto.Entry(producto).Reload();
            }
        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public byte Foto { get; set; }
        public bool Activo { get; set; }
    }

  


}
