using System.Collections.Generic;
using System.Globalization;

namespace Slovoca {
  class WordComparer : IEqualityComparer<string> {
    private readonly CultureInfo locale;

    public WordComparer(CultureInfo comparingLocale) {
      this.locale = comparingLocale;
    }

    public bool Equals(string x, string y) {
      return this.locale.CompareInfo.Compare(x, y) == 0;
    }
    
    public int GetHashCode(string obj) {
      return obj.GetHashCode();
    }
  }
}
