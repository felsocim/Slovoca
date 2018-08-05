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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiNew = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.tmiOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiSave = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.tmiExport = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiPrint = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
      this.tmiExit = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiCut = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiPaste = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.tmiSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiEntry = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiAddEntry = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiEditEntry = new System.Windows.Forms.ToolStripMenuItem();
      this.tmiRemoveEntry = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
      this.tmiFindEntry = new System.Windows.Forms.ToolStripMenuItem();
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
      this.tsbAdd = new System.Windows.Forms.ToolStripButton();
      this.tsbEdit = new System.Windows.Forms.ToolStripButton();
      this.tsbRemove = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.tstSearchQuery = new System.Windows.Forms.ToolStripTextBox();
      this.tsbFind = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbHelp = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbExit = new System.Windows.Forms.ToolStripButton();
      this.stsStatusBar = new System.Windows.Forms.StatusStrip();
      this.tslCurrentStatusOrInformation = new System.Windows.Forms.ToolStripStatusLabel();
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
      this.menuStrip1.SuspendLayout();
      this.tsToolbar.SuspendLayout();
      this.stsStatusBar.SuspendLayout();
      this.pnlForeignToNativePanel.SuspendLayout();
      this.pnlNativeToForeignPanel.SuspendLayout();
      this.layMainWindow.SuspendLayout();
      this.laySelectedItemColumn.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tmiEdit,
            this.tmiEntry,
            this.tmiHelp});
      resources.ApplyResources(this.menuStrip1, "menuStrip1");
      this.menuStrip1.Name = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiNew,
            this.toolStripMenuItem2,
            this.tmiOpen,
            this.tmiSave,
            this.tmiSaveAs,
            this.toolStripMenuItem3,
            this.tmiExport,
            this.tmiPrint,
            this.toolStripMenuItem4,
            this.tmiExit});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
      // 
      // tmiNew
      // 
      this.tmiNew.Image = global::Slovoca.Properties.Resources.NewFile_16x_24;
      resources.ApplyResources(this.tmiNew, "tmiNew");
      this.tmiNew.Name = "tmiNew";
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
      // 
      // tmiSave
      // 
      this.tmiSave.Image = global::Slovoca.Properties.Resources.Save_16x_24;
      resources.ApplyResources(this.tmiSave, "tmiSave");
      this.tmiSave.Name = "tmiSave";
      // 
      // tmiSaveAs
      // 
      this.tmiSaveAs.Image = global::Slovoca.Properties.Resources.SaveAs_16x_24;
      resources.ApplyResources(this.tmiSaveAs, "tmiSaveAs");
      this.tmiSaveAs.Name = "tmiSaveAs";
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
      // 
      // tmiExport
      // 
      this.tmiExport.Image = global::Slovoca.Properties.Resources.ExportData_16x_24;
      resources.ApplyResources(this.tmiExport, "tmiExport");
      this.tmiExport.Name = "tmiExport";
      // 
      // tmiPrint
      // 
      this.tmiPrint.Image = global::Slovoca.Properties.Resources.Print_16x_24;
      resources.ApplyResources(this.tmiPrint, "tmiPrint");
      this.tmiPrint.Name = "tmiPrint";
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
      // 
      // tmiExit
      // 
      this.tmiExit.Image = global::Slovoca.Properties.Resources.Exit_16x_24;
      resources.ApplyResources(this.tmiExit, "tmiExit");
      this.tmiExit.Name = "tmiExit";
      // 
      // tmiEdit
      // 
      this.tmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiCut,
            this.tmiCopy,
            this.tmiPaste,
            this.toolStripMenuItem1,
            this.tmiSettings});
      this.tmiEdit.Name = "tmiEdit";
      resources.ApplyResources(this.tmiEdit, "tmiEdit");
      // 
      // tmiCut
      // 
      this.tmiCut.Image = global::Slovoca.Properties.Resources.Cut_16x_24;
      resources.ApplyResources(this.tmiCut, "tmiCut");
      this.tmiCut.Name = "tmiCut";
      // 
      // tmiCopy
      // 
      this.tmiCopy.Image = global::Slovoca.Properties.Resources.Copy_16x_24;
      resources.ApplyResources(this.tmiCopy, "tmiCopy");
      this.tmiCopy.Name = "tmiCopy";
      // 
      // tmiPaste
      // 
      this.tmiPaste.Image = global::Slovoca.Properties.Resources.Paste_16x_24;
      resources.ApplyResources(this.tmiPaste, "tmiPaste");
      this.tmiPaste.Name = "tmiPaste";
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
      // 
      // tmiSettings
      // 
      this.tmiSettings.Image = global::Slovoca.Properties.Resources.Settings_16x_24;
      resources.ApplyResources(this.tmiSettings, "tmiSettings");
      this.tmiSettings.Name = "tmiSettings";
      // 
      // tmiEntry
      // 
      this.tmiEntry.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiAddEntry,
            this.tmiEditEntry,
            this.tmiRemoveEntry,
            this.toolStripMenuItem5,
            this.tmiFindEntry});
      this.tmiEntry.Name = "tmiEntry";
      resources.ApplyResources(this.tmiEntry, "tmiEntry");
      // 
      // tmiAddEntry
      // 
      this.tmiAddEntry.Image = global::Slovoca.Properties.Resources.Add_16x_24;
      resources.ApplyResources(this.tmiAddEntry, "tmiAddEntry");
      this.tmiAddEntry.Name = "tmiAddEntry";
      // 
      // tmiEditEntry
      // 
      this.tmiEditEntry.Image = global::Slovoca.Properties.Resources.Edit_16x_24;
      resources.ApplyResources(this.tmiEditEntry, "tmiEditEntry");
      this.tmiEditEntry.Name = "tmiEditEntry";
      // 
      // tmiRemoveEntry
      // 
      this.tmiRemoveEntry.Image = global::Slovoca.Properties.Resources.Remove_color_16x_24;
      resources.ApplyResources(this.tmiRemoveEntry, "tmiRemoveEntry");
      this.tmiRemoveEntry.Name = "tmiRemoveEntry";
      // 
      // toolStripMenuItem5
      // 
      this.toolStripMenuItem5.Name = "toolStripMenuItem5";
      resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
      // 
      // tmiFindEntry
      // 
      this.tmiFindEntry.Image = global::Slovoca.Properties.Resources.FindResults_16x_24;
      resources.ApplyResources(this.tmiFindEntry, "tmiFindEntry");
      this.tmiFindEntry.Name = "tmiFindEntry";
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
            this.tsbAdd,
            this.tsbEdit,
            this.tsbRemove,
            this.toolStripSeparator5,
            this.tstSearchQuery,
            this.tsbFind,
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
      // 
      // tsbSave
      // 
      this.tsbSave.Image = global::Slovoca.Properties.Resources.Save_16x_24;
      resources.ApplyResources(this.tsbSave, "tsbSave");
      this.tsbSave.Name = "tsbSave";
      // 
      // tsbSaveAs
      // 
      this.tsbSaveAs.Image = global::Slovoca.Properties.Resources.SaveAs_16x_24;
      resources.ApplyResources(this.tsbSaveAs, "tsbSaveAs");
      this.tsbSaveAs.Name = "tsbSaveAs";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
      // 
      // tsbAdd
      // 
      this.tsbAdd.Image = global::Slovoca.Properties.Resources.Add_16x_24;
      resources.ApplyResources(this.tsbAdd, "tsbAdd");
      this.tsbAdd.Name = "tsbAdd";
      this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
      // 
      // tsbEdit
      // 
      this.tsbEdit.Image = global::Slovoca.Properties.Resources.Edit_16x_24;
      resources.ApplyResources(this.tsbEdit, "tsbEdit");
      this.tsbEdit.Name = "tsbEdit";
      // 
      // tsbRemove
      // 
      this.tsbRemove.Image = global::Slovoca.Properties.Resources.Remove_color_16x_24;
      resources.ApplyResources(this.tsbRemove, "tsbRemove");
      this.tsbRemove.Name = "tsbRemove";
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
      // tsbFind
      // 
      this.tsbFind.Image = global::Slovoca.Properties.Resources.FindResults_16x_24;
      resources.ApplyResources(this.tsbFind, "tsbFind");
      this.tsbFind.Name = "tsbFind";
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
      // 
      // stsStatusBar
      // 
      this.stsStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslCurrentStatusOrInformation});
      resources.ApplyResources(this.stsStatusBar, "stsStatusBar");
      this.stsStatusBar.Name = "stsStatusBar";
      // 
      // tslCurrentStatusOrInformation
      // 
      this.tslCurrentStatusOrInformation.Name = "tslCurrentStatusOrInformation";
      resources.ApplyResources(this.tslCurrentStatusOrInformation, "tslCurrentStatusOrInformation");
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
      // 
      // lsbNativeToForeign
      // 
      resources.ApplyResources(this.lsbNativeToForeign, "lsbNativeToForeign");
      this.lsbNativeToForeign.FormattingEnabled = true;
      this.lsbNativeToForeign.Name = "lsbNativeToForeign";
      // 
      // lblSelectedItemColumnTitle
      // 
      resources.ApplyResources(this.lblSelectedItemColumnTitle, "lblSelectedItemColumnTitle");
      this.lblSelectedItemColumnTitle.Name = "lblSelectedItemColumnTitle";
      // 
      // laySelectedItemColumn
      // 
      resources.ApplyResources(this.laySelectedItemColumn, "laySelectedItemColumn");
      this.laySelectedItemColumn.Controls.Add(this.lblSelectedItemWord, 0, 0);
      this.laySelectedItemColumn.Controls.Add(this.lblSelectedItemNotes, 0, 2);
      this.laySelectedItemColumn.Controls.Add(this.lsbSelectedItemTranslations, 0, 1);
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
      // MainWindow
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.layMainWindow);
      this.Controls.Add(this.stsStatusBar);
      this.Controls.Add(this.tsToolbar);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainWindow";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.tsToolbar.ResumeLayout(false);
      this.tsToolbar.PerformLayout();
      this.stsStatusBar.ResumeLayout(false);
      this.stsStatusBar.PerformLayout();
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

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tmiNew;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem tmiOpen;
    private System.Windows.Forms.ToolStripMenuItem tmiSave;
    private System.Windows.Forms.ToolStripMenuItem tmiSaveAs;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem tmiExport;
    private System.Windows.Forms.ToolStripMenuItem tmiPrint;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    private System.Windows.Forms.ToolStripMenuItem tmiExit;
    private System.Windows.Forms.ToolStripMenuItem tmiEdit;
    private System.Windows.Forms.ToolStripMenuItem tmiCut;
    private System.Windows.Forms.ToolStripMenuItem tmiCopy;
    private System.Windows.Forms.ToolStripMenuItem tmiPaste;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem tmiSettings;
    private System.Windows.Forms.ToolStripMenuItem tmiEntry;
    private System.Windows.Forms.ToolStripMenuItem tmiHelp;
    private System.Windows.Forms.ToolStripMenuItem tmiAddEntry;
    private System.Windows.Forms.ToolStripMenuItem tmiEditEntry;
    private System.Windows.Forms.ToolStripMenuItem tmiRemoveEntry;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
    private System.Windows.Forms.ToolStripMenuItem tmiFindEntry;
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
    private System.Windows.Forms.ToolStripButton tsbAdd;
    private System.Windows.Forms.ToolStripButton tsbEdit;
    private System.Windows.Forms.ToolStripButton tsbRemove;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripTextBox tstSearchQuery;
    private System.Windows.Forms.ToolStripButton tsbFind;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripButton tsbHelp;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.StatusStrip stsStatusBar;
    private System.Windows.Forms.Label lblForeignToNativePanelTitle;
    private System.Windows.Forms.Panel pnlForeignToNativePanel;
    private System.Windows.Forms.Panel pnlNativeToForeignPanel;
    private System.Windows.Forms.Label lblNativeToForeignPanelTitle;
    private System.Windows.Forms.ToolStripStatusLabel tslCurrentStatusOrInformation;
    private System.Windows.Forms.TableLayoutPanel layMainWindow;
    private System.Windows.Forms.ListBox lsbForeignToNative;
    private System.Windows.Forms.ListBox lsbNativeToForeign;
    private System.Windows.Forms.Label lblSelectedItemColumnTitle;
    private System.Windows.Forms.TableLayoutPanel laySelectedItemColumn;
    private System.Windows.Forms.Label lblSelectedItemWord;
    private System.Windows.Forms.Label lblSelectedItemNotes;
    private System.Windows.Forms.ListBox lsbSelectedItemTranslations;
  }
}

