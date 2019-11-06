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
    class MySqlProdutoNutricaoRepository : MySqlRepository, IProdutoNutricao
    {
        public MySqlProdutoNutricaoRepository(IDbConnection connection) : base(connection)
        {

        }

        public IEnumerable<TipoProdutoNutricao> Carrega()
        {
            string sql = @"select *
                    from tipoprodutonutricao";
            return Connection.Query<TipoProdutoNutricao>(sql);
        }

        public void Excluir(ProdutoNutricao prod)
        {
                Connection.Execute("update produtonutricao set prodn_ativo = 'I' where prodm = @user_cod", prod);
            
        }

        public IEnumerable<ProdutoNutricao> GetByNome(string nome)
        {
            string sql = @"select prod.*, tipo.* from produtonutricao prod
                            inner join tipoprodutonutricao tipo on prod.tpn_cod = tipo.tpn_cod
                            where prod.pord_nome like @nome";
            return Connection.Query<ProdutoNutricao, TipoProdutoNutricao, ProdutoNutricao>(sql, (produtonutricao, tipoprodutonutricao) =>
            {
                produtonutricao.TipoProdutoNutricao = tipoprodutonutricao;
                return produtonutricao;
            }, new { nome = "%" + nome + "%" }, splitOn: "tpn_cod");
        }

        public void Gravar(ProdutoNutricao prod)
        {
            if (prod.Prodn_cod == null)
            {
                Connection.Execute("insert into produtonutricao" +
                    "(prodn_ativo,prodn_obs,prodn_previsaoentrega, prodn_nomeprod, prodn_valorunitario, tpn_cod)" +
                    " values(@prodn_ativo, @prodn_obs, @prodn_previsaoentrega, @prodn_nomeprod, @prodn_valorunitario, @tipoprodutonutricaoid)", prod);
            }
            else
            {
                Connection.Execute("update produtonutricao set  prodn_ativo = @prodn_ativo, prodn_obs = @prodn_obs, prodn_previsaoentrega = @prodn_previsaoentrega , "
                    + "prodn_nomeprod = @prodn_nomeprod, prodn_valorunitario = @prodn_valorunitario, tpn_cod = @tipoprodutonutricaoid"
                    + "where prodn_cod = @prodn_cod", prod);
            }
        }

        public ProdutoNutricao PegaId(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
