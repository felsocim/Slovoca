using System;
using System.Windows.Forms;

namespace Slovoca {
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      MainWindow window = new MainWindow();
      window.ToggleControls(false);

      Application.Run(window);
    }
  }
}
