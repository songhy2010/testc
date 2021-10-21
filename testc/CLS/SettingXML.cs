// Decompiled with JetBrains decompiler
// Type: smartMain.CLS.SettingXML
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System.Collections;
using System.Text;
using System.Xml;

namespace smartMain.CLS
{
    public class SettingXML
    {
        private string setting_File;

        public SettingXML(string p_File) => this.setting_File = p_File;

        public void WriteXML(Hashtable hTable)
        {
            IDictionaryEnumerator enumerator = hTable.GetEnumerator();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(this.setting_File, Encoding.UTF8);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("Configuration");
            while (enumerator.MoveNext())
                xmlTextWriter.WriteElementString(enumerator.Key.ToString(), enumerator.Value.ToString());
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Flush();
            xmlTextWriter.Close();
        }

        public Hashtable ReadXml()
        {
            Hashtable hashtable = new Hashtable();
            try
            {
                XmlTextReader xmlTextReader = new XmlTextReader(this.setting_File);
                try
                {
                    while (xmlTextReader.Read())
                    {
                        if (xmlTextReader.NodeType == XmlNodeType.Element)
                        {
                            string localName = xmlTextReader.LocalName;
                            xmlTextReader.Read();
                            if (xmlTextReader.NodeType == XmlNodeType.Text)
                            {
                                string str = xmlTextReader.Value;
                                hashtable.Add((object)localName, (object)str);
                            }
                        }
                    }
                }
                catch
                {
                }
                xmlTextReader.Close();
            }
            catch
            {
            }
            return hashtable;
        }
    }
}
