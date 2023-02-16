using RetoDev.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetoDev.Controladores
{
     class InterfazController
    {

        public static List<Medicamento> llenaDataGrid(int ultimoRegistro, string filtro )
        {
            List<FormaFarmaceutica> lff = FormaFarmaController.leerArchivo();
            List<Medicamento> lmed = MedicamentoController.leerArchivo(lff, ultimoRegistro, 5,filtro);
            return lmed;
        }

        public static int cuentaRegistros ()
        {
            return MedicamentoController.CuentaLineasTXT();
        }

        public static List<Medicamento> dameNombresMedicamento()
        {
            List<Medicamento> lmed = MedicamentoController.getNombreMedicamentos();
            return lmed;
        }

        public static List<FormaFarmaceutica> dameNombresFarmaceutica()
        {
            List<FormaFarmaceutica> lff = FormaFarmaController.getNombreFarmaceutica();
            return lff;
        }

        public static void nuevoRegistro(string NOMBREMEDICAMENTO, string CONCENTRACION,
                                    string NOMBREFORMAFARMACEUTICA, double PRECIO, int STOCK,
                                    string PRESENTACION, string Habilitado)
        {
            Medicamento med = new Medicamento();    
            MedicamentoController medC = new MedicamentoController();
            List<FormaFarmaceutica> lff = FormaFarmaController.getNombreFarmaceutica() ;
            med.NOMBRE = NOMBREMEDICAMENTO;
            med.CONCENTRACION = CONCENTRACION;
            med.IIDFORMAFARMACEUTICA = lff.Find(e => e.NOMBRE == NOMBREFORMAFARMACEUTICA).IIDFORMAFARMACEUTICA;
            med.PRECIO= PRECIO;
            med.STOCK= STOCK;
            med.PRESENTACION =PRESENTACION;
            med.BHABILITADO = Habilitado == "Activo" ? 1 : 0; 
            medC.nuevoMedicamento(med);
        }

        public static void editaRegistro(int NumeroColumna, string NOMBREMEDICAMENTO, string CONCENTRACION,
                                    string NOMBREFORMAFARMACEUTICA, double PRECIO, int STOCK,
                                    string PRESENTACION, string Habilitado)
        {

            Medicamento med = new Medicamento();
            MedicamentoController medC = new MedicamentoController();
            List<FormaFarmaceutica> lff = FormaFarmaController.getNombreFarmaceutica();
            med.NumeroColumna = NumeroColumna;
            med.NOMBRE = NOMBREMEDICAMENTO;
            med.CONCENTRACION = CONCENTRACION;
            med.IIDFORMAFARMACEUTICA = lff.Find(e => e.NOMBRE == NOMBREFORMAFARMACEUTICA).IIDFORMAFARMACEUTICA;
            med.PRECIO = PRECIO;
            med.STOCK = STOCK;
            med.PRESENTACION = PRESENTACION;
            med.BHABILITADO = Habilitado == "Activo" ? 1 : 0;
            MedicamentoController.editaMedicamento( med);
        }


        public static Medicamento toMedicamentoModel(DataTable table, int indice)
        {
            DataRow dr = table.Rows[indice];
            Medicamento med = new Medicamento();
            med.NumeroColumna = Int32.Parse(dr.ItemArray[0].ToString());
            med.IIDMEDICAMENTO = Int32.Parse(dr.ItemArray[1].ToString());
            med.NOMBRE = dr.ItemArray[2].ToString();
            med.CONCENTRACION = dr.ItemArray[3].ToString(); ;
            med.IIDFORMAFARMACEUTICA = Int32.Parse(dr.ItemArray[4].ToString());
            med.NOMBREFORMAFARMACEUTICA = dr.ItemArray[5].ToString();
            med.PRECIO = Double.Parse(dr.ItemArray[6].ToString());
            med.STOCK = Int32.Parse(dr.ItemArray[7].ToString());
            med.PRESENTACION = dr.ItemArray[8].ToString();
            med.BHABILITADO = Int32.Parse(dr.ItemArray[9].ToString());
            med.HABILITADO = dr.ItemArray[10].ToString();
            return med;

        }

        public static void eliminaRegistro(int id)
        {
            MedicamentoController.eliminaRegistro(id);
        }

    }
}
