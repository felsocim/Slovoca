using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Globalization;

namespace Slovoca {
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args) {
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      MainWindow window = new MainWindow();

      /*RegistryKey slovoca = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Slovoca");
      string locale = "en";

      if(slovoca != null) {
        try {
          locale = slovoca.GetValue("Locale").ToString();
        } catch(Exception) {
          locale = "en";
        }
      }*/

      //Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(locale);
      

      if(args.Length == 1) {
        window.ProjectOpen(args[0]);
      } else {
        window.ToggleControls(false);
      }

      Application.Run(window);
    }
  }
}
