using System.Text.Json;

namespace CertAPI.Repos
{
    public class JsonRepo       // file storage for metadata. should live in a database in future
    {
        public static List<JsonRepo>? LoadFromFile()
        {
            string file = "Storage/certificates.json";
            string json = File.ReadAllText(file);
            return JsonSerializer.Deserialize<List<JsonRepo>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}