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
                            where cli.cli_nome LIKE @Nome";
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

        public IEnumerable<ProdutoPedidoNutricao> GetByProduto(string cod)
        {
            string sql = @"select ppn.*, pd.*, pn.* from produtopedidonutricao ppn
                            inner join pedidonutricao pd on pd.pn_cod = ppn.pn_cod
                            inner join produtonutricao pn on pn.prodn_cod = ppn.prodn_cod
                            where ppn.pn_cod = @cod";
            return Connection.Query<ProdutoPedidoNutricao, PedidoNutricao, ProdutoNutricao, ProdutoPedidoNutricao>(sql, (produtopedidonutricao, pedidonutricao, produtonutricao) =>
            {
                produtopedidonutricao.PedidoNutricao = pedidonutricao;
                produtopedidonutricao.ProdutoNutricao = produtonutricao;
                return produtopedidonutricao;
            }, new { cod }, splitOn: "pn_cod, prodn_cod");
        }

        public void GravarProdutoPedido(ProdutoPedidoNutricao prodPedNutri)
        {
            Connection.Execute("INSERT INTO produtopedidonutricao " +
                "(pn_cod, prodn_cod, ppn_quantidade, ppn_peso, ppn_valorvenda) " +
                "VALUES (@idPedNutri, @idProdNutri, @ppn_quantidade, @ppn_peso, @ppn_valorvenda)", prodPedNutri);
        }

        public void GravarPedido(PedidoNutricao pedNutri)
        {
            if (pedNutri.Pn_cod == null)
            {
                Connection.Execute("INSERT INTO pedidonutricao " +
                    "(pn_previsaoentrega, pn_dataentrega, pn_porcentagem, pn_contato, " +
                    "pn_valortotal, pn_data, pn_obs, faz_cod, cli_cod, user_cod, pn_formapgto) " +
                    "VALUES(@pn_previsaoentrega, null, @pn_porcentagem, " +
                    "@pn_contato, @pn_valortotal, @pn_data, @pn_obs, @faz_cod, " +
                    "@cli_cod, @user_cod, @pn_formapgto)", pedNutri);
                pedNutri.Pn_cod = Convert.ToInt32(Connection.ExecuteScalar("select last_insert_id()"));
            }
            else
            {
                Connection.Execute("UPDATE pedidonutricao SET " +
                    "pn_previsaoentrega = @pn_previsaoentrega, pn_dataentrega = @pn_dataentrega, " +
                    "pn_porcentagem = @pn_porcentagem, pn_contato = @pn_contato, pn_valortotal = @pn_valortotal, " +
                    "pn_data = @pn_data, pn_obs = @pn_obs, faz_cod = @faz_cod, cli_cod = @cli_cod, user_cod = @user_cod, pn_formapgto = @pn_formapgto " +
                    "WHERE pn_cod = @pn_cod; ", pedNutri);
            }
        }

        public void DeletaProdutosPedido(int id)
        {
            Connection.Execute("delete from produtopedidonutricao where pn_cod = @id", new { id });
        }

        public void Excluir(int id)
        {
            Connection.Execute("delete from produtopedidonutricao where pn_cod = @id", new { id });
            Connection.Execute("delete from pedidonutricao where pn_cod = @id", new { id });
        }
    }
}
