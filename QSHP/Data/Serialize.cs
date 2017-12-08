using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace QSHP.Data
{
    public static class Serialize
    {
        public static string XmlSerialize(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            try
            {
                XmlWriterSettings setting = new XmlWriterSettings();
                setting.OmitXmlDeclaration = true;
                //setting.NewLineOnAttributes = true;
                setting.CheckCharacters = false;
                setting.Encoding = Encoding.Default;
                setting.Indent = true;
                MemoryStream mem = new MemoryStream();
                XmlSerializer xmlser = new XmlSerializer(obj.GetType());
                using (XmlWriter writer =  XmlWriter.Create(mem,setting))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add(string.Empty, string.Empty);
                    xmlser.Serialize(writer, obj, ns);
                    //xmlser.Serialize(writer, obj);
                }
                return Encoding.Default.GetString(mem.ToArray());
            }
            catch(Exception ex)
            {
                LogHelper.WriteDebugException(ex);
                return string.Empty;
            }
        }

        public static void XmlSerialize(object obj,XmlNode node)
        {
            XmlAttribute attr = node.OwnerDocument.CreateAttribute("Type");
            attr.Value = obj.GetType().FullName;
            node.Attributes.Append(attr);
            string text = Serialize.XmlSerialize(obj);
            node.InnerXml = text;
         }

        public static object XmlDeSerialize(string str, Type type)
        {
            if (string.IsNullOrEmpty(str))
            {
                return Activator.CreateInstance(type);
            }
            XmlSerializer xmlser = new XmlSerializer(type);
            try
            {
                using (StringReader writer = new StringReader(str))
                {
                    return xmlser.Deserialize(writer);
                }
            }
            catch(Exception ex)
            {
                LogHelper.WriteDebugException(ex);
                return Activator.CreateInstance(type);
            }
        }

        public static object XmlDeSerialize(XmlNode node)
        {
            XmlAttribute typeAttr = node.Attributes["Type"];
            if (typeAttr != null && !string.IsNullOrWhiteSpace(typeAttr.Value))
            {
                Type type = Type.GetType(typeAttr.Value, false);//反射获取对象类型
                return Serialize.XmlDeSerialize(node.InnerXml, type);
            }
            else
            {
                return null;
            }
            
        }

        public static T XmlDeSerialize<T>(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
            XmlSerializer xmlser = new XmlSerializer(typeof(T));
            try
            {
                using (StringReader writer = new StringReader(str))
                {
                    return (T)xmlser.Deserialize(writer);
                }
            }
            catch(Exception ex)
            {
                LogHelper.WriteDebugException(ex);
                return (T)Activator.CreateInstance(typeof(T));
            }
        }

        internal static T XmlDeSerialize<T>(object p)
        {
            throw new NotImplementedException();
        }
    }
}
