using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VentaNegocio
    {
        public List<Venta> listar(string id = "")
        {
            List<Venta> lista = new List<Venta>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=TP_Comercio; integrated security= true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select PR.IdProducto, PR.Nombre AS Producto, V.IdVentaMovimiento AS Factura,V.Cantidad, C.Nombre AS Cliente, V.Precio from Ventas_Movimiento V Inner join Productos PR  On V.IdVentaMovimiento=PR.IdProducto Inner join Clientes C On C.IdCliente = V.IdCliente";
                if (id != "")
                    comando.CommandText += "where V.IdVentaMovimiento = " + id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Venta vent = new Venta();
                    vent.Id = (Int64)lector["Factura"];
                    vent.Cantidad = (Int16)lector["Cantidad"];
                    vent.Precio = (decimal)lector["Precio"];


                    vent.Producto = new Producto();
                    vent.Producto.Id = (Int64)lector["IdProducto"];
                    vent.Producto.Nombre = (string)lector["Producto"];


                    vent.Cliente = new Cliente();
                    vent.Cliente.Id = (Int64)lector["IdCliente"];
                    vent.Cliente.Nombre = (string)lector["Cliente"];
                    vent.Cliente.Email = (string)lector["Email"];

                    lista.Add(vent);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void agregarConSP(Venta item)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AgregarVenta");
                datos.setearParametro("@IdCliente", item.Cliente.Id);
                datos.setearParametro("@IdProducto", item.Producto.Id);
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
