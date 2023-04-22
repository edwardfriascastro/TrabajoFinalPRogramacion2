using Presentacion.ProductosForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }
        public Productos(Entidad.Usuario usuario)
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
                btnAgregar.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnListado.Visible = true;
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
            ProductosForm.Agregar inicio = new ProductosForm.Agregar();
            inicio.TopLevel = false;
            inicio.Dock = DockStyle.Fill;
            panel1.Controls.Add(inicio);
            inicio.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ProductosForm.Editar inicio = new ProductosForm.Editar();
            panel1.Controls.Clear();
            inicio.TopLevel = false;
            inicio.Dock = DockStyle.Fill;
            panel1.Controls.Add(inicio);
            inicio.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductosForm.Eliminar inicio = new ProductosForm.Eliminar();
            panel1.Controls.Clear();
            inicio.TopLevel = false;
            inicio.Dock = DockStyle.Fill;
            panel1.Controls.Add(inicio);
            inicio.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductosForm.Listado inicio = new ProductosForm.Listado();
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
                ProductosForm.Listado inicio = new ProductosForm.Listado(txtBuscar.Text, filtro.Text);
                panel1.Controls.Clear();
                inicio.TopLevel = false;
                inicio.Dock = DockStyle.Fill;
                panel1.Controls.Add(inicio);
                inicio.Show();
            }
            else if (filtro.Text == "Codigo")
            {
                ProductosForm.Listado inicio = new ProductosForm.Listado();
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
