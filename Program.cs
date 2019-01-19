using System;
using System.Windows.Forms;

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

      if(args.Length == 1) {
        window.ProjectOpen(args[0]);
      } else {
        window.ToggleControls(false);
      }

      Application.Run(window);
    }
  }
}
