using System.Collections.Generic;
using System.Globalization;

namespace Slovoca {
  class WordComparer : IComparer<string> {
    private readonly CultureInfo locale;

    public WordComparer(CultureInfo comparingLocale) {
      this.locale = comparingLocale;
    }

    public int Compare(string x, string y) {
      return this.locale.CompareInfo.Compare(x, y);
    }
    
    public int GetHashCode(string obj) {
      return obj.GetHashCode();
    }
  }
}
