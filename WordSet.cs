using System.Collections.Generic;
using System.Globalization;

namespace Slovoca {
  public class WordSet {
    private SortedDictionary<string, Word> wholeVocabulary;

    public WordSet(CultureInfo locale) {
      this.wholeVocabulary = new SortedDictionary<string, Word>(new WordComparer(locale));
    }

    public SortedDictionary<string, Word> WholeVocabulary {
      get {
        return this.wholeVocabulary;
      }
    }

    public void AddWord(Word word) {
      this.WholeVocabulary.Add(word.Meaning, word);
    }

    public void RemoveWord(Word word) {
      this.WholeVocabulary.Remove(word.Meaning);
    }

    public Word FindWord(string meaning) {
      Word result;
      if(this.WholeVocabulary.TryGetValue(meaning, out result)) {
        return result;
      }

      throw new NotFoundException(meaning);
    }
  }
}
