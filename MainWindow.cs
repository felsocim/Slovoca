using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
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
      this.AboutDialog = new AboutBox();

      // Event handler associations
      this.CreateProjectDialog.OnConfirmProjectCreation += new NewProjectDialog.CreateProject(this.CreateNewProject);
      this.AddEntryDialog.OnAddConfirm += new NewEntryDialog.handleAddConfirm(this.AddForeignNativeEntry);

      InitializeComponent(); 
    }

    private Project CurrentProject { get; set; }

    private NewProjectDialog CreateProjectDialog { get; }

    private NewEntryDialog AddEntryDialog { get; }

    private AboutBox AboutDialog { get; }

    private ActiveVocabulary ActivePanel { get; set; }

    public void ToggleControls(bool activate) {
      // Main menu
      this.tmiSave.Enabled = activate;
      this.tmiSaveAs.Enabled = activate;
      this.tmiEntry.Enabled = activate;

      // Toolbar
      this.tsbSave.Enabled = activate;
      this.tsbSaveAs.Enabled = activate;
      this.tsbAddEntry.Enabled = activate;
      this.tsbEditEntry.Enabled = activate;
      this.tsbRemoveEntry.Enabled = activate;
      this.tstSearchQuery.Enabled = activate;
      this.tsbFindEntry.Enabled = activate;

      // Controls
      this.layMainWindow.Enabled = activate;
    }

    private void ClearSelectItemInformation() {
      this.lblSelectedItemWord.Text = "";
      this.lsbSelectedItemTranslations.Items.Clear();
      this.lblSelectedItemNotes.Text = "";
    }

    private void DeactivateEditControls(object sender, EventArgs e) {
      this.tsbEditEntry.Enabled = false;
      this.tsbRemoveEntry.Enabled = false;
    }

    private void TriggerNewProjectDialog(object sender, EventArgs e) {
      this.CreateProjectDialog.ShowDialog(this);
    }

    private void TriggerOpenProjectDialog(object sender, EventArgs e) {
      this.dlgOpenProject.ShowDialog(this);
    }

    private void ConfirmProjectOpen(object sender, CancelEventArgs e) {
      this.CurrentProject = new Project(this.dlgOpenProject.FileName);
      this.CurrentProject.ReadFromDisk();

      this.lsbForeignToNative.Items.Clear();
      this.lsbNativeToForeign.Items.Clear();

      foreach (Entry entry in this.CurrentProject.ForeignEntries.AllEntries.Values) {
        this.lsbForeignToNative.Items.Add(entry);
      }

      foreach(Entry entry in this.CurrentProject.NativeEntries.AllEntries.Values) {
        this.lsbNativeToForeign.Items.Add(entry);
      }

      this.ToggleControls(true);

      this.lblForeignToNativePanelTitle.Text = this.CurrentProject.ForeignEntries.Language.DisplayName + "-" + this.CurrentProject.NativeEntries.Language.DisplayName;
      this.lblNativeToForeignPanelTitle.Text = this.CurrentProject.NativeEntries.Language.DisplayName + "-" + this.CurrentProject.ForeignEntries.Language.DisplayName;
      this.SelectForeignToNativeVocabulary(null, null);
    }

    private void TriggerSaveProjectAsDialog(object sender, EventArgs e) {
      this.dlgSaveProjectAs.ShowDialog(this);
    }

    private void ConfirmSaveProjectAs(object sender, CancelEventArgs e) {
      this.CurrentProject.Location = this.dlgSaveProjectAs.FileName;
      this.CurrentProject.SaveToDisk();
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
      this.AddEntryDialog.PrepareForAdding();
      this.AddEntryDialog.ShowDialog(this);
    }

    private void TriggerEditEntry(object sender, EventArgs e) {
      ListBox active = this.ActivePanel == ActiveVocabulary.FOREIGN_TO_NATIVE ? this.lsbForeignToNative : lsbNativeToForeign;

      if(active.SelectedIndex == -1) {
        MessageBox.Show(this, "No item has been selected for editing!", "Nothing to edit", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      Entry selected = (Entry) active.SelectedItem;

      this.AddEntryDialog.ForeignLanguage = this.CurrentProject.ForeignEntries.Language;
      this.AddEntryDialog.ConfigureEnvironment(this.ActivePanel);
      this.AddEntryDialog.PrepareForEditing(selected);
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
        this.lsbSelectedItemTranslations.Items.Add(word.Meaning + (word.HasPronounciation() ? " [" + word.Pronounciation + "]" : ""));
      }

      this.lblSelectedItemNotes.Text = current.Notes;
    }

    private void AddForeignNativeEntry(Entry entry, bool editing) {
      bool insertIntoExisting = true;
      Entry existing = entry;

      try {
        existing = this.ActivePanel == ActiveVocabulary.FOREIGN_TO_NATIVE ? this.CurrentProject.ForeignEntries.FindEntry(entry) : this.CurrentProject.NativeEntries.FindEntry(entry);
      } catch (NotFoundException) {
        if (editing) {
          MessageBox.Show(this, "The edited entry is no longer present in the target vocabulary!", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        insertIntoExisting = false;
      }

      if (editing) {
        switch(this.ActivePanel) {
          case ActiveVocabulary.FOREIGN_TO_NATIVE:
            this.CurrentProject.ForeignEntries.RemoveEntry(existing);
            this.CurrentProject.ForeignEntries.AddEntry(entry);
            break;
          case ActiveVocabulary.NATIVE_TO_FOREIGN:
            this.CurrentProject.NativeEntries.RemoveEntry(existing);
            this.CurrentProject.NativeEntries.AddEntry(entry);
            break;
        }

        this.UpdateView();
        return;
      }

      if (!insertIntoExisting) {
        if (this.ActivePanel == ActiveVocabulary.FOREIGN_TO_NATIVE) {
          this.CurrentProject.ForeignEntries.AddEntry(entry);
        } else {
          this.CurrentProject.NativeEntries.AddEntry(entry);
        }

        this.UpdateView();
        return;
      }

      insertIntoExisting = MessageBox.Show(this, "The entry '" + entry.Meaning.Meaning + "' already exists in the selected vocabulary. Would you like to update it?", "Entry already exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

      if(insertIntoExisting) {
        if(this.ActivePanel == ActiveVocabulary.FOREIGN_TO_NATIVE) {
          existing.Meaning.Pronounciation = entry.Meaning.Pronounciation;
        }

        foreach (Word translation in entry.Translations.WholeVocabulary.Values) {
          existing.Translations.AddWord(translation);
        }

        existing.Notes = entry.Notes;
      } 

      this.UpdateView();
    }

    private void TriggerRemoveEntry(object sender, EventArgs e) {
      ListBox source;
      EntrySet target;

      switch(this.ActivePanel) {
        case ActiveVocabulary.FOREIGN_TO_NATIVE:
          target = this.CurrentProject.ForeignEntries;
          source = this.lsbForeignToNative;
          break;
        case ActiveVocabulary.NATIVE_TO_FOREIGN:
          target = this.CurrentProject.NativeEntries;
          source = this.lsbNativeToForeign;
          break;
        default:
          Console.WriteLine("[Error] No vocabulary is active!");
          return;
      }

      if (source.SelectedIndex == -1) {
        MessageBox.Show(this, "No item was selected in the active vocabulary!", "Nothing to remove", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      target.RemoveEntry((Entry) source.SelectedItem);
      this.ClearSelectItemInformation();
      this.UpdateView();
    }

    private void TriggerFindEntry(object sender, EventArgs e) {
      EntrySet source;
      ListBox target;

      switch (this.ActivePanel) {
        case ActiveVocabulary.FOREIGN_TO_NATIVE:
          source = this.CurrentProject.ForeignEntries;
          target = this.lsbForeignToNative;
          break;
        case ActiveVocabulary.NATIVE_TO_FOREIGN:
          source = this.CurrentProject.NativeEntries;
          target = this.lsbNativeToForeign;
          break;
        default:
          Console.WriteLine("[Error] No vocabulary is active!");
          return;
      }

      Entry found;

      try {
        found = source.FindEntry(this.tstSearchQuery.Text);
      } catch (NotFoundException) {
        MessageBox.Show(this, "The entry '" + this.tstSearchQuery.Text + "' was not found in the active vocabulary.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      target.SelectedItem = found;
    }

    private void TriggerSave(object sender, EventArgs e) {
      this.CurrentProject.SaveToDisk();
    }

    private void TriggerSlovocaOnline(object sender, EventArgs e) {
      System.Diagnostics.Process.Start("https://github.com/felsocim/Slovoca");
    }

    private void TriggerAboutSlovoca(object sender, EventArgs e) {
      this.AboutDialog.ShowDialog(this);
    }

    private void TriggerExit(object sender, EventArgs e) {
      // TODO: Check if unsaved and prompt user to confirm exit
      Application.Exit();
    }
  }
}
