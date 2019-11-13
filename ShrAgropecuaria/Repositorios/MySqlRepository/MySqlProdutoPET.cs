using ShrAgropecuaria.Classes;
using ShrAgropecuaria.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ShrAgropecuaria.Repositorios.MySqlRepository
{
    class MySqlProdutoPET : MySqlRepository, IProdutoPETRepository
    {
        public MySqlProdutoPET(IDbConnection connection): base(connection)
        {

        }

        public void Excluir(ProdutoPET pet)
        {
            Connection.Execute("update produtopet set pp_ativo = 'I' where pp_cod = @pp_cod", pet);
        }

        public ProdutoPET Get(int? id)
        {
            return Connection.Query<ProdutoPET>("select * from produtopet where pp_cod = @pp_cod", new { pp_cod = id }).FirstOrDefault();
        }

        public IEnumerable<ProdutoPET> GetAll()
        {
            string sql = "select pp_descricao, pp_fabricante, pp_valorcompra, pp_valorunitario, pp_estoque, cat_descricao from produtopet pp " +
                "inner join categoriaprodutopet cat on cat.cat_cod = pp.cat_cod";
            return Connection.Query<ProdutoPET, CategoriaProdutoPET, ProdutoPET>(sql, (produtopet, categoriaprodutopet) =>
            {
                produtopet.Cat = categoriaprodutopet;
                return produtopet;
            }, splitOn: "cat_cod, pp_descricao, pp_fabricante, pp.valorcompra, pp_valorunitario, pp_estoque, cat_descricao");
        }

        public IEnumerable<ProdutoPET> GetByCat(string nome)
        {
            string sql = "select pp.*, cat.* from produtopet pp " +
                "inner join categoriaprodutopet cat on cat.cat_cod = pp.cat_cod" +
                "where cat.cat_descricao like @nome";
            return Connection.Query<ProdutoPET, CategoriaProdutoPET, ProdutoPET>(sql, (produtopet, categoriaprodutopet) =>
            {
                produtopet.Cat = categoriaprodutopet;
                return produtopet;
            }, new { nome }, splitOn: "cat_cod");
        }

        public IEnumerable<ProdutoPET> GetById(int id)
        {
            string sql = "select pp.*, cat.* from produtopet pp " +
                "inner join categoriaprodutopet cat on cat.cat_cod = pp.cat_cod" +
                "where pp.pp_cod = @pp_cod";
            return Connection.Query<ProdutoPET, CategoriaProdutoPET, ProdutoPET>(sql, (produtopet, categoriaprodutopet) =>
            {
                produtopet.Cat = categoriaprodutopet;
                return produtopet;
            }, new { id }, splitOn: "cat_cod");
        }

        public IEnumerable<ProdutoPET> GetByNome(string Nome)
        {
            string sql = "select pp.*, cat.* from produtopet pp " +
                "inner join categoriaprodutopet cat on cat.cat_cod = pp.cat_cod " +
                "where pp.pp_descricao like @nome";
            return Connection.Query<ProdutoPET, CategoriaProdutoPET, ProdutoPET>(sql, (produtopet, categoriaprodutopet) =>
            {
                produtopet.Cat = categoriaprodutopet;
                return produtopet;
            }, new { nome = "%" + Nome  +"%" }, splitOn: "cat_cod");
        }

        public void Gravar(ProdutoPET pet)
        {
            if (pet.Pp_cod == null)
            {
                Connection.Execute("insert into produtopet (pp_fabricante, pp_valorcompra, pp_ativo, pp_estoque, pp_descricao, pp_valorunitario, cat_cod)" +
                    "values (@pp_fabricante, @pp_valorcompra, @pp_ativo, @pp_estoque, @pp_descricao, @pp_valorunitario, @categoriaprodutoPETId)", pet);
            }
            else
                Connection.Execute("update produtopet set pp_fabricante = @pp_fabricante, pp_valorcompra = @pp_valorcompra, pp_estoque=@pp_estoque, pp_descricao=@pp_descricao," +
                    "pp_valorunitario=@pp_valorunitario, cat_cod=@categoriaprodutoPETId where pp_cod = @pp_cod", pet);
        }

        public ProdutoPET PegaId(string nome)
        {
            return Connection.Query<ProdutoPET>("select * from produtopet where pp_descricao = @pp_descricao", new { nome }).FirstOrDefault();
        }
    }
}
