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
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
            
                dataGridView1.DataSource =  Negocio.Negocio.Instance.SeleccionarClientes();
               

        }
        public Listado(string text, string txt)
        {
            InitializeComponent();
            if (txt == "")
            {
                dataGridView1.DataSource = Negocio.Negocio.Instance.SeleccionarProductos();
            }
            else if (txt == "Nombre")
            {
                dataGridView1.DataSource = Negocio.Negocio.Instance.SeleccionarClienteNombre(text);
            }
            else if (txt == "Id")
            {
                dataGridView1.DataSource = Negocio.Negocio.Instance.SeleccionarCliente(Convert.ToInt32(text));

            }
            else if (txt=="Documento")
            {
                dataGridView1.DataSource = Negocio.Negocio.Instance.SeleccionarClienteDocumento(text);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
