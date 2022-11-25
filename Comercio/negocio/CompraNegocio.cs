using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                comando.CommandText = "Select PR.IdProducto, PR.Nombre AS Producto,C.Id,C.Cantidad,M.Id,M.Nombre AS Proveedor,PR.Stock, PR.Precio from Productos PR Inner join Tipo_Productos T On T.IdTipo=PR.IdTipo Inner join Marcas M On M.IdMarca = PR.IdMarca ";
                if (id != "")
                    comando.CommandText += "where PR.IdCompra = " + id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Compra comp = new Compra();
                    comp.Id = (Int64)lector["Id"];
                    comp.Cantidad = (Int16)lector["Cantidad"];
                    comp.Precio = (decimal)lector["Precio"];


                    comp.Producto = new Producto();
                    comp.Producto.Id = (Int64)lector["IdProducto"];
                    comp.Producto.Nombre = (string)lector["Nombre"];


                    comp.Proveedor = new Proveedor();
                    comp.Proveedor.Id = (Int64)lector["IdProveedor"];
                    comp.Proveedor.Nombre = (string)lector["Nombre"];

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

    /*    public List<Compra> listarSP()
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ListaCompra"); //falta hacer SP

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Compra aux = new Compra();
                    aux.Id = (Int64)datos.Lector["Id"];
                    aux.Producto = datos.Lector["Producto"]; //revisar todo
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }*/
        public void agregarConSP(Compra nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AgregarProducto");
                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@Producto", nuevo.Producto);
                datos.setearParametro("@Proveedor", nuevo.Proveedor);
                datos.setearParametro("@Cantidad", nuevo.Cantidad);
                datos.setearParametro("@Precio", nuevo.Precio);

                datos.ejectutarAccion();

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
