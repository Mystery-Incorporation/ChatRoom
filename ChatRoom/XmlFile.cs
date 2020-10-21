using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ChatRoom
{
    /// <summary>
    /// Creates and writes a XML file;
    /// </summary>
    class XmlFile
    {
        public static void writeXMLFile (object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();  
        }
    }
}
