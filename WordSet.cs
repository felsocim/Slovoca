using System.Collections.Generic;
using System.Globalization;

namespace Slovoca {
  class WordSet {
    private readonly CultureInfo language;
    private readonly Dictionary<string, Word> vocabulary;

    public WordSet(CultureInfo locale) {
      this.language = locale;
      this.vocabulary = new Dictionary<string, Word>(new WordComparer(this.language));
    }

    public Dictionary<string, Word> WholeVocabulary {
      get {
        return this.vocabulary;
      }
    }

    public void AddWord(Word word) {
      this.vocabulary.Add(word.Meaning, word);
    }

    public void RemoveWord(Word word) {
      this.vocabulary.Remove(word.Meaning);
    }

    public Word FindWord(string meaning) {
      if(this.vocabulary.TryGetValue(meaning, out Word result)) {
        return result;
      }


      throw new NotFoundException(meaning);
    }
  }
}
