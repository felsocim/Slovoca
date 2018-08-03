using System.Globalization;

namespace Slovoca {
  class Entry {
    public Entry(string meaning, string[] translations, string[] pronounciations, CultureInfo foreignLanguage) {
      this.Meaning = new Word(meaning);
      this.Translations = new WordSet(foreignLanguage);

      for(int i = 0; i < translations.Length; i++) {
        this.Translations.AddWord(new Word(translations[i], pronounciations == null || i >= pronounciations.Length ? null : pronounciations[i]));
      }
    }

    public Word Meaning { get; }

    public WordSet Translations { get; }

    public string Notes { get; set; }
  }
}
