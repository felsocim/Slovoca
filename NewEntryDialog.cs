using System;
using System.Globalization;
using System.Windows.Forms;

namespace Slovoca {
  public partial class NewEntryDialog : Form {
    public delegate void handleAddConfirm(Entry meaning);
    public event handleAddConfirm OnAddConfirm;
    public NewEntryDialog() {
      InitializeComponent();
    }

    public CultureInfo ForeignLanguage { get; set; }

    public void ConfigureEnvironment(ActiveVocabulary vocabulary) {
      this.lblNewEntryEntryPronounciation.Enabled = vocabulary == ActiveVocabulary.FOREIGN_TO_NATIVE;
      this.txbNewEntryEntryPronounciation.Enabled = vocabulary == ActiveVocabulary.FOREIGN_TO_NATIVE;
      this.lblNewEntryPronounciations.Enabled = vocabulary == ActiveVocabulary.NATIVE_TO_FOREIGN;
      this.txbNewEntryPronounciations.Enabled = vocabulary == ActiveVocabulary.NATIVE_TO_FOREIGN;
    }

    private void SelfClean() {
      this.txbNewEntryEntry.Clear();
      this.txbNewEntryTranslations.Clear();
      this.txbNewEntryPronounciations.Clear();
      this.txbNewEntryNotes.Clear();
    }

    private void CancelNewEntryAdd(object sender, EventArgs e) {
      this.SelfClean();
      this.Close();
    }

    private void TriggerNewEntryAdd(object sender, EventArgs e) {
      this.OnAddConfirm(new Entry(this.txbNewEntryEntry.Lines[0], this.txbNewEntryEntryPronounciation.Lines[0] == "" ? null : this.txbNewEntryEntryPronounciation.Lines[0], this.txbNewEntryTranslations.Lines, this.txbNewEntryPronounciations.Lines, this.txbNewEntryNotes.Lines, this.ForeignLanguage));

      this.SelfClean();
      this.Close();
    }
  }
}
