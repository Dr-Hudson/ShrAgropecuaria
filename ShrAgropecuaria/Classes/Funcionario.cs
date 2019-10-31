using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    class Funcionario
    {
        int forn_cod;
        string forn_bairro;
        string forn_complemento;
        string forn_cep;
        int forn_numero;
        string forn_endereco;
        string forn_nome;
        string forn_descricao;
        string forn_cpnj;
        string forn_telefone;
        Cidade cidade;

        public int Forn_cod { get => forn_cod; set => forn_cod = value; }
        public string Forn_bairro { get => forn_bairro; set => forn_bairro = value; }
        public string Forn_complemento { get => forn_complemento; set => forn_complemento = value; }
        public string Forn_cep { get => forn_cep; set => forn_cep = value; }
        public int Forn_numero { get => forn_numero; set => forn_numero = value; }
        public string Forn_endereco { get => forn_endereco; set => forn_endereco = value; }
        public string Forn_nome { get => forn_nome; set => forn_nome = value; }
        public string Forn_descricao { get => forn_descricao; set => forn_descricao = value; }
        public string Forn_cpnj { get => forn_cpnj; set => forn_cpnj = value; }
        public string Forn_telefone { get => forn_telefone; set => forn_telefone = value; }
        internal Cidade Cidade { get => cidade; set => cidade = value; }
    }
}
