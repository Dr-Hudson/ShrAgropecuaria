using Dapper;
using ShrAgropecuaria.Classes;
using ShrAgropecuaria.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.MySqlRepository
{
    class MySqlDespesaRepository : MySqlRepository, IDespesaRepository
    {

        public MySqlDespesaRepository (IDbConnection connection): base(connection)
        {

        }

        public Despesa Get(int? id)
        {
            
            if (id != null)
            {
                return Connection.Query<Despesa>("select * from despesas where desp_cod = @id", new { id = id }).FirstOrDefault();

            }
            return null;

        }

        public IEnumerable<Despesa> GetAll()
        {
            return Connection.Query<Despesa>("select * from despesas");
        }

        public Despesa GetNome(string nome)
        {
            return Connection.Query<Despesa>("select * from despesas where desp_descricao = @desp_descricao", new { desp_descricao = nome }).FirstOrDefault();
        }
    }
}
