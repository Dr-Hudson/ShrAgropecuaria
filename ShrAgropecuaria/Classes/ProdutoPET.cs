using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class ProdutoPET
    {
        int? pp_cod;
        string pp_fabricante;
        decimal pp_valorcompra;
        int pp_estoque;
        string pp_descricao;
        string pp_ativo;
        decimal pp_valorunitario;
        CategoriaProdutoPET cat;

        public int? Pp_cod { get => pp_cod; set => pp_cod = value; }

        public string Pp_descricao { get => pp_descricao; set => pp_descricao = value; }
        public decimal Pp_valorcompra { get => pp_valorcompra; set => pp_valorcompra = value; }
        public int Pp_estoque { get => pp_estoque; set => pp_estoque = value; }
        public string Pp_fabricante { get => pp_fabricante; set => pp_fabricante = value; }
        
        public decimal Pp_valorunitario { get => pp_valorunitario; set => pp_valorunitario = value; }
        internal CategoriaProdutoPET Cat { get => cat; set => cat = value; }

        public int? CategoriaProdutoPETId { get { return Cat?.Cat_cod; } }

        public string Pp_ativo { get => pp_ativo; set => pp_ativo = value; }

        public string CategoriaProdutoDescricao { get { return Cat?.Cat_descricao; } }

        public override bool Equals(object obj)
        {
            return obj is ProdutoPET pET &&
                   EqualityComparer<int?>.Default.Equals(pp_cod, pET.pp_cod);
        }

        public override int GetHashCode()
        {
            return -1452915636 + EqualityComparer<int?>.Default.GetHashCode(pp_cod);
        }
    }
}
