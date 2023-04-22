using Entidad;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class PrincipalAdmin : Form
    {
        public PrincipalAdmin()
        {
            InitializeComponent();
        }
        Usuario usuario = new Usuario();


        public PrincipalAdmin(Entidad.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void btnExpandir_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = true;
            btnExpandir.Visible = false;

        }

        public void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            btnMaximizar.Visible = false;
            btnExpandir.Visible = true;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            pPrincipal.Controls.Clear();
            Reporte inicio = new Reporte();
            inicio.TopLevel = false;
            inicio.Dock = DockStyle.Fill;
            pPrincipal.Controls.Add(inicio);
            inicio.Show();
        }

        private void pTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            pPrincipal.Controls.Clear();
            Productos inicio = new Productos(usuario);
            inicio.TopLevel = false;
            inicio.Dock = DockStyle.Fill;
            pPrincipal.Controls.Add(inicio);
            inicio.Show();

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            pPrincipal.Controls.Clear();

            Ventas inicio = new Ventas();
            inicio.TopLevel = false;
            inicio.Dock = DockStyle.Fill;
            pPrincipal.Controls.Add(inicio);
            inicio.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            pPrincipal.Controls.Clear();

            Clientes inicio = new Clientes(usuario);
            inicio.TopLevel = false;
            inicio.Dock = DockStyle.Fill;
            pPrincipal.Controls.Add(inicio);
            inicio.Show();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            pPrincipal.Controls.Clear();
            Compras inicio = new Compras();
            inicio.TopLevel = false;
            inicio.Dock = DockStyle.Fill;
            pPrincipal.Controls.Add(inicio);
            inicio.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registro inicio = new Registro();
            inicio.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login inicio = new Login();
            inicio.Show();
        }





    }

}
