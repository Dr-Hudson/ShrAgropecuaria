using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.MySqlRepository
{
    class Connection
    {
        public static MySqlConnection GetConnection()
        {
            //return new MySqlConnection("Server=127.0.0.1;port=3311;Database=unoeste;Uid=root;Pwd=;");
            return new MySqlConnection("Server=den1.mysql6.gear.host;port=3306;Database=engenharia2;Uid=engenharia2;Pwd=Engg123!;");
        }
    }
}
