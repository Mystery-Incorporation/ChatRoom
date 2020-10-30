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
        /// <summary>
        /// Writes file conten to xml file.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filename"></param>
        public static void writeXMLFile (object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();  
        }

        /// <summary>
        /// Reads a specified post in a xml file.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static StoredData readXMLFile(object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextReader reader = new StreamReader(filename);
            StoredData data = (StoredData)sr.Deserialize(reader);
            reader.Close();
            return data;
        }
    }
}