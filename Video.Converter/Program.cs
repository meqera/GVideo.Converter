using System;
using System.Threading;
using System.Windows.Forms;

namespace Video.Converter
{
    /*
     * Developer        : Gehan Fernando
     * Date             : 08th April 2016
     * Contact          : f.gehan@gmail.com / +94772269625
     * 
     * Application      : This application helps you to convert videos on format to another format. eg: mp4 to mov.
    **/

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormVideoMain());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show(ex.Message, "Error - " + "Video Converter", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception as Exception;
            MessageBox.Show(ex.Message, "Error - " + "Video Converter", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}