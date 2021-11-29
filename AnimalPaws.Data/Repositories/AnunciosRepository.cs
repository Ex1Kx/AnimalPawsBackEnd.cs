using AnimalPaws.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPaws.Data.Repositories
{
    public class AnunciosRepository : IAnuncios
    {
        private MySqlConfiguration _connectionString;
        public AnunciosRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<Anuncios>> GetAnuncios()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_anuncios, titulo, descripcion, imagen
                        FROM anuncios";
            return await db.QueryAsync<Anuncios>(sql, new { });
        }

        public async Task<bool> insertAnuncios(Anuncios anuncios)
        {
            var db = dbConnection();

            var sql = @"
                         INSERT INTO anuncios (titulo, descripcion, imagen)
                         VALUES (@titulo, @descripcion, @imagen)";
            var result = await db.ExecuteAsync(sql, new { anuncios.titulo, anuncios.descripcion, anuncios.imagen});

            return result > 0;

        }
    }
}
