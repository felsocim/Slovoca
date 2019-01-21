using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using Microsoft.Win32;

namespace Slovoca {
  public enum ActiveVocabulary {
    FOREIGN_TO_NATIVE,
    NATIVE_TO_FOREIGN
  }

  public partial class MainWindow : Form {
    private NewProjectDialog createProjectDialog;
    private NewEntryDialog addEntryDialog;
    private AboutBox aboutDialog;

    public MainWindow() {
      // Dialogs
      this.createProjectDialog = new NewProjectDialog();
      this.addEntryDialog = new NewEntryDialog();
      this.aboutDialog = new AboutBox();
      this.UnsavedChanges = false;

      // Event handler associations
      this.CreateProjectDialog.OnConfirmProjectCreation += new NewProjectDialog.CreateProject(this.CreateNewProject);
      this.AddEntryDialog.OnAddConfirm += new NewEntryDialog.handleAddConfirm(this.AddForeignNativeEntry);

      InitializeComponent(); 
    }

    private Project CurrentProject {
      get;
      set;
    }

    private NewProjectDialog CreateProjectDialog {
      get {
        return this.createProjectDialog;
      }
    }

    private NewEntryDialog AddEntryDialog {
      get {
        return this.addEntryDialog;
      }
    }

    private AboutBox AboutDialog {
      get {
        return this.aboutDialog;
      }
    }

    private ActiveVocabulary ActivePanel {
      get;
      set;
    }

    private bool UnsavedChanges {
      get;
      set;
    }

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

    public void SetActiveUILanguage(string locale) {
      switch(locale) {
        case "en":
          this.tmiEnglish.Checked = true;
          this.tmiSlovak.Checked = false;
          break;
        case "sk":
          this.tmiSlovak.Checked = true;
          this.tmiEnglish.Checked = false;
          break;
      }
    }

