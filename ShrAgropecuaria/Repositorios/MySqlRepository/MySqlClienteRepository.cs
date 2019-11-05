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
    class MySqlClienteRepository : MySqlRepository, IClienteRepository
    {
        public MySqlClienteRepository(IDbConnection connection) : base(connection)
        {

        }

        public void Excluir(Cliente cli)
        {
            Connection.Execute("delete from cliente where cli_cod = @cli_cod", cli);
        }

        public Cliente Get(int? id)
        {
            if (id != null)
            {
                return Connection.Query<Cliente>("select * from cliente where cli_cod = @id", new { id }).FirstOrDefault();
            }
            return null;
        }

        public void Gravar(Cliente cli)
        {
            if (cli.Cli_cod == null)
            {
                Connection.Execute("INSERT INTO cliente " +
                    "(cli_cod, cli_dataliberacao, cli_limite, cli_saldofiado, cli_bairro, cli_cep, cli_complemento, cli_numero, cli_nome, cli_cpf, cli_rg, cli_endereco, cli_telefone, cid_cod) " + 
                    "VALUES (@cli_cod, @cli_dataliberacao, @cli_limite, @cli_saldofiado, @cli_bairro, @cli_cep, @cli_complemento, @cli_numero, @cli_nome, @cli_cpf, @cli_rg, @cli_endereco, " +
                    " @cli_telefone, @cid_cod)", cli);
            }
            else
            {
                Connection.Execute("UPDATE cliente SET cli_dataliberacao = @cli_dataliberacao, cli_limite = @cli_limite, cli_saldofiado = @cli_saldofiado, cli_bairro = @cli_bairro," +
                    "cli_cep = @cli_cep, cli_complemento = @cli_complemento, cli_numero = @cli_numero, cli_nome = @cli_nome, cli_cpf = @cli_cpf, cli_rg = @cli_rg, cli_endereco = @cli_endereco, " +
                    "cli_telefone = @cli_telefone, cid_cod = @cid_cod WHERE cli_cod = @cli_cod;", cli);
            }
        }

        public Cliente PegaId(string nome)
        {
            string sql = @"select cli.*, cid.* from cliente cli
                            inner join cidade cid on cid.cid_cod = cli.cid_cod
                            where cli.cli_nome like @nome";
            return Connection.Query<Cliente>(sql, new { nome = "'%" + nome + "%'" }).FirstOrDefault();
        }

        public IEnumerable<Cliente> GetAll(string nome)
        {
            string sql = @"select cli.*, cid.* from cliente cli
                            inner join cidade cid on cid.cid_cod = cli.cid_cod
                            inner join estado est on est.est_uf = cid.est_uf
                            where forn.cli_nome like @nome";
            return Connection.Query<Cliente, Cidade, Estado, Cliente>(sql, (cliente, cidade, estado) =>
            {
                cliente.Cidade = cidade;
                cliente.Cidade.Estado = estado;
                return cliente;
            }, new { nome = "'%" + nome + "%'" }, splitOn: "cid_cod, est_uf");
        }

        public IEnumerable<Cliente> GetById(int id)
        {
            string sql = @"select cli.*, cid.* from cliente cli
                            inner join cidade cid on cid.cid_cod = cli.cid_cod
                            where cli.cli_cod = @id";
            return Connection.Query<Cliente, Cidade, Cliente>(sql, (cliente, cidade) =>
            {
                cliente.Cidade = cidade;
                return cliente;
            }, new { id });
        }

        public IEnumerable<Cliente> GetByNome(string Nome)
        {
            string sql = @"select cli.*, cid.* from cliente cli
                            inner join cidade cid on cid.cid_cod = cli.cid_cod
                            inner join estado est on est.est_uf = cid.est_uf
                            where forn.cli_nome like @nome";
            return Connection.Query<Cliente, Cidade, Estado, Cliente>(sql, (cliente, cidade, estado) =>
            {
                cliente.Cidade = cidade;
                cliente.Cidade.Estado = estado;
                return cliente;
            }, new { nome = "'%" + Nome + "%'" }, splitOn: "cid_cod, est_uf");
        }
    }
}
