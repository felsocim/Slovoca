using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using Microsoft.Win32;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace Slovoca {
  /// <summary>
  /// List of vocabulary parts (left and right).
  /// </summary>
  public enum ActiveVocabulary {
    FOREIGN_TO_NATIVE,
    NATIVE_TO_FOREIGN
  }

  /// <summary>
  /// This class represents the main program window's interface.
  /// 
  /// HINTS:
  /// Methods starting with 'Trigger' are associated to the events emitted by different controls of the main window's user interface.
  /// Methods starting with 'Confirm' are associated to the events triggered by the user when confirming an action such as new project creation or an entry modification, etc.
  /// </summary>
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

    /// <summary>
    /// Activates/deactivates controls related to vocabulary modification.
    /// </summary>
    /// <param name="activate">true for activation, false for deactivation</param>
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

    /// <summary>
    /// Cleares information from the middle column of the main window.
    /// </summary>
    private void ClearSelectItemInformation() {
      this.lblSelectedItemWord.Text = "";
      this.lsbSelectedItemTranslations.Items.Clear();
      this.lblSelectedItemNotes.Text = "";
    }

    private void DeactivateEditControls(object sender, EventArgs e) {
      this.tsbEditEntry.Enabled = false;
      this.tsbRemoveEntry.Enabled = false;
    }

    /// <summary>
    /// Checks the menu item corresponding to the currently used UI language.
    /// </summary>
    /// <param name="locale">current locale code</param>
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

    /// <summary>
    /// Saves program's settings (display language only for the moment) to a file.
    /// </summary>
    /// <param name="locale">Display language selected by the user.</param>
    /// <returns></returns>
    private string SaveProgramSettings(string locale) {
      FileStream file;
      XmlTextWriter writer;

      try {
        file = new FileStream(Globals.SettingsFile, FileMode.Create, FileAccess.Write, FileShare.Read);
        writer = new XmlTextWriter(file, System.Text.Encoding.UTF8) {
          Formatting = Formatting.Indented,
          Indentation = 2,
          IndentChar = ' '
        };
      } catch(Exception exception) {
        return exception.Message;
      }

      writer.WriteStartDocument();

      writer.WriteComment("Slovoca program settings file");
      writer.WriteComment("Created by Slovoca (C) 2019  Marek Felsoci");

      writer.WriteStartElement("Locale");
      writer.WriteString(locale);
      writer.WriteEndElement();

      writer.WriteEndDocument();
      writer.Close();

      return null;
    }

    private void TriggerChangeUILanguageToEnglish(object sender, EventArgs e) {
      if(!this.tmiEnglish.Checked) {
        string message = this.SaveProgramSettings("en");
        if(message != null) {
          MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_CHANGE_UI_LANGUAGE_ERROR_MESSAGE + "\n" + Properties.Resources.MAIN_WINDOW_ERROR_MESSAGE_PREFIX + " " + message, Properties.Resources.MAIN_WINDOW_CHANGE_UI_LANGUAGE_ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_CHANGE_UI_LANGUAGE_RESTART_REQUIRED_MESSAGE, Properties.Resources.MAIN_WINDOW_CHANGE_UI_LANGUAGE_RESTART_REQUIRED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void TriggerChangeUILanguageToSlovak(object sender, EventArgs e) {
      if(!this.tmiSlovak.Checked) {
        string message = this.SaveProgramSettings("sk");
        if(message != null) {
          MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_CHANGE_UI_LANGUAGE_ERROR_MESSAGE + "\n" + Properties.Resources.MAIN_WINDOW_ERROR_MESSAGE_PREFIX + " " + message, Properties.Resources.MAIN_WINDOW_CHANGE_UI_LANGUAGE_ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_CHANGE_UI_LANGUAGE_RESTART_REQUIRED_MESSAGE, Properties.Resources.MAIN_WINDOW_CHANGE_UI_LANGUAGE_RESTART_REQUIRED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void TriggerNewProjectDialog(object sender, EventArgs e) {
      if(this.UnsavedChanges) {
        switch(MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_MESSAGE, Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_CAPTION, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
          case System.Windows.Forms.DialogResult.Yes:
            string returnMessage = this.CurrentProject.SaveToDisk();
            if(returnMessage != null) {
              MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_PREFIX + " " + this.CurrentProject.Location + "'!\n" + Properties.Resources.MAIN_WINDOW_ERROR_MESSAGE_PREFIX + " " + returnMessage, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private void TriggerOpenHelpFile(object sender, EventArgs e) {
      try {
        Help.ShowHelp(this, Properties.Resources.HELP_FILE_PATH);
      } catch(Exception) {
        MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_HELP_FILE_CANNOT_BE_OPENED_MESSAGE, Properties.Resources.MAIN_WINDOW_HELP_FILE_CANNOT_BE_OPENED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void TriggerOpenProjectDialog(object sender, EventArgs e) {
      if(this.UnsavedChanges) {
        switch(MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_MESSAGE, Properties.Resources.MAIN_WINDOW_UNSAVED_CHANGES_CAPTION, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
          case System.Windows.Forms.DialogResult.Yes:
            string returnMessage = this.CurrentProject.SaveToDisk();
            if(returnMessage != null) {
              MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_PREFIX + " " + this.CurrentProject.Location + "'!\n" + Properties.Resources.MAIN_WINDOW_ERROR_MESSAGE_PREFIX + " " + returnMessage, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    /// <summary>
    /// Loads vocabulary project file from given location.
    /// </summary>
    /// <param name="location"></param>
    public void ProjectOpen(string location) {
      this.CurrentProject = new Project(location);

      string message = this.CurrentProject.ReadFromDisk();

      if(message != null) {
        MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_LOAD_FAILURE_MESSAGE + "\n" + Properties.Resources.MAIN_WINDOW_ERROR_MESSAGE_PREFIX + " " + message, Properties.Resources.MAIN_WINDOW_PROJECT_LOAD_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.CurrentProject = null;

        return;
      }

      this.lsbForeignToNative.Items.Clear();
      this.lsbNativeToForeign.Items.Clear();

      foreach(Entry entry in this.CurrentProject.ForeignEntries.AllEntries.Values) {
        this.lsbForeignToNative.Items.Add(entry);
      }

      foreach(Entry entry in this.CurrentProject.NativeEntries.AllEntries.Values) {
        this.lsbNativeToForeign.Items.Add(entry);
      }

      this.ToggleControls(true);

      this.lblForeignToNativePanelTitle.Text = Properties.Resources.MAIN_WINDOW_ENTRIES_IN_PREFIX + " " + this.CurrentProject.ForeignEntries.Language.NativeName + " (" + this.CurrentProject.ForeignEntries.Language.TwoLetterISOLanguageName.ToUpperInvariant() + ")";
      this.lblNativeToForeignPanelTitle.Text = Properties.Resources.MAIN_WINDOW_ENTRIES_IN_PREFIX + " " + this.CurrentProject.NativeEntries.Language.NativeName + " (" + this.CurrentProject.NativeEntries.Language.TwoLetterISOLanguageName.ToUpperInvariant() + ")";
      this.SelectForeignToNativeVocabulary(null, null);

      this.Text = "Slovoca - " + this.CurrentProject.Location;
    }

    private void ConfirmProjectOpen(object sender, CancelEventArgs e) {
      if(this.CurrentProject != null && this.CurrentProject.Location.CompareTo(this.dlgOpenProject.FileName) == 0) {
        MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_ALREADY_OPENED_MESSAGE, Properties.Resources.MAIN_WINDOW_PROJECT_ALREADY_OPENED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_PREFIX + " " + this.CurrentProject.Location + "'!\n" + Properties.Resources.MAIN_WINDOW_ERROR_MESSAGE_PREFIX + " " + returnMessage, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
      } else {
        this.UnsavedChanges = false;
        this.Text = "Slovoca - " + this.CurrentProject.Location;
      }
    }

    private void CreateNewProject(string file, CultureInfo native, CultureInfo foreign) {
      this.CurrentProject = new Project(file, native, foreign);
      this.ToggleControls(true);
      this.lblForeignToNativePanelTitle.Text = Properties.Resources.MAIN_WINDOW_ENTRIES_IN_PREFIX + " " + foreign.NativeName + " (" + foreign.TwoLetterISOLanguageName.ToUpperInvariant() + ")";
      this.lblNativeToForeignPanelTitle.Text = Properties.Resources.MAIN_WINDOW_ENTRIES_IN_PREFIX + " " + native.NativeName + " (" + native.TwoLetterISOLanguageName.ToUpperInvariant() + ")";
      this.SelectForeignToNativeVocabulary(null, null);
      this.Text = "Slovoca - " + this.CurrentProject.Location;
    }

    private void TriggerAddEntry(object sender, EventArgs e) {
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
          MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_NO_LIST_SELECTED_MESSAGE, Properties.Resources.MAIN_WINDOW_NO_LIST_SELECTED_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
          Console.WriteLine(Properties.Resources.MAIN_WINDOW_NO_LIST_SELECTED_CAPTION);
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
          Console.WriteLine(Properties.Resources.MAIN_WINDOW_NO_LIST_SELECTED_CAPTION);
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
        MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_PREFIX + " " + this.CurrentProject.Location + "'!\n" + Properties.Resources.MAIN_WINDOW_ERROR_MESSAGE_PREFIX + " " + returnMessage, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
              MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_PREFIX + " " + this.CurrentProject.Location + "'!\n" + Properties.Resources.MAIN_WINDOW_ERROR_MESSAGE_PREFIX + " " + returnMessage, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
              MessageBox.Show(this, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_PREFIX + " " + this.CurrentProject.Location + "'!\n" + Properties.Resources.MAIN_WINDOW_ERROR_MESSAGE_PREFIX + " " + returnMessage, Properties.Resources.MAIN_WINDOW_PROJECT_SAVE_FAILURE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
