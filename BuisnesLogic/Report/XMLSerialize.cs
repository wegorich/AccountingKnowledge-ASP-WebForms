using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using BusinessLogic.Error;

namespace BusinessLogic.Report
{
    /// <summary>
    /// Serealize object to XML
    /// </summary>
   public static class XMLSerialize
    {
        /// <summary>
        /// Serialize an object
        /// </summary>
        /// <param name="obj">The obj.</param>
         public static string SerializeAnObject(object obj)
        {
            var doc = new XmlDocument();
            var serializer = new XmlSerializer(obj.GetType());
            var stream = new MemoryStream();
            
            try
            {
                serializer.Serialize(stream, obj);
                stream.Position = 0;
                doc.Load(stream);
                return doc.InnerXml;
            }
            catch
            {
                throw new CustomException("Invalid serialization","Can`t make report from this object");
            }
            finally
            {
                stream.Close();
                stream.Dispose();
            }
        }

        /// <summary>
        /// XMLs the transform.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="xslt">The XSLT.</param>
        /// <param name="resultFile">The file to result html</param>
        public static void XMLTransform(string xml,string xslt,string resultFile)
       {
           var transform = new XslCompiledTransform();

           transform.Load(xslt);

           transform.Transform(xml, resultFile);
       }
    }
}
