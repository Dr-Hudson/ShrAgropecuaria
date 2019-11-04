using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class Estado
    {
        string est_uf;
        string est_nome;

        public string Est_uf { get => est_uf; set => est_uf = value; }
        public string Est_nome { get => est_nome; set => est_nome = value; }
    }
}
