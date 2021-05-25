using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashboardMVC.ControlesUsuario
{
    public partial class FacturacionUC : UserControl
    {
        public FacturacionUC()
        {
            InitializeComponent();
        }
        public FacturacionUC(int empresa1, int empresa2, String comElegido)
        {
            InitializeComponent();
            textBox1.Text = empresa1.ToString();
            textBox2.Text = empresa2.ToString();
            textBox3.Text = "Facturación realizada por " + comElegido;
        }

    }
}
