using System;
using System.Collections;
using System.Windows.Forms;

namespace DataGridView_A1
{
    public partial class Form1 : Form
    {
        // ArrayList para almacenar los objetos Persona
        // ArrayList pertenece al espacio de nombres System.Collections
        ArrayList listaPersonas = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Persona miColaborador1 = new Persona();

            miColaborador1.Id = 1;
            miColaborador1.Nombres = "Elena Carolina";
            miColaborador1.Apellidos = "Gonzalez Rodríguez";
            miColaborador1.Correo = "elena.gonzalez@ejemplo.com";
            miColaborador1.FechaNacimiento = new DateTime(1990, 5, 15);
            listaPersonas.Add(miColaborador1);

            dgvDatos.DataSource = null;
            dgvDatos.DataSource = listaPersonas;
        }

        // Este método SÍ está conectado al botón "Guardar" del ToolStrip
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bool esValido = true;

            if (Utilidades.EstaEnBlanco(txtID.Text))
            {
                errorProvider1.SetError(txtID, "Debe ingresar el Id del empleado.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(txtID, string.Empty);
            }

            if (Utilidades.EstaEnBlanco(txtNombres.Text))
            {
                errorProvider1.SetError(txtNombres, "Debe ingresar el nombre.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(txtNombres, string.Empty);
            }

            if (Utilidades.EstaEnBlanco(txtApellidos.Text))
            {
                errorProvider1.SetError(txtApellidos, "Debe ingresar los apellidos.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(txtApellidos, string.Empty);
            }

            if (!Utilidades.EsCorreoValido(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Ingrese un correo válido.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(txtEmail, string.Empty);
            }

            decimal salario;
            if (!decimal.TryParse(txtSalario.Text, out salario))
            {
                errorProvider1.SetError(txtSalario, "Ingrese un salario válido.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(txtSalario, string.Empty);
            }

            if (!esValido)
            {
                return;
            }

            Persona nuevaPersona = new Persona();
            nuevaPersona.Id = int.Parse(txtID.Text);
            nuevaPersona.Nombres = txtNombres.Text;
            nuevaPersona.Apellidos = txtApellidos.Text;
            nuevaPersona.Correo = txtEmail.Text;
            nuevaPersona.FechaNacimiento = dateTimePicker1.Value;
            nuevaPersona.Salario = salario;

            listaPersonas.Add(nuevaPersona);
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = listaPersonas;

            MessageBox.Show("Registro guardado correctamente.");
        }

        // Este método SÍ está conectado al botón "Limpiar" del ToolStrip
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtEmail.Clear();
            txtSalario.Clear();
            dateTimePicker1.Value = DateTime.Now;
            errorProvider1.Clear();
            txtID.Focus();
        }
    }
}