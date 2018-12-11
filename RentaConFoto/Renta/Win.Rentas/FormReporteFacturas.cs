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
    public partial class FormReporteFacturas : Form
    {
        FacturaBL _facturaBL;
        public FormReporteFacturas()
        {
            InitializeComponent();
             _facturaBL = new FacturaBL();
           /* var bindingSource = new BindingSource();
            bindingSource.DataSource = _facturaBL.ObtenerFacturas();


            var reporte = new ReporteFactura();
            reporte.SetDataSource(bindingSource);


            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // var _facturaBL = new FacturaBL();
           var fechainicial = dateTimePicker1.Value;
            var fechafinal = dateTimePicker2.Value;

            var bindingSource = new BindingSource();
            bindingSource.DataSource = _facturaBL.ObtenerFacturas(fechainicial, fechafinal);

            var reporte = new ReporteFactura();
            reporte.SetDataSource(bindingSource);


            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
