using System.Globalization;

namespace Slovoca {
  /// <summary>
  /// This class is used by the NewProjectDialog class to constitute the list of languages available to define a vocabulary with. It englobes items of CultureInfo class and provides them with custom implementation of the ToString function. 
  /// </summary>
  class CultureInfoItem {
    private readonly CultureInfo culture;

    public CultureInfoItem(CultureInfo culture) {
      this.culture = culture;
    }

    public CultureInfo Culture {
      get {
        return this.culture;
      }
    }

    public override string ToString() {
      return this.Culture.TwoLetterISOLanguageName.ToUpperInvariant() + " (" + this.Culture.NativeName + ")";
    }
  }
}