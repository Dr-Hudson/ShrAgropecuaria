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
    class MySqlContasAPagarRepository : MySqlRepository, IContasAPagarRepository
    {
        public MySqlContasAPagarRepository(IDbConnection connection): base(connection)
        {

        }

        public int conta(int id)
        {
            string sql = @"select count(*) from contasapagar where cap_cod = " + id;
            return Connection.Query<int>(sql).FirstOrDefault();
        }

        public void Excluir(DateTime a)
        {

            Connection.Execute("delete from contasapagar where cap_datageracao = @a", new { a });            
                
        }

        public ContasAPagar Get(int? id)
        {
            if(id != null)
            {
                return Connection.Query<ContasAPagar>("select * from contasapagar where cap_cod = @id", new { id = id }).FirstOrDefault();
            }
            return null;
        }

        public IEnumerable<ContasAPagar> GetAll(string nome)
        {
            string sql = @"select cap.*, desp.*, user.* from contasapagar cap
                            inner join despesas desp on desp.desp_cod = cap.desp_cod
                            inner join usuario user on user.user_cod = cap.user_cod
                            
                            where cap.cap_descricao like @nome";
            return Connection.Query<ContasAPagar, Despesa, Usuario, ContasAPagar>(sql, (contasapagar, despesa, usuario) =>
            {
                contasapagar.Despesa = despesa;
                contasapagar.User = usuario;
                
                return contasapagar;
                
            }, new { nome = "%" + nome + "%" }, splitOn: "desp_cod, user_cod");
        }

        public IEnumerable<ContasAPagar> GetData(DateTime data)
        {
            string sql = @"select cap.*, desp.*, user.* from contasapagar cap
                            inner join despesas desp on desp.desp_cod = cap.desp_cod
                            inner join usuario user on user.user_cod = cap.user_cod
                            
                            where cap.cap_datageracao = @data";
            return Connection.Query<ContasAPagar, Despesa, Usuario, ContasAPagar>(sql, (contasapagar, despesa, usuario) =>
            {
                contasapagar.Despesa = despesa;
                contasapagar.User = usuario;

                return contasapagar;

            }, new { data }, splitOn: "desp_cod, user_cod");
        }

        public void Gravar(List<ContasAPagar> lcap)
        {
            foreach(var cap in lcap)
            {
                Connection.Execute("insert into contasapagar" +
                    "(cap_datapagamento, cap_datageracao, cap_datavencimento, cap_valordespesa, cap_valorpago, cap_descricao, desp_cod, pedp_cod, user_cod)" +
                    " values(@cap_datapagamento, @cap_datageracao, @cap_datavencimento, @cap_valordespesa, @cap_valorpago, @cap_descricao, @despesaid, @pedidopetid, @usuarioid)", cap);
            }
            
                    
            
                
            
                /*Connection.Execute("update contasapagar set  cap_datapagamento = @cap_datapagamento, cap_datageracao = @cap_datageracao, cap_datavencimento = @cap_datavencimento, cap_descricao = @cap_descricao , "
                    + "cap_valordespesa = @cap_valordespesa, cap_valorpago = @cap_valorpago, "
                    + "desp_cod = @despesaid, pedp_cod = @pedidopetid, user_cod = @usuarioid where cap_cod = @cap_cod", cap);*/
            
        }
    }
}
