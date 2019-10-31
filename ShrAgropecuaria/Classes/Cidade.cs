using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    class Cidade
    {
        int cid_cod;
        string cid_nome;
        Estado estado;

        public int Cid_cod { get => cid_cod; set => cid_cod = value; }
        public string Cid_nome { get => cid_nome; set => cid_nome = value; }
        internal Estado Estado { get => estado; set => estado = value; }
    }
}
