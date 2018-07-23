using System.Globalization;

namespace Slovoca {
  class Entry {
    private readonly Word entry;
    private readonly WordSet translations;
    private string notes;

    public Entry(string meaning, string[] translations, string[] pronounciations, CultureInfo foreignLanguage) {
      this.entry = new Word(meaning);
      this.translations = new WordSet(foreignLanguage);

      for(int i = 0; i < translations.Length; i++) {
        this.translations.AddWord(new Word(translations[i], pronounciations == null || i >= pronounciations.Length ? null : pronounciations[i]));
      }
    }

    public Word Meaning {
      get {
        return this.entry;
      }
    }

    public WordSet Translations {
      get {
        return this.translations;
      }
    }
    
    public string Notes {
      get {
        return this.notes;
      }
      set {
        this.notes = value;
      }
    }
  }
}
