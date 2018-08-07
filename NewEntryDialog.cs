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

    private void TriggerNewEntryAdd(object sender, EventArgs e) {
      this.OnAddConfirm(new Entry(this.txbNewEntryEntry.Lines[0], this.txbNewEntryTranslations.Lines, this.txbNewEntryPronounciations.Lines, this.txbNewEntryNotes.Lines, this.ForeignLanguage));
      this.Close();
    }
  }
}
