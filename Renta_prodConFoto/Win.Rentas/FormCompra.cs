using BL.Rentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Rentas
{
    public partial class FormCompra : Form
    {
        ComprasBL _comprasBL;
        ProveedoresBL _proveedorBL;
        ProductosBL _productosBL;
        public FormCompra()
        {
            InitializeComponent();

            _comprasBL = new ComprasBL();
            listaComprasBindingSource.DataSource = _comprasBL.ObtenerCompras();

            _proveedorBL = new ProveedoresBL();
            listaProveedoresBindingSource.DataSource = _proveedorBL.ObtenerProveedor();

            _productosBL = new ProductosBL();
            listaProductosBindingSource.DataSource = _productosBL.ObtenerProductos();

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _comprasBL.AgregarCompra();
            listaComprasBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);

        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;
        }

        private void listaComprasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaComprasBindingSource.EndEdit();

            var compra = (Compra)listaComprasBindingSource.Current;
            var resultado = _comprasBL.GuardarCompra(compra);

            if (resultado.Exitoso == true)
            {
                listaComprasBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Compra Guardada");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            _comprasBL.CancelarCambios();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var compra = (Compra)listaComprasBindingSource.Current;
            _comprasBL.AgregarCompraDetalle(compra);
            DeshabilitarHabilitarBotones(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var compra = (Compra)listaComprasBindingSource.Current;
            var compradetalle = (CompraDetalle)compraDetalleBindingSource.Current;

            _comprasBL.RemoverCompraDetalle(compra, compradetalle);

            DeshabilitarHabilitarBotones(false);
        }

        private void compraDetalleDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void compraDetalleDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var compra = (Compra)listaComprasBindingSource.Current;
            _comprasBL.CalcularCompra(compra);

            listaComprasBindingSource.ResetBindings(false);

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea anular esta factura", "Anular", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var Id = Convert.ToInt32(idTextBox.Text);
                    Anular(Id);
                }
            }
        }
        private void Anular(int Id)
        {
            var resultado = _comprasBL.AnularCompra(Id);
            if (resultado == true)
            {
                listaComprasBindingSource.ResetBindings(false);

            }
            else
            {
                MessageBox.Show("Ocurrio un error al anular la compra");
            }
        }

        private void listaComprasBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var compra = (Compra)listaComprasBindingSource.Current;
            if (compra != null && compra.Id !=0 && compra.Activo == false)
            {
                label1.Visible = true;

            }
            else
            {
                label1.Visible = false;
            }
        }
// Actualizar Lista de Proveedores y lista de Productos en FORMULARIO COMPRAS
        private void Refresh_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var CompraiD = Convert.ToInt32(idTextBox.Text);
               _comprasBL.RefrescarDatos(CompraiD);

            
               // _comprasBL = new ComprasBL();
               // listaComprasBindingSource.DataSource = _comprasBL.ObtenerCompras();

                _proveedorBL = new ProveedoresBL();
                listaProveedoresBindingSource.DataSource = _proveedorBL.ObtenerProveedor();
                listaProveedoresBindingSource.ResetBindings(false);
                _productosBL = new ProductosBL();
                listaProductosBindingSource.DataSource = _productosBL.ObtenerProductos();
                listaProductosBindingSource.ResetBindings(false);

            }
        }
    }
}
