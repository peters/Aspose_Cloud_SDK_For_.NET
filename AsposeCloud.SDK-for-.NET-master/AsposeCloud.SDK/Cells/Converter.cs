using Aspose.Cloud.Common;
using System;
using System.IO;


namespace Aspose.Cloud.Cells
{
    public class Converter
    {
        /// <summary>
        /// Converter Class Constructor
        /// </summary>
        public Converter()
        {
         
        }
        /// <summary>
        /// Converter Class Constructor
        /// </summary>
        public Converter(string fileName)
        {
            FileName = fileName;          
        }
        
        /// <summary>
        /// Converter Class Constructor
        /// </summary>
        public Converter(string fileName, string worksheetName)
        {
            FileName = fileName;
            WorksheetName = worksheetName;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="outputFileName"></param>
        /// <param name="outputformat"></param>
        public void AutoShapeToImage(int index, string outputFileName, ImageFormat outputformat)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");
                else if (WorksheetName == "")
                    throw new Exception("No Worksheet name specified");

                //build URI
                string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/worksheets/" + WorksheetName + "/autoshapes/" + index + "?format=" + outputformat;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //get response stream
                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                using (Stream fileStream = System.IO.File.OpenWrite(outputFileName))
                {
                   Utils.CopyStream(responseStream, fileStream);
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="outputFileName"></param>
        /// <param name="outputformat"></param>
        public void ChartToImage(int index, string outputFileName, ImageFormat outputformat)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");
                else if (WorksheetName == "")
                    throw new Exception("No Worksheet name specified");

                //build URI
                string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/worksheets/" + WorksheetName + "/charts/" + index + "?format=" + outputformat;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //get response stream
                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                using (Stream fileStream = System.IO.File.OpenWrite(outputFileName))
                {
                    Utils.CopyStream(responseStream, fileStream);
                }

                responseStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="outputFileName"></param>
        /// <param name="outputformat"></param>
        public void OleObjectToImage(int index, string outputFileName, ImageFormat outputformat)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");
                else if (WorksheetName == "")
                    throw new Exception("No Worksheet name specified");

                //build URI
                string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/worksheets/" + WorksheetName + "/oleobjects/" + index + "?format=" + outputformat;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //get response stream
                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                using (Stream fileStream = System.IO.File.OpenWrite(outputFileName))
                {
                    Utils.CopyStream(responseStream, fileStream);
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="outputFileName"></param>
        /// <param name="outputformat"></param>
        public void PictureToImage(int index, string outputFileName, ImageFormat outputformat)
        {

            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");
                else if (WorksheetName == "")
                    throw new Exception("No Worksheet name specified");

                //build URI
                string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/worksheets/" + WorksheetName + "/pictures/" + index + "?format=" + outputformat;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //get response stream
                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                using (Stream fileStream = System.IO.File.OpenWrite(outputFileName))
                {
                    Utils.CopyStream(responseStream, fileStream);
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputFileName"></param>
        /// <param name="outputFormat"></param>
        /// <param name="saveLocation"></param>

        public void WorksheetToImage(string outputFileName, ImageFormat outputFormat)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");
                else if (WorksheetName == "")
                    throw new Exception("No Worksheet name specified");

                //build URI
                string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/worksheets/" + WorksheetName + "?format=" + outputFormat;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //get response stream
                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                using (Stream fileStream = System.IO.File.OpenWrite(outputFileName))
                {
                    Utils.CopyStream(responseStream, fileStream);
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// To convert a workbook 
        /// </summary>
        /// <param name="outputFileName"></param>
        /// <param name="outputFormat"></param>
        public void Save(string outputFileName, SaveFormat outputFormat)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/" + FileName;
                strURI += "?format=" + outputFormat;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //get response stream
                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                using (Stream fileStream = System.IO.File.OpenWrite(outputFileName))
                {
                    Utils.CopyStream(responseStream, fileStream);
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Convert Workbook to different file format without using storage
        /// </summary>
        /// <param name="outputFileName"></param>
        /// <param name="outputFormat"></param>
        public void ConvertLocalFile(string inputPath,string outputPath, SaveFormat outputFormat)
        {
            try
            {
               
                //build URI
                string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/convert?format=" + outputFormat;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                FileStream stream = new FileStream(inputPath,FileMode.Open);

                //get response stream
                Stream responseStream = Utils.ProcessCommand(signedURI, "PUT",stream);

                using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
                {
                    Utils.CopyStream(responseStream, fileStream);
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Convert Workbook to different file format without using storage
        /// </summary>
        /// <param name="outputFileName"></param>
        /// <param name="outputFormat"></param>
        public Stream ConvertLocalFile(Stream inputStream, SaveFormat outputFormat)
        {
            try
            {               
                //build URI
                string strURI = Aspose.Cloud.Common.Product.BaseProductUri + "/cells/convert?format=" + outputFormat;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                Stream fileStream = new MemoryStream();

                Utils.CopyStream(Utils.ProcessCommand(signedURI, "PUT", inputStream), fileStream);

                return fileStream;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public string WorksheetName { get; set; }

        /// <summary>
        /// Workbook name
        /// </summary>
        public string FileName { get; set; }
       
    }
}
