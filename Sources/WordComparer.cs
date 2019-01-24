using System.Collections.Generic;
using System.Globalization;

namespace Slovoca {
  /// <summary>
  /// This class provides comparison method for objects of the Word class. The string comparison respects comparison rules associated with provided language.
  /// </summary>
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
