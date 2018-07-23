namespace Slovoca {
  class Word {
    private string meaning,
      pronounciation;
    
    public Word(string meaning, string pronounciation = null) {
      this.meaning = meaning;
      this.pronounciation = pronounciation;
    }

    public string Meaning {
      get {
        return this.meaning;
      }
      set {
        this.meaning = value;
      }
    }

    public string Pronounciation {
      get {
        return this.pronounciation;
      }
      set {
        this.pronounciation = value;
      }
    }

    public bool HasPronounciation() {
      return this.pronounciation != null;
    }
  }
}
