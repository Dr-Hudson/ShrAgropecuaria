using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class ProdutoNutricao
    {
        int? prodn_cod;
        char prodn_ativo;
        string prodn_obs;
        DateTime prodn_previsaoentrega;
        string prodn_nomeprod;
        decimal prod_valorunitario;
        TipoProdutoNutricao tipoProdutoNutricao;

        public int? Prodn_cod { get => prodn_cod; set => prodn_cod = value; }
        public char Prodn_ativo { get => prodn_ativo; set => prodn_ativo = value; }
        public string Prodn_obs { get => prodn_obs; set => prodn_obs = value; }
        public DateTime Prodn_previsaoentrega { get => prodn_previsaoentrega; set => prodn_previsaoentrega = value; }
        public string Prodn_nomeprod { get => prodn_nomeprod; set => prodn_nomeprod = value; }
        public decimal Prod_valorunitario { get => prod_valorunitario; set => prod_valorunitario = value; }
        internal TipoProdutoNutricao TipoProdutoNutricao { get => tipoProdutoNutricao; set => tipoProdutoNutricao = value; }
        public int? TipoProdutoNutricaoid { get { return TipoProdutoNutricao?.Tpn_cod; } }
    }
}
