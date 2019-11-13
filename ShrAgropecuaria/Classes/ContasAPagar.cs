using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class ContasAPagar
    {
        int? cap_cod;
        DateTime cap_datapagamento;
        DateTime cap_datageracao;
        DateTime cap_datavencimento;
        decimal cap_valordespesa;
        decimal cap_valorpago;
        Despesa despesa;
        Usuario user;
        PedidoPET pedidopet;

        public int? Cap_cod { get => cap_cod; set => cap_cod = value; }
        public DateTime Cap_datapagamento { get => cap_datapagamento; set => cap_datapagamento = value; }
        public DateTime Cap_datageracao { get => cap_datageracao; set => cap_datageracao = value; }
        public DateTime Cap_datavencimento { get => cap_datavencimento; set => cap_datavencimento = value; }
        public decimal Cap_valordespesa { get => cap_valordespesa; set => cap_valordespesa = value; }
        public decimal Cap_valorpago { get => cap_valorpago; set => cap_valorpago = value; }
        public Usuario User { get => user; set => user = value; }
        internal Despesa Despesa { get => despesa; set => despesa = value; }

        internal PedidoPET Pedidopet { get => pedidopet; set => pedidopet = value; }


        public int? Despesaid { get { return Despesa?.Desp_cod; } }

        public int? Usuarioid { get { return User?.User_cod; } }

        public int? PedidoPetid { get { return Pedidopet?.Pedp_cod; } }

    }
}
