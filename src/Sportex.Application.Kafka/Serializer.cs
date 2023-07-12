namespace Sportex.Application.Kafka
{
    using System.IO;
    using Avro.IO;
    using Avro.Specific;

    public class AvroSerializer
    {
        public static byte[] Serialize<T>(T inputObject) where T : ISpecificRecord
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryEncoder = new BinaryEncoder(memoryStream);
                var specificDefaultWriter = new SpecificDefaultWriter(inputObject.Schema); // Schema comes from pre-compiled, code-gen phase
                specificDefaultWriter.Write(inputObject, binaryEncoder);

                return memoryStream.ToArray();
            }
        }

        public static T Deserialize<T>(byte[] bytes) where T : ISpecificRecord, new()
        {
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryDecoder = new BinaryDecoder(memoryStream);
                var finalObject = new T();

                var specificDefaultReader = new SpecificDefaultReader(finalObject.Schema, finalObject.Schema);
                specificDefaultReader.Read(finalObject, binaryDecoder);

                return finalObject;
            }
        }
    }
}
