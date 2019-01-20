namespace Slovoca {
  public class Word {
    public Word(string meaning, string pronounciation = null) {
      this.Meaning = meaning;
      this.Pronounciation = pronounciation;
    }

    public string Meaning { get; set; }

    public string Pronounciation { get; set; }

    public bool HasPronounciation() {
      return (this.Pronounciation != null && this.Pronounciation.Length > 0);
    }
  }
}
