using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoDev.Modelos
{
     class Medicamento
    {
        public int     NumeroColumna { set; get; }
        public int     IIDMEDICAMENTO { set; get; }
        public string  NOMBRE { set; get; }
        public string  CONCENTRACION { set; get; }
        public int     IIDFORMAFARMACEUTICA { set; get; }
        public string  NOMBREFORMAFARMACEUTICA { set; get; }
        public double  PRECIO { set; get; }
        public int     STOCK { set; get; }
        public string  PRESENTACION { set; get; }
        public int     BHABILITADO { set; get; }
        public string  HABILITADO { set; get; }
    }
}
