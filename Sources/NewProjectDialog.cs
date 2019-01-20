using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

namespace Slovoca {
  public partial class NewProjectDialog : Form {
    public delegate void CreateProject(string file, CultureInfo native, CultureInfo foreign);
    public event CreateProject OnConfirmProjectCreation;

    public NewProjectDialog() {
      InitializeComponent();
    }

    public string FileName { get; private set; }

    private void LoadSystemSupportedCultures(object sender, EventArgs e) {
      CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

      foreach(CultureInfo culture in cultures) {
        cmbNewProjectForeignCultures.Items.Add(new CultureInfoItem(culture));
        cmbNewProjectNativeCultures.Items.Add(new CultureInfoItem(culture));
      }
    }

    private void TriggerFileBrowseDialog(object sender, EventArgs e) {
      this.dlgNewProjectFileSave.ShowDialog(this);
    }

    private void ConfirmProjectFileSave(object sender, CancelEventArgs e) {
      this.FileName = this.dlgNewProjectFileSave.FileName;
      this.txbNewProjectFile.Text = this.FileName;
    }

    private void CancelProjectCreation(object sender, EventArgs e) {
      this.FileName = "";

      this.txbNewProjectFile.Text = "";
      this.cmbNewProjectForeignCultures.SelectedIndex = -1;
      this.cmbNewProjectNativeCultures.SelectedIndex = -1;

      this.Close();
    }

    private void ConfirmProjectCreation(object sender, EventArgs e) {
      if(this.txbNewProjectFile.Text == "") {
        MessageBox.Show(this, "You must choose location and name for your new project file!", "Unspecified project file", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (this.cmbNewProjectForeignCultures.SelectedIndex == -1) {
        MessageBox.Show(this, "You must choose a foreign language culture of your new personalized vocabulary!", "Unspecified foreign language culture", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (this.cmbNewProjectNativeCultures.SelectedIndex == -1) {
        MessageBox.Show(this, "You must choose a native language culture of your new personalized vocabulary!", "Unspecified native language culture", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      CultureInfoItem foreign = (CultureInfoItem) this.cmbNewProjectForeignCultures.SelectedItem,
                      native = (CultureInfoItem) this.cmbNewProjectNativeCultures.SelectedItem;

      this.OnConfirmProjectCreation(this.FileName, native.Culture, foreign.Culture);
      this.Close();
    }
  }
}
