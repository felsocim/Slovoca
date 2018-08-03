using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;
using System.IO;

namespace Slovoca {
  class Project {
    public Project(string location, CultureInfo native, CultureInfo foreign) {
      this.Location = location;
      this.NativeEntries = new EntrySet(native, true);
      this.ForeignEntries = new EntrySet(foreign, false);
    }

    [XmlIgnore]
    public string Location { get; set; }

    public EntrySet NativeEntries { get; }

    public EntrySet ForeignEntries { get; }

    public void SaveToDisk() {
      XmlSerializer serializer = new XmlSerializer(typeof(Project));
      FileStream file = new FileStream(this.Location, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
      serializer.Serialize(file, this);
    }
  }
}
