using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class ContasAReceber
    {
        int _cr_cod;
        DateTime _cr_dataVencimento;
        decimal _cr_valorAReceber;
        DateTime _cr_dataDoRecebimento;
        DateTime _cr_dataGeracao;
        decimal _cr_valorRecebido;
        int _vendaPet;
        int _usuario = Session.Instance.ID;

        public int Cr_cod { get => _cr_cod; set => _cr_cod = value; }
        public DateTime Cr_dataVencimento { get => _cr_dataVencimento; set => _cr_dataVencimento = value; }
        public decimal Cr_valorAReceber { get => _cr_valorAReceber; set => _cr_valorAReceber = value; }
        public DateTime Cr_dataDoRecebimento { get => _cr_dataDoRecebimento; set => _cr_dataDoRecebimento = value; }
        public DateTime Cr_dataGeracao { get => _cr_dataGeracao; set => _cr_dataGeracao = value; }
        public decimal Cr_valorRecebido { get => _cr_valorRecebido; set => _cr_valorRecebido = value; }
        public int VendaPet { get => _vendaPet; set => _vendaPet = value; }
        public int UsuarioId { get => _usuario; set => _usuario = value; }
        
    }
}
