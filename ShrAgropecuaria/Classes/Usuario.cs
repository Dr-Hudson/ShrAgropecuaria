using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Classes
{
    class Usuario
    {
        int? user_cod;
        int user_nivel;
        char user_status;
        string user_login;
        string user_senha;

        public int? User_cod { get => user_cod; set => user_cod = value; }
        public int User_nivel { get => user_nivel; set => user_nivel = value; }
        public char User_status { get => user_status; set => user_status = value; }
        public string User_login { get => user_login; set => user_login = value; }
        public string User_senha { get => user_senha; set => user_senha = value; }
    }
}
