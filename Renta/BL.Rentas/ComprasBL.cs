using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace BL.Rentas
{
    public class ComprasBL
    {
        Contexto _contexto;

        public BindingList<Compra> ListaCompras { get; set; }

        public ComprasBL()
        {
            _contexto = new Contexto();
        }

        public BindingList<Compra> ObtenerCompras()
        {
            _contexto.Compra.Include("CompraDetalle").Load();
            ListaCompras = _contexto.Compra.Local.ToBindingList();

            return ListaCompras;
        }
        public BindingList<Compra> ObtenerCompras(DateTime fechainicial, DateTime fechafinal)
        {
            _contexto.Compra.Include("CompraDetalle").Where(compra => compra.Fecha >= fechainicial
            && compra.Fecha <= fechafinal && compra.Activo == true).ToList();

            ListaCompras = _contexto.Compra.Local.ToBindingList();
            return ListaCompras;
        }
        public void AgregarCompra()
        {
            var nuevaCompra = new Compra();
            _contexto.Compra.Add(nuevaCompra);
        }

        public void AgregarCompraDetalle(Compra Compras)
        {
            if (Compras != null)
            {
                var nuevoDetalle = new CompraDetalle();
                Compras.CompraDetalle.Add(nuevoDetalle);
            }
        }

        public void RemoverCompraDetalle(Compra Compra, CompraDetalle CompraDetalle)
        {
            if (Compra != null && CompraDetalle != null)
            {
                Compra.CompraDetalle.Remove(CompraDetalle);
            }
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarCompra(Compra Compra)
        {
            var resultado = Validar(Compra);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            CalcularExistencia(Compra);

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }

        private void CalcularExistencia(Compra Compra)
        {
            foreach (var detalle in Compra.CompraDetalle)
            {
                var producto = _contexto.Productos.Find(detalle.ProductoId);
                if (producto != null)
                {
                    if (Compra.Activo == true)
                    {
                        producto.Existencia = producto.Existencia + detalle.Cantidad;
                    }
                   else
                    {
                        producto.Existencia = producto.Existencia - detalle.Cantidad;
                    }
                }
            }
        }

        private Resultado Validar(Compra Compra)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (Compra == null)
            {
                resultado.Mensaje = "Agregue una Compra para poderla salvar";
                resultado.Exitoso = false;

                return resultado;
            }

            if (Compra.Id != 0 && Compra.Activo == true)
            {
                resultado.Mensaje = "La compra ya fue realizada, no se pueden realizar cambios en ella";
                resultado.Exitoso = false;
            }

            if (Compra.Activo == false)
            {
                resultado.Mensaje = "La compra sta anulada y no se pueden realizar cambios en ella";
                resultado.Exitoso = false;
            }

            if (Compra.ProveedorID == 0)
            {
                resultado.Mensaje = "Seleccione un Proveedor";
                resultado.Exitoso = false;
            }

            if (Compra.CompraDetalle.Count == 0)
            {
                resultado.Mensaje = "Agregue productos a la compra";
                resultado.Exitoso = false;
            }

            foreach (var detalle in Compra.CompraDetalle)
            {
                if (detalle.ProductoId == 0)
                {
                    resultado.Mensaje = "Seleccione productos validos";
                    resultado.Exitoso = false;
                }
            }


            return resultado;
        }

        public void CalcularCompra(Compra Compra)
        {
            if (Compra != null)
            {
                double subtotal = 0;

                foreach (var detalle in Compra.CompraDetalle)
                {
                    var producto = _contexto.Productos.Find(detalle.ProductoId);
                    if (producto != null)
                    {
                        detalle.Precio = producto.Precio;
                        detalle.Total = detalle.Cantidad * producto.Precio;

                        subtotal += detalle.Total;
                    }
                }

                Compra.Subtotal = subtotal;
                Compra.Impuesto = subtotal * 0.15;
                Compra.Total = subtotal + Compra.Impuesto;
            }
        }

        public bool AnularCompra(int id)
        {
            foreach (var Compra in ListaCompras)
            {
                if (Compra.Id == id)
                {
                    Compra.Activo = false;

                    CalcularExistencia(Compra);

                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        //Actualizar Formulario
        public void RefrescarDatos(int CompraiD)
        {
            var compra = _contexto.Proveedor.Find(CompraiD);
            if (compra != null)
            {
                _contexto.Entry(compra).Reload();
            }
        }

    }

    public class Compra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ProveedorID { get; set; }
        public Proveedor Proveedor { get; set; }
        public BindingList<CompraDetalle> CompraDetalle { get; set; }
        public double Subtotal { get; set; }
        public double Impuesto { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }

        public Compra()
        {
            Fecha = DateTime.Now;
            CompraDetalle = new BindingList<CompraDetalle>();
            Activo = true;
        }
    }

    public class CompraDetalle
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }

        public CompraDetalle()
        {
            Cantidad = 1;
        }
    }

}

