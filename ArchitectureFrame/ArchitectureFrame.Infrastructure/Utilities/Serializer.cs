﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using System.Xml.Serialization;

namespace ArchitectureFrame.Infrastructure.Utilities
{
    public static class Serializer
    {
        public static string ToJson(object entity)
        {
            var converter = new IsoDateTimeConverter();
            converter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            var serializer = new JsonSerializer();
            serializer.Converters.Add(converter);

            var sb = new StringBuilder();
            serializer.Serialize(new JsonTextWriter(new StringWriter(sb)), entity);
            return sb.ToString();
        }

        public static T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T TryFromJson<T>(string json) where T : class, new()
        {
            try
            {
                var value = JsonConvert.DeserializeObject<T>(json);
                return value ?? new T();
            }
            catch (Exception)
            {
                return new T();
            }
        }

        public static string ToXml<T>(T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, obj);
                stream.Position = 0;
                var reader = new StreamReader(stream);
                var xml = reader.ReadToEnd();
                reader.Close();
                return xml;
            }
        }

        public static T FromXml<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                var writer = new StreamWriter(stream);
                writer.Write(xml);
                writer.Flush();
                stream.Position = 0;
                T instance = (T)serializer.Deserialize(stream);
                writer.Close();
                return instance;
            }
        }

    }
}
