using ShrAgropecuaria.Classes;
using ShrAgropecuaria.Repositorios.Interfaces;
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
                //Application.Run(Dependencia.Container.GetInstance<view_Login>());
            }
            
        }
    }
}
