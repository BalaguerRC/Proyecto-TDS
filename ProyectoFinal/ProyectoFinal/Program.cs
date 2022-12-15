using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    internal static class Program
    {
        public static bool boolAuthentication = false;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*do
            {
                Application.Run(new FormSplash());
                Application.Run(new FormLogin());
            } while (boolAuthentication);*/
            Application.Run(new FormSplash());
            Application.Run(new FormLogin());
            if (boolAuthentication)
            {
                Application.Run(new FormMenuPrincipal());
                
            }
        }
    }
}
