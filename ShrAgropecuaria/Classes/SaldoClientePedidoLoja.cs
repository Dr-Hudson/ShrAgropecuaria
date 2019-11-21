using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class SaldoClientePedidoLoja
    {
        int _scpl_cod;
        int _scpl_saldo;
        ProdutoNutricao _produtoNutricao;
        PedidoNutricao _pedidonutricao;

        public int Scpl_cod { get => _scpl_cod; set => _scpl_cod = value; }
        public int Scpl_saldo { get => _scpl_saldo; set => _scpl_saldo = value; }
        public ProdutoNutricao ProdutoNutricao { get => _produtoNutricao; set => _produtoNutricao = value; }
        public PedidoNutricao Pedidonutricao { get => _pedidonutricao; set => _pedidonutricao = value; }
        public int? PedidoNutricaoId { get => _pedidonutricao.Pn_cod; set => _pedidonutricao.Pn_cod = value; }
        public int? ProdutoNutricaoId { get => _produtoNutricao.Prodn_cod; set => _produtoNutricao.Prodn_cod = value; }
        
    }
}
