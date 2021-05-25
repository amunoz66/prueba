using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DashboardMVC.ControlesUsuario
{
    public partial class GraficoUC : UserControl
    {
        public GraficoUC()
        {
            InitializeComponent();
        }
        public GraficoUC(int[] empresa1, int[] empresa2, String comercial)
        {
            InitializeComponent();

            Series series1 = new Series("Empresa 1");
            series1.Points.DataBindY(empresa1);
            series1.ChartType = SeriesChartType.Column;

            Series series2 = new Series("Empresa 2");
            series2.Points.DataBindY(empresa2);
            series2.ChartType = SeriesChartType.Column;

            // añade las series al chart
            chart1.Series.Clear();
            chart1.Series.Add(series1);
            chart1.Series.Add(series2);
            chart1.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(251))))); ;
            
            // Muestra las etiquetas de datos
            series1.IsValueShownAsLabel = true;
            series2.IsValueShownAsLabel = true;

            chart1.ChartAreas[0].AxisX.Title = "Datos mensuales de ventas de " + comercial;

        }

    }
}
