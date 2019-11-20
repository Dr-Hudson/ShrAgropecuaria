using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class PedidoNutricao
    {
        int? pn_cod;
        DateTime pn_previsaoentrega;
        DateTime pn_dataentrega;
        decimal pn_porcentagem;
        string pn_contato;
        decimal pn_valortotal;
        DateTime pn_data;
        string pn_obs;
        Fazenda fazenda;
        Cliente cliente;
        Usuario usuario;

        public int? Pn_cod { get => pn_cod; set => pn_cod = value; }
        public DateTime Pn_previsaoentrega { get => pn_previsaoentrega; set => pn_previsaoentrega = value; }
        public DateTime Pn_dataentrega { get => pn_dataentrega; set => pn_dataentrega = value; }
        public decimal Pn_porcentagem { get => pn_porcentagem; set => pn_porcentagem = value; }
        public string Pn_contato { get => pn_contato; set => pn_contato = value; }
        public decimal Pn_valortotal { get => pn_valortotal; set => pn_valortotal = value; }
        public DateTime Pn_data { get => pn_data; set => pn_data = value; }
        public string Pn_obs { get => pn_obs; set => pn_obs = value; }
        public Fazenda Fazenda { get => fazenda; set => fazenda = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Usuario Usuario { get => usuario; set => usuario = value; }

        public string FazendaNome { get { return Fazenda.Faz_nome; } }
        public string ClienteNome { get { return cliente?.Cli_nome; } }
    }
}
