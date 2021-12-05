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
    public class UsuariosRepository : IUsuarios
    {
        private MySqlConfiguration _connectionString;
        public UsuariosRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<Usuarios>> GetUsuarios()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_usuarios, nombres, email, password, icon
                        FROM usuarios";
            return await db.QueryAsync<Usuarios>(sql, new { });
        }

        public async Task<bool> insertUsuarios(Usuarios usuarios)
        {
            var db = dbConnection();

            var sql = @"
                         INSERT INTO usuarios (nombres, email, password, icon)
                         VALUES (@nombres, @email, @password, @icon)";
            var result = await db.ExecuteAsync(sql, new { usuarios.nombres, usuarios.email, usuarios.password, usuarios.icon });

            return result > 0;
        }
    }
}
