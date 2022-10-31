using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        /**
        public List<Marca> listar(bool combobox = false)
        {
            List<Marca> lista = new List<Marca>();

            AccesoDatos datos = new AccesoDatos();

            if (combobox)
            {
                Marca estado0 = new Marca();

                estado0.ID = -1;
                estado0.Nombre = "--Seleccione Marca--";
                estado0.Estado = true;

                lista.Add(estado0);
            }

            try
            {
                datos.setearConsulta("select ID, Descripcion, Estado from Marcas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Descripcion"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    if (aux.Estado != false)
                    {
                        lista.Add(aux);
                    }
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
                string valores = "values('"
                    + nuevo.Nombre + "')";

                datos.setearConsulta("insert into Marcas(Descripcion) "
                    + valores);

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
