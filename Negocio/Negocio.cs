using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   
        public sealed class Negocio
        {

            private static readonly Lazy<Negocio> lazy = new Lazy<Negocio>(() => new Negocio());

            public static Negocio Instance { get { return lazy.Value; } }

            private Negocio() { }
            public void InsertarProducto(int codigoProducto, string nombreProducto, string descripcion, int cantidadProducto, decimal precioVenta, string proveedor)
            {
                Conexion.Instance.Conectar();
                Conexion.Instance.InsertarProducto(codigoProducto, nombreProducto, descripcion, cantidadProducto, precioVenta, proveedor);
                Conexion.Instance.Desconectar();

            }

            public DataTable SeleccionarProductos()
            {
                Conexion.Instance.Conectar();
                return Conexion.Instance.SeleccionarProductos();
            }
            public DataTable SeleccionarProducto(int codigoProducto)
            {
                Conexion.Instance.Conectar();
                return Conexion.Instance.SeleccionarProducto(codigoProducto);

            }
            public DataTable SeleccionarProductoNombre(string nombreProducto)
            {
                Conexion.Instance.Conectar();
                return Conexion.Instance.SeleccionarProductoNombre(nombreProducto);
            }

            public void ActualizarProducto(int codigoProducto, string nombreProducto, string descripcion, int cantidadProducto, decimal precioVenta, string proveedor)
            {
                Conexion.Instance.Conectar();
                Conexion.Instance.ActualizarProducto(codigoProducto, nombreProducto, descripcion, cantidadProducto, precioVenta, proveedor);
                Conexion.Instance.Desconectar();
            }


            public void EliminarProducto(int codigoProducto)
            {
                Conexion.Instance.Conectar();
                Conexion.Instance.EliminarProducto(codigoProducto);
                Conexion.Instance.Desconectar();
            }
            public void InsertarCliente(string nombreCliente, string apellidoCliente, string direccion, string documento, string telefono, DateTime fechaIngreso)
            {
                Conexion.Instance.Conectar();
                Conexion.Instance.InsertarCliente(nombreCliente, apellidoCliente, direccion, documento, telefono, fechaIngreso);
                Conexion.Instance.Desconectar();
            }
            public DataTable SeleccionarClientes()
            {
                Conexion.Instance.Conectar();
                return Conexion.Instance.SeleccionarClientes();
            }
            public DataTable SeleccionarCliente(int idCliente)
            {
                Conexion.Instance.Conectar();
                return Conexion.Instance.SeleccionarCliente(idCliente);
            }
            public DataTable SeleccionarClienteNombre(string nombreCliente)
            {
                Conexion.Instance.Conectar();
                return Conexion.Instance.SeleccionarClienteNombre(nombreCliente);
            }
            public DataTable SeleccionarClienteDocumento(string documento)
            {
                Conexion.Instance.Conectar();
                return Conexion.Instance.SeleccionarClienteDocumento(documento);
            }
            public void ActualizarCliente(int idCliente, string nombreCliente, string apellidoCliente, string direccion, string documento, string telefono, DateTime fechaIngreso)
            {
                Conexion.Instance.Conectar();
                Conexion.Instance.ActualizarCliente(idCliente, nombreCliente, apellidoCliente, direccion, documento, telefono, fechaIngreso);
                Conexion.Instance.Desconectar();
            }
            public void EliminarCliente(int idCliente)
            {
                Conexion.Instance.Conectar();
                Conexion.Instance.EliminarCliente(idCliente);
                Conexion.Instance.Desconectar();
            }
            public void InsertarVenta(int idCliente, int codigoProducto, int cantidad, int totalVenta, DateTime fechaVenta, int idFactura)
            {
                Conexion.Instance.Conectar();
                Conexion.Instance.InsertarVenta(idCliente, codigoProducto, fechaVenta, totalVenta, cantidad, idFactura);
                Conexion.Instance.Desconectar();
            }
            public void InsertarCompra(int idCompra, string Proveedor, int idProducto, DateTime fechaCompra, decimal totalCompras, int cantidadProducto, decimal precioCompra)
            {
                Conexion.Instance.Conectar();
                Conexion.Instance.InsertarCompra(idCompra, Proveedor, idProducto, fechaCompra, totalCompras, cantidadProducto, precioCompra);
                Conexion.Instance.Desconectar();
            }
            public DataTable SeleccionarReporte()
            {
                Conexion.Instance.Conectar();
                return Conexion.Instance.SeleccionarReporte();
            }
            public Usuario SeleccionarUsuario(string usuario, string password)
            {
                Conexion.Instance.Conectar();
                return Conexion.Instance.SeleccionarUsuario(usuario, password);
            }
            public void InsertarUsuario(Entidad.Usuario r)
            {
                Conexion.Instance.Conectar();
                Conexion.Instance.InsertarUsuario(r);
                Conexion.Instance.Conectar();
            }
        }
    }



