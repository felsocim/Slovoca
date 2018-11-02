using System.Globalization;

namespace Slovoca {
  class CultureInfoItem {
    public CultureInfoItem(CultureInfo culture) {
      this.Culture = culture;
    }

    public CultureInfo Culture { get; }

    public override string ToString() {
      return this.Culture.DisplayName;
    }
  }
}
