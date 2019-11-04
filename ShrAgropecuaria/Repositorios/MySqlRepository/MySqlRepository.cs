using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.MySqlRepository
{
    class MySqlRepository
    {
        public MySqlConnection Connection { get; set; }

        public MySqlRepository(IDbConnection connection)
        {
            Connection = connection as MySqlConnection;
        }
    }
}
