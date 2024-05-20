using Newtonsoft.Json;
using SendSMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SendSMS
{
    public class SMSService
    {
        private string urlServer = "http://api.mobizon.ua";
        private string apiKey = "uaee874c311646154e90880f662656c4d2e75c199bf2c75843df48492151fcf476330b";

        public BalanceResponseDTO GetBalance()
        {
            BalanceRequestDTO requestData = new BalanceRequestDTO()
            {
                ApiKey = apiKey,
            };
            string urlParams = ObjectToUrlParams(requestData);
            string path = $"{urlServer}/service/user/getownbalance?{urlParams}";

            WebRequest request = WebRequest.Create(path);
            request.ContentType = "application/json";
            request.Method = "GET";

            try
            {
                // Get the response
                using (WebResponse response = request.GetResponse())
                {
                    // Get the stream containing content returned by the server
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            // Read the content
                            string responseFromServer = reader.ReadToEnd();
                            var result = JsonConvert.DeserializeObject<MobizonResponseDTO<BalanceResponseDTO>>(responseFromServer);
                            return result.Data;
                        }
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("WebException occurred: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e.Message);
            }
            return null;

        }

        public string SendSMS(string text, string phone)
        {
            SendSMSRequestDTO requestData = new SendSMSRequestDTO()
            {
                ApiKey = apiKey,
                Recipient= phone,
                Text= text
            };
            string urlParams = ObjectToUrlParams(requestData);
            string path = $"{urlServer}/service/message/sendsmsmessage?{urlParams}";

            WebRequest request = WebRequest.Create(path);
            request.ContentType = "application/json";
            request.Method = "GET";

            try
            {
                // Get the response
                using (WebResponse response = request.GetResponse())
                {
                    // Get the stream containing content returned by the server
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            // Read the content
                            string responseFromServer = reader.ReadToEnd();
                            return responseFromServer;
                            //var result = JsonConvert.DeserializeObject<MobizonResponseDTO<BalanceResponseDTO>>(responseFromServer);
                            //return result.Data;
                        }
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("WebException occurred: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e.Message);
            }
            return null;
        }


        private string ObjectToUrlParams(object obj)
        {
            var properties = obj.GetType().GetProperties();
            var queryString = new StringBuilder();

            foreach (var property in properties)
            {
                // Get the property name
                var name = property.Name;
                name = char.ToLower(name[0]) + name.Substring(1);

                // Get the property value
                var value = property.GetValue(obj);

                // Encode the property value
                var encodedValue = Uri.EscapeDataString(value.ToString());

                // Append to the query string
                queryString.Append($"{name}={encodedValue}&");
            }

            // Remove the trailing "&"
            queryString.Length--;

            return queryString.ToString();
        }

    }
}
