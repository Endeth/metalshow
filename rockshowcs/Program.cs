using System;
using System.Windows.Forms;

namespace Metalshow
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            ApplicationContext form = new MetalshowContext();
            Application.Run( form );
        }
    }
}
