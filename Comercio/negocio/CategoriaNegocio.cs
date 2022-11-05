using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {

        public List<Tipo> listar(bool combobox = false)
        {
            List<Tipo> lista = new List<Tipo>();

            AccesoDatos datos = new AccesoDatos();

            if (combobox)
            {
                Tipo estado0 = new Tipo();

                estado0.IdTipo = -1;
                estado0.NombreTipo = "--Seleccione Categoría--";

                lista.Add(estado0);
            }

            try
            {
                datos.setearConsulta("select IdTipo, Nombre from Tipo_productos");
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
