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
    class MySqlFornecedorRepository : MySqlRepository, IFornecedorRepository
    {
        public MySqlFornecedorRepository(IDbConnection connection): base(connection)
        {

        }

        public void Excluir(Fornecedor forn)
        {
            Connection.Execute("delete from fornecedor where id = @id", forn);
        }

        public Fornecedor Get(int? id)
        {
            if(id != null)
            {
                return Connection.Query<Fornecedor>("select * from fornecedor where forn_cod = @id", new { id = id }).FirstOrDefault();
                
            }
            return null;
        }

        public IEnumerable<Fornecedor> GetAll(string nome)
        {
            string sql = @"select forn.*, cid.* from fornecedor forn
                            inner join cidade cid on cid.cid_cod = forn.cid_cod
                            where forn.forn_nome like @nome";
            return Connection.Query<Fornecedor, Cidade, Fornecedor>(sql, (fornecedor, cidade) =>
            {
                fornecedor.Cidade = cidade;
                return fornecedor;
            }, new { nome = "'%" + nome + "%'" });
        }

        public IEnumerable<Fornecedor> GetById(int id)
        {
            string sql = @"select forn.*, cid.* from fornecedor forn
                            inner join cidade cid on cid.cid_cod = forn.cid_cod
                            where forn.forn_cod = @id";
            return Connection.Query<Fornecedor, Cidade, Fornecedor>(sql, (fornecedor, cidade) =>
            {
                fornecedor.Cidade = cidade;
                return fornecedor;
            }, new {id});
        }

        public IEnumerable<Fornecedor> GetByNome(string Nome)
        {
            string sql = @"select forn.*, cid.* from fornecedor forn
                            inner join cidade cid on cid.cid_cod = forn.cid_cod
                            where forn.forn_nome like @nome";
            return Connection.Query<Fornecedor, Cidade, Fornecedor>(sql, (fornecedor, cidade) =>
            {
                fornecedor.Cidade = cidade;
                return fornecedor;
            }, new { nome = "'%" + Nome + "%'" });
        }

        public void Gravar(Fornecedor forn)
        {
            if(forn.Forn_cod == null)
            {
                Connection.Execute("insert into fornecedor" +
                    "(forn_bairro,forn_complemento,forn_cep, forn_numero, forn_endereco, forn_nome, forn_descricao, forn_cnpj, forn_telefone, cid_cod)"+
                    " values(@forn_bairro, @forn_complemento, @forn_cep, @forn_numero, @forn_endereco, @forn_nome, @forn_descricao, @forn_cnpj, @forn_telefone, @cidadeid)", forn);
            }
            else
            {
                Connection.Execute("update fornecedor set forn_cod = @forn_cod, forn_bairro = @forn_bairro, forn_complemento = @ forn_complemento, forn_cep = @forn_cep"
                    + "forn_numero = @forn_numero, forn_endereco = @forn_endereco, forn_nome = @forn_nome, forn_descricao = @forn_descricao, forn_cnpj = @forn_cnpj, forn_telefone = @forn_telefone"
                    +  "cid_cod = @cid_cod", forn);
            }
        }

        public Fornecedor PegaId(string nome)
        {
            string sql = @"select forn.*, cid.* from fornecedor forn
                            inner join cidade cid on cid.cid_cod = forn.cid_cod
                            where forn.forn_nome like @nome";
            return Connection.Query<Fornecedor>(sql, new { nome = "'%" + nome + "%'" }).FirstOrDefault();
        }
    }
}
