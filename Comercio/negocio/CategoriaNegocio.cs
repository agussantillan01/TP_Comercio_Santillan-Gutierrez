using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {

        //public List<Tipo> listar(bool combobox = false)
        //{
        //    List<Tipo> lista = new List<Tipo>();

        //    AccesoDatos datos = new AccesoDatos();

        //    if (combobox)
        //    {
        //        Tipo estado0 = new Tipo();

        //        estado0.IdTipo = -1;
        //        estado0.NombreTipo = "--Seleccione Categoría--";

        //        lista.Add(estado0);
        //    }

        //    try
        //    {
        //        datos.setearConsulta("select IdTipo, Nombre from Tipo_productos");
        //        datos.ejecutarLectura();

        //        while (datos.Lector.Read())
        //        {
        //            Tipo aux = new Tipo();

        //            aux.IdTipo = (Int64)datos.Lector["IdTipo"];
        //            aux.NombreTipo = (string)datos.Lector["Nombre"];

        //                lista.Add(aux);

        //        }

        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }

        //}
        public List<Tipo> listar(string id = "")
        {
            List<Tipo> lista = new List<Tipo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=TP_Comercio; integrated security= true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select IdTipo, Nombre from Tipo_Productos ";
                if (id != "")
                    comando.CommandText += "where IdTipo= " + id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Tipo cat = new Tipo();
                    cat.IdTipo = (Int64)lector["IdTipo"];
                    cat.NombreTipo = (string)lector["Nombre"];

                    lista.Add(cat);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Tipo> listarSP()
        {
            List<Tipo> lista = new List<Tipo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ListaCategorias");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Tipo aux = new Tipo();
                    aux.IdTipo = (Int64)datos.Lector["IdTipo"];
                    aux.NombreTipo = (string)datos.Lector["Nombre"];
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

        public void modificarConSP (Tipo tipo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ModificaCategoria");
                datos.setearParametro("@IdCategoria", tipo.IdTipo);
                datos.setearParametro("@Nombre", tipo.NombreTipo);




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
        public void agregar(Tipo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values('" + nuevo.NombreTipo + "')";

                datos.setearConsulta("INSERT INTO Tipo_Productos " + valores);

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
        /*
                public void modificar(Categoria modificar)
                {
                    AccesoDatos datos = new AccesoDatos();
                    try
                    {
                        datos.setearConsulta(
                            "update Categorias set Descripcion = '" + modificar.Nombre + "' where ID = " + modificar.ID);

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
                        Categoria aux = new Categoria();

                        aux.ID = ID;
                        aux.Estado = false;

                        datos.setearConsulta(
                            "update Categorias set Estado = 0 where ID = " + aux.ID);

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
