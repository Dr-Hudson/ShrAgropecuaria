using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class Cliente
    {
        int? cli_cod;
        DateTime cli_dataliberacao;
        decimal cli_limite;
        decimal cli_saldofiado;
        string cli_bairro;
        string cli_cep;
        string cli_complemento;
        decimal cli_numero;
        string cli_nome;
        string cli_cpf;
        string cli_rg;
        string cli_endereco;
        string cli_telefone;
        Cidade cidade;

        public int? Cli_cod { get => cli_cod; set => cli_cod = value; }
        public DateTime Cli_dataliberacao { get => cli_dataliberacao; set => cli_dataliberacao = value; }
        public decimal Cli_limite { get => cli_limite; set => cli_limite = value; }
        public decimal Cli_saldofiado { get => cli_saldofiado; set => cli_saldofiado = value; }
        public string Cli_bairro { get => cli_bairro; set => cli_bairro = value; }
        public string Cli_cep { get => cli_cep; set => cli_cep = value; }
        public string Cli_complemento { get => cli_complemento; set => cli_complemento = value; }
        public decimal Cli_numero { get => cli_numero; set => cli_numero = value; }
        public string Cli_nome { get => cli_nome; set => cli_nome = value; }
        public string Cli_cpf { get => cli_cpf; set => cli_cpf = value; }
        public string Cli_rg { get => cli_rg; set => cli_rg = value; }
        public string Cli_endereco { get => cli_endereco; set => cli_endereco = value; }
        public string Cli_telefone { get => cli_telefone; set => cli_telefone = value; }
        public Cidade Cidade { get => cidade; set => cidade = value; }

        public int? Cidadeid { get { return Cidade?.Cid_cod; } }
        public string CidadeNome { get { return cidade?.Cid_nome; } }
    }
}
