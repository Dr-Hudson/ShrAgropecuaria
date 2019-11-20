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
    class MySqlPedidoNutricaoRepository : MySqlRepository, IPedidoNutricaoRepository
    {
        public MySqlPedidoNutricaoRepository(IDbConnection connection) : base(connection)
        {

        }

        public IEnumerable<PedidoNutricao> GetByPedido(int idCli, int idFaz, bool entregue)
        {
            if (entregue)
            {
                string sql = @"select pd.*, faz.*, cli.*, usu.* from pedidonutricao pd
                            inner join fazenda faz on faz.faz_cod = pd.faz_cod
                            inner join cliente cli on cli.cli_cod = pd.cli_cod
                            inner join usuario usu on usu.user_cod = pd.user_cod
                            where pd.cli_cod = @idCli AND pd.faz_cod = @idFaz AND pd.pn_dataentrega IS NOT NULL";
                return Connection.Query<PedidoNutricao, Fazenda, Cliente, Usuario, PedidoNutricao>(sql, (pedidonutricao, fazenda, cliente, usuario) =>
                {
                    pedidonutricao.Cliente = cliente;
                    pedidonutricao.Fazenda = fazenda;
                    pedidonutricao.Usuario = usuario;
                    return pedidonutricao;
                }, new { idCli, idFaz }, splitOn: "faz_cod, cli_cod, user_cod");
            }
            else
            {
                string sql = @"select pd.*, faz.*, cli.*, usu.* from pedidonutricao pd
                            inner join fazenda faz on faz.faz_cod = pd.faz_cod
                            inner join cliente cli on cli.cli_cod = pd.cli_cod
                            inner join usuario usu on usu.user_cod = pd.user_cod
                            where pd.cli_cod = @idCli AND pd.faz_cod = @idFaz AND pd.pn_dataentrega IS NULL";
                return Connection.Query<PedidoNutricao, Fazenda, Cliente, Usuario, PedidoNutricao>(sql, (pedidonutricao, fazenda, cliente, usuario) =>
                {
                    pedidonutricao.Cliente = cliente;
                    pedidonutricao.Fazenda = fazenda;
                    pedidonutricao.Usuario = usuario;
                    return pedidonutricao;
                }, new { idCli, idFaz }, splitOn: "faz_cod, cli_cod, user_cod");
            }
        }

        public void AlterarDataEntrega(PedidoNutricao pedNutri)
        {
            if (pedNutri.Pn_dataentrega.Year.ToString() != "1")
                Connection.Execute("update pedidonutricao set pn_dataentrega = @pn_dataentrega where pn_cod = @pn_cod", pedNutri);
            else
                Connection.Execute("update pedidonutricao set pn_dataentrega = null where pn_cod = @pn_cod", pedNutri);
        }

        public IEnumerable<PedidoNutricao> GetAll()
        {
            string sql = @"select pd.*, faz.*, cli.*, usu.* from pedidonutricao pd
                            inner join fazenda faz on faz.faz_cod = pd.faz_cod
                            inner join cliente cli on cli.cli_cod = pd.cli_cod
                            inner join usuario usu on usu.user_cod = pd.user_cod";
            return Connection.Query<PedidoNutricao, Fazenda, Cliente, Usuario, PedidoNutricao>(sql, (pedidonutricao, fazenda, cliente, usuario) =>
            {
                pedidonutricao.Cliente = cliente;
                pedidonutricao.Fazenda = fazenda;
                pedidonutricao.Usuario = usuario;
                return pedidonutricao;
            }, splitOn: "faz_cod, cli_cod, user_cod");
        }

        public IEnumerable<PedidoNutricao> GetByNomeCliente(string Nome)
        {
            string sql = @"select pd.*, faz.*, cli.*, usu.* from pedidonutricao pd
                            inner join fazenda faz on faz.faz_cod = pd.faz_cod
                            inner join cliente cli on cli.cli_cod = pd.cli_cod
                            inner join usuario usu on usu.user_cod = pd.user_cod
                            where cli.cli_nome = @Nome";
            return Connection.Query<PedidoNutricao, Fazenda, Cliente, Usuario, PedidoNutricao>(sql, (pedidonutricao, fazenda, cliente, usuario) =>
            {
                pedidonutricao.Cliente = cliente;
                pedidonutricao.Fazenda = fazenda;
                pedidonutricao.Usuario = usuario;
                return pedidonutricao;
            }, new { Nome = "%" + Nome + "%" }, splitOn: "faz_cod, cli_cod, user_cod");
        }

        public IEnumerable<PedidoNutricao> GetByCod(string cod)
        {
            string sql = @"select pd.*, faz.*, cli.*, usu.* from pedidonutricao pd
                            inner join fazenda faz on faz.faz_cod = pd.faz_cod
                            inner join cliente cli on cli.cli_cod = pd.cli_cod
                            inner join usuario usu on usu.user_cod = pd.user_cod
                            where pd.pn_cod = @cod";
            return Connection.Query<PedidoNutricao, Fazenda, Cliente, Usuario, PedidoNutricao>(sql, (pedidonutricao, fazenda, cliente, usuario) =>
            {
                pedidonutricao.Cliente = cliente;
                pedidonutricao.Fazenda = fazenda;
                pedidonutricao.Usuario = usuario;
                return pedidonutricao;
            }, new { cod }, splitOn: "faz_cod, cli_cod, user_cod");
        }
    }
}
