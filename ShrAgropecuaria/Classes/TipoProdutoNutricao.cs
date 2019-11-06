using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class TipoProdutoNutricao
    {
        int? tpn_cod;
        string tpn_descricao;

        public int? Tpn_cod { get => tpn_cod; set => tpn_cod = value; }
        public string Tpn_descricao { get => tpn_descricao; set => tpn_descricao = value; }

        public override bool Equals(object obj)
        {
            return obj is TipoProdutoNutricao nutricao &&
                   Tpn_descricao == nutricao.Tpn_descricao;
        }

        public override int GetHashCode()
        {
            return -1966601253 + EqualityComparer<string>.Default.GetHashCode(Tpn_descricao);
        }

        public override string ToString()
        {
            return tpn_descricao;
        }
    }
}
