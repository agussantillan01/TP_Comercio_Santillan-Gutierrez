using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listar(string id = "")
        {
            List<Proveedor> lista = new List<Proveedor>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=TP_Comercio; integrated security= true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select IdProveedor, Nombre,Cuil,Domicilio,Email from Proveedores ";
                if (id != "")
                    comando.CommandText += "Where IdProveedor=" + id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Proveedor prove = new Proveedor();
                    prove.Id = (Int64)lector["IdProveedor"];
                    prove.Nombre = (string)lector["Nombre"];
                    prove.Cuil = (string)lector["Cuil"];
                    prove.Domicilio= (string)lector["Domicilio"];
                    prove.Email = (string)lector["Email"];


                    lista.Add(prove);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<Proveedor> listarSP()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ListaProveedores");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.Id = (Int64)datos.Lector["IdProveedor"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Domicilio = (string)datos.Lector["Domicilio"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Cuil = (string)datos.Lector["Cuil"];
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
        }
        public void agregarConSP(Proveedor nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AgregarProveedores");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Domicilio", nuevo.Domicilio);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Cuil", nuevo.Cuil);


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
        public void modificarConSP (Proveedor prove)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ModificaProveedor");
                datos.setearParametro("@IdProveedor", prove.Id);
                datos.setearParametro("@Nombre", prove.Nombre);
                datos.setearParametro("@Cuil", prove.Cuil);
                datos.setearParametro("@Domicilio", prove.Domicilio);
                datos.setearParametro("@Email", prove.Email);





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
