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
    class MySqlSaldoProdutoNutricaoRepository : MySqlRepository, ISaldoProdutoNutricao
    {
        public MySqlSaldoProdutoNutricaoRepository(IDbConnection connection) : base(connection)
        {

        }
        public IEnumerable<SaldoClientePedidoLoja> BuscaPorFazenda(string fazenda)
        {
            string sql = @"select saldo.*, ped.*, prod.* from saldoclientepedidoloja saldo
                            inner join pedidonutricao ped on saldo.pn_cod = ped.pn_cod
                            inner join produtonutricao prod on saldo.prodn_cod = prod.prodn_cod
                            inner join fazenda faz on faz.faz_cod = ped.faz_cod
                            where faz.faz_nome like @Fazenda";
            return Connection.Query<SaldoClientePedidoLoja, PedidoNutricao, ProdutoNutricao, SaldoClientePedidoLoja>(sql, (saldoclientepedidoloja, pedidonutricao, produtonutricao) =>
            {
                saldoclientepedidoloja.ProdutoNutricao = produtonutricao;
                saldoclientepedidoloja.Pedidonutricao = pedidonutricao;

                return saldoclientepedidoloja;
            }, new { Fazenda = "%" + fazenda + "%" }, splitOn: "pn_cod, prodn_cod, faz_cod");
        }

        public void Grava(SaldoClientePedidoLoja saldo)
        {
           Connection.Execute("update saldoclientepedidoloja set scpl_saldo = @scpl_saldo where scpl_cod = @scpl_cod;", saldo);
        }
    }
}
