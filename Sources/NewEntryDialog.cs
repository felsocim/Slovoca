﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Slovoca {
  /// <summary>
  /// Dialog allowing to add/edit an entry to/of a vocabulary.
  /// </summary>
  public partial class NewEntryDialog : Form {
    /// <summary>
    /// Function called when the user confirms an insertion/modification of the selected vocabulary entry.
    /// </summary>
    /// <param name="meaning">new/edited entry</param>
    /// <param name="editing">modification only?</param>
    public delegate void handleAddConfirm(Entry meaning, bool editing);
    public event handleAddConfirm OnAddConfirm;
    public NewEntryDialog() {
      InitializeComponent();
    }

    public CultureInfo ForeignLanguage { get; set; }

    public bool EditMode { get; set; }

    /// <summary>
    /// Configures the dialog depending on the target vocabulary part.
    /// </summary>
    /// <param name="vocabulary">Target vocabulary part.</param>
    public void ConfigureEnvironment(ActiveVocabulary vocabulary) {
      this.lblNewEntryEntryPronounciation.Enabled = vocabulary == ActiveVocabulary.FOREIGN_TO_NATIVE;
      this.txbNewEntryEntryPronounciation.Enabled = vocabulary == ActiveVocabulary.FOREIGN_TO_NATIVE;
      this.lblNewEntryPronounciations.Enabled = vocabulary == ActiveVocabulary.NATIVE_TO_FOREIGN;
      this.txbNewEntryPronounciations.Enabled = vocabulary == ActiveVocabulary.NATIVE_TO_FOREIGN;
    }

    /// <summary>
    /// Configures the dialog for adding an entry.
    /// </summary>
    public void PrepareForAdding() {
      this.Text = Properties.Resources.NEW_ENTRY_DIALOG_ADD_TITLE;
      this.btnNewEntryAdd.Text = Properties.Resources.NEW_ENTRY_DIALOG_ADD_BUTTON;
      this.txbNewEntryEntry.Enabled = true;
      this.EditMode = false;
    }

    /// <summary>
    /// Configures the dialog for editing the provided entry and fills it with associated data.
    /// </summary>
    /// <param name="entry">Entry to edit.</param>
    public void PrepareForEditing(Entry entry) {
      this.Text = Properties.Resources.NEW_ENTRY_DIALOG_EDIT_TITLE;
      this.btnNewEntryAdd.Text = Properties.Resources.NEW_ENTRY_DIALOG_EDIT_BUTTON;
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

    /// <summary>
    /// Triggers when the user clicks on the Add/Save button.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TriggerNewEntryAdd(object sender, EventArgs e) {
      if(this.txbNewEntryEntry.Lines.Length < 1) {
        MessageBox.Show(this, Properties.Resources.NEW_ENTRY_DIALOG_MISSING_ENTRY_MEANING, Properties.Resources.NEW_ENTRY_DIALOG_MISSING_DATA_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if(this.txbNewEntryTranslations.Lines.Length < 1) {
        MessageBox.Show(this, Properties.Resources.NEW_ENTRY_DIALOG_MISSING_TRANSLATION, Properties.Resources.NEW_ENTRY_DIALOG_MISSING_DATA_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
