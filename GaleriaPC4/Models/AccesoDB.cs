using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GaleriaPC4.Models
{
    public class AccesoDB
    {
        public List<Categoria> obtenerCategorias()
        {
            var lista = new List<Categoria>();
            var cadena = ConfigurationManager.ConnectionStrings["ConnectionGaleria"];
            
            using (var conexion = new SqlConnection(cadena.ConnectionString))
            {
                conexion.Open();

                var query = "SELECT * FROM Categorias";

                using (var comando = new SqlCommand(query,conexion))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categoria = new Categoria();
                            categoria.id = Convert.ToInt32(reader[0]);
                            categoria.nombre = reader[1].ToString();

                            lista.Add(categoria);
                        }
                    }
                }
            }

            return lista;
        }

        public List<Foto> obtenerFotos(int CatId)
        {
            var lista = new List<Foto>();
            var cadena = ConfigurationManager.ConnectionStrings["ConnectionGaleria"];

            using (var conexion = new SqlConnection(cadena.ConnectionString))
            {
                conexion.Open();

                var query = $"SELECT * FROM Fotos Where (CategoriaId = '{CatId}')";

                using (var comando = new SqlCommand(query, conexion))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var foto = new Foto();
                            foto.id = Convert.ToInt32(reader[0]);
                            foto.foto = reader[1].ToString();
                            foto.likes = Convert.ToInt32(reader[2]);
                            foto.dislikes = Convert.ToInt32(reader[3]);
                            foto.categoriaId = Convert.ToInt32(reader[4]);

                            lista.Add(foto);
                        }
                    }
                }
            }

            return lista;
        }

        public List<Foto> obtenerFoto(int codFoto)
        {
            var lista = new List<Foto>();
            var cadena = ConfigurationManager.ConnectionStrings["ConnectionGaleria"];

            using (var conexion = new SqlConnection(cadena.ConnectionString))
            {
                conexion.Open();

                var query = $"SELECT * FROM Fotos Where (Id = '{codFoto}')";

                using (var comando = new SqlCommand(query, conexion))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var foto = new Foto();
                            foto.id = Convert.ToInt32(reader[0]);
                            foto.foto = reader[1].ToString();
                            foto.likes = Convert.ToInt32(reader[2]);
                            foto.dislikes = Convert.ToInt32(reader[3]);
                            foto.categoriaId = Convert.ToInt32(reader[4]);

                            lista.Add(foto);
                        }
                    }
                }
            }

            return lista;
        }

        public void DarLike(int idFoto)
        {
            var cadena = ConfigurationManager.ConnectionStrings["ConnectionGaleria"];
            using (var conexion = new SqlConnection(cadena.ConnectionString))
            {
                conexion.Open();

                var query = $"Update Fotos Set Likes = Likes + 1 Where (Id = '{idFoto}')";

                using (var comando  = new SqlCommand(query, conexion))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void DarDislike(int idFoto)
        {
            var cadena = ConfigurationManager.ConnectionStrings["ConnectionGaleria"];
            using (var conexion = new SqlConnection(cadena.ConnectionString))
            {
                conexion.Open();

                var query = $"Update Fotos Set Dislikes = Dislikes + 1 Where (Id = '{idFoto}')";

                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }

        //public int getCategoryId(int codFoto)
        //{
        //    int categoriaId = 0;
        //    var lista = new List<Foto>();
        //    var cadena = ConfigurationManager.ConnectionStrings["ConnectionGaleria"];

        //    using (var conexion = new SqlConnection(cadena.ConnectionString))
        //    {
        //        conexion.Open();

        //        var query = $"SELECT Categorias.Id FROM Categorias JOIN Fotos ON (Fotos.Id == Categorias.Id) Where (Fotos.Id = '{codFoto}')";

        //        using (var comando = new SqlCommand(query, conexion))
        //        {
        //            using (var reader = comando.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    categoriaId = Convert.ToInt32(reader[0]);
        //                }
        //            }
        //        }
        //    }

        //    return categoriaId;
        //}
    }

}