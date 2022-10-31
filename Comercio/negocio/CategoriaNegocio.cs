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
/*
        public List<Categoria> listar(bool combobox = false)
        {
            List<Categoria> lista = new List<Categoria>();

            AccesoDatos datos = new AccesoDatos();

            if (combobox)
            {
                Categoria estado0 = new Categoria();

                estado0.ID = -1;
                estado0.Nombre = "--Seleccione Categoría--";
                estado0.Estado = true;

                lista.Add(estado0);
            }

            try
            {
                datos.setearConsulta("select ID, Descripcion, Estado from Categorias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();

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

        public void agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values('"
                    + nuevo.Nombre + "')";

                datos.setearConsulta("insert into Categorias(Descripcion) "
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
