using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Slovoca {
  public partial class NewEntryDialog : Form {
    public delegate void handleAddConfirm(Entry meaning, bool editing);
    public event handleAddConfirm OnAddConfirm;
    public NewEntryDialog() {
      InitializeComponent();
    }

    public CultureInfo ForeignLanguage { get; set; }

    public bool EditMode { get; set; }

    public void ConfigureEnvironment(ActiveVocabulary vocabulary) {
      this.lblNewEntryEntryPronounciation.Enabled = vocabulary == ActiveVocabulary.FOREIGN_TO_NATIVE;
      this.txbNewEntryEntryPronounciation.Enabled = vocabulary == ActiveVocabulary.FOREIGN_TO_NATIVE;
      this.lblNewEntryPronounciations.Enabled = vocabulary == ActiveVocabulary.NATIVE_TO_FOREIGN;
      this.txbNewEntryPronounciations.Enabled = vocabulary == ActiveVocabulary.NATIVE_TO_FOREIGN;
    }

    public void PrepareForAdding() {
      this.Text = "Add entry";
      this.btnNewEntryAdd.Text = "Add";
      this.txbNewEntryEntry.Enabled = true;
      this.EditMode = false;
    }

    public void PrepareForEditing(Entry entry) {
      this.Text = "Edit entry";
      this.btnNewEntryAdd.Text = "Save changes";
      this.txbNewEntryEntry.Text = entry.Meaning.Meaning;
      this.txbNewEntryEntry.Enabled = false;
      this.txbNewEntryEntryPronounciation.Text = entry.Meaning.HasPronounciation() ? entry.Meaning.Pronounciation : "";

      List<string> translations = new List<string>(),
                   pronounciations = new List<string>();
      foreach (Word translation in entry.Translations.WholeVocabulary.Values) {
        translations.Add(translation.Meaning);
        if(translation.HasPronounciation()) {
          pronounciations.Add(translation.Pronounciation);
        }
      }

      this.txbNewEntryTranslations.Lines = translations.ToArray();
      this.txbNewEntryPronounciations.Lines = pronounciations.ToArray();
      this.txbNewEntryNotes.Lines = entry.Notes.Split('\n');

      this.EditMode = true;
    }

    private void SelfClean() {
      this.txbNewEntryEntry.Clear();
      this.txbNewEntryEntryPronounciation.Clear();
      this.txbNewEntryTranslations.Clear();
      this.txbNewEntryPronounciations.Clear();
      this.txbNewEntryNotes.Clear();
    }

    private void CancelNewEntryAdd(object sender, EventArgs e) {
      this.SelfClean();
      this.Close();
    }

    private void TriggerNewEntryAdd(object sender, EventArgs e) {
      if(this.txbNewEntryEntry.Lines.Length < 1) {
        MessageBox.Show(this, "You must fill the entry value!", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if(this.txbNewEntryTranslations.Lines.Length < 1) {
        MessageBox.Show(this, "You must provide at least one translation!", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      this.OnAddConfirm(
        new Entry(
          this.txbNewEntryEntry.Lines[0],
          this.txbNewEntryEntryPronounciation.Lines.Length > 0 ? this.txbNewEntryEntryPronounciation.Lines[0] : null,
          this.txbNewEntryTranslations.Lines,
          this.txbNewEntryPronounciations.Lines,
          this.txbNewEntryNotes.Lines,
          this.ForeignLanguage
        ),
        this.EditMode
      );
      
      this.SelfClean();
      this.Close();
    }
  }
}
