using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solucion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }
        private void llenarCombo()
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "password";
            comboBox1.DisplayMember = "username";
            comboBox1.DataSource = UsuarioDAO.getLista();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
                throw new EmptyException("Ingrese todos los campos solicitados");

            if (comboBox1.SelectedValue.Equals(textBox2.Text))
            {
                Usuario u = (Usuario) comboBox1.SelectedItem;
                if (u.userType.Equals("True"))
                {
                    MessageBox.Show("¡Bienvenido!","Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Administrador form = new Administrador();
                    form.Show();
                    this.Hide();
                }
                else
                {
                 string query = $"SELECT idUser FROM APPUSER WHERE username ='{comboBox1.Text}';";
                                var dt = Conexion.realizarConsulta(query);
                                var dr = dt.Rows[0];
                                int idUser = Convert.ToInt32(dr[0].ToString());
                    MessageBox.Show("¡Bienvenido!","Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Normal form = new Normal(idUser);
                    form.Show();
                    this.Hide();
                }
            }
            else
                MessageBox.Show("¡Contraseña incorrecta!", "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CambiarContra unaVentana = new CambiarContra();
            unaVentana.ShowDialog();
            llenarCombo();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}