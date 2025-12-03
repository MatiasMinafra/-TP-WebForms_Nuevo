using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulos> Listar()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(
                    @"SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio,
                             M.Id AS IdMarca, M.Descripcion AS MarcaDesc,
                             C.Id AS IdCategoria, C.Descripcion AS CatDesc
                      FROM ARTICULOS A
                      LEFT JOIN MARCAS M ON A.IdMarca = M.Id
                      LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos art = new Articulos();
                    art.Id = (int)datos.Lector["Id"];
                    art.Codigo = datos.Lector["Codigo"]?.ToString();
                    art.Nombre = datos.Lector["Nombre"]?.ToString();
                    art.Descripcion = datos.Lector["Descripcion"]?.ToString();
                    art.Precio = datos.Lector["Precio"] != DBNull.Value ? (decimal)datos.Lector["Precio"] : 0;

                    art.Marca = new Marca
                    {
                        Id = datos.Lector["IdMarca"] != DBNull.Value ? (int)datos.Lector["IdMarca"] : 0,
                        Descripcion = datos.Lector["MarcaDesc"]?.ToString()
                    };

                    art.Categoria = new Categoria
                    {
                        Id = datos.Lector["IdCategoria"] != DBNull.Value ? (int)datos.Lector["IdCategoria"] : 0,
                        Descripcion = datos.Lector["CatDesc"]?.ToString()
                    };

                    lista.Add(art);
                }

                return lista;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<string> ListarImagenes(int idArticulo)
        {
            List<string> lista = new List<string>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo = @id");
                datos.SetearParametro("@id", idArticulo);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(datos.Lector["ImagenUrl"].ToString());
                }

                return lista;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}