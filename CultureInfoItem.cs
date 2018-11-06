using System.Globalization;

namespace Slovoca {
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
      return this.Culture.DisplayName;
    }
  }
}