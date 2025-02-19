
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
    public class MunicipalityRepository : IMunicipalityRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public MunicipalityRepository(MySQLConfiguration connectionString) 
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteMun(Municipio mun)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM municipio WHERE idmunicipio = @IdMunicipio ";
            var result = await db.ExecuteAsync(sql, new {idmunicipio= mun.IdMunicipio});

            return result > 0;
        }

        public async Task<IEnumerable<Municipio>> GetAllMun()
        {
            var db = dbConnection();

            var sql = @" SELECT idmunicipio, nombre, departamento_id FROM municipio";

            return await db.QueryAsync<Municipio>(sql, new {});
        }

        public async Task<Municipio> GetDetailsMun(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT idmunicipio, nombre, departamento_id FROM municipio WHERE idmunicipio = @IdMunicipio ";

            return await db.QueryFirstOrDefaultAsync<Municipio>(sql, new {IdMunicipio = id }); ;
        }

        public async Task<bool> InsertMun(Municipio mun)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO municipio (idmunicipio, nombre, departamento_id)
            VALUES (@IdMunicipio, @Nombre, @Departamento_Id) ";


            var result = await db.ExecuteAsync(sql, new 
                { mun.IdMunicipio, mun.Nombre, mun.Departamento_Id});

            return result > 0;
        }

        public async Task<bool> UpdateMun(Municipio mun)
        {
            var db = dbConnection();

            var sql = @" UPDATE municipio
                        SET
                            nombre = @Nombre, 
                            departamento_id = @Departamento_Id
                        WHERE idmunicipio = @IdMunicipio ";

            var result = await db.ExecuteAsync(sql, new
            { mun.IdMunicipio, mun.Nombre, mun.Departamento_Id });

            return result > 0;
        }
    }
}
