using Aspose.Cloud.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;


namespace Aspose.Cloud.Cells
{
    public class TextEditor
    {
        /// <summary>
        /// TextEditor Class Constructor
        /// </summary>
        public TextEditor(string fileName)
        {
            FileName = fileName;

        }

        public List<TextItem> FindText(string text)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/findText?text=" + text;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            TextEditorResponse textEditorResponse = JsonConvert.DeserializeObject<TextEditorResponse>(parsedJSON.ToString());

            return textEditorResponse.TextItems.TextItemList;

        }

        public int ReplaceText(string oldText,string newText)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/replaceText?oldValue=" + oldText + "&newValue=" + newText;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            TextEditorResponse textEditorResponse = JsonConvert.DeserializeObject<TextEditorResponse>(parsedJSON.ToString());

            return textEditorResponse.Matches;

        }
        public List<TextItem> GetTextItems()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/textItems";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);           

            //Deserializes the JSON to a object. 
            TextEditorResponse textEditorResponse = JsonConvert.DeserializeObject<TextEditorResponse>(parsedJSON.ToString());

            return textEditorResponse.TextItems.TextItemList;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<TextItem> FindText(string WorksheetName,string text)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorksheetName + "/findText?text=" + text;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            TextEditorResponse textEditorResponse = JsonConvert.DeserializeObject<TextEditorResponse>(parsedJSON.ToString());

            return textEditorResponse.TextItems.TextItemList;

        }
        public int ReplaceText(string workSheet, string oldText, string newText)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/"+workSheet+"/replaceText?oldValue=" + oldText + "&newValue=" + newText;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            TextEditorResponse textEditorResponse = JsonConvert.DeserializeObject<TextEditorResponse>(parsedJSON.ToString());

            return textEditorResponse.Matches;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TextItem> GetTextItems(string WorksheetName)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorksheetName + "/textItems";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            TextEditorResponse textEditorResponse = JsonConvert.DeserializeObject<TextEditorResponse>(parsedJSON.ToString());

            return textEditorResponse.TextItems.TextItemList;

        }

        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }
    }
}
