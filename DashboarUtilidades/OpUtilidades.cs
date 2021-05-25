using DashboardUtilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DashboardUtilidades
{
    public class OpUtilidades
    {
        public OpUtilidades()
        {

        }


        public String[] BuscarDatos(String[,] arrayComerciales, String comElegido)
        {
            String[] datosPersonales = new String[arrayComerciales.GetLength(1)];
            for (int i = 1; i < arrayComerciales.GetLength(0); i++)
            {
                if (arrayComerciales[i, 0].Equals(comElegido))
                {
                    for (int j = 0; j < arrayComerciales.GetLength(1); j++)
                    {
                        datosPersonales[j] = arrayComerciales[i, j];
                    }
                }
            }
            return datosPersonales;
        }

        public int[] BuscarFacturacion(String[,] arrayVentas, String comElegido)
        {
           // datosFacturacion = new String[2];
            int ventas1 = 0;
            int ventas2 = 0;

            for (int i = 1; i < arrayVentas.GetLength(0); i++)
            {
                if (arrayVentas[i, 0].Equals(comElegido))
                {
                    for (int j = 0; j < arrayVentas.GetLength(1)-2; j++)
                    {
                        if (arrayVentas[i, 1].Equals("1")){
                            ventas1 = ventas1 + int.Parse(arrayVentas[i, j + 2]);
                        }else if (arrayVentas[i, 1].Equals("2"))
                        {
                            ventas2 = ventas2 + int.Parse(arrayVentas[i, j + 2]);
                        }
                    }
                }
            }
            int[] datosFacturacion = { ventas1,ventas2};
            return datosFacturacion;
        }

        public int[] CrearSeriesGrafico(String[,] arrayVentas, String numEmpresa, String comElegido)
        {
            int[] serie = new int[12];

            for (int i = 1; i < arrayVentas.GetLength(0); i++)
            {
                if (arrayVentas[i, 0].Equals(comElegido))
                {
                    for (int j = 0; j < arrayVentas.GetLength(1) - 2; j++)
                    {
                        if (arrayVentas[i, 1].Equals(numEmpresa))
                        {
                            serie[j] = int.Parse(arrayVentas[i, j + 2]);
                        }
                    }
                }
            }
            return serie;
        }
    }
}
