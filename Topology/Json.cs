using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;


namespace Topology {
    public static class Json {
        public static void save<T>(string path, T obj) {
            using (FileStream fs = File.Open(path,
                FileMode.Create, FileAccess.Write, FileShare.Read)) {
                serialize<T>(fs, obj);
            }
        }

        public static T load<T>(string path) {
            using (FileStream fs = File.Open(path,
                FileMode.Open, FileAccess.Read, FileShare.Read)) {
                return deserialize<T>(fs);
            }
        }

        public static void serialize<T>(Stream stream, T obj) {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            js.WriteObject(stream, obj);
        }

        public static T deserialize<T>(Stream stream) {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            return (T)js.ReadObject(stream);
        }

        public static string toJsonString<T>(this T obj) {
            using (MemoryStream ms = new MemoryStream()) {
                serialize(ms, obj);
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms)) {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}