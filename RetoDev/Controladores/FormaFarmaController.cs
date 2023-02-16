using RetoDev.Modelos;
using RetoDev.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoDev.Controladores
{
    class FormaFarmaController
    {
        public static List<FormaFarmaceutica> leerArchivo()
        {
            String linea;
            List<FormaFarmaceutica> listaFormaFarmaceutica = new List<FormaFarmaceutica>();
            DataTable tableFormaFarma = new DataTable();
            string[] registroTXT;
            try
            {

                StreamReader sr = new StreamReader("C:\\Users\\Desarollos\\source\\repos\\RetoDev\\RetoDev\\Archivos\\FormaFarmaceutica.txt");
                linea = sr.ReadLine();
                int iteracion = 0;
                while (linea != null)
                {
                    registroTXT = linea.Split('|');
                    if (iteracion > 0)
                    {
                        FormaFarmaceutica ListaFarma = new FormaFarmaceutica();
                        ListaFarma.IIDFORMAFARMACEUTICA = Int32.Parse(registroTXT[0]);
                        ListaFarma.NOMBRE = registroTXT[1];
                        ListaFarma.BHABILITADO = Int32.Parse(registroTXT[2]);
                        listaFormaFarmaceutica.Add(ListaFarma);

                    }
                    linea = sr.ReadLine();
                    iteracion++;
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return listaFormaFarmaceutica;
        }


        public static List<FormaFarmaceutica> getNombreFarmaceutica()
        {
            String linea;
            List<FormaFarmaceutica> listaFormaFarmaceutica = new List<FormaFarmaceutica>();
            DataTable tableFormaFarma = new DataTable();
            string[] registroTXT;
            try
            {

                StreamReader sr = new StreamReader("C:\\Users\\Desarollos\\source\\repos\\RetoDev\\RetoDev\\Archivos\\FormaFarmaceutica.txt");
                linea = sr.ReadLine();
                int iteracion = 0;
                while (linea != null)
                {
                    registroTXT = linea.Split('|');
                    if (iteracion > 0)
                    {
                        FormaFarmaceutica ListaFarma = new FormaFarmaceutica();
                        ListaFarma.IIDFORMAFARMACEUTICA = Int32.Parse(registroTXT[0]);
                        ListaFarma.NOMBRE = registroTXT[1];
                        ListaFarma.BHABILITADO = Int32.Parse(registroTXT[2]);
                        listaFormaFarmaceutica.Add(ListaFarma);

                    }
                    linea = sr.ReadLine();
                    iteracion++;
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return listaFormaFarmaceutica;
        }
    }
}
