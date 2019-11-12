using ShrAgropecuaria.Classes;
using ShrAgropecuaria.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.MySqlRepository
{
    class MySqlFiadoRepository : MySqlRepository, IFiadoRepository
    {
        public MySqlFiadoRepository(IDbConnection connection) : base(connection)
        {

        }

        public IEnumerable<Cliente> BuscaPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> BuscaPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Grava(Cliente cli)
        {
            throw new NotImplementedException();
        }
    }
}
