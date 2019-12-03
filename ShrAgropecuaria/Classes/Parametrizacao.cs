using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    public class Parametrizacao
    {
        string par_nomeemp;
        string par_logo;
        string par_cnpj;
        string par_endereco;
        string par_bairro;
        string par_cep;
        string par_complemento;
        int par_numero;
        int cid_cod;

        public string Par_nomeemp { get => par_nomeemp; set => par_nomeemp = value; }
        public string Par_logo { get => par_logo; set => par_logo = value; }
        public string Par_cnpj { get => par_cnpj; set => par_cnpj = value; }
        public string Par_endereco { get => par_endereco; set => par_endereco = value; }
        public string Par_bairro { get => par_bairro; set => par_bairro = value; }
        public string Par_cep { get => par_cep; set => par_cep = value; }
        public string Par_complemento { get => par_complemento; set => par_complemento = value; }
        public int Par_numero { get => par_numero; set => par_numero = value; }
        public int Cid_cod { get => cid_cod; set => cid_cod = value; }
    }
}
