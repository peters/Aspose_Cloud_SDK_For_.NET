using Aspose.Cloud.Common;
using System;
using System.IO;
using System.Xml.XPath;

namespace Aspose.Cloud.Words
{
    public class MailMerge
    {
        /// <summary>
        /// Execute mail merge without regions.
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="strXML"></param>
        /// <param name="saveformat"></param>
        /// <param name="output"></param>
        /// <param name="documentFolder"></param>
        /// <param name="deleteFromStorage"></param>

        public void ExecuteMailMerge(string FileName, string strXML, SaveFormat saveformat, string output,
            string documentFolder = "", bool deleteFromStorage = false)
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/executeMailMerge" +
                    (documentFolder == "" ? "" : "?folder=" + documentFolder);

                string signedURI = Utils.Sign(strURI);

                string outputFileName = null;

                using (Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strXML, "xml"))
                {
                    string strResponse = null;

                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        //further process JSON response
                        strResponse = reader.ReadToEnd();
                    }

                    using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(strResponse)))
                    {
                        XPathDocument xPathDoc = new XPathDocument(ms);
                        XPathNavigator navigator = xPathDoc.CreateNavigator();

                        //get File Name
                        XPathNodeIterator nodes = navigator.Select("/SaaSposeResponse/Document/FileName");
                        nodes.MoveNext();
                        outputFileName = nodes.Current.InnerXml;
                        //build URI
                        strURI = Product.BaseProductUri + "/words/" + outputFileName;
                        strURI += "?format=" + saveformat + (documentFolder == "" ? "" : "&folder=" + documentFolder);
                    }
                }
                //sign URI
                signedURI = Utils.Sign(strURI);

                //get response stream
                using (Stream responseStream = Utils.ProcessCommand(signedURI, "GET"))
                {

                    using (Stream fileStream = System.IO.File.OpenWrite(output))
                    {
                        Utils.CopyStream(responseStream, fileStream);
                    }
                }

                if (deleteFromStorage)
                {
                    signedURI = Utils.Sign(Product.BaseProductUri + "/storage/file/" +
                        (documentFolder == "" ? outputFileName : documentFolder + "/" + outputFileName));
                    Utils.ProcessCommand(signedURI, "DELETE");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Execute mail merge with regions.
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="strXML"></param>
        /// <param name="saveformat"></param>
        /// <param name="output"></param>
        /// <param name="documentFolder"></param>
        /// <param name="deleteFromStorage"></param>
        public void ExecuteMailMergewithRegions(string FileName, string strXML, SaveFormat saveformat, string output,
            string documentFolder = "", bool deleteFromStorage = false)
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/executeMailMerge?withRegions=true" +
                    (documentFolder == "" ? "" : "&folder=" + documentFolder);

                string signedURI = Utils.Sign(strURI);

                string outputFileName = null;

                using (Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strXML, "xml"))
                {
                    string strResponse = null;

                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        //further process JSON response
                        strResponse = reader.ReadToEnd();
                    }

                    using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(strResponse)))
                    {
                        XPathDocument xPathDoc = new XPathDocument(ms);
                        XPathNavigator navigator = xPathDoc.CreateNavigator();

                        //get File Name
                        XPathNodeIterator nodes = navigator.Select("/SaaSposeResponse/Document/FileName");
                        nodes.MoveNext();
                        outputFileName = nodes.Current.InnerXml;
                        //build URI
                        strURI = Product.BaseProductUri + "/words/" + outputFileName;
                        strURI += "?format=" + saveformat + (documentFolder == "" ? "" : "&folder=" + documentFolder);
                    }
                }
                //sign URI
                signedURI = Utils.Sign(strURI);

                //get response stream
                using (Stream responseStream = Utils.ProcessCommand(signedURI, "GET"))
                {
                    using (Stream fileStream = System.IO.File.OpenWrite(output))
                    {
                        Utils.CopyStream(responseStream, fileStream);
                    }
                }

                if (deleteFromStorage)
                {
                    signedURI = Utils.Sign(Product.BaseProductUri + "/storage/file/" +
                        (documentFolder == "" ? outputFileName : documentFolder + "/" + outputFileName));
                    Utils.ProcessCommand(signedURI, "DELETE");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Execute mail merge template.
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="strXML"></param>
        /// <param name="saveformat"></param>
        /// <param name="output"></param>
        /// <param name="documentFolder"></param>
        /// <param name="deleteFromStorage"></param>
        public void ExecuteTemplate(string FileName, string strXML, SaveFormat saveformat, string output,
            string documentFolder = "", bool deleteFromStorage = false)
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/executeTemplate" +
                    (documentFolder == "" ? "" : "?folder=" + documentFolder);

                string signedURI = Utils.Sign(strURI);

                string outputFileName = null;

                using (Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strXML, "xml"))
                {
                    string strResponse = null;

                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        //further process JSON response
                        strResponse = reader.ReadToEnd();
                    }

                    using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(strResponse)))
                    {
                        XPathDocument xPathDoc = new XPathDocument(ms);
                        XPathNavigator navigator = xPathDoc.CreateNavigator();

                        //get File Name
                        XPathNodeIterator nodes = navigator.Select("/SaaSposeResponse/Document/FileName");
                        nodes.MoveNext();
                        outputFileName = nodes.Current.InnerXml;
                        //build URI
                        strURI = Product.BaseProductUri + "/words/" + outputFileName;
                        strURI += "?format=" + saveformat + (documentFolder == "" ? "" : "&folder=" + documentFolder);
                    }
                }
                //sign URI
                signedURI = Utils.Sign(strURI);

                //get response stream
                using (Stream responseStream = Utils.ProcessCommand(signedURI, "GET"))
                {
                    using (Stream fileStream = System.IO.File.OpenWrite(output))
                    {
                        Utils.CopyStream(responseStream, fileStream);
                    }
                }

                if (deleteFromStorage)
                {
                    signedURI = Utils.Sign(Product.BaseProductUri + "/storage/file/" +
                        (documentFolder == "" ? outputFileName : documentFolder + "/" + outputFileName));
                    Utils.ProcessCommand(signedURI, "DELETE");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /***********Method  InsertMailMerge Added by:Zeeshan*******/
        public void InsertMailMerge(string fileName, string strXML, string documentFolder = "")
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + fileName + "/executeMailMerge?withRegions=False" +
                    (documentFolder == "" ? "" : "?folder=" + documentFolder);

                string signedURI = Utils.Sign(strURI);

                string outputFileName = null;
                Stream responseStream = Utils.ProcessCommand(signedURI, "PUT", strXML, "xml");
                StreamReader reader = new StreamReader(responseStream);
                //further process JSON response
                string strResponse = reader.ReadToEnd();
                MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(strResponse));
                XPathDocument xPathDoc = new XPathDocument(ms);
                XPathNavigator navigator = xPathDoc.CreateNavigator();
                //get File Name
                XPathNodeIterator nodes = navigator.Select("/SaaSposeResponse/Document/FileName");
                nodes.MoveNext();
                //build URI
                strURI = Product.BaseProductUri + "/words/" + nodes.Current.InnerXml + "?format=pdf";
                //sign URI
                signedURI = Utils.Sign(strURI);
                //get response stream
                responseStream = Utils.ProcessCommand(signedURI, "GET");
                using (Stream fileStream = System.IO.File.OpenWrite(outputFileName))
                {
                    Utils.CopyStream(responseStream, fileStream);
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
