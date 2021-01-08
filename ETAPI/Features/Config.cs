using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace ETAPI.Features
{
    public static class Config
    {
        /// <summary>
        /// A function to load config information. If the config file does not exist or is invalid, it will be created.
        /// </summary>
        /// <param name="name">The name of the config file, excluding the type. For example, the name "SCPStats" would create a file "SCPStats.json".</param>
        /// <typeparam name="T">The config object. This object will be serialized into JSON.</typeparam>
        /// <returns>The deserialized JSON object.</returns>
        public static T AddConfig<T>(string name) where T : new()
        {
            T config;
            
            var str = Path.Combine(Application.dataPath, "../settings/plugins/"+name.Replace(".", "").Replace("/", "").Replace("\\", "")+".json");
            if (!File.Exists(str))
            {
                if (!Directory.Exists(Path.GetDirectoryName(str))) Directory.CreateDirectory(Path.GetDirectoryName(str));
                File.WriteAllText(str, JsonConvert.SerializeObject((object) new T(), Formatting.Indented));
            }
            try
            {
                config = JsonConvert.DeserializeObject<T>(File.ReadAllText(str));
            }
            catch (NullReferenceException)
            {
                File.WriteAllText(str, JsonConvert.SerializeObject((object) new T(), Formatting.Indented));
                config = new T();
            }
            catch (JsonException)
            {
                File.Move(str, Path.Combine(Application.dataPath, "../settings/plugins/INVALID-"+name.Replace(".", "").Replace("/", "").Replace("\\", "")+".json"));
                File.WriteAllText(str, JsonConvert.SerializeObject((object) new T(), Formatting.Indented));
                config = new T();
            }

            return config;
        }
    }
}