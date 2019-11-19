using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class Despesa
    {
        int? desp_cod;
        string desp_descricao;
        string desp_dia;

        public int? Desp_cod { get => desp_cod; set => desp_cod = value; }
        public string Desp_descricao { get => desp_descricao; set => desp_descricao = value; }
        public string Desp_dia { get => desp_dia; set => desp_dia = value; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return desp_descricao;
        }
    }
}
