using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ProveedoresNegocio
    {
        public List<Proveedores> listarSP()
        {
            List<Proveedores> lista = new List<Proveedores>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ListaProveedores");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Proveedores aux = new Proveedores();
                    aux.Id = (Int64)datos.Lector["IdProveedores"];
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
        public void agregarConSP(Proveedores nuevo)
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
    }
}
