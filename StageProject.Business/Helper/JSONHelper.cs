using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace StageProject.Business.Helper
{
    public class JSONHelper
    {
        public string GetJSONString(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }

        public T GetObjectFromJSONString<T>(string json) where T : new()
        {
            var jsonObject = JsonConvert.DeserializeObject<T>(json);
            return jsonObject;

            //using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            //{
            //    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            //    return (T)serializer.ReadObject(stream);
            //}
        }

        public T[] GetArrayFromJSONString<T>(string json) where T : new()
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T[]));
                return (T[])serializer.ReadObject(stream);
            }
        }
    }
}
