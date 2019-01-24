using System.Globalization;

namespace Slovoca {
  /// <summary>
  /// This class represents a vocabulary entry defined by a meaning, a list of its translations and user notes. 
  /// </summary>
  public class Entry {
    /// <summary>
    /// Constructs an entry from provided information.
    /// </summary>
    /// <param name="meaning">Meaning of the entry.</param>
    /// <param name="pronounciation">Pronunciation of the meaning.</param>
    /// <param name="translations">Translations of the entry.</param>
    /// <param name="pronounciations">Pronunciations of the translations.</param>
    /// <param name="notes">User annotations.</param>
    /// <param name="foreignLanguage">Language of the translations.</param>
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