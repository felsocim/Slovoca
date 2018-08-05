using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slovoca
{
  public partial class MainWindow : Form {
    public MainWindow() {
      this.AddEntryDialog = new NewEntryDialog();
      this.AddEntryDialog.OnAddConfirm += new NewEntryDialog.handleAddConfirm(AddForeignNativeEntry);
      InitializeComponent();
    }

    private NewEntryDialog AddEntryDialog { get; }

    private void tsbAdd_Click(object sender, EventArgs e) {
      this.AddEntryDialog.ShowDialog(this);
    }

    private void AddForeignNativeEntry(string meaning) {
      //this.lsvForeignToNative.Items.Add(meaning);
    }
  }
}
