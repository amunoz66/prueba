using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DashboardUtilidades;
using DashboardBLL;
using DashboardMVC.ControlesUsuario;


namespace DashboardMVC
{
    public partial class Form1 : Form
    {
        private String fileComerciales;
        private String fileVentas;
        private String comElegido;
        private String[] nombres;

        private String[,] arrayComerciales;
        private String[,] arrayVentas;
        private String com1;
        private String com2;
        private String com3;

        private TableLayoutPanel tlp;
        private UserControl comercialesUC;
        private UserControl facturacionUC;
        private UserControl graficoUC;

        public Form1()
        {
            InitializeComponent();

            fileComerciales = "1_datos_comerciales.csv";
            fileVentas = "2_facturacion_comercial.csv";
            comElegido = "";
            tlp = tlP0;

            // Crea objeto VO
            DashboardVO dashboardVO = new DashboardVO(fileComerciales, fileVentas);


            //Crea objeto BLL para procesarlo y crear los arrays de datos
            OperacionesBLL operacionesBLL = new OperacionesBLL(dashboardVO);
            arrayComerciales = operacionesBLL.CrearArrayComerciales(dashboardVO);
            arrayVentas = operacionesBLL.CrearArrayVentas(dashboardVO);

            // Rellena datos del panel superior con los nombres de los comerciales
            com1 = arrayComerciales[1, 1] + " " + arrayComerciales[1, 2];
            com2 = arrayComerciales[2, 1] + " " + arrayComerciales[2, 2];
            com3 = arrayComerciales[3, 1] + " " + arrayComerciales[3, 2];
            nombres = new String[]{com1,com2,com3};
            btCom1.Text = nombres[0];
            btCom2.Text = nombres[1]; 
            btCom3.Text = nombres[2];
            label_titulo.Text = "Selecciona un comercial";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!comElegido.Equals(""))
            {
                OperacionesBLL opBLL = new OperacionesBLL();
                //El objeto BLL llamará a un objeto OpUtilidades y devolverá un array con los datos del comercial
                String[] datos = opBLL.datosPersonales(arrayComerciales, comElegido);
                // Inicializamos objeto ComercialesUC que procesa los datos y los escribe en el UC
                comercialesUC = new ComercialesUC(datos[1] + datos[2], datos[3], datos[4] + " años", comElegido);
                limpiarUC();
                tlp.Controls.Add(comercialesUC,1,1);
            }
        }
        // Método que muestra los datos de ventas de ambas empresas por comercial
        // Evalua cuál es el comercial seleccionado y crea un array con los datos de ventas
        private void button2_Click(object sender, EventArgs e)
        {
            if (!comElegido.Equals(""))
            {
                OperacionesBLL opBLL = new OperacionesBLL();
                // int array con los datos de facturación del comercial seleccionado
                int[] datos = opBLL.datosFacturacion(arrayVentas, comElegido);
                // Variable que recoge el nombre del comercial
                String nombreComercial = nombres[int.Parse(comElegido)-1];
                // Objeto UC que dibuja los datos
                facturacionUC = new FacturacionUC(datos[0], datos[1], nombreComercial);

                limpiarUC();
                // Cargamos el User Control
                tlp.Controls.Add(facturacionUC, 1, 1);
            }
        }

        // Método que muestra las gráficas para cada empresa y las muestra en el UC
        private void button3_Click(object sender, EventArgs e)
        {
            if (!comElegido.Equals(""))
            {
                OperacionesBLL opBLL = new OperacionesBLL();
                // 2 arrays que recogen las series de datos para cada empresa y el comercial elegido
                int[] serie1 = opBLL.CrearSeries(arrayVentas, "1", comElegido);
                int[] serie2 = opBLL.CrearSeries(arrayVentas, "2", comElegido);
                // Variable que recoge el nombre del comercial
                String nombreComercial = nombres[int.Parse(comElegido) - 1];
                // Crea objeto UC con los datos de cada serie
                graficoUC = new GraficoUC(serie1, serie2, nombres[int.Parse(comElegido) - 1]);

                limpiarUC();
                // Carga el user control
                tlp.Controls.Add(graficoUC, 1, 1);
            }
            
        }

        //Metodo que borra los UC que estén cargados
        private void limpiarUC()
        {
            tlp.Controls.Remove(comercialesUC);
            tlp.Controls.Remove(facturacionUC);
            tlp.Controls.Remove(graficoUC);
        }

        // Métodos que evalúan el comercial elegido
        private void btCom1_Click(object sender, EventArgs e)
        {
            comElegido = "1";
            limpiarUC();
            label_titulo.Text = "Comercial: " + nombres[int.Parse(comElegido) - 1];
        }

        private void btCom2_Click(object sender, EventArgs e)
        {
            comElegido = "2";
            limpiarUC();
            label_titulo.Text = "Comercial: " + nombres[int.Parse(comElegido) - 1];
        }

        private void btCom3_Click(object sender, EventArgs e)
        {
            comElegido = "3";
            limpiarUC();
            label_titulo.Text = "Comercial: " + nombres[int.Parse(comElegido) - 1];
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            limpiarUC();
            label_titulo.Text = "Selecciona un comercial";
            comElegido = "";
        }
    }
}
