using Microsoft.Win32;
using RetoDev.Modelos;
using RetoDev.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoDev.Controladores
{
     class UsuarioController
    {
        public static List<Usuario> leerArchivo() {
            String linea;
            List<Usuario> listaUsuarios = new List<Usuario>();
            string[] registroTXT;
            try
            {

                StreamReader sr = new StreamReader("C:\\Users\\Desarollos\\source\\repos\\RetoDev\\RetoDev\\Archivos\\Usuarios.txt");
                linea = sr.ReadLine();
                int iteracion = 0;
                while (linea != null)
                {
                    registroTXT = linea.Split('|');
                    if (iteracion > 0)
                    {
                        Usuario usr = new Usuario();
                        usr.idusuario = Int32.Parse(registroTXT[0]);
                        usr.nombre = registroTXT[1];
                        usr.fechacreacion = DateTime.Parse(registroTXT[2]);
                        usr.usuario = registroTXT[3];
                        usr.password = registroTXT[4];
                        usr.idperfil = registroTXT[5];
                        usr.estatus = Int32.Parse(registroTXT[6]);
                        listaUsuarios.Add(usr);

                    }

                    Console.WriteLine(linea);

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
            return listaUsuarios;
        }

        public static bool iniciarSesion(string usuario, string contrasena)
        {
            bool todoOK = false;
            try
            {
                Usuario usr = leerArchivo().Find( e => e.usuario == usuario && e.password == contrasena);
                if (usr != null) {
                    todoOK = true;

        
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return todoOK;
        }

    }
}
