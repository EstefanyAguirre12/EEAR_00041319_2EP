using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Solucion
{
    public partial class Normal : Form
    {
    
    private int idUs=0, idaddress=0, idproduct=0, idpedido=0, addresspedido=0;
        public Normal(int idUser)
        {
            InitializeComponent();
            idUs=idUser;
        }
        private void llenarCombo()
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "idBusiness";
            comboBox1.DisplayMember = "name";
            comboBox1.DataSource = BusinessDAO.getLista();
        }
        private void actualizarDireccion()
        {
            List<Address> lista = AddressDAO.getLista(idUs);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }
        private void actualizarDireccionPedido()
        {
            List<Address> lista = AddressDAO.getLista(idUs);
            dataGridView5.DataSource = null;
            dataGridView5.DataSource = lista;
        }
        private void actualizarProductos()
        {
            List<Product> lista = ProductDAO.getLista(Convert.ToInt32(comboBox1.SelectedValue));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = lista;
        }
        private void actualizarPedidos()
        {
            List<Order> lista = OrderDAO.getListaUsuario(idUs);
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = lista;
        }

        private void Normal_Load(object sender, EventArgs e)
        {
            llenarCombo();
            actualizarDireccion();
            actualizarDireccionPedido();
            actualizarProductos();
            actualizarPedidos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                    throw new EmptyException("Campos vacios");
                AddressDAO.Agregar(idUs,textBox1.Text);
                MessageBox.Show("¡Agregado exitosamente!", 
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                actualizarDireccion();
                actualizarDireccionPedido();
            }
            catch (EmptyException exception)
            {
                MessageBox.Show("Ingrese todos los campos solicitados", exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int p = dataGridView1.CurrentRow.Index;
            idaddress = Convert.ToInt32(dataGridView1[0, p].Value);
            textBox1.Text = dataGridView1[1, p].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                    throw new EmptyException("Campos vacios");
                AddressDAO.Modificar(textBox1.Text, idaddress);
                MessageBox.Show("¡Actualizado exitosamente!", 
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                actualizarDireccion(); 
                actualizarDireccionPedido();
            }
            catch (EmptyException exception)
            {
                MessageBox.Show("Ingrese todos los campos solicitados", exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                    throw new EmptyException("Campos vacios");
                if (MessageBox.Show("¿Seguro que desea eliminar la direccion " + textBox1.Text + "?", 
                    "Hugo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AddressDAO.Eliminar(idaddress);
                    MessageBox.Show("¡Registro eliminado exitosamente!", 
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    actualizarDireccion();
                    actualizarDireccionPedido();
                }
            }
            catch (EmptyException exception)
            {
                MessageBox.Show("Seleccione un campo", exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int p = dataGridView2.CurrentRow.Index;
            idproduct = Convert.ToInt32(dataGridView2[0, p].Value);
            textBox3.Text = dataGridView2[1, p].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            actualizarProductos();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "")
                    throw new EmptyException("Campos vacios");
                DateTime fecha = DateTime.Now;
                string f = fecha.ToString("d");
                OrderDAO.Agregar(idproduct,addresspedido,f);
                MessageBox.Show("¡Agregado exitosamente!", 
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarProductos();
                actualizarPedidos();
            }
            catch (EmptyException exception)
            {
                MessageBox.Show("Seleccione un campo", exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }

        private void Normal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            actualizarPedidos();
        }

        private void button8_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("¿Seguro que desea eliminar el pedido?", 
                        "Hugo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OrderDAO.Eliminar(idpedido);
                    MessageBox.Show("¡Registro eliminado exitosamente!", 
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizarPedidos();
                }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int p = dataGridView3.CurrentRow.Index;
            idpedido = Convert.ToInt32(dataGridView3[0, p].Value);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarProductos();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int p = dataGridView5.CurrentRow.Index;
            addresspedido = Convert.ToInt32(dataGridView5[0, p].Value);
            textBox2.Text = dataGridView5[1, p].Value.ToString();
        }
    }
}