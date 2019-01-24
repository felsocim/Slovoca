using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

namespace Slovoca {
  /// <summary>
  /// Dialog allowing to create a new vocabulary project.
  /// </summary>
  public partial class NewProjectDialog : Form {
    /// <summary>
    /// Function called when the user confirms the creation of a new vocabulary project.
    /// </summary>
    /// <param name="file">location of the project file</param>
    /// <param name="native">native language of the vocabulary</param>
    /// <param name="foreign">foreign language of the vocabulary</param>
    public delegate void CreateProject(string file, CultureInfo native, CultureInfo foreign);
    public event CreateProject OnConfirmProjectCreation;

    public NewProjectDialog() {
      InitializeComponent();
    }

    public string FileName { get; private set; }

    /// <summary>
    /// Loads the list of languages available for the user to define the new vocabulary with.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LoadSystemSupportedCultures(object sender, EventArgs e) {
      CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);

      for(int i = 1; i < cultures.Length; i++) {
        cmbNewProjectForeignCultures.Items.Add(new CultureInfoItem(cultures[i]));
        cmbNewProjectNativeCultures.Items.Add(new CultureInfoItem(cultures[i]));
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

    /// <summary>
    /// Called when the user clicks on Create button.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ConfirmProjectCreation(object sender, EventArgs e) {
      if(this.txbNewProjectFile.Text == "") {
        MessageBox.Show(this, Properties.Resources.NEW_PROJECT_DIALOG_UNSPECIFIED_LOCATION, Properties.Resources.NEW_PROJECT_DIALOG_UNSPECIFIED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (this.cmbNewProjectForeignCultures.SelectedIndex == -1) {
        MessageBox.Show(this, Properties.Resources.NEW_PROJECT_DIALOG_UNSPECIFIED_FOREIGN_CULTURE, Properties.Resources.NEW_PROJECT_DIALOG_UNSPECIFIED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (this.cmbNewProjectNativeCultures.SelectedIndex == -1) {
        MessageBox.Show(this, Properties.Resources.NEW_PROJECT_DIALOG_UNSPECIFIED_NATIVE_CULTURE, Properties.Resources.NEW_PROJECT_DIALOG_UNSPECIFIED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      CultureInfoItem foreign = (CultureInfoItem) this.cmbNewProjectForeignCultures.SelectedItem,
                      native = (CultureInfoItem) this.cmbNewProjectNativeCultures.SelectedItem;

      this.OnConfirmProjectCreation(this.FileName, native.Culture, foreign.Culture);
      this.Close();
    }
  }
}
