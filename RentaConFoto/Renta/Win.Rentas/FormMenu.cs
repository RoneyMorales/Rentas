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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login();
        }
        public void Autorizar(Usuario usuario)
        {
            productosToolStripMenuItem.Enabled = usuario.PuedeVerProductos;
            clientesToolStripMenuItem.Enabled = usuario.PuedeVerClientes;
            //rentarToolStripMenuItem.Enabled = usuario.PuedeVerRentas;
            proveedoresToolStripMenuItem.Enabled = usuario.PuedeVerProveedores;
            compraToolStripMenuItem.Enabled = usuario.PuedeVerCompras;
            facturaToolStripMenuItem.Enabled = usuario.PuedeVerFacturas;
          
            reportesToolStripMenuItem.Enabled = usuario.PuedeVerReportes;

        }

        private void Login()
        {
            var formLogin = new FormLogin();
            formLogin.MenuPrincipal = this;
            formLogin.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProductos = new FormProductos();
            formProductos.MdiParent = this;
            formProductos.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formClientes = new FormClientes();
            formClientes.MdiParent = this;
            formClientes.Show();
        }

       /* private void rentarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formRentas = new FormRentas();
            formRentas.MdiParent = this;
            formRentas.Show();
        }*/

        private void FormMenu_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormProveedores = new FormProveedores();
            FormProveedores.MdiParent = this;
            FormProveedores.Show();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormCompra = new FormCompra();
            FormCompra.MdiParent = this;
            FormCompra.Show();
        }

        private void reporteDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormReporteProductos = new FormReporteProductos();
            FormReporteProductos.MdiParent = this;
            FormReporteProductos.Show();
        }

        private void reporteDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormReporteProveedores = new FormReporteProveedores();
            FormReporteProveedores.MdiParent = this;
            FormReporteProveedores.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormFactura = new FormFactura();
            FormFactura.MdiParent = this;
            FormFactura.Show();
        }

        private void reporteDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormReporteClientes = new FormReporteClientes();
            FormReporteClientes.MdiParent = this;
            FormReporteClientes.Show();
        }
    }
}
