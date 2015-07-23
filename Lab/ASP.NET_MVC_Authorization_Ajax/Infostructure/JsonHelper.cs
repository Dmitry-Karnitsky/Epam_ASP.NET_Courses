using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Collections;
using System.Web.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_2.Infostructure
{        
    public class JsonHelper
    {
        public async static Task<List<Dictionary<string, object>>> ReadJsonFromFileAndCache(string pathToFile, Cache cache)
        {
            string jsonString = null;
            Dictionary<string, List<Dictionary<string, object>>> jsonData = null;

            try
            {
               jsonString = await Task.Run(() => ReadJsonDataFromFile(pathToFile));
               jsonData = await Task.Run(() => JsonHelper.Parse(jsonString));               
            }
            catch
            {
                jsonString = String.Empty;
            }

            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

            foreach(var list in jsonData.Values)
            {
                result.AddRange(list);
            }

            CacheJson(cache, "jsonData", result, pathToFile);            

            return result;
        }

        private static Dictionary<string, List<Dictionary<string, object>>> Parse(string jsonString)
        {
            if (jsonString == null || jsonString == String.Empty)
                throw new ArgumentNullException("jsonString");

            Dictionary<string, ArrayList> jsonContent = null;
            try
            {
                jsonContent = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Dictionary<string, ArrayList>>(jsonString);
            }
            catch
            {
                throw new InvalidCastException("jsonString");
            }

            Dictionary<string, List<Dictionary<string, object>>> result = new Dictionary<string, List<Dictionary<string, object>>>();

            foreach (KeyValuePair<string, ArrayList> arrayElement in jsonContent)
            {
                List<Dictionary<string, object>> temp = new List<Dictionary<string, object>>();
                foreach (object obj in arrayElement.Value)
                {
                    temp.Add((Dictionary<string, object>)(obj));
                }

                result.Add(arrayElement.Key, temp);
            }

            return result;
        }         

        private static string ReadJsonDataFromFile(string physicalPath)
        {
            StringBuilder builder = new StringBuilder();

            using (System.IO.StreamReader reader = new System.IO.StreamReader(physicalPath))
            {
                while (!reader.EndOfStream)
                {
                    builder.AppendLine(reader.ReadLine());
                }
            }

            return builder.ToString();
        }

        private static void CacheJson(Cache cache, string key, object value, string pathToFile)
        {
            CacheDependency dependency = new CacheDependency(pathToFile);

            cache.Insert(key, value, dependency, Cache.NoAbsoluteExpiration,
                Cache.NoSlidingExpiration, CacheItemPriority.Normal, JsonItemRemovedCallback);
        }

        private static void JsonItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            
        }

    }
}