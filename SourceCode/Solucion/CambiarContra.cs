using System;
using System.Data;
using System.Windows.Forms;

namespace Solucion
{
    public partial class CambiarContra : Form
    {
        public CambiarContra()
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

        private void label2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void CambiarContra_Load(object sender, EventArgs e)
        {
            llenarCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool actualIgual = comboBox1.SelectedValue.Equals(textBox2.Text);
            bool nuevaValida = textBox1.Text.Length > 0;
           
            if (actualIgual && nuevaValida)
            {
                try
                {
                    UsuarioDAO.ModificarContra(comboBox1.Text, textBox1.Text);
                    MessageBox.Show("¡Contraseña actualizada exitosamente!", 
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Contraseña no actualizada! Favor intente mas tarde.", 
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("¡¡Favor verifique que los datos sean correctos!", 
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}