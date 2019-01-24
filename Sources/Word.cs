namespace Slovoca {
  /// <summary>
  /// This class represents either the meaning or one of the translations of a vocabulary entry.
  /// </summary>
  public class Word {
    public Word(string meaning, string pronounciation = null) {
      this.Meaning = meaning;
      this.Pronounciation = pronounciation;
    }

    /// <summary>
    /// Meaning of the word (word itself in its written form)
    /// </summary>
    public string Meaning { get; set; }

    /// <summary>
    /// Pronunciation of the word (may contain IPA characters)
    /// </summary>
    public string Pronounciation { get; set; }

    public bool HasPronounciation() {
      return (this.Pronounciation != null && this.Pronounciation.Length > 0);
    }
  }
}
