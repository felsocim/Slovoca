using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slovoca {
  public partial class NewEntryDialog : Form {
    public delegate void handleAddConfirm(string meaning);
    public event handleAddConfirm OnAddConfirm;
    public NewEntryDialog() {
      InitializeComponent();
    }

    private void TriggerNewEntryAdd(object sender, EventArgs e) {
      this.OnAddConfirm(this.txbNewEntryEntry.Text);
    }
  }
}
