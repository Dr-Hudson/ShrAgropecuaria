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
        int quantidade;
        int peso;
        decimal valorvenda;

        public PedidoNutricao PedidoNutricao { get => pedidoNutricao; set => pedidoNutricao = value; }
        public ProdutoNutricao ProdutoNutricao { get => produtoNutricao; set => produtoNutricao = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public int Peso { get => peso; set => peso = value; }
        public decimal Valorvenda { get => valorvenda; set => valorvenda = value; }

        public int? idPedNutri { get { return pedidoNutricao?.Pn_cod; } }
        public int? idProdNutri { get { return produtoNutricao?.Prodn_cod; } }
    }
}
