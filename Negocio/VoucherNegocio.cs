using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class VoucherNegocio
    {
        public Voucher ObtenerPorCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher = @codigo");
                datos.SetearParametro("@codigo", codigo);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    Voucher v = new Voucher();
                    v.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];
                    v.IdCliente = datos.Lector["IdCliente"] != DBNull.Value ? (int?)Convert.ToInt32(datos.Lector["IdCliente"]) : null;
                    v.FechaCanje = datos.Lector["FechaCanje"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(datos.Lector["FechaCanje"]) : null;
                    v.IdArticulo = datos.Lector["IdArticulo"] != DBNull.Value ? (int?)Convert.ToInt32(datos.Lector["IdArticulo"]) : null;

                    return v;
                }

                return null;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void RegistrarCanje(string codigoVoucher, int idCliente, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(
                    @"UPDATE Vouchers 
                      SET IdCliente = @idCliente,
                          FechaCanje = @fecha,
                          IdArticulo = @idArticulo
                      WHERE CodigoVoucher = @codigo");

                datos.SetearParametro("@idCliente", idCliente);
                datos.SetearParametro("@fecha", DateTime.Now.Date);
                datos.SetearParametro("@idArticulo", idArticulo);
                datos.SetearParametro("@codigo", codigoVoucher);

                datos.EjecutarAccion();
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
