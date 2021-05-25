using System;
using System.Collections.Generic;
using System.Text;

namespace DashboardUtilidades
{
    public class DashboardVO
    {
        private String fileComerciales;
        private String fileVentas;

        public DashboardVO(string fileComerciales, string fileVentas)
        {
            this.fileComerciales = fileComerciales;
            this.fileVentas = fileVentas;
        }

        public string FileComerciales { get => fileComerciales; set => fileComerciales = value; }
        public string FileVentas { get => fileVentas; set => fileVentas = value; }
    }
}
