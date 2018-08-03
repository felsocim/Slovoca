using System.Collections.Generic;
using System.Globalization;

namespace Slovoca {
  class EntrySet {
    public EntrySet(CultureInfo language, bool isNative) {
      this.Language = language;
      this.IsNative = isNative;
      this.AllEntries = new Dictionary<string, Entry>(new WordComparer(language));
    }

    public CultureInfo Language { get; }

    public bool IsNative { get; set; }

    public Dictionary<string, Entry> AllEntries { get; }

    public void AddEntry(Entry entry) {
      this.AllEntries.Add(entry.Meaning.Meaning, entry);
    }

    public void RemoveEntry(Entry entry) {
      this.AllEntries.Remove(entry.Meaning.Meaning);
    }

    public Entry FindEntry(Entry entry) {
      if(this.AllEntries.TryGetValue(entry.Meaning.Meaning, out Entry result)) {
        return result;
      }

      throw new NotFoundException(entry.Meaning.Meaning);
    }
  }
}
