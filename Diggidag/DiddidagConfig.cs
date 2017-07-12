using System;

namespace Diggidag
{
    [Serializable]
    public class DiggidagConfig
    {
        public string[] importXMLTags = new string[]
        {
            "TITLE", "FILENAME", "CREATOR", "LENGTH", "FILEREF"
        };

        public string[] columnNames = new string[]
        {
            "TITLE", "Media", "CREATOR", "LENGTH", "SoftSoda"
        };

        public string[] mediaColumns = new string[] { "Media" };

        public string defaultFilterTextBoxText = "Your filter text...";
    }
}
