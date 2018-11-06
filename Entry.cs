using System.Globalization;

namespace Slovoca {
  public class Entry {
    private readonly Word meaning;
    private readonly WordSet translations;
    private string notes;

    public Entry(string meaning, string pronounciation, string[] translations, string[] pronounciations, string[] notes, CultureInfo foreignLanguage) {
      this.meaning = new Word(meaning, pronounciation);
      this.translations = new WordSet(foreignLanguage);

      for(int i = 0; i < translations.Length; i++) {
        this.Translations.AddWord(new Word(translations[i], pronounciations == null || i >= pronounciations.Length ? null : pronounciations[i]));
      }

      this.notes = string.Join("\n", notes);
    }

    public Word Meaning {
      get {
        return this.meaning;
      }
    }

    public WordSet Translations {
      get {
        return this.translations;
      }
    }

    public string Notes { get; set; }

    public override string ToString() {
      return this.Meaning.Meaning;
    }
  }
}
