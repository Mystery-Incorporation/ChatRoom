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
        public static StoredData readXMLFile(object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextReader reader = new StreamReader(filename);
            StoredData data = (StoredData)sr.Deserialize(reader);
            reader.Close();
            return data;
            //FileStream fs = new FileStream(filename, FileMode.Open);
            //XmlReader reader = XmlReader.Create(fs);
            //contents i;
            //i = (contents)serializer.Deserialize(reader);
            //fs.Close();
        }
    }
}
//[XmlRoot(ElementName = "section")]
//public class Section
//{
//    [XmlElement(ElementName = "element1")]
//    public string Element1 { get; set; }
//    [XmlElement(ElementName = "element2")]
//    public string Element2 { get; set; }
//    [XmlElement(ElementName = "idx")]
//    public List<string> Idx { get; set; }
//    [XmlAttribute(AttributeName = "id")]
//    public string Id { get; set; }
//}

//[XmlRoot(ElementName = "contents")]
//public class Contents
//{
//    [XmlElement(ElementName = "section")]
//    public List<Section> Section { get; set; }
//}