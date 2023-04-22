using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion
{
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var a = Negocio.Negocio.Instance.SeleccionarProducto(Convert.ToInt32(txtBuscarCodigo.Text));
                txtCodigo.Text = a.Rows[0]["idProducto"].ToString();
                txtNombre.Text = a.Rows[0]["nombreProducto"].ToString();
                txtPrecio.Text = a.Rows[0]["precioVenta"].ToString();
            }
            catch (Exception r)
            {
                MessageBox.Show("El campo esta vacio o no existe");
            }
        }


        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                var a = txtCodigo.Text;
                var b = txtNombre.Text;
                var c = Convert.ToInt32(txtCantidad.Text);
                var d = Convert.ToInt32(txtPrecio.Text);
                var Total = c * d;
                txtBuscarCodigo.Text = "";

                // Obtener la DataView actual del DataGridView

                DataView dataView = dgv.DataSource as DataView;



                // Si la DataView es nula, crear una nueva y definir las columnas

                if (dataView == null)

                {

                    DataTable table = new DataTable();

                    table.Columns.Add("Código", typeof(string));

                    table.Columns.Add("Nombre", typeof(string));

                    table.Columns.Add("Cantidad", typeof(int));

                    table.Columns.Add("Precio", typeof(int));

                    table.Columns.Add("Total", typeof(int));

                    dataView = new DataView(table);

                    dgv.DataSource = dataView;

                }



                // Crear una nueva fila y agregar los valores a, b, c, d y Total a la fila

                DataRowView row = dataView.AddNew();

                row["Código"] = a;

                row["Nombre"] = b;

                row["Cantidad"] = c;

                row["Precio"] = d;

                row["Total"] = Total;



                // Mostrar la DataView en el DataGridView

                dgv.DataSource = dataView;


                // Sumar los totales y mostrar el resultado en el TextBox

                int sum = 0;

                foreach (DataRowView r in dataView)

                {
                    sum += Convert.ToInt32(r["Total"]);
                }

                txtTotal.Text = sum.ToString();



                txtBuscarCodigo.Text = "";

                txtCantidad.Text = "";

                txtCodigo.Text = "";

                txtNombre.Text = "";

                txtPrecio.Text = "";





            }
            catch (Exception r)
            {
                MessageBox.Show("El campo esta vacio o no existe");
            }

        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    var idCliente = Convert.ToInt32(txtCliente.Text);
                    var codigoProducto = Convert.ToInt32(row.Cells["Código"].Value);
                    var cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    // var total = Convert.ToInt32(row.Cells["Total"].Value);
                    var total = Convert.ToInt32(txtTotal.Text);
                    var idfactura = Convert.ToInt32(txtFactura.Text);
                    var fechaF = fecha.Value;


                    Negocio.Negocio.Instance.InsertarVenta(idCliente, codigoProducto, cantidad, total, fechaF, idfactura);
                }
                MessageBox.Show("Venta realizada con exito");
            }

            catch (Exception r)
            {
                MessageBox.Show("Campos Erroneos");
            }
        }

        private void txtFactura_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
