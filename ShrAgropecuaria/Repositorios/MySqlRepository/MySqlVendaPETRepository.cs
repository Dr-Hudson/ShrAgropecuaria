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
    class MySqlVendaPETRepository : MySqlRepository, IVendaPETRepository
    {
        public MySqlVendaPETRepository(IDbConnection connection) : base(connection)
        {

        }

        public void atualizarproduto(int cod, int n)
        {

            Connection.Execute("update produtopet set" +
                   " pp_estoque = @n" +
                   " where pp_cod = @cod", new { n, cod});
        }

        public void gravar(VendaPET venda)
        {
            Connection.Execute("insert into vendapet" +
                   "(vp_datavenda,vp_valortotal,cli_cod, user_cod)" +
                   " values(@vp_datavenda, @vp_valortotal, @clienteid, @usuarioid)", venda);
            venda.Vp_cod = Convert.ToInt32(Connection.ExecuteScalar("select last_insert_id()"));
        }

        public void GravarProds(ProdutoVenda pv)
        {
            Connection.Execute("insert into produtovenda" +
                   "(vp_cod, pp_cod, pv_quantidade, pv_valor_unitario)" +
                   " values(@vendaid, @produtoid, @pv_quantidade, @pv_valor_unitario)", pv);
           
        }

        public IEnumerable<VendaPET> getALL(string nome)
        {
            string sql = @"select ven.*, cli.*, user.* from vendapet ven
                            inner join cliente cli on ven.cli_cod = cli.cli_cod
                            inner join usuario user on user.user_cod = ven.user_cod
                            where cli.cli_nome like @Nome";
            return Connection.Query<VendaPET, Cliente, Usuario, VendaPET>(sql, (vendapet, cliente, usuario) =>
            {
                vendapet.Cliente = cliente;
                vendapet.Usuarioid = (int)usuario.User_cod;

                return vendapet;
            }, new { Nome = "%" + nome + "%" }, splitOn: "cli_cod, user_cod");
        }

        public IEnumerable<ProdutoVenda> GetPVenda(int? cod)
        {
            string sql = @"select pv.*, ven.*, pp.*, cat.* from produtovenda pv
                            inner join vendapet ven on pv.vp_cod = ven.vp_cod
                            inner join produtopet pp on pp.pp_cod = pv.pp_cod
                            inner join categoriaprodutopet cat on pp.cat_cod = cat.cat_cod
                            where pv.vp_cod = @id";
            return Connection.Query<ProdutoVenda, VendaPET, ProdutoPET, CategoriaProdutoPET, ProdutoVenda>(sql, (produtovenda, vendapet, produtopet, categoria) =>
            {
                produtopet.Cat = categoria;
                produtovenda.Produto = produtopet;
                produtovenda.Venda = vendapet;
                return produtovenda;
            }, new { id = cod }, splitOn: "vp_cod,pp_cod, cat_cod");
        }

        
    }
}
