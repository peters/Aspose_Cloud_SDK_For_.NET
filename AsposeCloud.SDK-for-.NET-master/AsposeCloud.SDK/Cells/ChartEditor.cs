using Aspose.Cloud.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;


namespace Aspose.Cloud.Cells
{
    public class ChartEditor
    {
        /// <summary>
        /// ChartEditor Class Constructor
        /// </summary>
        public ChartEditor(string fileName,string worksheetName)
        {
            FileName = fileName;
            WorksheetName = worksheetName;

        }

        public bool AddChart(ChartType chartType, int upperLeftRow, int upperLeftColumn, int lowerRightRow, int lowerRightColumn)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/worksheets/" + WorksheetName + "/charts?chartType=" + chartType + "&upperLeftRow=" + upperLeftRow +
                    "&upperLeftColumn=" + upperLeftColumn + "&lowerRightRow=" + lowerRightRow + "&lowerRightColumn=" + lowerRightColumn;
                
                string signedURI = Utils.Sign(strURI);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                    return true;
                else
                    return false;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteChart(int chartIndex)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorksheetName + "/charts/" + chartIndex;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "DELETE"));
            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            BaseResponse docResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

            if (docResponse.Status == "OK")
                return true;
            else
                return false;
        }
        
        public ChartArea GetChartArea(int chartIndex)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorksheetName + "/charts/" + chartIndex + "/chartArea";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            ChartEditorResponse chartResponse = JsonConvert.DeserializeObject<ChartEditorResponse>(parsedJSON.ToString());

            return chartResponse.ChartArea;
        }

        public FillFormat GetFillFormat(int chartIndex)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorksheetName + "/charts/" + chartIndex + "/chartArea/fillFormat";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            ChartEditorResponse chartResponse = JsonConvert.DeserializeObject<ChartEditorResponse>(parsedJSON.ToString());

            return chartResponse.FillFormat;
        }

        public Line GetBorder(int chartIndex)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorksheetName + "/charts/" + chartIndex + "/chartArea/border";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            ChartEditorResponse chartResponse = JsonConvert.DeserializeObject<ChartEditorResponse>(parsedJSON.ToString());

            return chartResponse.Line;

        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WorksheetName { get; set; }

    }
}
