using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace corono_app
{
    // API Methodes.
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    // RESTClient class
    // will handle all the API calls this application makes.
    // will take in: endPoint, Host, Headers
    class RESTClient
    {
        // defining endPoint, httpMethod, host and the headers.
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public string host { get; set; }
        public string[][] headers { get; set; }

        public RESTClient()
        {
            endPoint = "";
            httpMethod = httpVerb.GET;
        }
        // Making the request.
        public string makeRequest()
        {
            // defining the responseValue to an empty String
            string strResponseValue = string.Empty;
            // creating the webRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            // setting the Method and host
            request.Method = httpMethod.ToString();
            request.Host = host;
            // if the headers array includes more than 0
            // loop through the array and add all the items.
            if (headers.Length > 0)
            {
                for (int i = 0; i < headers.Length; i++)
                {
                    request.Headers.Add(headers[i][0], headers[i][1]);
                }
            }
            
            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            // defining strResponseValue
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            // catching the errors. IF there is an error.
            catch (Exception ex)
            {
                // setting strResponseValue to the error message.
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            // when all the code is finshed dispose the response.
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }
            // return strResponseValue
            return strResponseValue;
        }
    }
}
