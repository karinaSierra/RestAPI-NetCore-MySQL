
using Dapper;
using MySql.Data.MySqlClient;
using NetCore6APIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Data.Repositories
{
    public class DepartamentoRepository : IDepartamentRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public DepartamentoRepository(MySQLConfiguration connectionString) 
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Departamento>> GetAllDep()
        {
            var db = dbConnection();

            var sql = @" SELECT iddepartamento, nombre FROM departamento";

            return await db.QueryAsync<Departamento>(sql, new { });
        }

        public async Task<bool> InsertDep(Departamento dep)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO departamento (iddepartamento, nombre)
                        VALUES (@IdDepartamento, @Nombre) ";

            var result = await db.ExecuteAsync(sql, new
            { dep.IdDepartamento, dep.Nombre });

            return result > 0;
        }

        public async Task<bool> DeleteDep(Departamento dep)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM departamento WHERE iddepartamento = @IdDepartamento ";
            var result = await db.ExecuteAsync(sql, new { IdDepartamento = dep.IdDepartamento });

            return result > 0;
        }

        public async Task<bool> UpdateDep(Departamento dep)
        {
            var db = dbConnection();

            var sql = @" UPDATE departamento
                        SET
                            nombre = @Nombre
                        WHERE iddepartamento = @IdDepartamento ";

            var result = await db.ExecuteAsync(sql, new
            { dep.IdDepartamento, dep.Nombre }); ;

            return result > 0;
        }

        public async Task<Departamento> GetDetailsDep(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT iddepartamento, nombre FROM departamento WHERE iddepartamento = @iddepartamento ";

            return await db.QueryFirstOrDefaultAsync<Departamento>(sql, new {IdDepartamento = id }); ;
        }
    }
}
