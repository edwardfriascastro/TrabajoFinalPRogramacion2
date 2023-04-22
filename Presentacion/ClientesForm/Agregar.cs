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
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Negocio.Negocio.Instance.InsertarCliente(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtDocumento.Text,txtTelefono.Text,fecha.Value);
            MessageBox.Show("Cliente agregado correctamente");
            this.Close();
        }
    }
}
