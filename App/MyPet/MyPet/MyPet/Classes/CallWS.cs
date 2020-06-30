using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MyPet.Classes
{
    class CallWS
    {
        static public string ChamaWs(IDictionary<string, string> parametros, String method)
        {
            var responseData = string.Empty;
            HttpWebRequest request = WebRequest.Create("http://localhost/MyPetWS/MyPetWS.asmx" + method) as HttpWebRequest;
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/x-www-form-urlencoded";

            using (var requestWriter = request.GetRequestStream())
            {
                var mensagemBytes = Encoding.UTF8.GetBytes(string.Join("&", parametros.Select(m => string.Format("{0}={1}", m.Key, m.Value))));
                requestWriter.Write(mensagemBytes, 0, mensagemBytes.Length);
                requestWriter.Close();
            }

            using (var responseReader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                responseData = responseReader.ReadToEnd();
                responseReader.Close();
            }

            string resp = responseData.ToString();

            request.GetResponse().Close();

            return resp;
        }
    }
}
