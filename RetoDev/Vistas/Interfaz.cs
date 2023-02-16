using RetoDev.Controladores;
using RetoDev.Modelos;
using RetoDev.Utilidades;
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
    public partial class Interfaz : Form
    {
        private int iniciaPaginacion;
        private int cantidadRegistros;
        private int permitirBorrar;
        public Interfaz()
        {
            InitializeComponent();
            UsuarioController usuario = new UsuarioController();
            MedicamentoController med = new MedicamentoController();
            FormaFarmaController ff = new FormaFarmaController();
            //usuario.leerArchivo();
            permitirBorrar = 0;
            iniciaPaginacion = 0;
            cantidadRegistros = InterfazController.cuentaRegistros();
            inicializaGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void inicializaFormularioAlta()
        {
            btnAgregar.Visible = true;
            btnActualizar.Visible = false;
            List<FormaFarmaceutica> lff = InterfazController.dameNombresFarmaceutica();
            foreach(FormaFarmaceutica f in lff)
            {
                cbFormafar.Items.Add(f.NOMBRE);
            }
            cbHabilitado.Items.Add("Activo");
            cbHabilitado.Items.Add("Inactivo");
           
        }

        public void iniciaFormularioEditar(DataTable table,int  indice)
        {
            limpiarFormulario();
            inicializaFormularioAlta();
            btnAgregar.Visible = false;
            btnActualizar.Visible = true;
            Medicamento med = InterfazController.toMedicamentoModel(table, indice);
            textBox1.Text = med.NumeroColumna.ToString();
            txtNombreMed.Text = med.NOMBRE;
            txtConcentracion.Text = med.CONCENTRACION;
            txtPrecio.Text = med.PRECIO.ToString();
            txtStock.Text = med.STOCK.ToString();
            txtPresentacion.Text = med.PRESENTACION;
            cbFormafar.Text = med.NOMBREFORMAFARMACEUTICA;
            cbHabilitado.Text = med.BHABILITADO == 1 ? "Activo": "Inactivo";

        }

        public void inicializaGrid()
        {

            DataTable datos = FunGenerales.ToDataTable(InterfazController.llenaDataGrid(iniciaPaginacion,txtFiltrar.Text));
            dataGridView1.DataSource = datos;
            dataGridView1.Columns[0].Visible = false; //NumeroColumna
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[4].Visible = false; //IIDFORMAFARMACEUTICA
            dataGridView1.Columns[5].HeaderText = "IIDFORMAFARMACEUTICA";
            dataGridView1.Columns[9].Visible = false; //BHABILITADO

            cantidadRegistros = InterfazController.cuentaRegistros();




        }

        public void paginacion(string direccion)
        {
            int calculaPaginacion;
            if (direccion == "S")
            { //siguiente
                calculaPaginacion = iniciaPaginacion + 5;
                if (calculaPaginacion > 0 && calculaPaginacion < cantidadRegistros)
                    iniciaPaginacion = calculaPaginacion;
            }
            else if (direccion == "A")
            {// Anteriror
                calculaPaginacion = iniciaPaginacion - 5;
                if (calculaPaginacion >= 0 && calculaPaginacion < cantidadRegistros)
                    iniciaPaginacion = calculaPaginacion;
            }
            inicializaGrid();

        }



        private void btnAnterior_Click(object sender, EventArgs e)
        {
            paginacion("A");
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            paginacion("S");

        }

        public void limpiarFormulario()
        {
            txtNombreMed.Text = "";
            txtConcentracion.Text = "";
            cbFormafar.Items.Clear();
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtPresentacion.Text = "";
            txtFiltrar.Text = "";
            cbHabilitado.Items.Clear();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if( txtNombreMed.Text == "" || 
                txtConcentracion.Text == "" || 
                cbFormafar.Text == "" || 
                txtPrecio.Text == "" || 
                txtStock.Text == "" || 
                txtPresentacion.Text == "" || 
                cbHabilitado.Text == "")
            {
                MessageBox.Show("Todos los campos son obligatorios");
                return;
            }

            InterfazController.nuevoRegistro(txtNombreMed.Text, txtConcentracion.Text, cbFormafar.Text, 
                Double.Parse(txtPrecio.Text),Int32.Parse(txtStock.Text), txtPresentacion.Text, cbHabilitado.Text);
            groupBox1.Visible = false;
            limpiarFormulario();
            inicializaGrid();
            MessageBox.Show("Registro agregado exitosamente");

        }

        private void btnIniciaAlta_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
            inicializaFormularioAlta();
            groupBox1.Visible = true;

        }

        private void btnCierraAlta_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            limpiarFormulario();
        }



        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            int row;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                row = dataGridView1.SelectedRows[0].Index;
                iniciaFormularioEditar(dt, row);
                groupBox1.Visible = true;
            }
            else if (dataGridView1.SelectedCells.Count > 0)
            {
                row = dataGridView1.SelectedCells[0].RowIndex;
                iniciaFormularioEditar(dt, row);
                groupBox1.Visible = true;
            }

            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            int indice = Int32.Parse(textBox1.Text);
            InterfazController.editaRegistro(indice, txtNombreMed.Text, txtConcentracion.Text, cbFormafar.Text,
               Double.Parse(txtPrecio.Text), Int32.Parse(txtStock.Text), txtPresentacion.Text, cbHabilitado.Text);
            groupBox1.Visible = false;
            limpiarFormulario();
            inicializaGrid();
            MessageBox.Show("Registro actualizado exitosamente");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           if(dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    btnEditar.Enabled = true;
                }else if (dataGridView1.SelectedCells.Count > 0)
                {
                    btnEditar.Enabled = true;
                }
                else
                {
                    btnEditar.Enabled = false;
                }
            }
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            Medicamento med = new Medicamento();
            int row;
            {
                DialogResult result = MessageBox.Show("¿seguro que quieres elimimnar el registro?", "Confirmación", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;

                }
                limpiarFormulario();
                groupBox1.Visible = false;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    row = dataGridView1.SelectedRows[0].Index;
                    med = InterfazController.toMedicamentoModel(dt, row);
                   
                }
                else if (dataGridView1.SelectedCells.Count > 0)
                {
                    row = dataGridView1.SelectedCells[0].RowIndex;
                    med = InterfazController.toMedicamentoModel(dt, row);
                    
                }

                InterfazController.eliminaRegistro(med.IIDMEDICAMENTO);
                inicializaGrid();
                MessageBox.Show("Registro agregado exitosamente");
            }
        }


        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            DataTable datos = FunGenerales.ToDataTable(InterfazController.llenaDataGrid(iniciaPaginacion, txtFiltrar.Text));
            dataGridView1.DataSource = datos;
            dataGridView1.Columns[0].Visible = false; //NumeroColumna
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[4].Visible = false; //IIDFORMAFARMACEUTICA
            dataGridView1.Columns[5].HeaderText = "IIDFORMAFARMACEUTICA";
            dataGridView1.Columns[9].Visible = false; //BHABILITADO
        }


    }
}
