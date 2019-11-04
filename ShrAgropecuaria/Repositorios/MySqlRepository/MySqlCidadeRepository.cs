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
    class MySqlCidadeRepository :  MySqlRepository, ICidadeRepository
    {
        public MySqlCidadeRepository(IDbConnection connection) : base(connection)
        {
        }

        public Cidade Get(int? id)
        {
            if (id != null)
            {
                return Connection.Query<Cidade>("select * from cidade where cid_id = @id", new { id = id }).FirstOrDefault();
            }
            return null;
        }

        public Cidade PegaId(string nome)
        {
            string sql = @"select *
                    from cidade
                    where cid_nome = @nome";
            return Connection.Query<Cidade>(sql, new { nome }).FirstOrDefault();
        }

        public IEnumerable<Cidade> GetByNome(string nome)
        {
            string sql = @"select *
                    from cidade 
                    where nome like @nome";
            return Connection.Query<Cidade>(sql, new { nome = "%" + nome + "%" });
        }

        public IEnumerable<Cidade> GetById(int id)
        {
            string sql = @"select *
                    from cidade
                    where cid_id = @id";
            return Connection.Query<Cidade>(sql, new { id });
        }

        public IEnumerable<Cidade> GetAll()
        {
            return Connection.Query<Cidade>("select * from cidade order by cid_nome");
        }
    }
}
