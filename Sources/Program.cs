using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace Slovoca {
  static class Globals {
    public const string SettingsFile = "settings.xml";
  }

  /// <summary>
  /// Main class of the program.
  /// </summary>
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args) {
      // Try to determine language code for the application from program settings file (if any). If the code can not be determined from the settings file, Slovoca will try to use the current OS language, if it fails English will be used as fallback language.
      FileStream file = null;
      XDocument settings = null;
      string locale;

      try {
        file = new FileStream(Globals.SettingsFile, FileMode.Open, FileAccess.Read, FileShare.Read);
        settings = XDocument.Load(file);
        locale = (string)(from culture in settings.Descendants("Locale")
                          select culture).First();
      } catch(FileNotFoundException) {
        locale = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
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
