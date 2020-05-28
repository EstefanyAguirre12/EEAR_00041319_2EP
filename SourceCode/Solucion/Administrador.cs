using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Solucion
{
    public partial class Administrador : Form
    {
        private int idUser = 0, idnegocio=0,idproducto=0;
        public Administrador()
        {
            InitializeComponent();
        }

        private void llenarCombo()
        {
            comboBox2.DataSource = null;
            comboBox2.ValueMember = "idBusiness";
            comboBox2.DisplayMember = "name";
            comboBox2.DataSource = BusinessDAO.getLista();
        }
        private void actualizarUsuarios()
        {
            List<Usuario> lista = UsuarioDAO.getLista();
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = lista;
        }
        private void actualizarNegocios()
        {
            List<Business> lista = BusinessDAO.getLista();
            dataGridView6.DataSource = null;
            dataGridView6.DataSource = lista;
        }
        private void actualizarProductos()
        {
            List<Product> lista = ProductDAO.getLista(Convert.ToInt32(comboBox2.SelectedValue));
            dataGridView7.DataSource = null;
            dataGridView7.DataSource = lista;
        }
        private void actualizarOrdenes()
        {
            List<Order> lista = OrderDAO.getLista();
            dataGridView8.DataSource = null;
            dataGridView8.DataSource = lista;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarProductos();
        }
        private void Administrador_Load(object sender, EventArgs e)
        {
            llenarCombo();
            actualizarUsuarios();
            actualizarProductos();
            actualizarNegocios();
            actualizarOrdenes();
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try{
                if (radioButton1.Checked)
                {
                    if (string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox5.Text))
                        throw new EmptyException("Ingrese todos los campos solicitados");
                    UsuarioDAO.Agregar(textBox6.Text, textBox5.Text, textBox5.Text, true);
                    MessageBox.Show("¡Agregado exitosamente!",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UsuarioDAO.Agregar(textBox6.Text, textBox5.Text, textBox5.Text, false);
                    MessageBox.Show("¡Agregado exitosamente!",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                textBox6.Clear();
                textBox5.Clear();
                textBox4.Clear();
                actualizarUsuarios();
            }
            catch (Exception)
            {
                MessageBox.Show("El usuario que ha digitado, no se encuentra disponible.", 
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el usuario?", 
                "Hugo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UsuarioDAO.Eliminar(idUser);
                MessageBox.Show("¡Registro eliminado exitosamente!", 
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Clear();
                textBox5.Clear();
                textBox4.Clear();
                actualizarUsuarios();
            }
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int p = dataGridView4.CurrentRow.Index;
            idUser = Convert.ToInt32(dataGridView4[0, p].Value);
            textBox6.Text = dataGridView4[1, p].Value.ToString();
            textBox5.Text = dataGridView4[2, p].Value.ToString();
            textBox4.Text = dataGridView4[3, p].Value.ToString();

            if (dataGridView4[4, p].Value.ToString().Equals("True")){
                radioButton1.Checked=true;
            }else
            {
                radioButton2.Checked=true;
            }
        }

        private void dataGridView6_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int p = dataGridView6.CurrentRow.Index;
            idnegocio = Convert.ToInt32(dataGridView6[0, p].Value);
            textBox8.Text = dataGridView6[1, p].Value.ToString();
            textBox7.Text = dataGridView6[2, p].Value.ToString();
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int p = dataGridView7.CurrentRow.Index;
            idproducto = Convert.ToInt32(dataGridView7[0, p].Value);
            textBox9.Text = dataGridView7[1, p].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {                        
            BusinessDAO.Agregar(textBox8.Text, textBox7.Text);
            MessageBox.Show("¡Agregado exitosamente!",
                "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            textBox8.Clear();
            textBox7.Clear();
            llenarCombo();
            actualizarNegocios();
                    
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el negocio?", 
                    "Hugo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BusinessDAO.Eliminar(idnegocio);
                MessageBox.Show("¡Registro eliminado exitosamente!", 
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox8.Clear();
                textBox7.Clear();
                llenarCombo();
                actualizarNegocios();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ProductDAO.Agregar(Convert.ToInt32(comboBox2.SelectedValue), textBox9.Text);
            MessageBox.Show("¡Agregado exitosamente!",
                "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            textBox9.Clear();
            actualizarProductos();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el producto?", 
                "Hugo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProductDAO.Eliminar(idproducto);
                MessageBox.Show("¡Registro eliminado exitosamente!", 
                "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox9.Clear();
                actualizarProductos();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            actualizarOrdenes();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }
        private void button17_Click(object sender, EventArgs e)
        {
        Form1 inicio = new Form1();
                    inicio.Show();
                    this.Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }

        private void Administrador_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}