namespace Slovoca {
  partial class NewProjectDialog {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectDialog));
      this.layNewProjectDialog = new System.Windows.Forms.TableLayoutPanel();
      this.lblNewProjectFile = new System.Windows.Forms.Label();
      this.cmbNewProjectForeignCultures = new System.Windows.Forms.ComboBox();
      this.cmbNewProjectNativeCultures = new System.Windows.Forms.ComboBox();
      this.txbNewProjectFile = new System.Windows.Forms.TextBox();
      this.lblNewProjectForeign = new System.Windows.Forms.Label();
      this.lblNewProejctNative = new System.Windows.Forms.Label();
      this.btnNewProjectBrowseFile = new System.Windows.Forms.Button();
      this.btnNewProjectCancel = new System.Windows.Forms.Button();
      this.btnNewProjectCreate = new System.Windows.Forms.Button();
      this.dlgNewProjectFileSave = new System.Windows.Forms.SaveFileDialog();
      this.layNewProjectDialog.SuspendLayout();
      this.SuspendLayout();
      // 
      // layNewProjectDialog
      // 
      resources.ApplyResources(this.layNewProjectDialog, "layNewProjectDialog");
      this.layNewProjectDialog.Controls.Add(this.lblNewProjectFile, 0, 0);
      this.layNewProjectDialog.Controls.Add(this.cmbNewProjectForeignCultures, 0, 3);
      this.layNewProjectDialog.Controls.Add(this.cmbNewProjectNativeCultures, 1, 3);
      this.layNewProjectDialog.Controls.Add(this.txbNewProjectFile, 0, 1);
      this.layNewProjectDialog.Controls.Add(this.lblNewProjectForeign, 0, 2);
      this.layNewProjectDialog.Controls.Add(this.lblNewProejctNative, 1, 2);
      this.layNewProjectDialog.Controls.Add(this.btnNewProjectBrowseFile, 2, 1);
      this.layNewProjectDialog.Controls.Add(this.btnNewProjectCancel, 0, 4);
      this.layNewProjectDialog.Controls.Add(this.btnNewProjectCreate, 1, 4);
      this.layNewProjectDialog.Name = "layNewProjectDialog";
      // 
      // lblNewProjectFile
      // 
      resources.ApplyResources(this.lblNewProjectFile, "lblNewProjectFile");
      this.lblNewProjectFile.Name = "lblNewProjectFile";
      // 
      // cmbNewProjectForeignCultures
      // 
      resources.ApplyResources(this.cmbNewProjectForeignCultures, "cmbNewProjectForeignCultures");
      this.cmbNewProjectForeignCultures.FormattingEnabled = true;
      this.cmbNewProjectForeignCultures.Name = "cmbNewProjectForeignCultures";
      // 
      // cmbNewProjectNativeCultures
      // 
      resources.ApplyResources(this.cmbNewProjectNativeCultures, "cmbNewProjectNativeCultures");
      this.layNewProjectDialog.SetColumnSpan(this.cmbNewProjectNativeCultures, 2);
      this.cmbNewProjectNativeCultures.FormattingEnabled = true;
      this.cmbNewProjectNativeCultures.Name = "cmbNewProjectNativeCultures";
      // 
      // txbNewProjectFile
      // 
      resources.ApplyResources(this.txbNewProjectFile, "txbNewProjectFile");
      this.layNewProjectDialog.SetColumnSpan(this.txbNewProjectFile, 2);
      this.txbNewProjectFile.Name = "txbNewProjectFile";
      this.txbNewProjectFile.ReadOnly = true;
      // 
      // lblNewProjectForeign
      // 
      resources.ApplyResources(this.lblNewProjectForeign, "lblNewProjectForeign");
      this.lblNewProjectForeign.Name = "lblNewProjectForeign";
      // 
      // lblNewProejctNative
      // 
      resources.ApplyResources(this.lblNewProejctNative, "lblNewProejctNative");
      this.layNewProjectDialog.SetColumnSpan(this.lblNewProejctNative, 2);
      this.lblNewProejctNative.Name = "lblNewProejctNative";
      // 
      // btnNewProjectBrowseFile
      // 
      resources.ApplyResources(this.btnNewProjectBrowseFile, "btnNewProjectBrowseFile");
      this.btnNewProjectBrowseFile.Name = "btnNewProjectBrowseFile";
      this.btnNewProjectBrowseFile.UseVisualStyleBackColor = true;
      this.btnNewProjectBrowseFile.Click += new System.EventHandler(this.TriggerFileBrowseDialog);
      // 
      // btnNewProjectCancel
      // 
      resources.ApplyResources(this.btnNewProjectCancel, "btnNewProjectCancel");
      this.btnNewProjectCancel.Name = "btnNewProjectCancel";
      this.btnNewProjectCancel.UseVisualStyleBackColor = true;
      this.btnNewProjectCancel.Click += new System.EventHandler(this.CancelProjectCreation);
      // 
      // btnNewProjectCreate
      // 
      resources.ApplyResources(this.btnNewProjectCreate, "btnNewProjectCreate");
      this.layNewProjectDialog.SetColumnSpan(this.btnNewProjectCreate, 2);
      this.btnNewProjectCreate.Name = "btnNewProjectCreate";
      this.btnNewProjectCreate.UseVisualStyleBackColor = true;
      this.btnNewProjectCreate.Click += new System.EventHandler(this.ConfirmProjectCreation);
      // 
      // dlgNewProjectFileSave
      // 
      this.dlgNewProjectFileSave.DefaultExt = "slovo";
      resources.ApplyResources(this.dlgNewProjectFileSave, "dlgNewProjectFileSave");
      this.dlgNewProjectFileSave.InitialDirectory = "%USERPROFILE%";
      this.dlgNewProjectFileSave.FileOk += new System.ComponentModel.CancelEventHandler(this.ConfirmProjectFileSave);
      // 
      // NewProjectDialog
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ControlBox = false;
      this.Controls.Add(this.layNewProjectDialog);
      this.Name = "NewProjectDialog";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Shown += new System.EventHandler(this.LoadSystemSupportedCultures);
      this.layNewProjectDialog.ResumeLayout(false);
      this.layNewProjectDialog.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel layNewProjectDialog;
    private System.Windows.Forms.Label lblNewProjectFile;
    private System.Windows.Forms.Label lblNewProjectForeign;
    private System.Windows.Forms.Label lblNewProejctNative;
    private System.Windows.Forms.TextBox txbNewProjectFile;
    private System.Windows.Forms.ComboBox cmbNewProjectForeignCultures;
    private System.Windows.Forms.ComboBox cmbNewProjectNativeCultures;
    private System.Windows.Forms.Button btnNewProjectBrowseFile;
    private System.Windows.Forms.Button btnNewProjectCancel;
    private System.Windows.Forms.Button btnNewProjectCreate;
    private System.Windows.Forms.SaveFileDialog dlgNewProjectFileSave;
  }
}