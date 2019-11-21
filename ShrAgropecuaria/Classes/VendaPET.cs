using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class VendaPET
    {
        int? _vp_cod;
        DateTime _vp_datavenda;
        decimal _vp_valortotal;
        Cliente _cliente;
        int _usuarioid = Session.Instance.ID;

        public int? Vp_cod { get => _vp_cod; set => _vp_cod = value; }
        public DateTime Vp_datavenda { get => _vp_datavenda; set => _vp_datavenda = value; }
        public decimal Vp_valortotal { get => _vp_valortotal; set => _vp_valortotal = value; }
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
        public int? Clienteid { get => _cliente.Cli_cod; set => _cliente.Cli_cod = value; }
        public int Usuarioid { get => _usuarioid; set => _usuarioid = value; }
    }
}
