using System.Globalization;

namespace Slovoca {
  public class Entry {
    public Entry(string meaning, string pronounciation, string[] translations, string[] pronounciations, string[] notes, CultureInfo foreignLanguage) {
      this.Meaning = new Word(meaning, pronounciation);
      this.Translations = new WordSet(foreignLanguage);

      for(int i = 0; i < translations.Length; i++) {
        this.Translations.AddWord(new Word(translations[i], pronounciations == null || i >= pronounciations.Length ? null : pronounciations[i]));
      }

      this.Notes = string.Join("\n", notes);
    }

    public Word Meaning {
      get;
      private set;
    }

    public WordSet Translations {
      get;
      private set;
    }

    public string Notes {
      get;
      set; 
    }

    public override string ToString() {
      return this.Meaning.Meaning;
    }
  }
}