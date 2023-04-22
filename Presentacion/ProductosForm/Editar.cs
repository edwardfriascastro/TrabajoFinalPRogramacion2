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
    public partial class Editar : Form
    {
        public Editar()
        {
            InitializeComponent();
        }

       

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var a = Negocio.Negocio.Instance.SeleccionarProducto(Convert.ToInt32(txtbuscarcodigo.Text));
                txtCodigo.Text = a.Rows[0]["idProducto"].ToString();
                txtNombre.Text = a.Rows[0]["nombreProducto"].ToString();
                txtDescripcion.Text = a.Rows[0]["descripcion"].ToString();
                txtCantidad.Text = a.Rows[0]["cantidadProducto"].ToString();
                txtPrecio.Text = a.Rows[0]["precioVenta"].ToString();
                txtProveedor.Text = a.Rows[0]["proveedor"].ToString();
            }
            catch(Exception r) 
            {
                MessageBox.Show("El campo esta vacio o no existe");
            
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Negocio.Negocio.Instance.ActualizarProducto(Convert.ToInt32(txtCodigo.Text), txtNombre.Text, txtDescripcion.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToDecimal(txtPrecio.Text), txtProveedor.Text);
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtProveedor.Text = "";
            txtbuscarcodigo.Text = "";
            MessageBox.Show("Producto Actualizado");
        }
    }
}
