using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }
        public Clientes(Entidad.Usuario usuario)
        { //ni eliminar, ni editar
            InitializeComponent();
            if (usuario.Admin)
            {
                btnAgregar.Visible = true;
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                btnListado.Visible = true;
            }
            else
            {
                btnAgregar.Visible = true;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnListado.Visible = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
            ClientesForm.Agregar inicio = new ClientesForm.Agregar();
            inicio.TopLevel = false;
            inicio.Dock = DockStyle.Fill;
            panel1.Controls.Add(inicio);
            inicio.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ClientesForm.Editar inicio = new ClientesForm.Editar();
            panel1.Controls.Clear();
            inicio.TopLevel = false;
            inicio.Dock = DockStyle.Fill;
            panel1.Controls.Add(inicio);
            inicio.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientesForm.Eliminar inicio = new ClientesForm.Eliminar();
            panel1.Controls.Clear();
            inicio.TopLevel = false;
            inicio.Dock = DockStyle.Fill;
            panel1.Controls.Add(inicio);
            inicio.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClientesForm.Listado inicio = new ClientesForm.Listado();
            panel1.Controls.Clear();
            inicio.TopLevel = false;
            inicio.Dock = DockStyle.Fill;
            panel1.Controls.Add(inicio);
            inicio.Show();

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (filtro.Text == "Nombre")
            {
                ClientesForm.Listado inicio = new ClientesForm.Listado(txtBuscar.Text, filtro.Text);
                panel1.Controls.Clear();
                inicio.TopLevel = false;
                inicio.Dock = DockStyle.Fill;
                panel1.Controls.Add(inicio);
                inicio.Show();
            }
            else if (filtro.Text == "Id")
            {
                ClientesForm.Listado inicio = new ClientesForm.Listado(txtBuscar.Text, filtro.Text);
                panel1.Controls.Clear();
                inicio.TopLevel = false;
                inicio.Dock = DockStyle.Fill;
                panel1.Controls.Add(inicio);
                inicio.Show();
            }
            else if (filtro.Text == "Documento")
            {
                ClientesForm.Listado inicio = new ClientesForm.Listado(txtBuscar.Text, filtro.Text);
                panel1.Controls.Clear();
                inicio.TopLevel = false;
                inicio.Dock = DockStyle.Fill;
                panel1.Controls.Add(inicio);
                inicio.Show();
            }
            else
            {
                MessageBox.Show("Seleccione una opcion de filtrado");
            }
        }
    }

}


