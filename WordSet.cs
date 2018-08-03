using System.Collections.Generic;
using System.Globalization;

namespace Slovoca {
  class WordSet {
    public WordSet(CultureInfo locale) {
      this.WholeVocabulary = new Dictionary<string, Word>(new WordComparer(locale));
    }

    public Dictionary<string, Word> WholeVocabulary { get; }

    public void AddWord(Word word) {
      this.WholeVocabulary.Add(word.Meaning, word);
    }

    public void RemoveWord(Word word) {
      this.WholeVocabulary.Remove(word.Meaning);
    }

    public Word FindWord(string meaning) {
      if(this.WholeVocabulary.TryGetValue(meaning, out Word result)) {
        return result;
      }

      throw new NotFoundException(meaning);
    }
  }
}
