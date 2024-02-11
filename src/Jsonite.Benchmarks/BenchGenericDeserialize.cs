using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;

namespace Jsonite.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchGenericDeserialize
    {
        private readonly string testJson;

        public BenchGenericDeserialize()
        {
            testJson = File.ReadAllText("test.json");
        }

        [Benchmark(Description = "Textamina.Jsonite")]
        public object TestJsonite()
        {
            return Json.Deserialize(testJson);
        }

        [Benchmark(Description = "Newtonsoft.Json")]
        public Dictionary<string, object> TestNewtonsoftJson()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(testJson);
        }

        [Benchmark(Description = "System.Text.Json (FastJsonParser)")]
        public Dictionary<string, object> TestSystemTextJson()
        {
            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(testJson);
        }

        [Benchmark(Description = "ServiceStack.Text")]
        public Dictionary<string, object> TestServiceStackText()
        {
            // Force ServiceStack.Text to deserialize completely the object (otherwise it is deserializing only the first object level, which is not what we want to test here)
            ServiceStack.Text.JsConfig.ConvertObjectTypesIntoStringDictionary = true;
            return (Dictionary<string, object>)ServiceStack.StringExtensions.FromJson<object>(testJson);
        }

        [Benchmark(Description = "fastJSON")]
        public object TestFastJson()
        {
            return fastJSON.JSON.Parse(testJson);
        }

        [Benchmark(Description = "Jil")]
        public Dictionary<string, object> TestJil()
        {
            return Jil.JSON.Deserialize<Dictionary<string, object>>(testJson);
        }

        [Benchmark(Description = "JavaScriptSerializer")]
        public object TestJavaScriptSerializer()
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.DeserializeObject(testJson);
        }
    }
}