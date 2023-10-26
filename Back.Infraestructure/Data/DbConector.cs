using FirebirdSql.Data.FirebirdClient;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Infraestructure.Data
{
    public class DbConector
    {
        private readonly IConfiguration _configuration;
        private readonly AdminContext _managerContext;
        private readonly ApplicationDbContext _appContext;

        protected DbConector(IConfiguration configuration, AdminContext managerContext, ApplicationDbContext appContext)
        {
            _configuration = configuration;
            _managerContext = managerContext;
            _appContext = appContext;
        }

        public IDbConnection CreateConnection()
        {
            string _connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqliteConnection(_connectionString);
        }

        public IDbConnection ConexionFb()
        {
            string _connectionString = _configuration.GetConnectionString("Develop");
            return new FbConnection(_connectionString);
        }

    }
}
