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
    public partial class ComercialesUC : UserControl
    {
        public ComercialesUC()
        {
            InitializeComponent();
        }
        public ComercialesUC(String nombre, String ciudad, String edad, String comElegido)
        {
            InitializeComponent();

            label1.Text = nombre;
            label2.Text = ciudad;
            label3.Text = edad;

            String imagen = "../avatar" + comElegido + ".png";
            pictureBox1.Image = Image.FromFile(@imagen);
        }
    }
}
