using System;

namespace Slovoca {
  class NotFoundException : Exception {
    public NotFoundException(string meaning) {
      Console.WriteLine("Word " + meaning + " is not in vocabulary!");
    }
  }
}
