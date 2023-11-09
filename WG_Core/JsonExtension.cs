using System;
using System.Text.Json;

namespace WG_Core
{
    public class JsonExtension
    {
        public T DeSerialize<T>(string json) where T : class
        {
            try
            {
                return (T)JsonSerializer.Deserialize(json, typeof(T));
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine(jsonEx.Message);
                return default(T);
            }
            catch { throw; }
        }
    }
}
