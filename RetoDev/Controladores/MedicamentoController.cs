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
    class MedicamentoController
    {
        public static List<Medicamento> leerArchivo(List<FormaFarmaceutica> ListaFarma,int iniciaPaginacion, int tamanioPaginado,string filtro)
        {
            String linea;
            int fin = iniciaPaginacion + tamanioPaginado;
            int inicio = iniciaPaginacion + 1;
            List<Medicamento> listaMedicamento = new List<Medicamento>();
            listaMedicamento.Capacity = tamanioPaginado - 1;
            DataTable tableMedicamentos = new DataTable();
            string[] registroTXT;
            StreamReader sr = new StreamReader("C:\\Users\\Desarollos\\source\\repos\\RetoDev\\RetoDev\\Archivos\\Medicamentos.txt");
            try
            {

              
                linea = sr.ReadLine();
                int iteracion = 0;
                while (linea != null)
                {
                    registroTXT = linea.Split('|');
                    if (iteracion > 0 && (iteracion >= inicio  && iteracion <= fin))
                    {
                        Medicamento medicamento = new Medicamento();
                        
                        int numeroColumna = iteracion;
                        medicamento.NumeroColumna = numeroColumna;
                        medicamento.IIDMEDICAMENTO = Int32.Parse(registroTXT[0]);
                        medicamento.NOMBRE = registroTXT[1];
                        medicamento.CONCENTRACION = registroTXT[2];
                        medicamento.IIDFORMAFARMACEUTICA = Int32.Parse(registroTXT[3]);
                        medicamento.NOMBREFORMAFARMACEUTICA = ListaFarma.Find( e => e.IIDFORMAFARMACEUTICA == Int32.Parse(registroTXT[3])).NOMBRE ;
                        medicamento.PRECIO = Double.Parse(registroTXT[4]);
                        medicamento.STOCK = Int32.Parse(registroTXT[5]);
                        medicamento.PRESENTACION = registroTXT[6];
                        medicamento.BHABILITADO = Int32.Parse(registroTXT[7]);
                        medicamento.HABILITADO = registroTXT[7] == "1" ? "Activo" : "inactivo";


                        listaMedicamento.Add(medicamento);

                    }
                    linea = sr.ReadLine();
                    iteracion++;
                }
                sr.Close();
                sr.Dispose();
                
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                sr.Close();
                sr.Dispose();
            }
            if(filtro != "")
            {
                listaMedicamento = listaMedicamento.FindAll(e =>  e.NOMBRE.ToLower().Contains(filtro.ToLower()) || e.PRESENTACION.ToLower().Contains(filtro.ToLower()) || e.CONCENTRACION.ToLower().Contains(filtro.ToLower()));
            }

            return listaMedicamento;
        }

        public static int CuentaLineasTXT()
        {
            String linea;
            int iteracion = 0;
            List<Medicamento> listaMedicamento = new List<Medicamento>();
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\Desarollos\\source\\repos\\RetoDev\\RetoDev\\Archivos\\Medicamentos.txt");
                linea = sr.ReadLine();

                while (linea != null)
                {
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
            return iteracion  -1 ;// la primera son los headers
        }

        public static List<Medicamento> getNombreMedicamentos()
        {
            String linea;
            List<Medicamento> listaMedicamento = new List<Medicamento>();
            string[] registroTXT;
            try
            {

                StreamReader sr = new StreamReader("C:\\Users\\Desarollos\\source\\repos\\RetoDev\\RetoDev\\Archivos\\Medicamentos.txt");
                linea = sr.ReadLine();
                int iteracion = 0;
                while (linea != null)
                {
                    registroTXT = linea.Split('|');
                    if (iteracion > 0)
                    {
                        Medicamento medicamento = new Medicamento();
                        int numeroColumna = iteracion;
                        medicamento.NumeroColumna = numeroColumna;
                        medicamento.IIDMEDICAMENTO = Int32.Parse(registroTXT[0]);
                        medicamento.NOMBRE = registroTXT[1];                  
                        listaMedicamento.Add(medicamento);


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
            return listaMedicamento;
        }

        public void nuevoMedicamento( Medicamento nuevoMed)
        {
            int id = CuentaLineasTXT() + 1;
            String linea;
            try
            {

                using (StreamWriter sw =  File.AppendText(@"C:\Users\Desarollos\source\repos\RetoDev\RetoDev\Archivos\Medicamentos.txt"))
                {
                    linea = id.ToString() + "|" + nuevoMed.NOMBRE + "|" + nuevoMed.CONCENTRACION + "|" +
                       nuevoMed.IIDFORMAFARMACEUTICA.ToString() + "|" + nuevoMed.PRECIO.ToString() + "|" +
                       nuevoMed.STOCK.ToString() + "|" + nuevoMed.PRESENTACION + "|" + nuevoMed.BHABILITADO.ToString();
                    sw.WriteLine(linea);
                    sw.Close();
                    Console.ReadLine();
                }

               
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }

        public static List<Medicamento> dameTodosMedicamentos()
        {
            String linea;
            List<Medicamento> listaMedicamento = new List<Medicamento>();
            string[] registroTXT;
            try
            {

                StreamReader sr = new StreamReader("C:\\Users\\Desarollos\\source\\repos\\RetoDev\\RetoDev\\Archivos\\Medicamentos.txt");
                linea = sr.ReadLine();
                int iteracion = 0;
                while (linea != null)
                {
                    registroTXT = linea.Split('|');
                    if (iteracion > 0)
                    {
                        Medicamento medicamento = new Medicamento();
                        int numeroColumna = iteracion;
                        medicamento.NumeroColumna = numeroColumna;
                        medicamento.IIDMEDICAMENTO = Int32.Parse(registroTXT[0]);
                        medicamento.NOMBRE = registroTXT[1];
                        medicamento.CONCENTRACION = registroTXT[2];
                        medicamento.IIDFORMAFARMACEUTICA = Int32.Parse(registroTXT[3]);
                        medicamento.PRECIO = Double.Parse(registroTXT[4]);
                        medicamento.STOCK = Int32.Parse(registroTXT[5]);
                        medicamento.PRESENTACION = registroTXT[6];
                        medicamento.BHABILITADO = Int32.Parse(registroTXT[7]);
                        medicamento.HABILITADO = registroTXT[7] == "1" ? "Activo" : "inactivo";
                        listaMedicamento.Add(medicamento);

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
            return listaMedicamento;
        }

        public static void editaMedicamento(Medicamento editarMedicamento)
        {
            String linea;
            List<Medicamento> lmed = dameTodosMedicamentos();
            foreach (Medicamento med in lmed.Where(e => e.NumeroColumna == editarMedicamento.NumeroColumna))
            {
              
                        med.NOMBRE = editarMedicamento.NOMBRE;
                     
                        med.CONCENTRACION = editarMedicamento.CONCENTRACION;
                       
                        med.IIDFORMAFARMACEUTICA = editarMedicamento.IIDFORMAFARMACEUTICA;
                        
                        med.PRECIO = editarMedicamento.PRECIO;
                      
                        med.STOCK = editarMedicamento.STOCK;
                       
                        med.PRESENTACION = editarMedicamento.PRESENTACION;
                      
                        med.BHABILITADO = editarMedicamento.BHABILITADO ;
                      

                
            }
            try
                {

                using (StreamWriter sw = File.CreateText(@"C:\Users\Desarollos\source\repos\RetoDev\RetoDev\Archivos\Medicamentos.txt"))
                {
                    linea = "IIDMEDICAMENTO|NOMBRE|CONCENTRACION|IIDFORMAFARMACEUTICA|PRECIO|STOCK|PRESENTACION|BHABILITADO";
                    sw.WriteLine(linea);
                    foreach (Medicamento medUpd in lmed)
                    {
                        linea = medUpd.NumeroColumna.ToString() + "|" + medUpd.NOMBRE + "|" + medUpd.CONCENTRACION + "|" +
                                medUpd.IIDFORMAFARMACEUTICA.ToString() + "|" + medUpd.PRECIO.ToString() + "|" +
                                medUpd.STOCK.ToString() + "|" + medUpd.PRESENTACION + "|" + medUpd.BHABILITADO.ToString();
                        sw.WriteLine(linea);
                    }

                    sw.Close();
                    Console.ReadLine();
                }

            }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }




        }

        public static void eliminaRegistro(int idRegistro)
        {
            String linea;
            List<Medicamento> lmed = dameTodosMedicamentos();
            try
            {

                using (StreamWriter sw = File.CreateText(@"C:\Users\Desarollos\source\repos\RetoDev\RetoDev\Archivos\Medicamentos.txt"))
                {
                    linea = "IIDMEDICAMENTO|NOMBRE|CONCENTRACION|IIDFORMAFARMACEUTICA|PRECIO|STOCK|PRESENTACION|BHABILITADO";
                    sw.WriteLine(linea);
                    foreach (Medicamento medUpd in lmed)
                    {
                        if(medUpd.IIDMEDICAMENTO != idRegistro)
                        {
                            linea = medUpd.IIDMEDICAMENTO.ToString() + "|" + medUpd.NOMBRE + "|" + medUpd.CONCENTRACION + "|" +
                            medUpd.IIDFORMAFARMACEUTICA.ToString() + "|" + medUpd.PRECIO.ToString() + "|" +
                            medUpd.STOCK.ToString() + "|" + medUpd.PRESENTACION + "|" + medUpd.BHABILITADO.ToString();
                            sw.WriteLine(linea);
                        }

                    }

                    sw.Close();
                    Console.ReadLine();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }




        }
    }

}
