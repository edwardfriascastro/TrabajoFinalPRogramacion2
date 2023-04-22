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
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
        }

        private void btnAgregar(object sender, EventArgs e)
        {
            Negocio.Negocio.Instance.InsertarProducto(Convert.ToInt32(txtCodigo.Text), txtNombre.Text, txtDescripcion.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToDecimal(txtPrecio.Text), txtProveedor.Text);
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtProveedor.Text = "";
            MessageBox.Show("Producto Insertado");
        }
        
    }
}
