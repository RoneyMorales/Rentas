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
        public FormReporteCompras()
        {
            InitializeComponent();
            var _compraBL= new ComprasBL();
          var bindingSource = new BindingSource();
          bindingSource.DataSource = _compraBL.ObtenerCompras();

       
          var reporte = new ReporteCompras();
            reporte.SetDataSource(bindingSource);


            crystalReportViewer1.ReportSource = reporte;
          crystalReportViewer1.RefreshReport();
        }
    }
}
