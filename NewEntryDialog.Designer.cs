namespace Slovoca
{
  partial class NewEntryDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewEntryDialog));
      this.lblNewEntryEntry = new System.Windows.Forms.Label();
      this.txbNewEntryEntry = new System.Windows.Forms.TextBox();
      this.lblNewEntryTranslations = new System.Windows.Forms.Label();
      this.txbNewEntryTranslations = new System.Windows.Forms.TextBox();
      this.lblNewEntryNotes = new System.Windows.Forms.Label();
      this.txbNewEntryNotes = new System.Windows.Forms.TextBox();
      this.layNewEntryDialogLayout = new System.Windows.Forms.TableLayoutPanel();
      this.chkNewEntryAddToFtoN = new System.Windows.Forms.CheckBox();
      this.chkNewEntryAddToNtoF = new System.Windows.Forms.CheckBox();
      this.btnNewEntryCancel = new System.Windows.Forms.Button();
      this.btnNewEntryAdd = new System.Windows.Forms.Button();
      this.layNewEntryDialogLayout.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblNewEntryEntry
      // 
      resources.ApplyResources(this.lblNewEntryEntry, "lblNewEntryEntry");
      this.layNewEntryDialogLayout.SetColumnSpan(this.lblNewEntryEntry, 2);
      this.lblNewEntryEntry.Name = "lblNewEntryEntry";
      // 
      // txbNewEntryEntry
      // 
      resources.ApplyResources(this.txbNewEntryEntry, "txbNewEntryEntry");
      this.layNewEntryDialogLayout.SetColumnSpan(this.txbNewEntryEntry, 2);
      this.txbNewEntryEntry.Name = "txbNewEntryEntry";
      // 
      // lblNewEntryTranslations
      // 
      resources.ApplyResources(this.lblNewEntryTranslations, "lblNewEntryTranslations");
      this.layNewEntryDialogLayout.SetColumnSpan(this.lblNewEntryTranslations, 2);
      this.lblNewEntryTranslations.Name = "lblNewEntryTranslations";
      // 
      // txbNewEntryTranslations
      // 
      resources.ApplyResources(this.txbNewEntryTranslations, "txbNewEntryTranslations");
      this.layNewEntryDialogLayout.SetColumnSpan(this.txbNewEntryTranslations, 2);
      this.txbNewEntryTranslations.Name = "txbNewEntryTranslations";
      // 
      // lblNewEntryNotes
      // 
      resources.ApplyResources(this.lblNewEntryNotes, "lblNewEntryNotes");
      this.layNewEntryDialogLayout.SetColumnSpan(this.lblNewEntryNotes, 2);
      this.lblNewEntryNotes.Name = "lblNewEntryNotes";
      // 
      // txbNewEntryNotes
      // 
      resources.ApplyResources(this.txbNewEntryNotes, "txbNewEntryNotes");
      this.layNewEntryDialogLayout.SetColumnSpan(this.txbNewEntryNotes, 2);
      this.txbNewEntryNotes.Name = "txbNewEntryNotes";
      // 
      // layNewEntryDialogLayout
      // 
      resources.ApplyResources(this.layNewEntryDialogLayout, "layNewEntryDialogLayout");
      this.layNewEntryDialogLayout.Controls.Add(this.lblNewEntryEntry, 0, 0);
      this.layNewEntryDialogLayout.Controls.Add(this.txbNewEntryNotes, 0, 5);
      this.layNewEntryDialogLayout.Controls.Add(this.txbNewEntryEntry, 0, 1);
      this.layNewEntryDialogLayout.Controls.Add(this.lblNewEntryNotes, 0, 4);
      this.layNewEntryDialogLayout.Controls.Add(this.lblNewEntryTranslations, 0, 2);
      this.layNewEntryDialogLayout.Controls.Add(this.txbNewEntryTranslations, 0, 3);
      this.layNewEntryDialogLayout.Controls.Add(this.chkNewEntryAddToFtoN, 0, 6);
      this.layNewEntryDialogLayout.Controls.Add(this.chkNewEntryAddToNtoF, 1, 6);
      this.layNewEntryDialogLayout.Controls.Add(this.btnNewEntryCancel, 0, 7);
      this.layNewEntryDialogLayout.Controls.Add(this.btnNewEntryAdd, 1, 7);
      this.layNewEntryDialogLayout.Name = "layNewEntryDialogLayout";
      // 
      // chkNewEntryAddToFtoN
      // 
      resources.ApplyResources(this.chkNewEntryAddToFtoN, "chkNewEntryAddToFtoN");
      this.chkNewEntryAddToFtoN.Name = "chkNewEntryAddToFtoN";
      this.chkNewEntryAddToFtoN.UseVisualStyleBackColor = true;
      // 
      // chkNewEntryAddToNtoF
      // 
      resources.ApplyResources(this.chkNewEntryAddToNtoF, "chkNewEntryAddToNtoF");
      this.chkNewEntryAddToNtoF.Name = "chkNewEntryAddToNtoF";
      this.chkNewEntryAddToNtoF.UseVisualStyleBackColor = true;
      // 
      // btnNewEntryCancel
      // 
      resources.ApplyResources(this.btnNewEntryCancel, "btnNewEntryCancel");
      this.btnNewEntryCancel.Name = "btnNewEntryCancel";
      this.btnNewEntryCancel.UseVisualStyleBackColor = true;
      // 
      // btnNewEntryAdd
      // 
      resources.ApplyResources(this.btnNewEntryAdd, "btnNewEntryAdd");
      this.btnNewEntryAdd.Name = "btnNewEntryAdd";
      this.btnNewEntryAdd.UseVisualStyleBackColor = true;
      this.btnNewEntryAdd.Click += new System.EventHandler(this.TriggerNewEntryAdd);
      // 
      // NewEntryDialog
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ControlBox = false;
      this.Controls.Add(this.layNewEntryDialogLayout);
      this.Name = "NewEntryDialog";
      this.layNewEntryDialogLayout.ResumeLayout(false);
      this.layNewEntryDialogLayout.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblNewEntryEntry;
    private System.Windows.Forms.TableLayoutPanel layNewEntryDialogLayout;
    private System.Windows.Forms.TextBox txbNewEntryNotes;
    private System.Windows.Forms.TextBox txbNewEntryEntry;
    private System.Windows.Forms.Label lblNewEntryNotes;
    private System.Windows.Forms.Label lblNewEntryTranslations;
    private System.Windows.Forms.TextBox txbNewEntryTranslations;
    private System.Windows.Forms.CheckBox chkNewEntryAddToFtoN;
    private System.Windows.Forms.CheckBox chkNewEntryAddToNtoF;
    private System.Windows.Forms.Button btnNewEntryCancel;
    private System.Windows.Forms.Button btnNewEntryAdd;
  }
}