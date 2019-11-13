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
        public void Excluir(ContasAPagar cap)
        {
            throw new NotImplementedException();
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
            string sql = @"select cap.*, desp.*, user.*, pedp.* from contasapagar cap
                            inner join despesa desp on desp.desp_cod = cap.desp_cod
                            inner join usuario user on user.user_cod = cap.user_cod
                            inner join pedidopet pedp on pedp.pedp_cod = cap.pedp_cod
                            where forn.forn_nome like @nome";
            return Connection.Query<ContasAPagar, Despesa, Usuario, PedidoPET, ContasAPagar>(sql, (contasapagar, despesa, usuario, pedidopet) =>
            {
                contasapagar.Despesa = despesa;
                contasapagar.User = usuario;
                contasapagar.Pedidopet = pedidopet;
                return contasapagar;
                
            }, new { nome = "%" + nome + "%" }, splitOn: "desp_cod, user_cod, pedp_cod");
        }

        public void Gravar(ContasAPagar cap, int parcela)
        {
            if (cap.Cap_cod == null)
            {
                for(int i = 0; i<parcela; i++)
                {
                    Connection.Execute("insert into contasapagar" +
                    "(cap_datapagamento, cap_datageracao, cap_datavencimento, cap_valordespesa, cap_valorpago, desp_cod, pedp_cod, user_cod)" +
                    " values(@cap_datapagamento, @cap_datageracao, @cap_datavencimento, @cap_valordespesa, @cap_valorpago, @despesaid, @pedidopetid, @usuarioid)", cap);
                }
                
            }
            else
            {
                Connection.Execute("update contasapagar set  cap_datapagamento = @cap_datapagamento, cap_datageracao = @cap_datageracao, cap_datavencimento = @cap_datavencimento , "
                    + "cap_valordespesa = @cap_valordespesa, cap_valorpago = @cap_valorpago, "
                    + "desp_cod = @despesaid, pedp_cod = @pedidopetid, user_cod = @usuarioid where cap_cod = @cap_cod", cap);
            }
        }
    }
}
