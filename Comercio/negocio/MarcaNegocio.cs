using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {

        //public List<Marca> listar(bool combobox = false)
        //{
        //    List<Marca> lista = new List<Marca>();

        //    AccesoDatos datos = new AccesoDatos();

        //    if (combobox)
        //    {
        //        Marca estado0 = new Marca();

        //        estado0.Id = -1;
        //        estado0.NombreMarca = "--Seleccione Marca--";

        //        lista.Add(estado0);
        //    }

        //    try
        //    {
        //        datos.setearConsulta("Select IdMarca,Nombre from marcas");
        //        datos.ejecutarLectura();

        //        while (datos.Lector.Read())
        //        {
        //            Marca aux = new Marca();

        //            aux.Id = (Int64)datos.Lector["IdMarca"];
        //            aux.NombreMarca = (string)datos.Lector["Nombre"];



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

        
        public List<Marca> listar (string id = "")
        {
            List<Marca> lista = new List<Marca>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=TP_Comercio; integrated security= true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select IdMarca, Nombre from Marcas ";
                if (id != "")
                    comando.CommandText += "where IdMarca= " + id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (Int64)lector["IdMarca"];
                    marca.NombreMarca = (string)lector["Nombre"];

                    lista.Add(marca);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Devuelve lista completa de Marcas
        public List<Marca> listarSP()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ListaMarcas");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (Int64)datos.Lector["IdMarca"];
                    aux.NombreMarca = (string)datos.Lector["Nombre"];
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

        public void agregar(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values('" + nuevo.NombreMarca + "')";

                datos.setearConsulta("insert into Marcas (Nombre) " + valores);

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
        public void modificarConSP(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ModificaMarca");
                datos.setearParametro("@IdMarca", marca.Id);
                datos.setearParametro("@Nombre", marca.NombreMarca);




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
                public void modificar(Marca modificar)
                {
                    AccesoDatos datos = new AccesoDatos();
                    try
                    {

                        datos.setearConsulta(
                            "update Marcas set Descripcion = '" + modificar.Nombre + "'where ID = " + modificar.ID);

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
                        Marca aux = new Marca();

                        aux.ID = ID;
                        aux.Estado = false;

                        datos.setearConsulta(
                            "update Marcas set Estado = 0 where ID = " + aux.ID);

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
