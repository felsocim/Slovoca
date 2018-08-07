using System.Globalization;

namespace Slovoca {
  public class Entry {
    public Entry(string meaning, string[] translations, string[] pronounciations, string[] notes, CultureInfo foreignLanguage) {
      this.Meaning = new Word(meaning);
      this.Translations = new WordSet(foreignLanguage);

      for(int i = 0; i < translations.Length; i++) {
        this.Translations.AddWord(new Word(translations[i], pronounciations == null || i >= pronounciations.Length ? null : pronounciations[i]));
      }

      this.Notes = string.Join(" ", notes);
    }

    public Word Meaning { get; }

    public WordSet Translations { get; }

    public string Notes { get; set; }
  }
}
