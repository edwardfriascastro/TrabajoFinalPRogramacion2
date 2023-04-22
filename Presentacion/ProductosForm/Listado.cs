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
    public partial class Listado : Form
    {
       

        public Listado()
        {
            InitializeComponent();
            dataGridView1.DataSource = Negocio.Negocio.Instance.SeleccionarProductos();
            
        }
        public Listado(string text,string txt)
        {
            InitializeComponent();
            if (txt == "")
            {
                dataGridView1.DataSource = Negocio.Negocio.Instance.SeleccionarProductos();
            }
            else if (txt == "Nombre")
            {
                dataGridView1.DataSource = Negocio.Negocio.Instance.SeleccionarProductoNombre(text);
            }
            else if (txt == "Codigo")
            {
                dataGridView1.DataSource = Negocio.Negocio.Instance.SeleccionarProducto(Convert.ToInt32(text));
               
            }

        }
        
    }
}
