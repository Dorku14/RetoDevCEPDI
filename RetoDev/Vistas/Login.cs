using RetoDev.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetoDev
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {


            iniciarSesion();
        }

        public void iniciarSesion()
        {
            if (txtUsuario.Text == "" && txtContrasena.Text == "")
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }
            if (!UsuarioController.iniciarSesion(txtUsuario.Text, txtContrasena.Text))
            {
                MessageBox.Show("Usuario o Contraseña incorrectos.");
                return;
            }
            Interfaz interfaz = new Interfaz();
            interfaz.Show();
            this.Hide();
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                iniciarSesion();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                iniciarSesion();
            }
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                iniciarSesion();
            }
        }
    }
}
