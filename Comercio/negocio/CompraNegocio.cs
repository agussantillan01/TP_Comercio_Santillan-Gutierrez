using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Xml.Linq;
using System.Data;
using System.Collections;
using Microsoft.Win32;
using static System.Collections.Specialized.BitVector32;

namespace negocio
{
    public class CompraNegocio
    {
        public List<Compra> listar(string id = "")
        {
            List<Compra> lista = new List<Compra>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=TP_Comercio; integrated security= true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select PR.IdProducto, PR.Nombre AS Producto, C.IdCompraMovimiento,C.Cantidad,P.IdProveedor, P.Nombre AS Proveedor, C.Precio from Compra_Movimiento C Inner join Productos PR  On C.IdCompraMovimiento=PR.IdProducto Inner join Proveedores P On P.IdProveedor = C.IdProveedores ";
                if (id != "")
                    comando.CommandText += "where C.IdCompraMovimiento = " + id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Compra comp = new Compra();
                    comp.Id = (Int64)lector["IdCompraMovimiento"];
                    comp.Cantidad = (Int16)lector["Cantidad"];
                    comp.Precio = (decimal)lector["Precio"];


                    comp.Producto = new Producto();
                    comp.Producto.Id = (Int64)lector["IdProducto"];
                    comp.Producto.Nombre = (string)lector["Producto"];


                    comp.Proveedor = new Proveedor();
                    comp.Proveedor.Id = (Int64)lector["IdProveedor"];
                    comp.Proveedor.Nombre = (string)lector["Proveedor"];

                    lista.Add(comp);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarConSP(Compra item)
        {

            AccesoDatos datos = new AccesoDatos();
   
            try
            {
                    datos.setearProcedimiento("SP_AgregarCompra");
                    datos.setearParametro("@IDProducto", item.Producto.Id);
                    datos.setearParametro("@IdProveedor", item.Proveedor.Id);
                    datos.setearParametro("@Cantidad", item.Cantidad);
                    datos.setearParametro("@Precio", item.Precio);

                    datos.ejectutarAccion();
                    datos.cerrarConexion();

                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
