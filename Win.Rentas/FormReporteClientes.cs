﻿using BL.Rentas;
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
    public partial class FormReporteClientes : Form
    {
        public FormReporteClientes()
        {
            InitializeComponent();
             var _clientesBL = new ClientesBL();
             var bindingSource = new BindingSource();
             bindingSource.DataSource = _clientesBL.ObtenerClientes();

             var reporte = new ReporteClientes();
             reporte.SetDataSource(bindingSource);

             crystalReportViewer1.ReportSource = reporte;
             crystalReportViewer1.RefreshReport();

            /*var _clientesBL = new ClientesBL();
            var bindingSourceClientes = new BindingSource();
            bindingSourceClientes.DataSource = _clientesBL.ObtenerClientes();
            var _ciudadBL = new CiudadBL();
            var bindingSourceCiudad = new BindingSource();
            bindingSourceCiudad.DataSource = _ciudadBL.ObtenerCategorias();

            var reporte = new ReporteClientes();
            reporte.Database.Tables[0].SetDataSource(bindingSourceClientes.DataSource);
            reporte.Database.Tables[1].SetDataSource(bindingSourceCiudad.DataSource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();*/


        }
    }
}
