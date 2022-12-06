using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VentaNegocio
    {
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
