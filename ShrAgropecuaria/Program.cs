using ShrAgropecuaria.Classes;
using ShrAgropecuaria.Repositorios.Interfaces;
using ShrAgropecuaria.Repositorios.MySqlRepository;
using ShrAgropecuaria.Views;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjAvaliacao2Bim
{
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (ThreadScopedLifestyle.BeginScope(Dependencia.Container))
            {

                Dependencia.Configurar();
                Application.Run(new view_Menu());
                /*MySqlParametrizacaoRepository m = new MySqlParametrizacaoRepository(Connection.GetConnection());
                if(m.Get() == null)
                    Application.Run(Dependencia.Container.GetInstance<view_Parametrização>());
                Application.Run(Dependencia.Container.GetInstance<view_Login>());*/
            }
            
        }
    }
}
