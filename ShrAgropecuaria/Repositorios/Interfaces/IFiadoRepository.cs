using ShrAgropecuaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.Interfaces
{
    interface IFiadoRepository
    {
        IEnumerable<Cliente> BuscaPorNome(string nome);

        IEnumerable<Cliente> BuscaPorCpf(string cpf);

        void Grava(Cliente cli);
    }
}
