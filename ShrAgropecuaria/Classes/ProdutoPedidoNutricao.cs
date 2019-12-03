using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class ProdutoPedidoNutricao
    {
        PedidoNutricao pedidoNutricao;
        ProdutoNutricao produtoNutricao;
        int ppn_quantidade;
        int ppn_peso;
        decimal ppn_valorvenda;

        public PedidoNutricao PedidoNutricao { get => pedidoNutricao; set => pedidoNutricao = value; }
        public ProdutoNutricao ProdutoNutricao { get => produtoNutricao; set => produtoNutricao = value; }

        public string NomeProd { get { return produtoNutricao?.Prodn_nomeprod; } }

        public int? idPedNutri { get { return pedidoNutricao?.Pn_cod; } }
        public int? idProdNutri { get { return produtoNutricao?.Prodn_cod; } }

        public int Ppn_quantidade { get => ppn_quantidade; set => ppn_quantidade = value; }
        public int Ppn_peso { get => ppn_peso; set => ppn_peso = value; }
        public decimal Ppn_valorvenda { get => ppn_valorvenda; set => ppn_valorvenda = value; }
    }
}
