using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class Fazenda
    {
        int? faz_cod;
        decimal faz_quantgado;
        decimal faz_tamanho;
        string faz_nome;
        string faz_inscricaoestadual;
        string rota;
        Cidade cidade;
        Cliente cliente;

        public int? Faz_cod { get => faz_cod; set => faz_cod = value; }
        public decimal Faz_quantgado { get => faz_quantgado; set => faz_quantgado = value; }
        public decimal Faz_tamanho { get => faz_tamanho; set => faz_tamanho = value; }
        public string Faz_nome { get => faz_nome; set => faz_nome = value; }
        public string Faz_inscricaoestadual { get => faz_inscricaoestadual; set => faz_inscricaoestadual = value; }
        public string Rota { get => rota; set => rota = value; }
        public Cidade Cidade { get => cidade; set => cidade = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }

        public int? Cidadeid { get { return Cidade?.Cid_cod; } }
        public int? Clienteid { get { return Cliente?.Cli_cod; } }
    }
}
