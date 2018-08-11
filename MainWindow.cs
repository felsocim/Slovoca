using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace Slovoca {
  public enum ActiveVocabulary {
    FOREIGN_TO_NATIVE,
    NATIVE_TO_FOREIGN
  }

  public partial class MainWindow : Form {
    public MainWindow() {
      // Dialogs
      this.CreateProjectDialog = new NewProjectDialog();
      this.AddEntryDialog = new NewEntryDialog();

      // Event handler associations
      this.CreateProjectDialog.OnConfirmProjectCreation += new NewProjectDialog.CreateProject(this.CreateNewProject);
      this.AddEntryDialog.OnAddConfirm += new NewEntryDialog.handleAddConfirm(this.AddForeignNativeEntry);

      InitializeComponent(); 
    }

    private Project CurrentProject { get; set; }

    private NewProjectDialog CreateProjectDialog { get; }

    private NewEntryDialog AddEntryDialog { get; }

    private ActiveVocabulary ActivePanel { get; set; }

    public void ToggleControls(bool activate) {
      // Main menu
      this.tmiSave.Enabled = activate;
      this.tmiSaveAs.Enabled = activate;
      this.tmiExport.Enabled = activate;
      this.tmiPrint.Enabled = activate;
      this.tmiCut.Enabled = activate;
      this.tmiCopy.Enabled = activate;
      this.tmiPaste.Enabled = activate;
      this.tmiAddEntry.Enabled = activate;
      this.tmiFindEntry.Enabled = activate;

      // Toolbar
      this.tsbSave.Enabled = activate;
      this.tsbSaveAs.Enabled = activate;
      this.tsbAddEntry.Enabled = activate;
      this.tstSearchQuery.Enabled = activate;
      this.tsbFindEntry.Enabled = activate;

      // Controls
      this.layMainWindow.Enabled = activate;
    }

    private void DeactivateEditControls(object sender, EventArgs e) {
      this.tsbEditEntry.Enabled = false;
      this.tsbRemoveEntry.Enabled = false;
    }

    private void TriggerNewProjectDialog(object sender, EventArgs e) {
      this.CreateProjectDialog.ShowDialog(this);
    }

    private void CreateNewProject(string file, CultureInfo native, CultureInfo foreign) {
      this.CurrentProject = new Project(file, native, foreign);
      this.ToggleControls(true);
      this.lblForeignToNativePanelTitle.Text = foreign.DisplayName + "-" + native.DisplayName;
      this.lblNativeToForeignPanelTitle.Text = native.DisplayName + "-" + foreign.DisplayName;
      this.SelectForeignToNativeVocabulary(null, null);
    }

    private void tsbAdd_Click(object sender, EventArgs e) {
      this.AddEntryDialog.ForeignLanguage = this.CurrentProject.ForeignEntries.Language;
      this.AddEntryDialog.ConfigureEnvironment(this.ActivePanel);
      this.AddEntryDialog.ShowDialog(this);
    }

    private void SelectForeignToNativeVocabulary(object sender, EventArgs e) {
      this.ActivePanel = ActiveVocabulary.FOREIGN_TO_NATIVE;

      this.pnlForeignToNativePanel.BackColor = Color.Blue;
      this.lblForeignToNativePanelTitle.ForeColor = Color.White;
      this.pnlNativeToForeignPanel.BackColor = Color.White;
      this.lblNativeToForeignPanelTitle.ForeColor = Color.Black;
    }

    private void SelectNativeToForeignVocabulary(object sender, EventArgs e) {
      this.ActivePanel = ActiveVocabulary.NATIVE_TO_FOREIGN;

      this.pnlForeignToNativePanel.BackColor = Color.White;
      this.lblForeignToNativePanelTitle.ForeColor = Color.Black;
      this.pnlNativeToForeignPanel.BackColor = Color.Blue;
      this.lblNativeToForeignPanelTitle.ForeColor = Color.White;
    }

    private void UpdateView() {
      ListBox target = this.ActivePanel == ActiveVocabulary.FOREIGN_TO_NATIVE ? this.lsbForeignToNative : this.lsbNativeToForeign;
      EntrySet current = this.ActivePanel == ActiveVocabulary.FOREIGN_TO_NATIVE ? this.CurrentProject.ForeignEntries : this.CurrentProject.NativeEntries;

      target.Items.Clear();

      for (int i = 0; i < current.AllEntries.Count; i++) {
        target.Items.Add(current.AllEntries.ElementAt(i).Value);
      }
    }

    private void ShowDetailedEntryInformation(object sender, EventArgs e) {
      ListBox selected;
      switch (this.ActivePanel) {
        case ActiveVocabulary.FOREIGN_TO_NATIVE:
          selected = this.lsbForeignToNative;
          break;
        case ActiveVocabulary.NATIVE_TO_FOREIGN:
          selected = this.lsbNativeToForeign;
          break;
        default:
          MessageBox.Show(this, "No vocabulary has been selected!", "Unspecified vocabulary", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
      }

      if (selected.SelectedIndex == -1) {
        return;
      }

      this.tsbEditEntry.Enabled = true;
      this.tsbRemoveEntry.Enabled = true;

      Entry current = (Entry) selected.SelectedItem;

      this.lblSelectedItemWord.Text = current.Meaning.Meaning;

      if(current.Meaning.HasPronounciation()) {
        this.lblSelectedItemWord.Text += " [" + current.Meaning.Pronounciation + "]";
      }

      this.lsbSelectedItemTranslations.Items.Clear();

      for (int i = 0; i < current.Translations.WholeVocabulary.Count; i++) {
        Word word = current.Translations.WholeVocabulary.ElementAt(i).Value;
        this.lsbSelectedItemTranslations.Items.Add(word.Meaning + " [" + word.Pronounciation + "]");
      }

      this.lblSelectedItemNotes.Text = current.Notes;
    }

    private void AddForeignNativeEntry(Entry entry) {
      bool insertIntoExisting = true;
      Entry existing = entry;

      try {
        existing = this.ActivePanel == ActiveVocabulary.FOREIGN_TO_NATIVE ? this.CurrentProject.ForeignEntries.FindEntry(entry) : this.CurrentProject.NativeEntries.FindEntry(entry);
      } catch (NotFoundException) {
        insertIntoExisting = false;
      }

      if(insertIntoExisting) {
        if (MessageBox.Show(this, "The entry '" + entry.Meaning.Meaning + "' already exists in the selected vocabulary. Would you like to update it with the translations you've defined in this window?", "Entry already exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
          for (int i = 0; i < entry.Translations.WholeVocabulary.Count; i++) {
            existing.Translations.AddWord(entry.Translations.WholeVocabulary.Values.ElementAt(i));
          }
        } else {
          return;
        }        
      } else {
        if (this.ActivePanel == ActiveVocabulary.FOREIGN_TO_NATIVE) {
          this.CurrentProject.ForeignEntries.AddEntry(entry);
        } else {
          this.CurrentProject.NativeEntries.AddEntry(entry);
        }
      }

      this.UpdateView();
    }
  }
}
