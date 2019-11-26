using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class ProdutoVenda
    {
        VendaPET _venda;
        ProdutoPET _produto;
        int _pv_quantidade;
        int? _vendaid = null;
        decimal pv_valor_unitario;

        public VendaPET Venda { get => _venda; set => _venda = value; }
        public int? Vendaid { get => _vendaid; set => _vendaid = value; }
        public ProdutoPET Produto { get => _produto; set => _produto = value; }
        public int? ProdutoID { get => _produto.Pp_cod; set => _produto.Pp_cod = value; }
        public string DescricaoProduto { get { return _produto.Pp_descricao; } }
        public int Pv_quantidade { get => _pv_quantidade; set => _pv_quantidade = value; }
        public decimal Pv_valor_unitario { get => pv_valor_unitario; set => pv_valor_unitario = value; }

        

        public override bool Equals(object obj)
        {
            return obj is ProdutoVenda venda &&
                   EqualityComparer<ProdutoPET>.Default.Equals(_produto, venda._produto);
        }

        public override int GetHashCode()
        {
            return 498314639 + EqualityComparer<ProdutoPET>.Default.GetHashCode(_produto);
        }
    }
}
