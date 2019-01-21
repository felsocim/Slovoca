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
      // Try to determine language code for the application from the Registry database. If the code can not be determined, English will be used by default.
      string locale = "en";

      try {
        RegistryKey slovoca = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Slovoca");
        locale = slovoca.GetValue("Locale").ToString();
      } catch(Exception) {
        locale = "en";
      }

      Thread.CurrentThread.CurrentUICulture = new CultureInfo(locale);

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      MainWindow window = new MainWindow();

      window.SetActiveUILanguage(locale);

      if(args.Length == 1) {
        window.ProjectOpen(args[0]);
      } else {
        window.ToggleControls(false);
      }

      // Show the UI
      Application.Run(window);
    }
  }
}
