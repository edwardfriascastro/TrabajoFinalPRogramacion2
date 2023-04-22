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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtusuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
            }
        }

        private void txtcontrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "Contraseña")
            {
                txtContrasena.Text = "";
                txtContrasena.UseSystemPasswordChar = true;

            }
        }

        private void txtcontrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "Contraseña";
                txtContrasena.UseSystemPasswordChar = false;
            }
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";

            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad.Usuario usuario = new Entidad.Usuario();
                usuario.NombreUsuario = txtUsuario.Text;
                usuario.Contrasena = txtContrasena.Text;
                usuario.Admin = checkBox1.Checked;
                Negocio.Negocio.Instance.InsertarUsuario(usuario);
                MessageBox.Show("Usuario registrado con exito");
                txtContrasena.Text = "";
                txtUsuario.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Este Usuario ya existe");
            }
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad.Usuario usuario = new Entidad.Usuario();
                usuario.NombreUsuario = txtUsuario.Text;
                usuario.Contrasena = txtContrasena.Text;
                usuario.Admin = checkBox1.Checked;
                Negocio.Negocio.Instance.InsertarUsuario(usuario);
                MessageBox.Show("Usuario registrado con exito");
                txtContrasena.Text = "";
                txtUsuario.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Este Usuario ya existe");
            }

        }
    }

}
