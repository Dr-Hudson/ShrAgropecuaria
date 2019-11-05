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
                return Connection.Query<Cidade>("select * from cidade where cid_cod = @id", new { id = id }).FirstOrDefault();
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
            string sql = @"select cid.*, est.* 
                    from cidade cid
                    inner join estado est on cid.est_uf = est.est_uf
                    where cid.cid_nome like @nome";
            return Connection.Query<Cidade, Estado, Cidade>(sql, (cidade,estado) =>
            {
                cidade.Estado = estado;
                return cidade;
            }, new {nome = "%" + nome + "%"}, splitOn: "est_uf");
        }

        public IEnumerable<Cidade> GetById(int id)
        {
            string sql = @"select *
                    from cidade
                    where cid_cod = @id";
            return Connection.Query<Cidade>(sql, new { id });
        }

        public IEnumerable<Cidade> GetAll()
        {
            string sql = "select cid.* , esta.* from cidade cid " +
                "inner join estado esta on cid.est_uf = esta.est_uf";
                
            return Connection.Query<Cidade, Estado, Cidade>(sql, (cidade, estado) =>
              {
                  cidade.Estado = estado;
                  return cidade;
              } ,splitOn: "est_uf");
        }
    }
}
