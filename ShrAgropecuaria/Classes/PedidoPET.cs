using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class PedidoPET
    {
        int pedp_cod;
        DateTime pedp_dataentrega;
        string pedp_vendedor;
        DateTime pedp_previsaoentrega;
        DateTime pedp_data;
        decimal pedp_valortotal;
        Usuario user;
        Fornecedor fornecedor;

        public int Pedp_cod { get => pedp_cod; set => pedp_cod = value; }
        public DateTime Pedp_dataentrega { get => pedp_dataentrega; set => pedp_dataentrega = value; }
        public string Pedp_vendedor { get => pedp_vendedor; set => pedp_vendedor = value; }
        public DateTime Pedp_previsaoentrega { get => pedp_previsaoentrega; set => pedp_previsaoentrega = value; }
        public DateTime Pedp_data { get => pedp_data; set => pedp_data = value; }
        public decimal Pedp_valortotal { get => pedp_valortotal; set => pedp_valortotal = value; }
        public Usuario User { get => user; set => user = value; }
        public Fornecedor Fornecedor { get => fornecedor; set => fornecedor = value; }

        public int? Usuarioid { get { return User?.User_cod; } }

        public int? Fornecedorid { get { return Fornecedor?.Forn_cod; } }


    }
}
