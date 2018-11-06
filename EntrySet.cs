using System.Collections.Generic;
using System.Globalization;

namespace Slovoca {
  public class EntrySet {
    private readonly CultureInfo language;
    private SortedDictionary<string, Entry> allEntries;

    public EntrySet(CultureInfo language, bool isNative) {
      this.language = language;
      this.IsNative = isNative;
      this.allEntries = new SortedDictionary<string, Entry>(new WordComparer(language));
    }

    public CultureInfo Language {
      get {
        return this.language;
      }
    }

    public bool IsNative { get; set; }

    public SortedDictionary<string, Entry> AllEntries {
      get {
        return this.allEntries;
      }
    }

    public void AddEntry(Entry entry) {
      this.AllEntries.Add(entry.Meaning.Meaning, entry);
    }

    public void RemoveEntry(Entry entry) {
      this.AllEntries.Remove(entry.Meaning.Meaning);
    }

    public Entry FindEntry(Entry entry) {
      Entry result;
      if(this.AllEntries.TryGetValue(entry.Meaning.Meaning, out result)) {
        return result;
      }

      throw new NotFoundException(entry.Meaning.Meaning);
    }

    public Entry FindEntry(string meaning) {
      Entry result;
      if (this.AllEntries.TryGetValue(meaning, out result)) {
        return result;
      }

      throw new NotFoundException(meaning);
    }
  }
}
