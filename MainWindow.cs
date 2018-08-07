using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Slovoca {
  enum ActiveVocabulary {
    FOREIGN_TO_NATIVE,
    NATIVE_TO_FOREIGN
  }

  public partial class MainWindow : Form {
    public MainWindow() {
      this.AddEntryDialog = new NewEntryDialog();
      this.AddEntryDialog.OnAddConfirm += new NewEntryDialog.handleAddConfirm(AddForeignNativeEntry);
      InitializeComponent();
      this.ActivePanel = ActiveVocabulary.FOREIGN_TO_NATIVE;
      this.ForeignToNative = new EntrySet(new CultureInfo("cs-CZ"), false);
      this.NativeToForeign = new EntrySet(new System.Globalization.CultureInfo("sk-SK"), true);
    }

    private EntrySet ForeignToNative { get; }

    private EntrySet NativeToForeign { get; }

    private ActiveVocabulary ActivePanel { get; set; }

    private NewEntryDialog AddEntryDialog { get; }

    private void tsbAdd_Click(object sender, EventArgs e) {
      this.AddEntryDialog.ShowDialog(this);
    }

    private void UpdateView() {
      ListBox target = this.ActivePanel == ActiveVocabulary.FOREIGN_TO_NATIVE ? this.lsbForeignToNative : this.lsbNativeToForeign;
      EntrySet current = this.ActivePanel == ActiveVocabulary.FOREIGN_TO_NATIVE ? this.ForeignToNative : this.NativeToForeign;

      target.Items.Clear();

      for (int i = 0; i < current.AllEntries.Count; i++) {
        target.Items.Add(current.AllEntries.ElementAt(i).Key);
      }
    }

    private void AddForeignNativeEntry(Entry entry) {
      bool insertIntoExisting = true;
      Entry existing = entry;

      try {
        existing = this.ActivePanel == ActiveVocabulary.FOREIGN_TO_NATIVE ? this.ForeignToNative.FindEntry(entry) : this.NativeToForeign.FindEntry(entry);
      } catch (NotFoundException) {
        insertIntoExisting = false;
      }

      if(insertIntoExisting) {
        for(int i = 0; i < entry.Translations.WholeVocabulary.Count; i++) {
          existing.Translations.AddWord(entry.Translations.WholeVocabulary.Values.ElementAt(i));
        }
      } else {
        this.ForeignToNative.AddEntry(entry);
      }

      this.UpdateView();
    }
  }
}
