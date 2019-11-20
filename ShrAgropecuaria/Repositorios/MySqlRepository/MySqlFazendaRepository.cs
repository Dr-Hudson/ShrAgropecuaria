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
    class MySqlFazendaRepository : MySqlRepository, IFazendaRepository
    {
        public MySqlFazendaRepository(IDbConnection connection) : base(connection)
        {

        }

        public IEnumerable<Fazenda> GetAll(string nome)
        {
            string sql = @"select faz.*, cli.*, cid.*, est.* from fazenda faz
                            inner join cliente cli on cli.cli_cod = faz.cli_cod
                            inner join cidade cid on cid.cid_cod = faz.cid_cod
                            inner join estado est on est.est_uf = cid.est_uf
                            where faz.faz_nome like @nome";
            return Connection.Query<Fazenda, Cliente, Cidade, Estado, Fazenda>(sql, (fazenda, cliente, cidade, estado) =>
            {
                fazenda.Cidade = cidade;
                fazenda.Cidade.Estado = estado;
                fazenda.Cliente = cliente;
                return fazenda;
            }, new { nome = "%" + nome + "%" }, splitOn: "cli_cod, cid_cod, est_uf");
        }

        public IEnumerable<Fazenda> GetByNome(string Nome)
        {
            string sql = @"select faz.*, cid.*, cli.* from fazenda faz
                            inner join cliente cli on cli.cli_cod = faz.cli_cod
                            inner join cidade cid on cid.cid_cod = faz.cid_cod
                            inner join estado est on est.est_uf = cid.est_uf
                            where faz.faz_nome like @nome";
            return Connection.Query<Fazenda, Cidade, Cliente, Estado, Fazenda>(sql, (fazenda, cidade, cliente, estado) =>
            {
                fazenda.Cidade = cidade;
                fazenda.Cidade.Estado = estado;
                fazenda.Cliente = cliente;
                return fazenda;
            }, new { nome = "%" + Nome + "%" }, splitOn: "cid_cod, est_uf");
        }

        public IEnumerable<Fazenda> GetByIE(string ie)
        {
            string sql = @"select faz.*, cid.*, cli.* from fazenda faz
                            inner join cliente cli on cli.cli_cod = faz.cli_cod
                            inner join cidade cid on cid.cid_cod = faz.cid_cod
                            inner join estado est on est.est_uf = cid.est_uf
                            where faz.faz_inscricaoestadual like @ie";
            return Connection.Query<Fazenda, Cidade, Cliente, Estado, Fazenda>(sql, (fazenda, cidade, cliente, estado) =>
            {
                fazenda.Cidade = cidade;
                fazenda.Cidade.Estado = estado;
                fazenda.Cliente = cliente;
                return fazenda;
            }, new { ie = "%" + ie + "%" }, splitOn: "cid_cod, est_uf");
        }
    }
}
