namespace Slovoca
{
  partial class MainWindow
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
      this.msMainMenu = new System.Windows.Forms.MenuStrip();
      this.tmiFile = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiNew = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.tmiOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiSave = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.tmiExit = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiEntry = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiAddEntry = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiEditEntry = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiRemoveEntry = new System.Windows.Forms.ToolStripMenuItem();
      this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.slovenèinaSlovakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiViewHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiSlovocaOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
      this.tmiAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.tsToolbar = new System.Windows.Forms.ToolStrip();
      this.tsbNew = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbOpen = new System.Windows.Forms.ToolStripButton();
      this.tsbSave = new System.Windows.Forms.ToolStripButton();
      this.tsbSaveAs = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbAddEntry = new System.Windows.Forms.ToolStripButton();
      this.tsbEditEntry = new System.Windows.Forms.ToolStripButton();
      this.tsbRemoveEntry = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.tstSearchQuery = new System.Windows.Forms.ToolStripTextBox();
      this.tsbFindEntry = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbHelp = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbExit = new System.Windows.Forms.ToolStripButton();
      this.pnlForeignToNativePanel = new System.Windows.Forms.Panel();
      this.lblForeignToNativePanelTitle = new System.Windows.Forms.Label();
      this.pnlNativeToForeignPanel = new System.Windows.Forms.Panel();
      this.lblNativeToForeignPanelTitle = new System.Windows.Forms.Label();
      this.layMainWindow = new System.Windows.Forms.TableLayoutPanel();
      this.lsbForeignToNative = new System.Windows.Forms.ListBox();
      this.lsbNativeToForeign = new System.Windows.Forms.ListBox();
      this.lblSelectedItemColumnTitle = new System.Windows.Forms.Label();
      this.laySelectedItemColumn = new System.Windows.Forms.TableLayoutPanel();
      this.lblSelectedItemWord = new System.Windows.Forms.Label();
      this.lblSelectedItemNotes = new System.Windows.Forms.Label();
      this.lsbSelectedItemTranslations = new System.Windows.Forms.ListBox();
      this.lblSelectedItemTranslationsDescription = new System.Windows.Forms.Label();
      this.lblSelectedItemNotesDescription = new System.Windows.Forms.Label();
      this.lblSelectedItemWordDescription = new System.Windows.Forms.Label();
      this.dlgOpenProject = new System.Windows.Forms.OpenFileDialog();
      this.dlgSaveProjectAs = new System.Windows.Forms.SaveFileDialog();
      this.msMainMenu.SuspendLayout();
      this.tsToolbar.SuspendLayout();
      this.pnlForeignToNativePanel.SuspendLayout();
      this.pnlNativeToForeignPanel.SuspendLayout();
      this.layMainWindow.SuspendLayout();
      this.laySelectedItemColumn.SuspendLayout();
      this.SuspendLayout();
      // 
      // msMainMenu
      // 
      this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiFile,
            this.tmiEntry,
            this.languageToolStripMenuItem,
            this.tmiHelp});
      resources.ApplyResources(this.msMainMenu, "msMainMenu");
      this.msMainMenu.Name = "msMainMenu";
      // 
      // tmiFile
      // 
      this.tmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiNew,
            this.toolStripMenuItem2,
            this.tmiOpen,
            this.tmiSave,
            this.tmiSaveAs,
            this.toolStripMenuItem3,
            this.tmiExit});
      this.tmiFile.Name = "tmiFile";
      resources.ApplyResources(this.tmiFile, "tmiFile");
      // 
      // tmiNew
      // 
      this.tmiNew.Image = global::Slovoca.Properties.Resources.NewFile_16x_24;
      resources.ApplyResources(this.tmiNew, "tmiNew");
      this.tmiNew.Name = "tmiNew";
      this.tmiNew.Click += new System.EventHandler(this.TriggerNewProjectDialog);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
      // 
      // tmiOpen
      // 
      this.tmiOpen.Image = global::Slovoca.Properties.Resources.OpenFolder_16x_24;
      resources.ApplyResources(this.tmiOpen, "tmiOpen");
      this.tmiOpen.Name = "tmiOpen";
      this.tmiOpen.Click += new System.EventHandler(this.TriggerOpenProjectDialog);
      // 
      // tmiSave
      // 
      this.tmiSave.Image = global::Slovoca.Properties.Resources.Save_16x_24;
      resources.ApplyResources(this.tmiSave, "tmiSave");
      this.tmiSave.Name = "tmiSave";
      this.tmiSave.Click += new System.EventHandler(this.TriggerSave);
      // 
      // tmiSaveAs
      // 
      this.tmiSaveAs.Image = global::Slovoca.Properties.Resources.SaveAs_16x_24;
      resources.ApplyResources(this.tmiSaveAs, "tmiSaveAs");
      this.tmiSaveAs.Name = "tmiSaveAs";
      this.tmiSaveAs.Click += new System.EventHandler(this.TriggerSaveProjectAsDialog);
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
      // 
      // tmiExit
      // 
      this.tmiExit.Image = global::Slovoca.Properties.Resources.Exit_16x_24;
      resources.ApplyResources(this.tmiExit, "tmiExit");
      this.tmiExit.Name = "tmiExit";
      this.tmiExit.Click += new System.EventHandler(this.TriggerExit);
      // 
      // tmiEntry
      // 
      this.tmiEntry.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiAddEntry,
            this.tmiEditEntry,
            this.tmiRemoveEntry});
      this.tmiEntry.Name = "tmiEntry";
      resources.ApplyResources(this.tmiEntry, "tmiEntry");
      // 
      // tmiAddEntry
      // 
      this.tmiAddEntry.Image = global::Slovoca.Properties.Resources.Add_16x_24;
      resources.ApplyResources(this.tmiAddEntry, "tmiAddEntry");
      this.tmiAddEntry.Name = "tmiAddEntry";
      this.tmiAddEntry.Click += new System.EventHandler(this.tsbAdd_Click);
      // 
      // tmiEditEntry
      // 
      this.tmiEditEntry.Image = global::Slovoca.Properties.Resources.Edit_16x_24;
      resources.ApplyResources(this.tmiEditEntry, "tmiEditEntry");
      this.tmiEditEntry.Name = "tmiEditEntry";
      this.tmiEditEntry.Click += new System.EventHandler(this.TriggerEditEntry);
      // 
      // tmiRemoveEntry
      // 
      this.tmiRemoveEntry.Image = global::Slovoca.Properties.Resources.Remove_color_16x_24;
      resources.ApplyResources(this.tmiRemoveEntry, "tmiRemoveEntry");
      this.tmiRemoveEntry.Name = "tmiRemoveEntry";
      this.tmiRemoveEntry.Click += new System.EventHandler(this.TriggerRemoveEntry);
      // 
      // languageToolStripMenuItem
      // 
      this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.slovenèinaSlovakToolStripMenuItem});
      this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
      resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
      // 
      // englishToolStripMenuItem
      // 
      this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
      resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
      // 
      // slovenèinaSlovakToolStripMenuItem
      // 
      this.slovenèinaSlovakToolStripMenuItem.Name = "slovenèinaSlovakToolStripMenuItem";
      resources.ApplyResources(this.slovenèinaSlovakToolStripMenuItem, "slovenèinaSlovakToolStripMenuItem");
      // 
      // tmiHelp
      // 
      this.tmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiViewHelp,
            this.tmiSlovocaOnline,
            this.toolStripMenuItem6,
            this.tmiAbout});
      this.tmiHelp.Name = "tmiHelp";
      resources.ApplyResources(this.tmiHelp, "tmiHelp");
      // 
      // tmiViewHelp
      // 
      this.tmiViewHelp.Image = global::Slovoca.Properties.Resources.Question_16x_24;
      resources.ApplyResources(this.tmiViewHelp, "tmiViewHelp");
      this.tmiViewHelp.Name = "tmiViewHelp";
      // 
      // tmiSlovocaOnline
      // 
      this.tmiSlovocaOnline.Image = global::Slovoca.Properties.Resources.Web_16x_24;
      resources.ApplyResources(this.tmiSlovocaOnline, "tmiSlovocaOnline");
      this.tmiSlovocaOnline.Name = "tmiSlovocaOnline";
      this.tmiSlovocaOnline.Click += new System.EventHandler(this.TriggerSlovocaOnline);
      // 
      // toolStripMenuItem6
      // 
      this.toolStripMenuItem6.Name = "toolStripMenuItem6";
      resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
      // 
      // tmiAbout
      // 
      this.tmiAbout.Name = "tmiAbout";
      resources.ApplyResources(this.tmiAbout, "tmiAbout");
      this.tmiAbout.Click += new System.EventHandler(this.TriggerAboutSlovoca);
      // 
      // tsToolbar
      // 
      this.tsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.toolStripSeparator1,
            this.tsbOpen,
            this.tsbSave,
            this.tsbSaveAs,
            this.toolStripSeparator2,
            this.tsbAddEntry,
            this.tsbEditEntry,
            this.tsbRemoveEntry,
            this.toolStripSeparator5,
            this.tstSearchQuery,
            this.tsbFindEntry,
            this.toolStripSeparator6,
            this.tsbHelp,
            this.toolStripSeparator7,
            this.tsbExit});
      resources.ApplyResources(this.tsToolbar, "tsToolbar");
      this.tsToolbar.Name = "tsToolbar";
      // 
      // tsbNew
      // 
      this.tsbNew.Image = global::Slovoca.Properties.Resources.NewFile_16x_24;
      resources.ApplyResources(this.tsbNew, "tsbNew");
      this.tsbNew.Name = "tsbNew";
      this.tsbNew.Click += new System.EventHandler(this.TriggerNewProjectDialog);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // tsbOpen
      // 
      this.tsbOpen.Image = global::Slovoca.Properties.Resources.OpenFolder_16x_24;
      resources.ApplyResources(this.tsbOpen, "tsbOpen");
      this.tsbOpen.Name = "tsbOpen";
      this.tsbOpen.Click += new System.EventHandler(this.TriggerOpenProjectDialog);
      // 
      // tsbSave
      // 
      this.tsbSave.Image = global::Slovoca.Properties.Resources.Save_16x_24;
      resources.ApplyResources(this.tsbSave, "tsbSave");
      this.tsbSave.Name = "tsbSave";
      this.tsbSave.Click += new System.EventHandler(this.TriggerSave);
      // 
      // tsbSaveAs
      // 
      this.tsbSaveAs.Image = global::Slovoca.Properties.Resources.SaveAs_16x_24;
      resources.ApplyResources(this.tsbSaveAs, "tsbSaveAs");
      this.tsbSaveAs.Name = "tsbSaveAs";
      this.tsbSaveAs.Click += new System.EventHandler(this.TriggerSaveProjectAsDialog);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
      // 
      // tsbAddEntry
      // 
      this.tsbAddEntry.Image = global::Slovoca.Properties.Resources.Add_16x_24;
      resources.ApplyResources(this.tsbAddEntry, "tsbAddEntry");
      this.tsbAddEntry.Name = "tsbAddEntry";
      this.tsbAddEntry.Click += new System.EventHandler(this.tsbAdd_Click);
      // 
      // tsbEditEntry
      // 
      this.tsbEditEntry.Image = global::Slovoca.Properties.Resources.Edit_16x_24;
      resources.ApplyResources(this.tsbEditEntry, "tsbEditEntry");
      this.tsbEditEntry.Name = "tsbEditEntry";
      this.tsbEditEntry.Click += new System.EventHandler(this.TriggerEditEntry);
      // 
      // tsbRemoveEntry
      // 
      this.tsbRemoveEntry.Image = global::Slovoca.Properties.Resources.Remove_color_16x_24;
      resources.ApplyResources(this.tsbRemoveEntry, "tsbRemoveEntry");
      this.tsbRemoveEntry.Name = "tsbRemoveEntry";
      this.tsbRemoveEntry.Click += new System.EventHandler(this.TriggerRemoveEntry);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
      // 
      // tstSearchQuery
      // 
      this.tstSearchQuery.Name = "tstSearchQuery";
      resources.ApplyResources(this.tstSearchQuery, "tstSearchQuery");
      // 
      // tsbFindEntry
      // 
      this.tsbFindEntry.Image = global::Slovoca.Properties.Resources.FindResults_16x_24;
      resources.ApplyResources(this.tsbFindEntry, "tsbFindEntry");
      this.tsbFindEntry.Name = "tsbFindEntry";
      this.tsbFindEntry.Click += new System.EventHandler(this.TriggerFindEntry);
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
      // 
      // tsbHelp
      // 
      this.tsbHelp.Image = global::Slovoca.Properties.Resources.Question_16x_24;
      resources.ApplyResources(this.tsbHelp, "tsbHelp");
      this.tsbHelp.Name = "tsbHelp";
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
      // 
      // tsbExit
      // 
      this.tsbExit.Image = global::Slovoca.Properties.Resources.Exit_16x_24;
      resources.ApplyResources(this.tsbExit, "tsbExit");
      this.tsbExit.Name = "tsbExit";
      this.tsbExit.Click += new System.EventHandler(this.TriggerExit);
      // 
      // pnlForeignToNativePanel
      // 
      resources.ApplyResources(this.pnlForeignToNativePanel, "pnlForeignToNativePanel");
      this.pnlForeignToNativePanel.BackColor = System.Drawing.Color.White;
      this.pnlForeignToNativePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlForeignToNativePanel.Controls.Add(this.lblForeignToNativePanelTitle);
      this.pnlForeignToNativePanel.Name = "pnlForeignToNativePanel";
      // 
      // lblForeignToNativePanelTitle
      // 
      resources.ApplyResources(this.lblForeignToNativePanelTitle, "lblForeignToNativePanelTitle");
      this.lblForeignToNativePanelTitle.Name = "lblForeignToNativePanelTitle";
      this.lblForeignToNativePanelTitle.Click += new System.EventHandler(this.SelectForeignToNativeVocabulary);
      // 
      // pnlNativeToForeignPanel
      // 
      resources.ApplyResources(this.pnlNativeToForeignPanel, "pnlNativeToForeignPanel");
      this.pnlNativeToForeignPanel.BackColor = System.Drawing.Color.White;
      this.pnlNativeToForeignPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlNativeToForeignPanel.Controls.Add(this.lblNativeToForeignPanelTitle);
      this.pnlNativeToForeignPanel.Name = "pnlNativeToForeignPanel";
      // 
      // lblNativeToForeignPanelTitle
      // 
      resources.ApplyResources(this.lblNativeToForeignPanelTitle, "lblNativeToForeignPanelTitle");
      this.lblNativeToForeignPanelTitle.Name = "lblNativeToForeignPanelTitle";
      this.lblNativeToForeignPanelTitle.Click += new System.EventHandler(this.SelectNativeToForeignVocabulary);
      // 
      // layMainWindow
      // 
      resources.ApplyResources(this.layMainWindow, "layMainWindow");
      this.layMainWindow.Controls.Add(this.pnlNativeToForeignPanel, 2, 0);
      this.layMainWindow.Controls.Add(this.pnlForeignToNativePanel, 0, 0);
      this.layMainWindow.Controls.Add(this.lsbForeignToNative, 0, 1);
      this.layMainWindow.Controls.Add(this.lsbNativeToForeign, 2, 1);
      this.layMainWindow.Controls.Add(this.lblSelectedItemColumnTitle, 1, 0);
      this.layMainWindow.Controls.Add(this.laySelectedItemColumn, 1, 1);
      this.layMainWindow.Name = "layMainWindow";
      // 
      // lsbForeignToNative
      // 
      resources.ApplyResources(this.lsbForeignToNative, "lsbForeignToNative");
      this.lsbForeignToNative.FormattingEnabled = true;
      this.lsbForeignToNative.Name = "lsbForeignToNative";
      this.lsbForeignToNative.Click += new System.EventHandler(this.SelectForeignToNativeVocabulary);
      this.lsbForeignToNative.SelectedIndexChanged += new System.EventHandler(this.ShowDetailedEntryInformation);
      // 
      // lsbNativeToForeign
      // 
      resources.ApplyResources(this.lsbNativeToForeign, "lsbNativeToForeign");
      this.lsbNativeToForeign.FormattingEnabled = true;
      this.lsbNativeToForeign.Name = "lsbNativeToForeign";
      this.lsbNativeToForeign.Click += new System.EventHandler(this.SelectNativeToForeignVocabulary);
      this.lsbNativeToForeign.SelectedIndexChanged += new System.EventHandler(this.ShowDetailedEntryInformation);
      // 
      // lblSelectedItemColumnTitle
      // 
      resources.ApplyResources(this.lblSelectedItemColumnTitle, "lblSelectedItemColumnTitle");
      this.lblSelectedItemColumnTitle.Name = "lblSelectedItemColumnTitle";
      // 
      // laySelectedItemColumn
      // 
      resources.ApplyResources(this.laySelectedItemColumn, "laySelectedItemColumn");
      this.laySelectedItemColumn.Controls.Add(this.lblSelectedItemWord, 0, 1);
      this.laySelectedItemColumn.Controls.Add(this.lblSelectedItemNotes, 0, 5);
      this.laySelectedItemColumn.Controls.Add(this.lsbSelectedItemTranslations, 0, 3);
      this.laySelectedItemColumn.Controls.Add(this.lblSelectedItemTranslationsDescription, 0, 2);
      this.laySelectedItemColumn.Controls.Add(this.lblSelectedItemNotesDescription, 0, 4);
      this.laySelectedItemColumn.Controls.Add(this.lblSelectedItemWordDescription, 0, 0);
      this.laySelectedItemColumn.Name = "laySelectedItemColumn";
      // 
      // lblSelectedItemWord
      // 
      resources.ApplyResources(this.lblSelectedItemWord, "lblSelectedItemWord");
      this.lblSelectedItemWord.Name = "lblSelectedItemWord";
      // 
      // lblSelectedItemNotes
      // 
      resources.ApplyResources(this.lblSelectedItemNotes, "lblSelectedItemNotes");
      this.lblSelectedItemNotes.Name = "lblSelectedItemNotes";
      // 
      // lsbSelectedItemTranslations
      // 
      resources.ApplyResources(this.lsbSelectedItemTranslations, "lsbSelectedItemTranslations");
      this.lsbSelectedItemTranslations.FormattingEnabled = true;
      this.lsbSelectedItemTranslations.Name = "lsbSelectedItemTranslations";
      // 
      // lblSelectedItemTranslationsDescription
      // 
      resources.ApplyResources(this.lblSelectedItemTranslationsDescription, "lblSelectedItemTranslationsDescription");
      this.lblSelectedItemTranslationsDescription.Name = "lblSelectedItemTranslationsDescription";
      // 
      // lblSelectedItemNotesDescription
      // 
      resources.ApplyResources(this.lblSelectedItemNotesDescription, "lblSelectedItemNotesDescription");
      this.lblSelectedItemNotesDescription.Name = "lblSelectedItemNotesDescription";
      // 
      // lblSelectedItemWordDescription
      // 
      resources.ApplyResources(this.lblSelectedItemWordDescription, "lblSelectedItemWordDescription");
      this.lblSelectedItemWordDescription.Name = "lblSelectedItemWordDescription";
      // 
      // dlgOpenProject
      // 
      this.dlgOpenProject.DefaultExt = "*.slovo";
      resources.ApplyResources(this.dlgOpenProject, "dlgOpenProject");
      this.dlgOpenProject.InitialDirectory = "%USERPROFILE%";
      this.dlgOpenProject.FileOk += new System.ComponentModel.CancelEventHandler(this.ConfirmProjectOpen);
      // 
      // dlgSaveProjectAs
      // 
      this.dlgSaveProjectAs.DefaultExt = "*.slovo";
      resources.ApplyResources(this.dlgSaveProjectAs, "dlgSaveProjectAs");
      this.dlgSaveProjectAs.InitialDirectory = "%USERPROFILE%";
      this.dlgSaveProjectAs.FileOk += new System.ComponentModel.CancelEventHandler(this.ConfirmSaveProjectAs);
      // 
      // MainWindow
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.Controls.Add(this.layMainWindow);
      this.Controls.Add(this.tsToolbar);
      this.Controls.Add(this.msMainMenu);
      this.MainMenuStrip = this.msMainMenu;
      this.Name = "MainWindow";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TriggerQuit);
      this.msMainMenu.ResumeLayout(false);
      this.msMainMenu.PerformLayout();
      this.tsToolbar.ResumeLayout(false);
      this.tsToolbar.PerformLayout();
      this.pnlForeignToNativePanel.ResumeLayout(false);
      this.pnlNativeToForeignPanel.ResumeLayout(false);
      this.layMainWindow.ResumeLayout(false);
      this.layMainWindow.PerformLayout();
      this.laySelectedItemColumn.ResumeLayout(false);
      this.laySelectedItemColumn.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip msMainMenu;
    private System.Windows.Forms.ToolStripMenuItem tmiFile;
    private System.Windows.Forms.ToolStripMenuItem tmiNew;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem tmiOpen;
    private System.Windows.Forms.ToolStripMenuItem tmiSave;
    private System.Windows.Forms.ToolStripMenuItem tmiSaveAs;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem tmiExit;
    private System.Windows.Forms.ToolStripMenuItem tmiEntry;
    private System.Windows.Forms.ToolStripMenuItem tmiHelp;
    private System.Windows.Forms.ToolStripMenuItem tmiAddEntry;
    private System.Windows.Forms.ToolStripMenuItem tmiEditEntry;
    private System.Windows.Forms.ToolStripMenuItem tmiRemoveEntry;
    private System.Windows.Forms.ToolStripMenuItem tmiViewHelp;
    private System.Windows.Forms.ToolStripMenuItem tmiSlovocaOnline;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
    private System.Windows.Forms.ToolStripMenuItem tmiAbout;
    private System.Windows.Forms.ToolStrip tsToolbar;
    private System.Windows.Forms.ToolStripButton tsbNew;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton tsbOpen;
    private System.Windows.Forms.ToolStripButton tsbSave;
    private System.Windows.Forms.ToolStripButton tsbSaveAs;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton tsbExit;
    private System.Windows.Forms.ToolStripButton tsbAddEntry;
    private System.Windows.Forms.ToolStripButton tsbEditEntry;
    private System.Windows.Forms.ToolStripButton tsbRemoveEntry;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripTextBox tstSearchQuery;
    private System.Windows.Forms.ToolStripButton tsbFindEntry;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripButton tsbHelp;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.Label lblForeignToNativePanelTitle;
    private System.Windows.Forms.Panel pnlForeignToNativePanel;
    private System.Windows.Forms.Panel pnlNativeToForeignPanel;
    private System.Windows.Forms.Label lblNativeToForeignPanelTitle;
    private System.Windows.Forms.TableLayoutPanel layMainWindow;
    private System.Windows.Forms.ListBox lsbForeignToNative;
    private System.Windows.Forms.ListBox lsbNativeToForeign;
    private System.Windows.Forms.Label lblSelectedItemColumnTitle;
    private System.Windows.Forms.TableLayoutPanel laySelectedItemColumn;
    private System.Windows.Forms.Label lblSelectedItemWord;
    private System.Windows.Forms.Label lblSelectedItemNotes;
    private System.Windows.Forms.ListBox lsbSelectedItemTranslations;
    private System.Windows.Forms.OpenFileDialog dlgOpenProject;
    private System.Windows.Forms.SaveFileDialog dlgSaveProjectAs;
    private System.Windows.Forms.Label lblSelectedItemTranslationsDescription;
    private System.Windows.Forms.Label lblSelectedItemNotesDescription;
    private System.Windows.Forms.Label lblSelectedItemWordDescription;
    private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem slovenèinaSlovakToolStripMenuItem;
  }
}
