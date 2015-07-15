using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Ennerbot
{
    public class Serializer
    {
        /// <summary>
        /// Serializes the object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize<T>(T obj)
        {
            var serializer = new XmlSerializer(typeof (T));
            
            // Get the serialized contents
            using (var memStream = new MemoryStream())
            {
                serializer.Serialize(memStream, obj);

                // Reset the stream position
                memStream.Position = 0;

                // Read the stream
                using (var reader = new StreamReader(memStream, new UTF8Encoding()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Deserializes a file into type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public T Deserialize<T>(Stream stream)
        {
            var serializer = new XmlSerializer(typeof (T));

            // Get the deserialized object
            return (T) serializer.Deserialize(stream);
        }
    }
}
