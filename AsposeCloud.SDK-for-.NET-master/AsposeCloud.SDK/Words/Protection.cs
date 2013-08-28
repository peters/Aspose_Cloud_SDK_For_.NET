using Aspose.Cloud.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Aspose.Cloud.Words
{
    public class Protection
    {
        public string FileName { get; set; }
        public Protection(string fileName)
        {
            FileName = fileName;
        }
        /***********Method  GetProtection Added by:Zeeshan*******/
        public string GetProtection()
        { 
         try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Product.BaseProductUri + "/words/" + FileName;
                strURI += "/protection";

                //sign URI
                string signedURI = Utils.Sign(strURI);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                ProtectionResponse ProtectionResponse = JsonConvert.DeserializeObject<ProtectionResponse>(parsedJSON.ToString());
                return ProtectionResponse.ProtectionData.ProtectionType;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /***********Method  ProtectDocument Added by:Zeeshan*******/
        public bool ProtectDocument(string password, ProtectionType protectionType)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Product.BaseProductUri + "/words/" + FileName;
                strURI += "/protection";

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                ProtectionRequest protectionRequest = new ProtectionRequest();
                protectionRequest.Password = password;
                protectionRequest.ProtectionType = protectionType.ToString();

                string strJSON = JsonConvert.SerializeObject(protectionRequest);

                Stream responseStream = Utils.ProcessCommand(signedURI, "PUT", strJSON);
                StreamReader reader = new StreamReader(responseStream);
                
                //further process JSON response
                string strResponseJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strResponseJSON);

                //Deserializes the JSON to a object. 
                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                    return true;
                else
                    return false;
            
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /***********Method  ChangeProtection Added by:Zeeshan*******/
        public bool ChangeProtection(string oldPassword,string newPassword, ProtectionType protectionType)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Product.BaseProductUri + "/words/" + FileName;
                strURI += "/protection";

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                ProtectionRequest protectionRequest = new ProtectionRequest();
                protectionRequest.Password = oldPassword;
                protectionRequest.NewPassword = newPassword;
                protectionRequest.ProtectionType = protectionType.ToString();

                string strJSON = JsonConvert.SerializeObject(protectionRequest);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strJSON);
                StreamReader reader = new StreamReader(responseStream);

                //further process JSON response
                string strResponseJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strResponseJSON);

                //Deserializes the JSON to a object. 
                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /***********Method  UnProtectDocument Added by:Zeeshan*******/
        public bool UnProtectDocument(string password)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Product.BaseProductUri + "/words/" + FileName;
                strURI += "/protection";

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                ProtectionRequest protectionRequest = new ProtectionRequest();
                protectionRequest.Password = password;

                string strJSON = JsonConvert.SerializeObject(protectionRequest);

                Stream responseStream = Utils.ProcessCommand(signedURI, "DELETE", strJSON);
                StreamReader reader = new StreamReader(responseStream);

                //further process JSON response
                string strResponseJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strResponseJSON);

                //Deserializes the JSON to a object. 
                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

    }
}
