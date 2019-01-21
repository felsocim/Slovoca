using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slovoca {
  /// <summary>
  /// Dialog showing assembly information to the user in a human readable form together with the GPL license information.
  /// </summary>
  partial class AboutBox : Form {
    public AboutBox() {
      InitializeComponent();
      this.Text = String.Format(Properties.Resources.ABOUT_BOX_TITLE_PREFIX + " {0}", AssemblyTitle);
      this.labelProductName.Text = AssemblyProduct;
      this.labelDescription.Text = Properties.Resources.ABOUT_BOX_DESCRIPTION;
      this.labelVersion.Text = String.Format(Properties.Resources.ABOUT_BOX_VERSION_PREFIX + " {0}", AssemblyVersion);
      this.labelCopyright.Text = AssemblyCopyright;
      this.textBoxDescription.Text = Properties.Resources.ABOUT_BOX_GNU;
    }

    #region Assembly Attribute Accessors

    public string AssemblyTitle {
      get {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if (attributes.Length > 0) {
          AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
          if (titleAttribute.Title != "") {
            return titleAttribute.Title;
          }
        }
        return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    public string AssemblyVersion {
      get {
        return Assembly.GetExecutingAssembly().GetName().Version.ToString();
      }
    }

    public string AssemblyDescription {
      get {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        if (attributes.Length == 0) {
          return "";
        }
        return ((AssemblyDescriptionAttribute)attributes[0]).Description;
      }
    }

    public string AssemblyProduct {
      get {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
        if (attributes.Length == 0) {
          return "";
        }
        return ((AssemblyProductAttribute)attributes[0]).Product;
      }
    }

    public string AssemblyCopyright {
      get {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        if (attributes.Length == 0) {
          return "";
        }
        return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
      }
    }

    public string AssemblyCompany {
      get {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        if (attributes.Length == 0) {
          return "";
        }
        return ((AssemblyCompanyAttribute)attributes[0]).Company;
      }
    }
    #endregion
  }
}
