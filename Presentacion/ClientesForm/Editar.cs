using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.ClientesForm
{
    public partial class Editar : Form
    {
        public Editar()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var a = Negocio.Negocio.Instance.SeleccionarCliente(Convert.ToInt32(txtBuscarCodigo.Text));
                
                txtNombre.Text = a.Rows[0]["nombre"].ToString();
                txtApellido.Text = a.Rows[0]["apellido"].ToString();
                txtDocumento.Text = a.Rows[0]["documento"].ToString();
                txtDireccion.Text = a.Rows[0]["direccion"].ToString();
                txtTelefono.Text = a.Rows[0]["telefono"].ToString();
                fecha.Value = Convert.ToDateTime(a.Rows[0]["fechaIngreso"].ToString());
                

            }
            catch (Exception r)
            {
                MessageBox.Show("El campo esta vacio o no existe");

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Negocio.Negocio.Instance.ActualizarCliente(Convert.ToInt32(txtBuscarCodigo.Text), txtNombre.Text, txtApellido.Text, txtDocumento.Text, txtDireccion.Text, txtTelefono.Text, fecha.Value);
            MessageBox.Show("Cliente actualizado correctamente");
        }
    }
}