    private void TriggerChangeUILanguageToEnglish(object sender, EventArgs e) {
      if(!this.tmiEnglish.Checked) {
        try {
          RegistryKey slovoca = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Slovoca", true);
          slovoca.SetValue("Locale", "en");
        } catch(Exception exception) {
          MessageBox.Show(this, Properties.Resources.MAIN_WINDOWS_CHANGE_UI_LANGUAGE_ERROR_MESSAGE + "\n" + Properties.Resources.MAIN_WINDOWS_ERROR_MESSAGE_PREFIX + " " + exception.Message, Properties.Resources.MAIN_WINDOWS_CHANGE_UI_LANGUAGE_ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        MessageBox.Show(this, Properties.Resources.MAIN_WINDOWS_CHANGE_UI_LANGUAGE_RESTART_REQUIRED_MESSAGE, Properties.Resources.MAIN_WINDOWS_CHANGE_UI_LANGUAGE_RESTART_REQUIRED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void TriggerChangeUILanguageToSlovak(object sender, EventArgs e) {
      if(!this.tmiSlovak.Checked) {
        try {
          RegistryKey slovoca = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Slovoca", true);
          slovoca.SetValue("Locale", "sk");
        } catch(Exception exception) {
          MessageBox.Show(this, Properties.Resources.MAIN_WINDOWS_CHANGE_UI_LANGUAGE_ERROR_MESSAGE + "\n" + Properties.Resources.MAIN_WINDOWS_ERROR_MESSAGE_PREFIX + " " + exception.Message, Properties.Resources.MAIN_WINDOWS_CHANGE_UI_LANGUAGE_ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        MessageBox.Show(this, Properties.Resources.MAIN_WINDOWS_CHANGE_UI_LANGUAGE_RESTART_REQUIRED_MESSAGE, Properties.Resources.MAIN_WINDOWS_CHANGE_UI_LANGUAGE_RESTART_REQUIRED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void TriggerNewProjectDialog(object sender, EventArgs e) {
      if(this.UnsavedChanges) {
        switch(MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_MESSAGE, Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_CAPTION, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
          case System.Windows.Forms.DialogResult.Yes:
            string returnMessage = this.CurrentProject.SaveToDisk();
            if(returnMessage != null) {
              MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_PREFIX + " " + this.CurrentProject.Location + "'!\n" + Properties.Resources.MAIN_WINDOWS_ERROR_MESSAGE_PREFIX + " " + returnMessage, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
              this.UnsavedChanges = false;
              this.Text = "Slovoca - " + this.CurrentProject.Location;
            }
            break;
          case System.Windows.Forms.DialogResult.Cancel:
            return;
        }
      }

      this.CreateProjectDialog.ShowDialog(this);
    }

    private void TriggerOpenProjectDialog(object sender, EventArgs e) {
      if(this.UnsavedChanges) {
        switch(MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_MESSAGE, Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_CAPTION, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
          case System.Windows.Forms.DialogResult.Yes:
            string returnMessage = this.CurrentProject.SaveToDisk();
            if(returnMessage != null) {
              MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_PREFIX + " " + this.CurrentProject.Location + "'!\n" + Properties.Resources.MAIN_WINDOWS_ERROR_MESSAGE_PREFIX + " " + returnMessage, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
              this.UnsavedChanges = false;
              this.Text = "Slovoca - " + this.CurrentProject.Location;
            }
            break;
          case System.Windows.Forms.DialogResult.Cancel:
            return;
        }
      }

      this.dlgOpenProject.ShowDialog(this);
    }

    public void ProjectOpen(string location) {
      this.CurrentProject = new Project(location);
      this.CurrentProject.ReadFromDisk();

      this.lsbForeignToNative.Items.Clear();
      this.lsbNativeToForeign.Items.Clear();

      foreach(Entry entry in this.CurrentProject.ForeignEntries.AllEntries.Values) {
        this.lsbForeignToNative.Items.Add(entry);
      }

      foreach(Entry entry in this.CurrentProject.NativeEntries.AllEntries.Values) {
        this.lsbNativeToForeign.Items.Add(entry);
      }

      this.ToggleControls(true);

      this.lblForeignToNativePanelTitle.Text = Properties.Resources.MAIN_WINDOW_ENTRIES_IN_PREFIX + " " + this.CurrentProject.ForeignEntries.Language.DisplayName;
      this.lblNativeToForeignPanelTitle.Text = Properties.Resources.MAIN_WINDOW_ENTRIES_IN_PREFIX + " " + this.CurrentProject.NativeEntries.Language.DisplayName;
      this.SelectForeignToNativeVocabulary(null, null);

      this.Text = "Slovoca - " + this.CurrentProject.Location;
    }

    private void ConfirmProjectOpen(object sender, CancelEventArgs e) {
      if(this.CurrentProject != null && this.CurrentProject.Location.CompareTo(this.dlgOpenProject.FileName) == 0) {
        MessageBox.Show(this, Properties.Resources.MAIN_WINDOWS_PROJECT_ALREADY_OPENED_MESSAGE, Properties.Resources.MAIN_WINDOWS_PROJECT_ALREADY_OPENED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      this.ProjectOpen(this.dlgOpenProject.FileName);
    }

    private void TriggerSaveProjectAsDialog(object sender, EventArgs e) {
      this.dlgSaveProjectAs.ShowDialog(this);
    }

    private void ConfirmSaveProjectAs(object sender, CancelEventArgs e) {
      this.CurrentProject.Location = this.dlgSaveProjectAs.FileName;

      string returnMessage = this.CurrentProject.SaveToDisk();
      if(returnMessage != null) {
        MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_PREFIX + " " + this.CurrentProject.Location + "'!\n" + Properties.Resources.MAIN_WINDOWS_ERROR_MESSAGE_PREFIX + " " + returnMessage, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
      } else {
        this.UnsavedChanges = false;
        this.Text = "Slovoca - " + this.CurrentProject.Location;
      }
    }

    private void CreateNewProject(string file, CultureInfo native, CultureInfo foreign) {
      this.CurrentProject = new Project(file, native, foreign);
      this.ToggleControls(true);
      this.lblForeignToNativePanelTitle.Text = Properties.Resources.MAIN_WINDOW_ENTRIES_IN_PREFIX + " " + foreign.DisplayName;
      this.lblNativeToForeignPanelTitle.Text = Properties.Resources.MAIN_WINDOW_ENTRIES_IN_PREFIX + " " + native.DisplayName;
      this.SelectForeignToNativeVocabulary(null, null);
      this.Text = "Slovoca - " + this.CurrentProject.Location;
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
        MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_NOTHING_SELECTED_MESSAGE, Properties.Resources.MAIN_WINDOW_NOTHING_SELECTED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

      this.UnsavedChanges = true;
      this.Text = "Slovoca - " + this.CurrentProject.Location + " " + Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_TAG;
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
          MessageBox.Show(this, Properties.Resources.MAIN_WINDOWS_NO_LIST_SELECTED_MESSAGE, Properties.Resources.MAIN_WINDOWS_NO_LIST_SELECTED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
          MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_ENTRY_DISAPPEARED_MESSAGE, Properties.Resources.MAIN_WINDOW_ENTRY_DISAPPEARED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

      insertIntoExisting = MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_ENTRY_ALREADY_EXISTS_MESSAGE_PREFIX + " " + entry.Meaning.Meaning + " " + Properties.Resources.MAIN_WINDOW_ENTRY_ALREADY_EXISTS_MESSAGE_SUFFIX, Properties.Resources.MAIN_WINDOW_ENTRY_ALREADY_EXISTS_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

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
          Console.WriteLine(Properties.Resources.MAIN_WINDOWS_NO_LIST_SELECTED_CAPTION);
          return;
      }

      if (source.SelectedIndex == -1) {
        MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_NOTHING_SELECTED_MESSAGE, Properties.Resources.MAIN_WINDOW_NOTHING_SELECTED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
          Console.WriteLine(Properties.Resources.MAIN_WINDOWS_NO_LIST_SELECTED_CAPTION);
          return;
      }

      Entry found;

      try {
        found = source.FindEntry(this.tstSearchQuery.Text);
      } catch (NotFoundException) {
        MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_ENTRY_NOT_FOUND_MESSAGE, Properties.Resources.MAIN_WINDOW_ENTRY_NOT_FOUND_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      target.SelectedItem = found;
    }

    private void TriggerSave(object sender, EventArgs e) {
      string returnMessage = this.CurrentProject.SaveToDisk();
      if(returnMessage != null) {
        MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_PREFIX + " " + this.CurrentProject.Location + "'!\n" + Properties.Resources.MAIN_WINDOWS_ERROR_MESSAGE_PREFIX + " " + returnMessage, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
      } else {
        this.UnsavedChanges = false;
        this.Text = "Slovoca - " + this.CurrentProject.Location;
      }
    }

    private void TriggerSlovocaOnline(object sender, EventArgs e) {
      System.Diagnostics.Process.Start("https://github.com/felsocim/Slovoca");
    }

    private void TriggerAboutSlovoca(object sender, EventArgs e) {
      this.AboutDialog.ShowDialog(this);
    }

    private void TriggerExit(object sender, EventArgs e) {
      if(this.UnsavedChanges) {
        switch(MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_MESSAGE, Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_CAPTION, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
          case System.Windows.Forms.DialogResult.Yes:
            string returnMessage = this.CurrentProject.SaveToDisk();
            if(returnMessage != null) {
              MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_PREFIX + " " + this.CurrentProject.Location + "'!\n" + Properties.Resources.MAIN_WINDOWS_ERROR_MESSAGE_PREFIX + " " + returnMessage, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
              this.UnsavedChanges = false;
              this.Text = "Slovoca - " + this.CurrentProject.Location;
            }
            break;
          case System.Windows.Forms.DialogResult.Cancel:
            return;
        } 
      }

      Application.Exit();
    }

    private void TriggerQuit(object sender, FormClosingEventArgs e) {
      if(this.UnsavedChanges) {
        switch(MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_MESSAGE, Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_CAPTION, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
          case System.Windows.Forms.DialogResult.Yes:
            string returnMessage = this.CurrentProject.SaveToDisk();
            if(returnMessage != null) {
              MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_PREFIX + " " + this.CurrentProject.Location + "'!\n" + Properties.Resources.MAIN_WINDOWS_ERROR_MESSAGE_PREFIX + " " + returnMessage, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
              this.UnsavedChanges = false;
              this.Text = "Slovoca - " + this.CurrentProject.Location;
            }
            break;
          case System.Windows.Forms.DialogResult.Cancel:
            e.Cancel = true;
            break;
        }
      }
    }
  }
}
