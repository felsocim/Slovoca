using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System;

namespace Slovoca {
  public class Project {
    public Project() { }

    public Project(string location, CultureInfo native, CultureInfo foreign) {
      this.Location = location;
      this.NativeEntries = new EntrySet(native, true);
      this.ForeignEntries = new EntrySet(foreign, false);
    }

    public Project(string location) {
      this.Location = location;
    }

    public string Location { get; set; }

    public EntrySet NativeEntries { get; set; }

    public EntrySet ForeignEntries { get; set; }

    private void WriteEntrySet(XmlTextWriter writer, ActiveVocabulary target) {
      EntrySet entries;

      if(target == ActiveVocabulary.FOREIGN_TO_NATIVE) {
        writer.WriteStartElement("ForeignEntries");
        entries = this.ForeignEntries;
      } else {
        writer.WriteStartElement("NativeEntries");
        entries = this.NativeEntries;
      }

      foreach (Entry entry in entries.AllEntries.Values) {
        writer.WriteStartElement("Entry");
        writer.WriteStartElement("Word");
        writer.WriteStartElement("Meaning");
        writer.WriteString(entry.Meaning.Meaning);
        writer.WriteEndElement();
        writer.WriteStartElement("Pronounciation");
        writer.WriteString(entry.Meaning.HasPronounciation() ? entry.Meaning.Pronounciation : "");
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteStartElement("Translations");

        foreach (Word translation in entry.Translations.WholeVocabulary.Values) {
          writer.WriteStartElement("Word");
          writer.WriteStartElement("Meaning");
          writer.WriteString(translation.Meaning);
          writer.WriteEndElement();
          writer.WriteStartElement("Pronounciation");
          writer.WriteString(translation.HasPronounciation() ? translation.Pronounciation : "");
          writer.WriteEndElement();
          writer.WriteEndElement();
        }

        writer.WriteEndElement();
        writer.WriteStartElement("Notes");
        writer.WriteString(entry.Notes ?? "");
        writer.WriteEndElement();
        writer.WriteEndElement();
      }

      writer.WriteEndElement();
    }

    private void LoadEntrySet(XElement vocabulary, ActiveVocabulary target) {
      EntrySet set = null;
      IEnumerable<XElement> entries = null;

      switch (target) {
        case ActiveVocabulary.FOREIGN_TO_NATIVE:
          set = this.ForeignEntries;
          entries = from entry in vocabulary.Elements("ForeignEntries").Elements("Entry") select entry;
          break;
        case ActiveVocabulary.NATIVE_TO_FOREIGN:
          set = this.NativeEntries;
          entries = from entry in vocabulary.Elements("NativeEntries").Elements("Entry") select entry;
          break;
      }

      foreach (XElement entry in entries) {
        List<string> translations = new List<string>(),
                     pronounciations = new List<string>();

        IEnumerable<XElement> words = from node in entry.Elements("Translations").Elements("Word") select node;

        foreach (XElement word in words) {
          translations.Add((string)(from item in word.Elements("Meaning") select item).First());
          pronounciations.Add((string)(from item in word.Elements("Pronounciation") select item).First());
        }

        XElement meaning = (from node in entry.Elements("Word") select node).First(),
                 notes = (from node in entry.Elements("Notes") select node).First();

        switch (target) {
          case ActiveVocabulary.FOREIGN_TO_NATIVE:
            set.AddEntry(new Entry((string)(from node in meaning.Elements("Meaning") select node).First(), (string)(from node in meaning.Elements("Pronounciation") select node).First(), translations.ToArray(), pronounciations.ToArray(), ((string)notes).Split('\n'), this.NativeEntries.Language));
            break;
          case ActiveVocabulary.NATIVE_TO_FOREIGN:
            set.AddEntry(new Entry((string)(from node in meaning.Elements("Meaning") select node).First(), (string)(from node in meaning.Elements("Pronounciation") select node).First(), translations.ToArray(), pronounciations.ToArray(), ((string)notes).Split('\n'), this.ForeignEntries.Language));
            break;
        }
      }
    }

    public string SaveToDisk() {
      FileStream file;
      XmlTextWriter writer;

      try {
        file = new FileStream(this.Location, FileMode.Create, FileAccess.Write, FileShare.Read);
        writer = new XmlTextWriter(file, System.Text.Encoding.UTF8) {
          Formatting = Formatting.Indented,
          Indentation = 2,
          IndentChar = ' '
        };
      } catch(Exception exception) {
        return exception.Message;
      }

      writer.WriteStartDocument();

      writer.WriteComment("Slovoca vocabulary project file");
      writer.WriteComment("Created by Slovoca (C) 2018 Marek Felsoci (Feldev)");

      writer.WriteStartElement("Vocabulary");

      writer.WriteStartElement("Properties");
      writer.WriteStartElement("ForeignLanguage");
      writer.WriteString(this.ForeignEntries.Language.Name);
      writer.WriteEndElement();
      writer.WriteStartElement("NativeLanguage");
      writer.WriteString(this.NativeEntries.Language.Name);
      writer.WriteEndElement();
      writer.WriteEndElement();

      this.WriteEntrySet(writer, ActiveVocabulary.FOREIGN_TO_NATIVE);
      this.WriteEntrySet(writer, ActiveVocabulary.NATIVE_TO_FOREIGN);

      writer.WriteEndElement();

      writer.WriteEndDocument();
      writer.Close();

      return null;
    }

    public void ReadFromDisk() {
      FileStream file = new FileStream(this.Location, FileMode.Open, FileAccess.Read, FileShare.Read);
      XElement vocabulary = XElement.Load(file);

      this.ForeignEntries = new EntrySet(new CultureInfo((string) (from culture in vocabulary.Descendants("ForeignLanguage") select culture).First()), false);
      this.NativeEntries = new EntrySet(new CultureInfo((string) (from culture in vocabulary.Descendants("NativeLanguage") select culture).First()), true);

      this.LoadEntrySet(vocabulary, ActiveVocabulary.FOREIGN_TO_NATIVE);
      this.LoadEntrySet(vocabulary, ActiveVocabulary.NATIVE_TO_FOREIGN);

      file.Close();
    }
  }
}