using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class ClienteNegocio
    {
        public Cliente ObtenerPorDocumento(string documento)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@"SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP 
                                       FROM Clientes 
                                       WHERE Documento = @doc");
                datos.SetearParametro("@doc", documento);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    var c = new Cliente();
                    c.Id = (int)datos.Lector["Id"];
                    c.Documento = (string)datos.Lector["Documento"];
                    c.Nombre = (string)datos.Lector["Nombre"];
                    c.Apellido = (string)datos.Lector["Apellido"];
                    c.Email = (string)datos.Lector["Email"];
                    c.Direccion = (string)datos.Lector["Direccion"];
                    c.Ciudad = (string)datos.Lector["Ciudad"];
                    c.CP = (int)datos.Lector["CP"];
                    return c;
                }

                return null;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public int Guardar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (cliente.Id == 0)
                {
                    datos.SetearConsulta(
                        @"INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP)
                          VALUES (@doc, @nombre, @apellido, @mail, @dir, @ciudad, @cp);
                          SELECT SCOPE_IDENTITY();");

                    datos.SetearParametro("@doc", cliente.Documento);
                    datos.SetearParametro("@nombre", cliente.Nombre);
                    datos.SetearParametro("@apellido", cliente.Apellido);
                    datos.SetearParametro("@mail", cliente.Email);
                    datos.SetearParametro("@dir", cliente.Direccion);
                    datos.SetearParametro("@ciudad", cliente.Ciudad);
                    datos.SetearParametro("@cp", cliente.CP);

                    datos.EjecutarLectura();

                    if (datos.Lector.Read())
                        return Convert.ToInt32(datos.Lector[0]);

                    return 0;
                }
                else
                {
                    datos.SetearConsulta(
                        @"UPDATE Clientes SET 
                            Nombre = @nombre, 
                            Apellido = @apellido, 
                            Email = @mail, 
                            Direccion = @dir, 
                            Ciudad = @ciudad, 
                            CP = @cp
                          WHERE Id = @id");

                    datos.SetearParametro("@nombre", cliente.Nombre);
                    datos.SetearParametro("@apellido", cliente.Apellido);
                    datos.SetearParametro("@mail", cliente.Email);
                    datos.SetearParametro("@dir", cliente.Direccion);
                    datos.SetearParametro("@ciudad", cliente.Ciudad);
                    datos.SetearParametro("@cp", cliente.CP);
                    datos.SetearParametro("@id", cliente.Id);

                    datos.EjecutarAccion();
                    return cliente.Id;
                }
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }
}
