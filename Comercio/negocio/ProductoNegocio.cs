using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Xml.Linq;


namespace negocio
{
    public class ProductoNegocio
    {

        public List<Producto> listar(string id="")
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=TP_Comercio; integrated security= true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select PR.IdProducto, PR.Nombre,T.IdTipo,T.Nombre AS Tipo, PR.Descripcion,M.IdMarca,M.Nombre AS Marca,PR.Stock, PR.StockMinimo, PR.Precio, PR.Estado, PR.Estado from Productos PR Inner join Tipo_Productos T On T.IdTipo=PR.IdTipo Inner join Marcas M On M.IdMarca = PR.IdMarca ";
                if (id != "")
                comando.CommandText += "where PR.IdProducto = " + id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (Int64)lector["IdProducto"];
                    prod.Nombre = (string)lector["Nombre"];
                    prod.Descripcion = (string)lector["Descripcion"];
                    prod.stock = (int)lector["Stock"];
                    prod.stockMinimo = (Int16)lector["StockMinimo"];
                    prod.Precio = (decimal)lector["Precio"];
                    prod.Estado = (bool)lector["Estado"];


                    prod.Tipo = new Tipo();
                    prod.Tipo.IdTipo = (Int64)lector["IdTipo"];
                    prod.Tipo.NombreTipo = (string)lector["Tipo"];


                    prod.Marca = new Marca();
                    prod.Marca.Id = (Int64)lector["IdMarca"];
                    prod.Marca.NombreMarca = (string)lector["Marca"];

                    lista.Add(prod);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void agregarConSP(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AgregarProducto");
                datos.setearParametro("@Nombre",nuevo.Nombre);
                datos.setearParametro("@IdTipo",nuevo.Tipo.IdTipo);
                datos.setearParametro("@Descripcion",nuevo.Descripcion);
                datos.setearParametro("@IdMarca",nuevo.Marca.Id);
                datos.setearParametro("@Stock",nuevo.stock);
                datos.setearParametro("@StockMinimo", nuevo.stockMinimo);
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


        public void modificarConSP(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ModificaProducto");
                datos.setearParametro("@Id", producto.Id);
                datos.setearParametro("@Nombre", producto.Nombre);
                datos.setearParametro("@IdTipo", producto.Tipo.IdTipo);
                datos.setearParametro("@Descripcion", producto.Descripcion);
                datos.setearParametro("@IdMarca", producto.Marca.Id);
                datos.setearParametro("@Stock", producto.stock);
                datos.setearParametro("@StockMinimo", producto.stockMinimo);
                datos.setearParametro("@Precio", producto.Precio);







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

        public void eliminarConSP(int ID)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                Producto aux = new Producto();
                datos.setearProcedimiento("SP_EliminaProducto");
                datos.setearParametro("@Id", ID);
  
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

            /**
            public void agregar(Producto nuevo)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    string valores = "values('"
                        + nuevo.Codigo + "', '"
                        + nuevo.Nombre + "', '"
                        + nuevo.Descripcion + "', "
                        + nuevo.Marca.ID + ", "
                        + nuevo.Categoria.ID + ", '"
                        + nuevo.UrlImagen + "', "
                        + nuevo.Precio + ", "
                        + nuevo.Stock + ", 1 )";

                    datos.setearConsulta("insert into Articulos(Codigo, Nombre, Descripcion,IDMarca,IDCategoria,ImagenUrl,Precio,Stock,Estado)" + valores);


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

            public void modificar(Producto modificar)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {


                    //datos.setearConsulta("update Articulos set codigo = '" + modificar.Codigo + "', nombre = '" + modificar.Nombre + "', Descripcion = '" + modificar.Descripcion +
                    //    "', IdMarca = " + modificar.Marca.ID + ", IdCategoria = " + modificar.Categoria.ID + ", ImagenUrl = '" + modificar.UrlImagen + "', Precio = " + modificar.Precio + ", Stock = " + modificar.Stock + ", Estado = 1 WhERE id = " + modificar.ID + ";");

                    datos.setearConsulta("update Articulos set codigo = @codigo, nombre = @nombre, Descripcion = @descripcion, IdMarca = @IDMarca, IdCategoria = @IDCategoria, ImagenUrl = @imagenUrl, Precio = @precio, Stock = @stock, Estado = 1 WhERE Id = " + modificar.ID + "");

                    datos.agregarParametro("@codigo", modificar.Codigo);
                    datos.agregarParametro("@nombre", modificar.Nombre);
                    datos.agregarParametro("@descripcion", modificar.Descripcion);
                    datos.agregarParametro("@IDMarca", modificar.Marca.ID);
                    datos.agregarParametro("@IDCategoria", modificar.Categoria.ID);
                    datos.agregarParametro("@imagenUrl", modificar.UrlImagen);
                    datos.agregarParametro("@precio", modificar.Precio);
                    datos.agregarParametro("@stock", modificar.Stock);


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

            public void eliminar(int ID)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    Producto aux = new Producto();

                    aux.ID = ID;
                    aux.Estado = false;

                    datos.setearConsulta(
                        "update Articulos set Estado = 0 where ID = " + aux.ID + ""
                        );

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
            }*/
        }
    }
}
