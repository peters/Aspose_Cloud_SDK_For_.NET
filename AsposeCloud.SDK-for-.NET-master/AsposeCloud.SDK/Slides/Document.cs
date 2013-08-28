using Aspose.Cloud.Common;
using Aspose.Cloud.SDK.Slides;
using Aspose.Cloud.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace Aspose.Cloud.Slides
{
    /// <summary>
    /// Deals with PowerPoint presentation level aspects
    /// </summary>
    public class Document
    {
        public Document(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Presentation name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Saves the document into various formats without uploading to any storage
        /// </summary>
        /// <param name="inputFile">Input file stream</param>
        /// <param name="outputPath">Save the output file to</param>
        /// <param name="saveFormat">Output format to save</param>
        public void Convert(Stream inputFile, string outputPath, SaveFormat saveFormat)
        {

            //build URI to convert presentation
            string strURI = Product.BaseProductUri + "/slides/convert?format=" + saveFormat;

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "PUT", inputFile);

            //Save output file
            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// Finds the slide count of the specified PowerPoint document
        /// </summary>
        /// <returns>slide count</returns>
        public int GetSlideCount()
        {
            //build URI to get slide count
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            SlidesResponse slidesResponse = JsonConvert.DeserializeObject<SlidesResponse>(parsedJSON.ToString());

            int count = slidesResponse.Slides.SlideList.Count;
            return count;
        }
        /***********Method  GetSlide Added by:Zeeshan*******/
        public Slide GetSlide(int slideNumber)
        {
            try
            {
                //build URI to get slide count
                string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber;

                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();

                System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                SlideDetailResponse slidesResponse = JsonConvert.DeserializeObject<SlideDetailResponse>(parsedJSON.ToString());

                return slidesResponse.Slide;
            }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// Finds the slide count of the specified PowerPoint document from a third party storage
        /// </summary>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <param name="folderName">In case of Amazon S3 storage the folder's path starts with Amazon S3 Bucket name.</param>
        /// <returns>slide count</returns>
        public int GetSlideCount(StorageType storageType, string storageName, string folderName)
        {
            //build URI to get slide count
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + FileName
                + "/slides" + (string.IsNullOrEmpty(folderName) ? "" : "?folder=" + folderName));

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("&storage=" + storageName);
                    break;
            }

            string signedURI = Utils.Sign(strURI.ToString());

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            SlidesResponse slidesResponse = JsonConvert.DeserializeObject<SlidesResponse>(parsedJSON.ToString());

            int count = slidesResponse.Slides.SlideList.Count;
            return count;
        }

        /// <summary>
        /// Gets a list containing all document properties
        /// </summary>
        /// <returns>List of document properties</returns>
        public List<DocumentProperty> GetDocumentProperties()
        {
            //build URI to get document properties
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/documentProperties";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            DocumentPropertiesResponse documentPropertiesResponse = JsonConvert.DeserializeObject<DocumentPropertiesResponse>(parsedJSON.ToString());

            return documentPropertiesResponse.DocumentProperties.List;
        }

        /// <summary>
        /// Gets the value of a particular property
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns>value of the specified property</returns>
        public DocumentProperty GetDocumentProperty(string propertyName)
        {

            //build URI to get single property
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/presentation/documentProperties/" + propertyName;
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            DocumentPropertyResponse documentPropertyResponse = JsonConvert.DeserializeObject<DocumentPropertyResponse>(parsedJSON.ToString());

            return documentPropertyResponse.DocumentProperty;
        }

        /// <summary>
        /// Removes all the custom properties and resets all the built-in properties
        /// </summary>
        public bool RemoveAllProperties()
        {

            //build URI to remove/reset all the properties
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/documentProperties";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "DELETE");
            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

            if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Replaces all instances of old text with new text in a presentation
        /// </summary>
        /// <param name="oldText"></param>
        /// <param name="newText"></param>
        public bool ReplaceText(string oldText, string newText)
        {
            //build URI to replace text
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/replaceText?oldValue=" +
                oldText + "&newValue=" + newText + "&ignoreCase=true";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "POST");
            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

            if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Replaces all instances of old text with new text in a slide
        /// </summary>
        /// <param name="oldText"></param>
        /// <param name="newText"></param>
        /// <param name="slideNumber"></param>
        public bool ReplaceText(string oldText, string newText, int slideNumber)
        {
            //build URI to replace text in a particular slide
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber + "/replaceText?oldValue=" +
                oldText + "&newValue=" + newText + "&ignoreCase=true";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "POST");
            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

            if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Deletes a particular custom property or resets a particular built-in property
        /// </summary>
        /// <param name="propertyName"></param>
        public bool DeleteDocumentProperty(string propertyName)
        {

            //build URI to remove single property
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/documentProperties/" + propertyName;
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "DELETE");
            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

            if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets all the text items in a presentation
        /// </summary>
        /// <returns>A list containing all the text items</returns>
        public List<TextItem> GetAllTextItems()
        {
            //build URI to get all text items in a presentation
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/textItems";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());

            return textItemsResponse.TextItems.Items;
        }

        /// <summary>
        /// Gets all the text items in a presentation from a 3rd party storage
        /// </summary>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <param name="folderName">In case of Amazon S3 storage the folder's path starts with Amazon S3 Bucket name.</param>
        /// <returns>A list containing all the text items</returns>
        public List<TextItem> GetAllTextItems(StorageType storageType, string storageName, string folderName)
        {
            //build URI to get all text items in a presentation
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + FileName
                + "/textItems" + (string.IsNullOrEmpty(folderName) ? "" : "?folder=" + folderName));

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("&storage=" + storageName);
                    break;
            }
            string signedURI = Utils.Sign(strURI.ToString());

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());

            return textItemsResponse.TextItems.Items;
        }

        /// <summary>
        /// Gets all the text items in a slide from a 3rd party storage
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <param name="withEmpty">Set this to true to include items for shapes without text</param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <param name="folderName">In case of Amazon S3 storage the folder's path starts with Amazon S3 Bucket name.</param>
        /// <returns>A list containing all the text items in a slide</returns>
        public List<TextItem> GetAllTextItems(int slideNumber, bool withEmpty,
            StorageType storageType, string storageName, string folderName)
        {
            //build URI to get all text items in a slide
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + FileName
                + "/slides/" + slideNumber + "/textItems?withEmpty=" + withEmpty +
                (string.IsNullOrEmpty(folderName) ? "" : "&folder=" + folderName));

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("&storage=" + storageName);
                    break;
            }
            string signedURI = Utils.Sign(strURI.ToString());

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());

            return textItemsResponse.TextItems.Items;
        }

        /// <summary>
        /// Gets all the text items in a slide
        /// </summary>
        /// <param name="slideNumber"></param>
        /// /// <param name="withEmpty">Set this to true to include items for shapes without text</param>
        /// <returns>A list containing all the text items in a slide</returns>
        public List<TextItem> GetAllTextItems(int slideNumber, bool withEmpty)
        {
            //build URI to get all text items in a slide
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber + "/textItems?withEmpty=" + withEmpty;
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());

            return textItemsResponse.TextItems.Items;
        }

        /// <summary>
        /// saves the document into various formats
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="saveFormat"></param>
        public void SaveAs(string outputPath, SaveFormat saveFormat)
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/slides/" + FileName;
            strURI += "?format=" + saveFormat;

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// Saves the document from third party storage into various formats
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="saveFormat"></param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <param name="folderName">In case of Amazon S3 storage the folder's path starts with Amazon S3 Bucket name.</param>
        public void SaveAs(string outputPath, SaveFormat saveFormat, StorageType storageType, string storageName, string folderName)
        {

            //build URI
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + FileName
               + "?format=" + saveFormat + (string.IsNullOrEmpty(folderName) ? "" : "&folder=" + folderName));

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("&storage=" + storageName);
                    break;
            }

            string signedURI = Utils.Sign(strURI.ToString());

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// Saves a particular slide into various formats from a 3rd party storage
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="slideNumber"></param>
        /// <param name="imageFormat"></param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <param name="folderName">In case of Amazon S3 storage the folder's path starts with Amazon S3 Bucket name.</param>
        public void SaveSlideAs(string outputPath, int slideNumber, ImageFormat imageFormat,
            StorageType storageType, string storageName, string folderName)
        {
            //build URI
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + FileName
               + "/slides/" + slideNumber + "?format=" + imageFormat +
               (string.IsNullOrEmpty(folderName) ? "" : "&folder=" + folderName));

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("&storage=" + storageName);
                    break;
            }

            string signedURI = Utils.Sign(strURI.ToString());

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// Saves a particular slide into various formats
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="slideNumber"></param>
        /// <param name="imageFormat"></param>
        public void SaveSlideAs(string outputPath, int slideNumber, ImageFormat imageFormat)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" +
                slideNumber + "?format=" + imageFormat;

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// Saves a particular slide into various formats with specified width and height from a 3rd party storage
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="slideNumber"></param>
        /// <param name="imageFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <param name="folderName">In case of Amazon S3 storage the folder's path starts with Amazon S3 Bucket name.</param>
        public void SaveSlideAs(string outputPath, int slideNumber, ImageFormat imageFormat, int width, int height,
            StorageType storageType, string storageName, string folderName)
        {
            //build URI
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + FileName
               + "/slides/" + slideNumber + "?format=" + imageFormat + "&width=" + width + "&height=" + height +
               (string.IsNullOrEmpty(folderName) ? "" : "&folder=" + folderName));

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("&storage=" + storageName);
                    break;
            }

            string signedURI = Utils.Sign(strURI.ToString());

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// Saves a particular slide into various formats with specified width and height
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="slideNumber"></param>
        /// <param name="imageFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SaveSlideAs(string outputPath, int slideNumber, ImageFormat imageFormat, int width, int height)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" +
                slideNumber + "?format=" + imageFormat + "&width=" + width + "&height=" + height;

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// Sets the value of a particular property or adds a new property if the specified property does not exist
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public bool SetDocumentProperty(string propertyName, string value)
        {

            //build URI to remove single property
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/documentProperties/" + propertyName;
            string signedURI = Utils.Sign(strURI);

            //serialize the JSON request content
            DocumentProperty docProperty = new DocumentProperty();
            docProperty.Value = value;
            string strJSON = JsonConvert.SerializeObject(docProperty);

            Stream responseStream = Utils.ProcessCommand(signedURI, "PUT", strJSON);
            StreamReader reader = new StreamReader(responseStream);
            string strResponse = reader.ReadToEnd();
            //Parse the json string to JObject
            JObject pJSON = JObject.Parse(strResponse);

            DocumentPropertyResponse baseResponse = JsonConvert.DeserializeObject<DocumentPropertyResponse>(pJSON.ToString());

            if ((baseResponse.Code == "200" && baseResponse.Status == "OK") || (baseResponse.Code == "201" && baseResponse.Status == "Created"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Adds one or more new custom properties
        /// </summary>
        /// <param name="CustomPropertyList"></param>
        /// <returns></returns>
        public void AddCustomProperty(CustomPropertyList list)
        {

            //build URI
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/presentation/documentProperties";
            string signedURI = Utils.Sign(strURI);

            string strContent = ToXml(list);

            Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strContent, "xml");
        }
        private string ToXml(object obj)
        {
            var nsSerializer = new XmlSerializerNamespaces();
            nsSerializer.Add("", "");

            string retval = null;
            if (obj != null)
            {
                StringBuilder sb = new StringBuilder();
                using (XmlWriter writer = XmlWriter.Create(sb, new XmlWriterSettings() { OmitXmlDeclaration = true }))
                {
                    new XmlSerializer(obj.GetType()).Serialize(writer, obj, nsSerializer);
                }
                retval = sb.ToString();
            }
            return retval;
        }

        public bool DeleteAllSlides(StorageType storageType, string storageName, string folderName)
        {
            //build URI to remove all the slides
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + FileName
              + "/slides" + (string.IsNullOrEmpty(folderName) ? "" : "?folder=" + folderName));

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("&storage=" + storageName);
                    break;
            }
            string signedURI = Utils.Sign(strURI.ToString());

            Stream responseStream = Utils.ProcessCommand(signedURI, "DELETE");
            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

            if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                return true;
            else
                return false;

        }

        public bool DeleteAllSlides()
        {
            //build URI to remove all the slides
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "DELETE");
            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

            if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                return true;
            else
                return false;

        }
        /***********Method  DeleteSlide Added by:Zeeshan*******/
        public bool DeleteSlide(int slideNumber)
        {
            try
            {
                //build URI to remove slide
                string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber;
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "DELETE");
                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                    return true;
                else
                    return false;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// replacing of text in first cell of table on the first slide.
        /// </summary>
        /// 
        /***********Method  ReplaceTextItems Added by:Zeeshan*******/
        /**       public bool ReplaceTextItems(UriResponse uri, string name)
               {

                   try
                   {
                       //build URI
                       string strURI = Product.BaseProductUri + "/slides/" + FileName + "/textItems";
                       string signedURI = Utils.Sign(strURI);

                       //serialize the JSON request content
                       TextItem txtItem = new TextItem();
                       UriResponse uriResponse = uri;
                       ShapeURI sUri = new ShapeURI();
                       sUri.Uri = uriResponse;
                       txtItem.Uri = sUri;
                       txtItem.Text = name;
                       string strJSON = JsonConvert.SerializeObject(txtItem);

                       Stream responseStream = Utils.ProcessCommand(signedURI, "PUT", strJSON);
                       StreamReader reader = new StreamReader(responseStream);
                       string strResponse = reader.ReadToEnd();
                       //Parse the json string to JObject
                       JObject pJSON = JObject.Parse(strResponse);
                       TextItemsResponse baseResponse = JsonConvert.DeserializeObject<TextItemsResponse>(pJSON.ToString());
                       if ((baseResponse.Code == "200" && baseResponse.Status == "OK") || (baseResponse.Code == "201" && baseResponse.Status == "Created"))
                           return true;
                       else
                           return false;
                   }
                   catch (Exception ex)
                   {
                       throw ex;
                   }
               }**/

        public Theme GetTheme(int slideNumber)
        {
            try
            {
                //build URI to get all text items in a slide
                string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber + "/theme";
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                ThemeResponse themeResponse = JsonConvert.DeserializeObject<ThemeResponse>(parsedJSON.ToString());

                return themeResponse.Theme;
            }
            catch (Exception ex)
            { throw ex; }
        }
        /***********Method  MergeDocuments Added by:Zeeshan*******/
        public bool MergeDocuments(String[] sourceFiles)
        {

            try
            {
                //New PDF Filename
                String mergedFileName = FileName;

                if (sourceFiles.Length < 2)
                {
                    throw new Exception("Two or more files are requred to merge.");
                }


                //build URI to get page count
                String strURI = Product.BaseProductUri + "/slides/" + mergedFileName + "/merge";
                String signedURI = Utils.Sign(strURI);

                SourceFilesList sourcefileslist = new SourceFilesList();
                sourcefileslist.List = sourceFiles;

                string jsondata = JsonConvert.SerializeObject(sourcefileslist);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST", jsondata, "json"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
                    return true;
                else
                    return false;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /***********Method  SetDocumentProperties Added by:Zeeshan*******/

        //public bool SetDocumentProperties(List<DocumentProperty> DocumentProperties)
        //{
        //    try
        //    {
        //        //build URI to remove single property
        //        string strURI = Product.BaseProductUri + "/slides/" + FileName + "/documentProperties";
        //        string signedURI = Utils.Sign(strURI);
        //        DocumentPropertiesEnvelop properties = new DocumentPropertiesEnvelop();
        //        properties.List = DocumentProperties;

        //        //serialize the JSON request content
        //        //DocumentProperty docProperty = new DocumentProperty();
        //        //docProperty.Value = value;
        //        string strJSON = JsonConvert.SerializeObject(properties);

        //        Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strJSON);
        //        StreamReader reader = new StreamReader(responseStream);
        //        string strResponse = reader.ReadToEnd();
        //        //Parse the json string to JObject
        //        JObject pJSON = JObject.Parse(strResponse);

        //        DocumentPropertyResponse baseResponse = JsonConvert.DeserializeObject<DocumentPropertyResponse>(pJSON.ToString());

        //        if ((baseResponse.Code == "200" && baseResponse.Status == "OK") || (baseResponse.Code == "201" && baseResponse.Status == "Created"))
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
