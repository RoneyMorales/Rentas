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
    public partial class FormReporteCompras : Form
    {
        ComprasBL _comprasBL;
        public FormReporteCompras()
        {
           
            InitializeComponent();
           
            _comprasBL= new ComprasBL();
           /*var bindingSource = new BindingSource();
           bindingSource.DataSource = _compraBL.ObtenerCompras();


           var reporte = new ReporteCompras();
             reporte.SetDataSource(bindingSource);


             crystalReportViewer1.ReportSource = reporte;
           crystalReportViewer1.RefreshReport();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fechainicial = dateTimePicker1.Value;
            var fechafinal = dateTimePicker2.Value;

            var bindingSource = new BindingSource();
            bindingSource.DataSource = _comprasBL.ObtenerCompras(fechainicial, fechafinal);

            var reporte = new ReporteCompras();
            reporte.SetDataSource(bindingSource);


            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
