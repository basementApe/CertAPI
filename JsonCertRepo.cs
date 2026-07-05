using System.Text.Json;

namespace CertAPI
{
    public class JsonCertRepo:ICertRepo
    {
        private readonly string filename = "certifications.json";
        public List<Certification> LoadCerts()
        {
            if (!File.Exists(filename)) return new List<Certification>();
            var json = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<List<Certification>>(json)!;
        }

        public void SaveCert(Certification certification)
        {
            var certs = LoadCerts();

            certs.Add(certification);

            var json = JsonSerializer.Serialize(certs);
            File.WriteAllText(filename, json);
        }
    }
}

