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
    class MySqlFiadoRepository : MySqlRepository, IFiadoRepository
    {
        public MySqlFiadoRepository(IDbConnection connection) : base(connection)
        {

        }

        public IEnumerable<Cliente> BuscaPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> BuscaPorNome(string nome)
        {
            string sql = @"select cli.*, cid.* from cliente cli
                            inner join cidade cid on cid.cid_cod = cli.cid_cod
                            inner join estado est on est.est_uf = cid.est_uf
                            where cli.cli_nome like @Nome";
            return Connection.Query<Cliente, Cidade, Estado, Cliente>(sql, (cliente, cidade, estado) =>
            {
                cliente.Cidade = cidade;
                cliente.Cidade.Estado = estado;
                return cliente;
            }, new { Nome = "%" + nome + "%" }, splitOn: "cid_cod, est_uf");
        }

        public void Grava(Cliente cli)
        {
            Connection.Execute("update cliente set cli_saldofiado = @cli_saldofiado "
                   + "where cli_cod = @cli_cod", cli);
        }
    }
}
