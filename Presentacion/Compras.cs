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
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                var a = txtCodigoProducto.Text;
                var d = Convert.ToInt32(txtPrecioCompra.Text);
                var c = Convert.ToInt32(txtCantidad.Text);
                var Total = c * d;

                // Obtener la DataView actual del DataGridView

                DataView dataView = dgv.DataSource as DataView;



                // Si la DataView es nula, crear una nueva y definir las columnas

                if (dataView == null)

                {

                    DataTable table = new DataTable();

                    table.Columns.Add("Codigo", typeof(string));

                    table.Columns.Add("Cantidad", typeof(int));

                    table.Columns.Add("Precio", typeof(decimal));

                    table.Columns.Add("Total", typeof(decimal));

                    dataView = new DataView(table);

                    dgv.DataSource = dataView;

                }



                // Crear una nueva fila y agregar los valores a, b, c, d y Total a la fila

                DataRowView row = dataView.AddNew();

                row["Codigo"] = a;

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



                txtCodigoProducto.Text = "";

                txtCantidad.Text = "";

                txtPrecioCompra.Text = "";





                MessageBox.Show("Producto agregado correctamente");
            }
            catch (Exception r)
            {/*"El campo esta vacio o no existe"*/
                MessageBox.Show(r.Message);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    var codigoProducto = Convert.ToInt32(row.Cells["Codigo"].Value);
                    var cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    var precioCompra = Convert.ToInt32(row.Cells["Precio"].Value);
                    // var total = Convert.ToInt32(row.Cells["Total"].Value);
                    var total = Convert.ToDecimal(txtTotal.Text);
                    var fechaF = fecha.Value;
                    var proveedor = txtProveedor.Text;
                    var idCompra = Convert.ToInt32(txtIdCompra.Text);

                    //int idCompra, string Proveedor, int idProducto, DateTime fechaCompra, decimal totalCompras, int cantidadProducto, decimal precioCompra
                    Negocio.Negocio.Instance.InsertarCompra(idCompra, proveedor, codigoProducto, fechaF, total, cantidad, precioCompra);
                }
                MessageBox.Show("Compra realizada con exito");
                txtProveedor.Text = "";
                txtIdCompra.Text = "";
                txtTotal.Text = "";
                dgv.DataSource = null;
            }
            catch (Exception r)
            {
                MessageBox.Show("Error al guardar la compra");
            }
        }

    }

}
