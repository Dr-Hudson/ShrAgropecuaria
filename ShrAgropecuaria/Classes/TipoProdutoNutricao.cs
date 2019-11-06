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
    }
}
