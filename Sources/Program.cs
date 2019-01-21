using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Slovoca {
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args) {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      MainWindow window = new MainWindow();

      RegistryKey slovoca = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Slovoca");
      int locale = 1033;

      if(slovoca != null) {
        try {
          locale = int.Parse(slovoca.GetValue("Locale").ToString());
        } catch(Exception) {
          locale = 1033;
        }
      }

      window.Locale = locale;
      window.Strings = new System.Resources.ResXResourceSet("Strings" + locale.ToString());

      if(args.Length == 1) {
        window.ProjectOpen(args[0]);
      } else {
        window.ToggleControls(false);
      }

      Application.Run(window);
    }
  }
}
