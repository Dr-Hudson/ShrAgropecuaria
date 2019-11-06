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
    class MySqlCategoriaProdutoPET : MySqlRepository, ICategoriaProdutoPET
    {

        public MySqlCategoriaProdutoPET(IDbConnection connection): base(connection)
        {

        }

        public CategoriaProdutoPET Get(int? id)
        {
            return Connection.Query<CategoriaProdutoPET>("select * from categoriaprodutopet where cat_cod = @cat_cod", new { id }).FirstOrDefault();
        }

        public IEnumerable<CategoriaProdutoPET> GetAll()
        {
            return Connection.Query<CategoriaProdutoPET>("select * from categoriaprodutopet");
        }

        

        public IEnumerable<CategoriaProdutoPET> GetByNome(string Nome)
        {
            return Connection.Query<CategoriaProdutoPET>("select * from categoriaprodutopet where cat_descricao = @nome", new { nome = Nome });
        }

        public CategoriaProdutoPET PegaId(string nome)
        {
            return Connection.Query<CategoriaProdutoPET>("select * from categoriaprodutopet where cat_descricao = @nome", new { nome }).FirstOrDefault();
        }
    }
}
