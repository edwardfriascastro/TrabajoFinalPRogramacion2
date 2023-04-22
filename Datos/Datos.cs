using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        private static readonly Conexion instance = new Conexion();

        private string connectionString = "Data Source=.;Initial Catalog=GestionInventario;Integrated Security=True";

        private Conexion() { }

        public static Conexion Instance
        {
            get
            {
                return instance;
            }
        }

        public void Conectar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected successfully.");
            }
        }

        public void Desconectar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Close();
                Console.WriteLine("Disconnected successfully.");
            }
        }
        //hecho

        public void InsertarProducto(int codigoProducto, string nombreProducto, string descripcion, int cantidadProducto, decimal precioVenta, string proveedor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_InsertarProducto", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idProducto", codigoProducto);
                command.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@cantidadProducto", cantidadProducto);
                command.Parameters.AddWithValue("@precioVenta", precioVenta);
                command.Parameters.AddWithValue("@proveedor", proveedor);
                command.ExecuteNonQuery();
            }

        }
        //hecho
        public DataTable SeleccionarProductos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_SeleccionarProductos", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        //hecho
        public void ActualizarProducto(int idProducto, string nombreProducto, string descripcion, int cantidadProducto, decimal precioVenta, string proveedor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_ActualizarProducto", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idProducto", idProducto);
                command.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@cantidadProducto", cantidadProducto);
                command.Parameters.AddWithValue("@precioVenta", precioVenta);
                command.Parameters.AddWithValue("@proveedor", proveedor);
                command.ExecuteNonQuery();
            }
        }
        //hecho
        public DataTable SeleccionarProducto(int idProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_SeleccionarProducto", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idProducto", idProducto);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        //hecho
        public void EliminarProducto(int idProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_EliminarProducto", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idProducto", idProducto);
                command.ExecuteNonQuery();
            }
        }


        //hecho
        public DataTable SeleccionarProductoNombre(string nombreProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_SeleccionarProductoNombre", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }
        public void InsertarCliente(string nombre, string apellido, string direccion, string documento, string telefono, DateTime fechaIngreso)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_InsertarCliente", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@direccion", direccion);
                command.Parameters.AddWithValue("@documento", documento);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@fechaIngreso", fechaIngreso);
                command.ExecuteNonQuery();
            }
        }
        public DataTable SeleccionarCliente(int idCliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_SeleccionarCliente", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", idCliente);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }

        public DataTable SeleccionarClientes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_SeleccionarClientes", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }
        public DataTable SeleccionarClienteNombre(string nombre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_SeleccionarClienteNombre", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombre", nombre);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }
        public DataTable SeleccionarClienteDocumento(string documento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_SeleccionarClienteDocumento", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@documento", documento);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }
        public void EliminarCliente(int idCliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("sp_EliminarCliente", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", idCliente);
                command.ExecuteNonQuery();
            }
        }
        public void ActualizarCliente(int idCliente, string nombre, string apellido, string direccion, string documento, string telefono, DateTime fechaIngreso)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_ActualizarCliente", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", idCliente);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@direccion", direccion);
                command.Parameters.AddWithValue("@documento", documento);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@fechaIngreso", fechaIngreso);
                command.ExecuteNonQuery();
            }
        }
        public void InsertarVenta(int idCliente, int idProducto, DateTime fechaVenta, int totalVentas, int cantidadProducto, int idFactura)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_InsertarVenta", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", idCliente);
                command.Parameters.AddWithValue("@idProducto", idProducto);
                command.Parameters.AddWithValue("@fechaVenta", fechaVenta);
                command.Parameters.AddWithValue("@totalVentas", totalVentas);
                command.Parameters.AddWithValue("@cantidadProducto", cantidadProducto);
                command.Parameters.AddWithValue("@idFactura", idFactura);
                command.ExecuteNonQuery();
            }
        }
        public void InsertarCompra(int idCompra, string Proveedor, int idProducto, DateTime fechaCompra, decimal totalCompras, int cantidadProducto, decimal precioCompra)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_InsertarCompra", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCompra", idCompra);
                command.Parameters.AddWithValue("@proveedor", Proveedor);
                command.Parameters.AddWithValue("@idProducto", idProducto);
                command.Parameters.AddWithValue("@fechaCompra", fechaCompra);
                command.Parameters.AddWithValue("@totalCompras", totalCompras);
                command.Parameters.AddWithValue("@cantidadProducto", cantidadProducto);
                command.Parameters.AddWithValue("@precioCompra", precioCompra);
                command.ExecuteNonQuery();

            }
        }
        public DataTable SeleccionarReporte()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Reporte", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public void InsertarUsuario(Entidad.Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("InsertarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                command.Parameters.AddWithValue("@admin", usuario.Admin);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public Entidad.Usuario SeleccionarUsuario(string nombreUsuario, string contrasena)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ObtenerUsuarioPorNombreYContrasena", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                command.Parameters.AddWithValue("@contrasena", contrasena);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        IdUsuario = reader.GetInt32(0),
                        NombreUsuario = reader.GetString(1),
                        Contrasena = reader.GetString(2),
                        Admin = reader.GetBoolean(3)
                    };
                    return usuario;
                }
                return null;
            }


        }
    }
}
