using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.ProductosForm
{
    public partial class Eliminar : Form
    {
        public Eliminar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           var  a=Negocio.Negocio.Instance.SeleccionarProducto(Convert.ToInt32(txtBuscarCodigo.Text));
            dataGridView1.DataSource = a;
            dataGridView1.Refresh();


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Negocio.Negocio.Instance.EliminarProducto(Convert.ToInt32(txtBuscarCodigo.Text));
            MessageBox.Show("Producto Eliminado");
            dataGridView1.Refresh();
        }
    }
}
