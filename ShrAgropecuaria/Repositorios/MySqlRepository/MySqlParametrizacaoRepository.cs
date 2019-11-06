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
    class MySqlParametrizacaoRepository : MySqlRepository, IParametrizacaoRepository
    {
        public MySqlParametrizacaoRepository(IDbConnection connection) : base(connection)
        {

        }
        public Parametrizacao Get()
        {
            string sql = @"select *
                    from parametrizacao";
            return Connection.Query<Parametrizacao>(sql).FirstOrDefault();
        }

        public void Gravar(Parametrizacao par, Boolean f)
        {
            if(f == true)
            {
                Connection.Execute("insert into parametrizacao" +
                   "(par_logo,par_nomeemp)" +
                   " values(@user_nivel, @user_status, @user_login, @user_senha)", par);
            }
        }

        public void Gravar(ProdutoNutricao user)
        {
            throw new NotImplementedException();
        }
    }
}
